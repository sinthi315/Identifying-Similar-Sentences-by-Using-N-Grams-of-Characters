using Detecting_Similarities.IFilter;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Detecting_Similarities
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please give an integer value (< 0).");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openfiledialog.FileName;
                textBox1.Text += path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openfiledialog.FileName;
                textBox3.Text += path;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            richTextBox1.Clear();
            List<string> text1 = new List<string>();
            List<string> text2 = new List<string>();
            List<string> listNGram1 = new List<string>();
            List<string> listNGram2 = new List<string>();
            List<Matrix> matrix1 = new List<Matrix>();
            List<Matrix> matrix2 = new List<Matrix>();
            int nGramSize = Convert.ToInt32(textBox2.Text);
            if (nGramSize == 0)
            {
                MessageBox.Show("NGram size is must be set greater than 0.");
            }
            string path1 = textBox1.Text;
            string path2 = textBox3.Text;
            if ((textBox1.Text != null) && (textBox2.Text != null) && (textBox3.Text != null))
            {
                /* Extracting text from .docx, .doc, .pdf. .txt. .ppt, .pptx file*/
                text1 = textExtracting(path1);
                text2 = textExtracting(path2);

                /*Creating Tri-grams of those text after filtering stopwords, delimiters etc.*/
                listNGram1 = createNGramText(text1, nGramSize);
                listNGram2 = createNGramText(text2, nGramSize);

                /*Creating distance matrices i.e. Matrix1 and Matrix2 in Oracle 10g Database*/
                matrix1 = createMatrix(listNGram1);
                matrix2 = createMatrix(listNGram2);

                /*Find total matched values from distance matrices*/
                var matched = from outer in matrix1
                              from inner in matrix2
                              where outer.Row.Equals(inner.Row) && outer.Column.Equals(inner.Column) && outer.Value.Equals(inner.Value)
                              select new { outer, inner };

                /*Find total non-matched values from distance matrices*/
                var nonMatchedItems = matrix1.Where(l1 => !matrix2.Any(l2 => (l1.Row == l2.Row) && (l1.Column == l2.Column) && (l1.Value == l2.Value))).Concat(matrix2.Where(l1 => !matrix1.Any(l2 => (l1.Row == l2.Row) && (l1.Column == l2.Column) && (l1.Value == l2.Value))));

                /*Find out total intersect, union and minus values between two distance matrics*/
                var matrixIntersect = matrix1.Intersect(matrix2, new MatrixComparer());
                richTextBox1.AppendText("\nIntersect Value: " + matrixIntersect.Count() + "\n");
                var matrixUnion = matrix1.Union(matrix2, new MatrixComparer());
                richTextBox1.AppendText("Union Value: " + matrixUnion.Count() + "\n");
                var matrixMinus = matrixUnion.Except(matrixIntersect, new MatrixComparer());
                richTextBox1.AppendText("The total number of elements in Matrix1: " + matrix1.Count + "\n");
                richTextBox1.AppendText("The total number of elements in Matrix2: " + matrix2.Count + "\n");

                /*Finally Calulating the Co-Occarances between Matrix1 and Matrix2 databases to find out the measure of similarity*/
                float matrixJaccardCoefficient = (float)matrixIntersect.Count() / (float)(matrix1.Count + matrix2.Count - matrixIntersect.Count());
                float matrixJaccardDistance = (float)(matrixUnion.Count() - matrixIntersect.Count()) / (float)matrixUnion.Count();
                float matrixDiceCoefficient = (float)(2 * matrixIntersect.Count()) / (float)(matrix1.Count + matrix2.Count);
                float matrixDiceDissimilarity = (float)1 - ((float)(2 * matrixIntersect.Count()) / (float)(matrix1.Count + matrix2.Count));
                float matrixOverlapCoefficient = (float)matrixIntersect.Count() / (float)Math.Min(matrix1.Count, matrix2.Count);
                float matrixCosineSimilarityMeasure = (float)matrixIntersect.Count() / (float)(Math.Sqrt(matrix1.Count) * Math.Sqrt(matrix2.Count));
                float matrixSimpleMatchingCoefficient = (float)matrixIntersect.Count() / (float)matrixUnion.Count();

                richTextBox1.AppendText("\nJaccard Coefficient (Similarity): " + matrixJaccardCoefficient + "\n");
                richTextBox1.AppendText("Jaccard Coefficient (Dis-similarity): " + matrixJaccardDistance + "\n");
                richTextBox1.AppendText("Dice Similarity Coefficient: " + matrixDiceCoefficient + "\n");
                richTextBox1.AppendText("Dice Dissimilarity Coefficient: " + matrixDiceDissimilarity + "\n");
                richTextBox1.AppendText("Overlap Coefficient: " + matrixOverlapCoefficient + "\n");
                richTextBox1.AppendText("Cosine Similarity Measure: " + matrixCosineSimilarityMeasure + "\n");
                richTextBox1.AppendText("Simple Matching Coefficient: " + matrixSimpleMatchingCoefficient + "\n");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                stopwatch.Stop();
                richTextBox1.AppendText("Time elapsed: " + stopwatch.Elapsed);
            }
            else
            {
                MessageBox.Show("Sorry there is no file!!!");
            }
        }
        static List<Matrix> createMatrix(List<string> list)
        {
            List<Matrix> matrix = new List<Matrix>();
            int i, j, k;

            for (j = 0; j < list.Count; j++)
            {
                for (i = 0; i < list.Count; i++)
                {
                    string Row = list[j];
                    string Column = list[i];
                    k = i - j;
                    if (k >= 0)
                    {
                        matrix.Add(new Matrix { Row = Row, Column = Column, Value = k });
                    }
                }
            }

            return matrix;
        }
        private List<string> createNGramText(List<string> textList, int nGramSize)
        {
            string filteredLine = "";
            List<string> listNGram = new List<string>();
            foreach (string s in textList)
            {
                if (s != null)
                {
                    richTextBox1.AppendText("Raw Data: " + "'" + s + "'" + "\n");
                    filteredLine = StopwordTool.RemoveStopwords(s).ToLower();
                    richTextBox1.AppendText("Filtered Data: " + "'" + filteredLine + "'" + "\n");
                    for (int i = 0; i < filteredLine.Length - nGramSize + 1; i++)
                    {
                        listNGram.Add(filteredLine.Substring(i, nGramSize));
                    }
                }
            }
            return listNGram;
        }
        private List<string> textExtracting(string path)
        {
            List<string> text = new List<string>();
            string extension;
            extension = System.IO.Path.GetExtension(path);
            switch (extension)
            {
                case ".pdf":
                    {
                        text = ExtractTextFromPdf(path);
                        break;
                    }
                case ".txt":
                    {
                        text = GetTextFromText(path);
                        break;
                    }
                case ".doc":
                case ".docx":
                    {
                        text = GetTextFromWord(path);
                        break;
                    }
                case ".ppt":
                case ".pptx":
                    {
                        text = GetTextFromPPT(path);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Please provide valid file formate which contains text for detecting similarities and dissimilarities.");
                        break;
                    }
            }
            return text;
        }
        private List<string> ExtractTextFromPdf(string path)
        {
            List<string> text = new List<string>();
            if (!File.Exists(path))
            {
                MessageBox.Show("Please give the valid path of the PDF file.");
            }
            PdfReader reader2 = new PdfReader(path);
            for (int page = 1; page <= reader2.NumberOfPages; page++)
            {
                ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                PdfReader reader = new PdfReader(path);
                String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                text.Add(s);
                reader.Close();
            }

            return text;
        }
        private List<string> GetTextFromText(string path)
        {
            List<string> text = new List<string>();
            string line;
            if (!File.Exists(path))
            {
                MessageBox.Show("Please give the valid path of the Text file.");
            }
            FileStream file1 = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BufferedStream bs1 = new BufferedStream(file1);
            StreamReader sr1 = new StreamReader(bs1);
            while ((line = sr1.ReadLine()) != null)
            {
                text.Add(line);
            }
            return text;
        }
        private List<string> GetTextFromWord(string path)
        {
            List<string> text = new List<string>();
            string line;
            if (!File.Exists(path))
            {
                MessageBox.Show("Please give the valid path of the Word file.");
            }
            TextReader reader = new FilterReader(path);
            using (reader)
            {
                line = reader.ReadToEnd();
                text.Add(line);
            }
            return text;
        }
        private List<string> GetTextFromPPT(string path)
        {
            List<string> text = new List<string>();
            string line;
            if (!File.Exists(path))
            {
                MessageBox.Show("Please give the valid path of the PowerPont file.");
            }
            TextReader reader = new FilterReader(path);
            using (reader)
            {
                line = reader.ReadToEnd();
                text.Add(line);
            }
            return text;
        }
    }
}

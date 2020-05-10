using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Detecting_Similarities
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            richTextBox1.Clear();
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
            if ((textBox1.Text != null) && (Uri.IsWellFormedUriString(textBox1.Text, UriKind.Absolute)) && (textBox3.Text != null) && (Uri.IsWellFormedUriString(textBox3.Text, UriKind.Absolute)) && (textBox2.Text != null))
            {
                /*Extract whole HTML from both URL1 and URL2. Then remove all html tags, remove double lines, new lines from that HTML string */
                string extractStringURL1 = ExtracttextURL(path1);
                string extractStringURL2 = ExtracttextURL(path2);

                /*Creating Tri-grams of those text after filtering stopwords, delimiters etc.*/
                listNGram1 = createNGramText(extractStringURL1, nGramSize);
                listNGram2 = createNGramText(extractStringURL2, nGramSize);

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
            else if (textBox2.Text == null)
            {
                MessageBox.Show("Please give a right value of n-gram size.");
            }
            else
            {
                MessageBox.Show("Please Provide Right Format of URL!!!");
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
        private List<string> createNGramText(string textList, int nGramSize)
        {
            string filteredLine = "";
            string line = "";
            List<string> listNGram = new List<string>();
            using (StringReader reader = new StringReader(textList))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    filteredLine = StopwordTool.RemoveStopwords(line).ToLower();
                    for (int i = 0; i < filteredLine.Length - nGramSize + 1; i++)
                    {
                        listNGram.Add(filteredLine.Substring(i, nGramSize));
                    }
                }
            }
            return listNGram;
        }
        private static string ExtracttextURL(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            HttpContent content = response.Content;
            string result = content.ReadAsStringAsync().Result;
            string innerText = RemoveUnwantedTags(result);
            string removeNewLine = RemoveDoubleNewLines(innerText);
            string trim = TrimNewLines(removeNewLine);
            return trim;
        }
        private static string RemoveUnwantedTags(string data)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(data);

            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");

                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }
                    }
                    parentNode.RemoveChild(node);
                }
            }

            return document.DocumentNode.InnerHtml;
        }
        private static string RemoveDoubleNewLines(string str)
        {
            string pattern = "[\n]+";
            return Regex.Replace(str, pattern, "\n");
        }
        private static string TrimNewLines(string str)
        {
            int start = 0;
            while (start < str.Length && str[start] == '\n')
            {
                start++;
            }

            int end = str.Length - 1;
            while (end >= 0 && str[end] == '\n')
            {
                end--;
            }

            if (start > end)
            {
                return string.Empty;
            }

            string trimmed = str.Substring(start, end - start + 1);
            return trimmed;
        }
    }
}

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Detecting_Similarities
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new Detecting_Similarities.RoundedButton();
            this.button2 = new Detecting_Similarities.RoundedButton();
            this.roundedButton1 = new Detecting_Similarities.RoundedButton();
            this.roundedButton2 = new Detecting_Similarities.RoundedButton();
            this.roundedButton3 = new Detecting_Similarities.RoundedButton();
            this.roundedButton4 = new Detecting_Similarities.RoundedButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AccessibleName = "";
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button1.Location = new System.Drawing.Point(37, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(286, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Detect Similarities between English Sentences from Files";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button2.Location = new System.Drawing.Point(37, 157);
            this.button2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(286, 62);
            this.button2.TabIndex = 0;
            this.button2.Text = "Detect Similarities of English Texts from Web-pages";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.roundedButton1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.roundedButton1.Location = new System.Drawing.Point(37, 305);
            this.roundedButton1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roundedButton1.Size = new System.Drawing.Size(254, 55);
            this.roundedButton1.TabIndex = 1;
            this.roundedButton1.Text = "Multilingualism of Files (English-French)";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // roundedButton2
            // 
            this.roundedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedButton2.BackColor = System.Drawing.Color.White;
            this.roundedButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.roundedButton2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.roundedButton2.Location = new System.Drawing.Point(37, 372);
            this.roundedButton2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roundedButton2.Size = new System.Drawing.Size(254, 55);
            this.roundedButton2.TabIndex = 2;
            this.roundedButton2.Text = "Multilingualism of URLs (English-French)";
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // roundedButton3
            // 
            this.roundedButton3.AccessibleName = "";
            this.roundedButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedButton3.BackColor = System.Drawing.Color.White;
            this.roundedButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.roundedButton3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.roundedButton3.Location = new System.Drawing.Point(37, 86);
            this.roundedButton3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedButton3.Name = "roundedButton3";
            this.roundedButton3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.roundedButton3.Size = new System.Drawing.Size(286, 59);
            this.roundedButton3.TabIndex = 3;
            this.roundedButton3.Text = "Detect Similarities between French Sentences from Files";
            this.roundedButton3.UseVisualStyleBackColor = false;
            this.roundedButton3.Click += new System.EventHandler(this.roundedButton3_Click);
            // 
            // roundedButton4
            // 
            this.roundedButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedButton4.BackColor = System.Drawing.Color.White;
            this.roundedButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.roundedButton4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.roundedButton4.Location = new System.Drawing.Point(37, 231);
            this.roundedButton4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedButton4.Name = "roundedButton4";
            this.roundedButton4.Size = new System.Drawing.Size(286, 62);
            this.roundedButton4.TabIndex = 4;
            this.roundedButton4.Text = "Detect Similarities of French Texts from Web-pages";
            this.roundedButton4.UseVisualStyleBackColor = false;
            this.roundedButton4.Click += new System.EventHandler(this.roundedButton4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BackgroundImage = global::Detecting_Similarities.Properties.Resources.icon_find_replace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 592);
            this.Controls.Add(this.roundedButton4);
            this.Controls.Add(this.roundedButton3);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detecting Similarity and Dissimilarity Using N-Grams";
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedButton button1;
        private RoundedButton button2;
        private RoundedButton roundedButton1;
        private RoundedButton roundedButton2;
        private RoundedButton roundedButton3;
        private RoundedButton roundedButton4;
    }
}


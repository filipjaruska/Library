namespace Library.Forms
{
    partial class FromBooks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromBooks));
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            linkLabel1 = new LinkLabel();
            label3 = new Label();
            lbIsbn = new Label();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            label2 = new Label();
            lbId = new Label();
            lbAuthor = new Label();
            label1 = new Label();
            lbName = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(438, 657);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lbIsbn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lbId);
            panel1.Controls.Add(lbAuthor);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lbName);
            panel1.Location = new Point(456, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 657);
            panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(396, 511);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(93, 89);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            pictureBox2.MouseEnter += pictureBox2_MouseEnter;
            pictureBox2.MouseLeave += pictureBox2_MouseLeave;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.Location = new Point(68, 563);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(90, 37);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "About";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(4, 62);
            label3.Name = "label3";
            label3.Size = new Size(47, 21);
            label3.TabIndex = 8;
            label3.Text = "ISBN:";
            // 
            // lbIsbn
            // 
            lbIsbn.AutoSize = true;
            lbIsbn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbIsbn.Location = new Point(57, 62);
            lbIsbn.Name = "lbIsbn";
            lbIsbn.Size = new Size(127, 21);
            lbIsbn.TabIndex = 7;
            lbIsbn.Text = "9999999999999";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(319, 120);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(218, 320);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(4, 120);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(314, 320);
            textBox1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(455, 83);
            label2.Name = "label2";
            label2.Size = new Size(34, 25);
            label2.TabIndex = 4;
            label2.Text = "ID:";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lbId.Location = new Point(485, 83);
            lbId.MaximumSize = new Size(52, 25);
            lbId.Name = "lbId";
            lbId.Size = new Size(52, 25);
            lbId.TabIndex = 3;
            lbId.Text = "9999";
            // 
            // lbAuthor
            // 
            lbAuthor.AutoSize = true;
            lbAuthor.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lbAuthor.Location = new Point(68, 83);
            lbAuthor.MaximumSize = new Size(337, 25);
            lbAuthor.Name = "lbAuthor";
            lbAuthor.Size = new Size(337, 25);
            lbAuthor.TabIndex = 2;
            lbAuthor.Text = "VeryVeryVeryVeryVeryVeryVeryLongName";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(4, 83);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 1;
            label1.Text = "Author:";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbName.Location = new Point(4, 11);
            lbName.MaximumSize = new Size(533, 37);
            lbName.Name = "lbName";
            lbName.Size = new Size(533, 37);
            lbName.TabIndex = 0;
            lbName.Text = "Book Name Very Long Even Longer? Maybe";
            lbName.Click += lbName_Click;
            lbName.MouseEnter += lbName_MouseEnter;
            lbName.MouseLeave += lbName_MouseLeave;
            // 
            // FromBooks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.BlueViolet;
            ClientSize = new Size(1018, 681);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "FromBooks";
            Text = "FromBooks";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Label lbName;
        private Label lbId;
        private Label lbAuthor;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Label lbIsbn;
        private Label label3;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox2;
    }
}
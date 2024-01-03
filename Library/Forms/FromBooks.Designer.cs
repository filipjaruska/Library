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
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            label2 = new Label();
            lbId = new Label();
            lbAuthor = new Label();
            label1 = new Label();
            lbName = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(455, 63);
            label2.Name = "label2";
            label2.Size = new Size(34, 25);
            label2.TabIndex = 4;
            label2.Text = "ID:";
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lbId.Location = new Point(485, 63);
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
            lbAuthor.Location = new Point(68, 63);
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
            label1.Location = new Point(4, 63);
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
            // textBox1
            // 
            textBox1.Location = new Point(118, 246);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 128);
            textBox1.TabIndex = 5;
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
    }
}
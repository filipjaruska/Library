﻿namespace Library.Forms
{
    partial class FromBorrowed
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
            returned = new Button();
            fine = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(98, 179);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(799, 451);
            dataGridView1.TabIndex = 0;
            // 
            // returned
            // 
            returned.Location = new Point(773, 95);
            returned.Name = "returned";
            returned.Size = new Size(124, 47);
            returned.TabIndex = 1;
            returned.Text = "Returned";
            returned.UseVisualStyleBackColor = true;
            returned.Click += returned_Click;
            // 
            // fine
            // 
            fine.Location = new Point(608, 96);
            fine.Name = "fine";
            fine.Size = new Size(118, 46);
            fine.TabIndex = 2;
            fine.Text = "button2";
            fine.UseVisualStyleBackColor = true;
            // 
            // FromBorrowed
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 642);
            Controls.Add(fine);
            Controls.Add(returned);
            Controls.Add(dataGridView1);
            Name = "FromBorrowed";
            Text = "FromBorrowed";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button returned;
        private Button fine;
    }
}
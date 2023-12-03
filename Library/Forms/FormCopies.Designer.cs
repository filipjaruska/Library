using System.ComponentModel;

namespace Library.Forms
{
    partial class FromCopies
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            comboBoxBranches = new ComboBox();
            dataGridView1 = new DataGridView();
            btnSave = new Button();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxBranches
            // 
            comboBoxBranches.FormattingEnabled = true;
            comboBoxBranches.Location = new Point(155, 39);
            comboBoxBranches.Name = "comboBoxBranches";
            comboBoxBranches.Size = new Size(224, 23);
            comboBoxBranches.TabIndex = 4;
            comboBoxBranches.SelectedIndexChanged += comboBoxBranches_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(984, 561);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(849, 39);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(147, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FromCopies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 642);
            Controls.Add(btnSave);
            Controls.Add(dataGridView1);
            Controls.Add(comboBoxBranches);
            Name = "FromCopies";
            Text = "Form1";
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxBranches;
        private DataGridView dataGridView1;
        private Button btnSave;
    }
}
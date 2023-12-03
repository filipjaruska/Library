namespace Library
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            comboBoxBranches = new ComboBox();
            btnSave = new Button();
            panelMenu = new Panel();
            btnBorrowed = new Button();
            btnCopies = new Button();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panelToFill = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(48, 428);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(132, 209);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBoxBranches
            // 
            comboBoxBranches.FormattingEnabled = true;
            comboBoxBranches.Location = new Point(12, 327);
            comboBoxBranches.Name = "comboBoxBranches";
            comboBoxBranches.Size = new Size(224, 23);
            comboBoxBranches.TabIndex = 3;
            comboBoxBranches.SelectedIndexChanged += comboBoxBranches_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(83, 365);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "button1";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.SlateBlue;
            panelMenu.Controls.Add(btnBorrowed);
            panelMenu.Controls.Add(btnCopies);
            panelMenu.Controls.Add(dataGridView1);
            panelMenu.Controls.Add(btnSave);
            panelMenu.Controls.Add(panel1);
            panelMenu.Controls.Add(comboBoxBranches);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(240, 681);
            panelMenu.TabIndex = 5;
            // 
            // btnBorrowed
            // 
            btnBorrowed.FlatAppearance.BorderSize = 0;
            btnBorrowed.FlatStyle = FlatStyle.Flat;
            btnBorrowed.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnBorrowed.Image = Properties.Resources.icons8_nook_52;
            btnBorrowed.ImageAlign = ContentAlignment.MiddleLeft;
            btnBorrowed.Location = new Point(3, 210);
            btnBorrowed.Name = "btnBorrowed";
            btnBorrowed.Padding = new Padding(15, 0, 15, 0);
            btnBorrowed.Size = new Size(234, 60);
            btnBorrowed.TabIndex = 2;
            btnBorrowed.Text = "Borrowed ";
            btnBorrowed.TextAlign = ContentAlignment.MiddleLeft;
            btnBorrowed.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBorrowed.UseVisualStyleBackColor = true;
            btnBorrowed.Click += btnBorrowed_Click;
            // 
            // btnCopies
            // 
            btnCopies.FlatAppearance.BorderSize = 0;
            btnCopies.FlatStyle = FlatStyle.Flat;
            btnCopies.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnCopies.Image = Properties.Resources.icons8_literature_52;
            btnCopies.ImageAlign = ContentAlignment.MiddleLeft;
            btnCopies.Location = new Point(3, 144);
            btnCopies.Name = "btnCopies";
            btnCopies.Padding = new Padding(15, 0, 15, 0);
            btnCopies.Size = new Size(234, 60);
            btnCopies.TabIndex = 1;
            btnCopies.Text = "Book Copies";
            btnCopies.TextAlign = ContentAlignment.MiddleLeft;
            btnCopies.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCopies.UseVisualStyleBackColor = true;
            btnCopies.Click += btnCopies_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(240, 120);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(72, 46);
            label1.Name = "label1";
            label1.Size = new Size(108, 32);
            label1.TabIndex = 1;
            label1.Text = "Library";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources.icons8_book_stack_52;
            pictureBox1.Image = Properties.Resources.icons8_book_stack_52;
            pictureBox1.InitialImage = Properties.Resources.icons8_book_stack_52;
            pictureBox1.Location = new Point(12, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(54, 55);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelToFill
            // 
            panelToFill.BackColor = SystemColors.ActiveCaption;
            panelToFill.Dock = DockStyle.Fill;
            panelToFill.Location = new Point(240, 0);
            panelToFill.Name = "panelToFill";
            panelToFill.Size = new Size(1024, 681);
            panelToFill.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1264, 681);
            Controls.Add(panelToFill);
            Controls.Add(panelMenu);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Library";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private ComboBox comboBoxBranches;
        private Button btnSave;
        private Panel panelMenu;
        private Button btnCopies;
        private Panel panel1;
        private Button btnBorrowed;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panelToFill;
    }
}
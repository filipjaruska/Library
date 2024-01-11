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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelMenu = new Panel();
            btnBooks = new Button();
            btnStaff = new Button();
            btnBorrowed = new Button();
            btnCopies = new Button();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panelToFill = new Panel();
            textBox1 = new TextBox();
            label2 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelToFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.MediumPurple;
            panelMenu.Controls.Add(btnBooks);
            panelMenu.Controls.Add(btnStaff);
            panelMenu.Controls.Add(btnBorrowed);
            panelMenu.Controls.Add(btnCopies);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(240, 681);
            panelMenu.TabIndex = 5;
            // 
            // btnBooks
            // 
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnBooks.Image = (Image)resources.GetObject("btnBooks.Image");
            btnBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnBooks.Location = new Point(3, 290);
            btnBooks.Name = "btnBooks";
            btnBooks.Padding = new Padding(15, 0, 15, 0);
            btnBooks.Size = new Size(234, 60);
            btnBooks.TabIndex = 4;
            btnBooks.Text = "Books";
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnStaff
            // 
            btnStaff.FlatAppearance.BorderSize = 0;
            btnStaff.FlatStyle = FlatStyle.Flat;
            btnStaff.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnStaff.Image = Properties.Resources.icons8_nook_52;
            btnStaff.ImageAlign = ContentAlignment.MiddleLeft;
            btnStaff.Location = new Point(0, 374);
            btnStaff.Name = "btnStaff";
            btnStaff.Padding = new Padding(15, 0, 15, 0);
            btnStaff.Size = new Size(234, 60);
            btnStaff.TabIndex = 3;
            btnStaff.Text = "Staff";
            btnStaff.TextAlign = ContentAlignment.MiddleLeft;
            btnStaff.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnStaff.UseVisualStyleBackColor = true;
            btnStaff.Click += btnStaff_Click;
            // 
            // btnBorrowed
            // 
            btnBorrowed.FlatAppearance.BorderSize = 0;
            btnBorrowed.FlatStyle = FlatStyle.Flat;
            btnBorrowed.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            btnBorrowed.Image = (Image)resources.GetObject("btnBorrowed.Image");
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
            panel1.BackColor = Color.SlateBlue;
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
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources.icons8_book_stack_52;
            pictureBox1.Image = Properties.Resources.icons8_book_stack_52;
            pictureBox1.InitialImage = Properties.Resources.icons8_book_stack_52;
            pictureBox1.Location = new Point(12, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 55);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panelToFill
            // 
            panelToFill.BackColor = Color.BlueViolet;
            panelToFill.Controls.Add(textBox1);
            panelToFill.Controls.Add(label2);
            panelToFill.Dock = DockStyle.Fill;
            panelToFill.Location = new Point(240, 0);
            panelToFill.Name = "panelToFill";
            panelToFill.Size = new Size(1024, 681);
            panelToFill.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(321, 60);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(382, 60);
            textBox1.TabIndex = 1;
            textBox1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(293, 9);
            label2.Name = "label2";
            label2.Size = new Size(436, 37);
            label2.TabIndex = 0;
            label2.Text = "Successfully connected to Database";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
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
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelToFill.ResumeLayout(false);
            panelToFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelMenu;
        private Button btnCopies;
        private Panel panel1;
        private Button btnBorrowed;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panelToFill;
        private Button btnStaff;
        private Label label2;
        private TextBox textBox1;
        private ErrorProvider errorProvider1;
        private Button btnBooks;
    }
}
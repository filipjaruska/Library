using Library.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Net;
using Library.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            using (var context = new AppDbContext())
            {
                comboBoxBranches.DisplayMember = "BranchName";
                comboBoxBranches.ValueMember = "BranchId";
                comboBoxBranches.DataSource = context.LibraryBranches.ToList();
            }


        }
        public Form currentChildForm;

        private bool changesMade = false;
        private void comboBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBranches.SelectedIndex > -1)
            {
                int branchId = (int)comboBoxBranches.SelectedValue;
                DisplayBookCopies(branchId);
            }
        }
        private void DisplayBookCopies(int branchId)
        {
            using (var context = new AppDbContext())
            {
                var bookCopiesQuery = context.BookCopies
                    .Include(bc => bc.Book)
                    .Where(bc => bc.BranchId == branchId)
                    .Select(bc => new BookCopyViewModel
                    {
                        CopyId = bc.CopyId,
                        BookId = bc.BookId,
                        Title = bc.Book.BookTitle,
                        Condition = bc.CopyCondition,
                        Acquisition = bc.CopyAcquisitionYear,
                        Available = bc.CopyAvailable,
                    });

                var bookCopiesList = new BindingList<BookCopyViewModel>(bookCopiesQuery.ToList());
                dataGridView1.DataSource = bookCopiesList;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changesMade = true;
            btnSave.Enabled = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var bookCopyViewModel = row.DataBoundItem as BookCopyViewModel;

                if (bookCopyViewModel != null)
                {
                    UpdateDatabase(bookCopyViewModel.BookId, bookCopyViewModel.CopyId);
                }
            }
        }

        private void UpdateDatabase(int bookId, int copyId)
        {
            using (var context = new AppDbContext())
            {
                var bookCopy = context.BookCopies.Find(bookId, copyId);
                if (bookCopy != null)
                {
                    // Update the bookCopy entity as needed
                    context.Entry(bookCopy).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public class BookCopyViewModel
        {
            public int CopyId { get; set; }
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Condition { get; set; }
            public int Acquisition { get; set; }
            public bool Available { get; set; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (changesMade)
            {
                SaveChanges();
                changesMade = false;
                btnSave.Enabled = false;
            }
        }
        private void SaveChanges()
        {
            var data = dataGridView1.DataSource as BindingList<BookCopyViewModel>;
            if (data != null)
            {
                using (var context = new AppDbContext())
                {
                    foreach (var viewModel in data)
                    {
                        var bookCopy = context.BookCopies.Find(viewModel.BookId, viewModel.CopyId);
                        if (bookCopy != null)
                        {
                            // Map the changes from viewModel to bookCopy
                            bookCopy.CopyCondition = viewModel.Condition;
                            bookCopy.CopyAcquisitionYear = viewModel.Acquisition;
                            bookCopy.CopyAvailable = viewModel.Available;
                            // ... map other fields as necessary ...
                        }
                    }
                    context.SaveChanges();
                }
            }
        }

        public Button btnCurrent;
        public void ActivateButton(object btnSender, Color color)
        {
            if (btnSender != null)
            {
                DisableButton();
                btnCurrent = btnSender as Button;
                btnCurrent.BackColor = Color.BlueViolet;
                btnCurrent.ForeColor = color;
                btnCurrent.TextAlign = ContentAlignment.MiddleCenter;
                btnCurrent.TextImageRelation = TextImageRelation.TextBeforeImage;
                btnCurrent.ImageAlign = ContentAlignment.MiddleRight;
            }
        }
        public void DisableButton()
        {
            if (btnCurrent != null)
            {
                btnCurrent.BackColor = Color.SlateBlue;
                btnCurrent.ForeColor = Color.Black;
                btnCurrent.TextAlign = ContentAlignment.MiddleLeft;
                btnCurrent.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnCurrent.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btnCopies_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Aqua);
            OpenChildForm(new  FromCopies());
        }

        private void btnBorrowed_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Red);
            OpenChildForm(new FromBorrowed());
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelToFill.Controls.Add(childForm);
            panelToFill.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }

}
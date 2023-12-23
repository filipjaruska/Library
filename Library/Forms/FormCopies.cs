using Library.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Library.Form1;

namespace Library.Forms
{
    public partial class FromCopies : Form
    {
        public FromCopies()
        {
            InitializeComponent();


            using (var context = new AppDbContext())
            {
                comboBoxBranches.DisplayMember = "BranchName";
                comboBoxBranches.ValueMember = "BranchId";
                comboBoxBranches.DataSource = context.LibraryBranches.ToList();
            }

            //Temporary stilling for dataGridView
            dataGridView1.Columns["CopyId"]!.ReadOnly = true;
            dataGridView1.Columns["BookId"]!.ReadOnly = true;
            //basic
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.None;
            //header
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            //cels
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            //grid and row
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.RowHeadersVisible = false;
        }
        private bool changesMade = false;

        private void comboBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBranches.SelectedIndex > -1)
            {
                int branchId = (int)comboBoxBranches.SelectedValue!;
                DisplayBookCopies(branchId);
            }
        }
        
        private void DisplayBookCopies(int branchId)
        {
            using (var context = new AppDbContext())
            {
                var bookCopiesQuery = context.BookCopies
                    .Include(bc => bc.Book)
                    .Where(bc => bc.BranchId == branchId && bc.CopyAvailable == true)
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;
            if (changesMade)
            {
                SaveChanges();
                changesMade = false;
                btnSave.Enabled = false;
            }
        }

        private void SaveChanges()
        {
            BindingList<BookCopyViewModel>? data = dataGridView1.DataSource as BindingList<BookCopyViewModel>;
            if (data != null)
            {
                using (var context = new AppDbContext())
                {
                    foreach (var viewModel in data)
                    {
                        var bookCopy = context.BookCopies.Find(viewModel.BookId, viewModel.CopyId);
                        if (bookCopy != null)
                        {
                            bookCopy.CopyCondition = viewModel.Condition;
                            bookCopy.CopyAcquisitionYear = viewModel.Acquisition;
                            bookCopy.CopyAvailable = viewModel.Available;
                        }
                    }
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
    }
}

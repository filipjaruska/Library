using Library.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Components;
using Microsoft.EntityFrameworkCore;
using static Library.Forms.FromCopies;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Library.Forms
{
    public partial class FromBorrowed : Form
    {


        public FromBorrowed()
        {
            InitializeComponent();


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


            var binder = new DataGridBinder();
            binder.BindDataToGrid(
                queryFunc: context => context.BookCopies.Include(bc => bc.Book),
                whereFunc: bc => bc.CopyAvailable == false,
                selectFunc: bc => new BookCopyViewModel
                {
                    CopyId = bc.CopyId,
                    BookId = bc.BookId,
                    Title = bc.Book.BookTitle,
                    Condition = bc.CopyCondition,
                    Acquisition = bc.CopyAcquisitionYear,
                    Available = bc.CopyAvailable,
                },
                dataGridView: dataGridView1
                );
        }

        private void returned_Click(object sender, EventArgs e)
        {
            var selectedBookCopy = dataGridView1.CurrentRow?.DataBoundItem as BookCopyViewModel;
            if (selectedBookCopy != null)
            {
                selectedBookCopy.Available = true;
                using (var context = new AppDbContext())
                {
                    var bookCopy = context.BookCopies.Find(selectedBookCopy.BookId, selectedBookCopy.CopyId);
                    if (bookCopy != null)
                    {
                        bookCopy.CopyAvailable = true;
                        context.SaveChanges();
                    }
                }
                dataGridView1.Refresh();
            }
        }
    }
}

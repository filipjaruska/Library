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
            DataGridStyle.DefaultStyle(dataGridView1);

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
            ReturnHandler returnHandler = new ReturnHandler(dataGridView1);
            returned.Click += returnHandler.HandleReturnClick;
        }
    }
}

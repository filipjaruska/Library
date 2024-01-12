using Library.Data;
using Library.Components;
using Microsoft.EntityFrameworkCore;

namespace Library.Forms
{
    public partial class FromBorrowed : Form
    {


        public FromBorrowed()
        {
            InitializeComponent();
            DataGridStyle.DefaultStyle(dataGridView1);

            // Create a DataGridBinder and bind the borrowed book copies data to the DataGridView.
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
            // Create a ReturnHandler and subscribe it to the Click event of the return button.
            ReturnHandler returnHandler = new ReturnHandler(dataGridView1);
            returned.Click += returnHandler.HandleReturnClick;
        }
    }
}

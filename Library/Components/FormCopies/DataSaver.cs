using System.ComponentModel;
using Library.Data;
using Library.Forms;

public class DataSaver
{
    private DataGridView dataGridView1;

    public DataSaver(DataGridView dataGridView)
    {
        dataGridView1 = dataGridView;
    }

    public void SaveChanges()
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
}
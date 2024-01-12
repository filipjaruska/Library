using System.ComponentModel;
using Library.Data;
using Library.Forms;

public class DataSaver
{
    private DataGridView dataGridView1;

    // The constructor takes a DataGridView as a parameter and stores it in the dataGridView1 field.
    public DataSaver(DataGridView dataGridView)
    {
        dataGridView1 = dataGridView;
    }

    // The SaveChanges method saves changes made in the DataGridView to the database.
    // It iterates over the book copies in the DataGridView's data source adn finds the corresponding book copy in the database, updates it and saves the changes.
    public void SaveChanges()
    {
        // Try to cast the DataGridView's data source to a BindingList of BookCopyViewModel
        BindingList<BookCopyViewModel>? data = dataGridView1.DataSource as BindingList<BookCopyViewModel>;
        if (data != null)
        {
            using (var context = new AppDbContext())
            {
                foreach (var viewModel in data)
                {
                    // Find the corresponding book copy in the database
                    var bookCopy = context.BookCopies.Find(viewModel.BookId, viewModel.CopyId);
                    if (bookCopy != null)
                    {
                        // Update the book copy's properties
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
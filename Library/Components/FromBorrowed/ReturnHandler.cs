using Library.Data;
public class ReturnHandler
{
    // A DataGridView that displays a list of book copies.
    private DataGridView dataGridView1;

    // The constructor takes a DataGridView as a parameter and stores it in the dataGridView1 field.
    public ReturnHandler(DataGridView dataGridView)
    {
        dataGridView1 = dataGridView;
    }

    // The HandleReturnClick method is intended to be used as an event handler for a button click event.
    // It sets the Available property of the selected book copy to true, both in the DataGridView and in the database.
    public void HandleReturnClick(object sender, EventArgs e)
    {
        // Cast the data bound item of the current row in the DataGridView to a BookCopyViewModel
        var selectedBookCopy = dataGridView1.CurrentRow?.DataBoundItem as BookCopyViewModel;
        if (selectedBookCopy != null)
        {
            // Set the Available property of the selected book copy to true
            selectedBookCopy.Available = true;
            using (var context = new AppDbContext())
            {
                // Find the corresponding book copy in the database
                var bookCopy = context.BookCopies.Find(selectedBookCopy.BookId, selectedBookCopy.CopyId);
                if (bookCopy != null)
                {
                    // Set the CopyAvailable property of the book copy in the database to true and save changes
                    bookCopy.CopyAvailable = true;
                    context.SaveChanges();
                }
            }
            dataGridView1.Refresh();
        }
    }
}
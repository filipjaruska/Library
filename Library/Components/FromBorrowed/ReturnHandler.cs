using System;
using System.Windows.Forms;
using Library.Data;
using Library.Forms;

public class ReturnHandler
{
    private DataGridView dataGridView1;

    public ReturnHandler(DataGridView dataGridView)
    {
        dataGridView1 = dataGridView;
    }

    public void HandleReturnClick(object sender, EventArgs e)
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
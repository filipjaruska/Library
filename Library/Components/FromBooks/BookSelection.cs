using Library.Data;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

public class BookSelection
{
    private DataGridView _dataGridView1;
    private Label _lbName;
    private Label lbId;
    private Label lbIsbn;
    private Label lbAuthor;
    private PictureBox pictureBox1;
    private TextBox textBox1;
    public string linkToGoogleBookPage;

    // The constructor takes a DataGridView and various controls as parameters and stores them in the corresponding fields.
    public BookSelection(DataGridView dataGridView, Label nameLabel, Label idLabel, Label isbnLabel, Label authorLabel, PictureBox pictureBox, TextBox textBox)
    {
        _dataGridView1 = dataGridView;
        _lbName = nameLabel;
        lbId = idLabel;
        lbIsbn = isbnLabel;
        lbAuthor = authorLabel;
        pictureBox1 = pictureBox;
        textBox1 = textBox;
    }

    // The HandleBookSelection method updates the controls with the details of the selected book, performs a Google Custom Search for the book title, and updates the PictureBox and TextBox with the image and snippet of the first search result.
    // It also stores the link to the Google Books page of the first search result in the linkToGoogleBookPage field.
    public async Task HandleBookSelection()
    {
        // Check if any row is selected in the DataGridView
        if (_dataGridView1.SelectedRows.Count > 0)
        {
            // Cast the DataGridView's data source to a BindingList of Book
            BindingList<Book>? data = _dataGridView1.DataSource as BindingList<Book>;
            if (data != null)
            {
                // Get the index of the selected row
                var selectedRowIndex = _dataGridView1.SelectedRows[0].Index;
                // Check if the selected row index is valid
                if (selectedRowIndex >= 0 && selectedRowIndex < data.Count)
                {
                    // Get the selected book
                    var selectedBook = data[selectedRowIndex];
                    // Update the labels with the selected book's details
                    _lbName.Text = selectedBook.BookTitle;
                    lbId.Text = selectedBook.BookId.ToString();
                    lbIsbn.Text = selectedBook.BookIsbn;
                    using (var context = new AppDbContext())
                    {
                        // Get the selected book's author from the database
                        var book = context.Books.Include(b => b.BookAuthors)
                            .ThenInclude(ba => ba.Author)
                            .Single(b => b.BookId == selectedBook.BookId);

                        // Update the author label with the selected book's author
                        lbAuthor.Text = $@"{book.BookAuthors.First().Author.AuthorFirstName} {book.BookAuthors.First().Author.AuthorLastName}";
                    }

                    // Perform a Google Custom Search for the selected book's title
                    GoogleCustomSearch googleSearch = new GoogleCustomSearch(pictureBox1, textBox1);
                    await googleSearch.GetGoogleCustomSearch(selectedBook.BookTitle);
                    linkToGoogleBookPage = googleSearch.linkToGoogleBookPage;
                }
            }
        }
    }
}
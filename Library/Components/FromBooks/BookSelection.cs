using Library.Data;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

public class BookSelection
{
    private DataGridView dataGridView1;
    private Label lbName;
    private Label lbId;
    private Label lbIsbn;
    private Label lbAuthor;
    private PictureBox pictureBox1;
    private TextBox textBox1;
    public string linkToGoogleBookPage;

    public BookSelection(DataGridView dataGridView, Label nameLabel, Label idLabel, Label isbnLabel, Label authorLabel, PictureBox pictureBox, TextBox textBox)
    {
        dataGridView1 = dataGridView;
        lbName = nameLabel;
        lbId = idLabel;
        lbIsbn = isbnLabel;
        lbAuthor = authorLabel;
        pictureBox1 = pictureBox;
        textBox1 = textBox;
    }

    public async Task HandleBookSelection()
    {
        if (dataGridView1.SelectedRows.Count > 0)
        {
            BindingList<Book>? data = dataGridView1.DataSource as BindingList<Book>;
            if (data != null)
            {
                var selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                if (selectedRowIndex >= 0 && selectedRowIndex < data.Count)
                {
                    var selectedBook = data[selectedRowIndex];
                    lbName.Text = selectedBook.BookTitle;
                    lbId.Text = selectedBook.BookId.ToString();
                    lbIsbn.Text = selectedBook.BookIsbn;
                    using (var context = new AppDbContext())
                    {
                        var book = context.Books.Include(b => b.BookAuthors)
                            .ThenInclude(ba => ba.Author)
                            .Single(b => b.BookId == selectedBook.BookId);

                        lbAuthor.Text = $@"{book.BookAuthors.First().Author.AuthorFirstName} {book.BookAuthors.First().Author.AuthorLastName}";
                    }

                    GoogleCustomSearch googleSearch = new GoogleCustomSearch(pictureBox1, textBox1);
                    await googleSearch.GetGoogleCustomSearch(selectedBook.BookTitle);
                    linkToGoogleBookPage = googleSearch.linkToGoogleBookPage;
                }
            }
        }
    }
}
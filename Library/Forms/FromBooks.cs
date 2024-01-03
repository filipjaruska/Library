using Library.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using static Library.Forms.FormStaff;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library.Forms
{
    public partial class FromBooks : Form
    {
        public FromBooks()
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



            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            var bookTitleColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookTitle",
                HeaderText = "Book Title",
                Name = "bookTitleColumn"
            };

            dataGridView1.Columns.Add(bookTitleColumn);

            var binder = new DataGridBinder();
            binder.BindDataToGrid(
                queryFunc: context => context.Books,
                whereFunc: null,
                selectFunc: b => b,
                dataGridView: dataGridView1
            );


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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

                        using (var context = new AppDbContext())
                        {
                            var book = context.Books.Include(b => b.BookAuthors)
                                .ThenInclude(ba => ba.Author)
                                .Single(b => b.BookId == selectedBook.BookId);

                            lbAuthor.Text = $@"{book.BookAuthors.First().Author.AuthorFirstName} {book.BookAuthors.First().Author.AuthorLastName}";
                        }


                        string apiKey = "bruh"; 
                        string apiUrl = $"https://api.nytimes.com/svc/books/v3/reviews.json?title={selectedBook.BookTitle}&api-key={apiKey}";


                        wtf(apiUrl);
                        


                    }
                }
            }
        }

        private async Task wtf(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(content);
                    string description = json.results[0].book_summary;

                    
                    textBox1.Text = description;
                }
            }
        }

        private void lbName_Click(object sender, EventArgs e)
        {
            string urlEncodedSearchQuery = System.Web.HttpUtility.UrlEncode(lbName.Text);

            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = $"https://www.google.com/search?q={urlEncodedSearchQuery}",
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(psi);
        }

        private void lbName_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lbName.ForeColor = Color.Red;
        }

        private void lbName_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lbName.ForeColor = Color.Black;
        }
    }
}

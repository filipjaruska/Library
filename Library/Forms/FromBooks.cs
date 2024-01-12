using Library.Components;

namespace Library.Forms
{
    public partial class FromBooks : Form
    {
        private string _linkToGoogleBookPage;
        public FromBooks()
        {
            InitializeComponent();
            // Changes the style of the DataGridView so that i don't have to do it manually every time
            DataGridStyle.DefaultStyle(dataGridView1);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // DataGridView columns
            var bookTitleColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookTitle",
                HeaderText = "Book Title",
                Name = "bookTitleColumn"
            };
            dataGridView1.Columns.Add(bookTitleColumn);

            // Loads data into the DataGridView
            var binder = new DataGridBinder();
            binder.BindDataToGrid(
                queryFunc: context => context.Books,
                whereFunc: null,
                selectFunc: b => b,
                dataGridView: dataGridView1
            );
        }

        private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            BookSelection bookSelection = new BookSelection(dataGridView1, lbName, lbId, lbIsbn, lbAuthor, pictureBox1, textBox1);
            await bookSelection.HandleBookSelection();
            _linkToGoogleBookPage = bookSelection.linkToGoogleBookPage;
        }

        // Opens a new tab in the browser with defined search query
        private void lbName_Click(object sender, EventArgs e)
        {
            OpenBrowser.OpenLinkInBrowser("https://www.google.com/search?q=", lbName.Text);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenBrowser.OpenLinkInBrowser(_linkToGoogleBookPage);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenBrowser.OpenLinkInBrowser("https://www.youtube.com/results?search_query=", lbName.Text + " Book");
        }

        // Hover effect for the lbName
        private void lbName_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lbName.ForeColor = Color.BlueViolet;
        }

        private void lbName_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lbName.ForeColor = Color.Black;
        }

        // Hover effect for the pictureBox
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}

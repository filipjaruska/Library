using Library.Data;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            treeView1.Nodes.Clear();

            using var context = new AppDbContext();
            var authors = context.Author.ToList();

            foreach (var author in authors)
            {
                var node = new TreeNode($"{author.AuthorFirstName} {author.AuthorLastName}");
                node.Tag = author.AuthorId;
                treeView1.Nodes.Add(node);
            }

        }
    }
}
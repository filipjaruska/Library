using Library.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Net;
using Library.Forms;
using System.Windows.Forms;
using System.Xml;
using static Library.Components.Form1.ChangeButton;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = true;
            textBox1.Text = Path.GetFullPath("App.config");
            using (var dbContext = new AppDbContext())
            {
                label2.Text = "Succesfuly connected to database";
                try
                {
                    dbContext.Database.OpenConnection();
                    dbContext.Database.CloseConnection();
                }
                catch (Exception e)
                {
                    label2.Text = "No connection to database";
                    errorProvider1.SetError(textBox1, e.Message);
                }
            }
        }

        private Form _currentChildForm;
        private Button _btnCurrent;
        private void btnCopies_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Aqua);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FromCopies());
        }

        private void btnBorrowed_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Red);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FromBorrowed());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Peru);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FromBooks());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Green);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FormStaff());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HandleResetButton(_currentChildForm);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HandleResetButton(_currentChildForm);
        }
    }

}
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
        // The constructor initializes the form and tests the database connection.
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = true;
            // Try to get the full path of the App.config file to see if it exists.
            try
            {
                textBox1.Text = Path.GetFullPath("App.config");
            }
            catch (Exception e)
            {
                errorProvider1.SetError(textBox1, e.Message);
            }

            // Try to open and close the database connection to test if it's working.
            label2.Text = "Succesfuly connected to database";
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Database.OpenConnection();
                    dbContext.Database.CloseConnection();
                }
            }
            catch (Exception e)
            {
                label2.Text = "No connection to database";
                errorProvider1.SetError(textBox1, e.Message);
            }
            
        }

        private Form _currentChildForm;
        private Button _btnCurrent;

        // Handle the Click events.
        private void btnCopies_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Aqua);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FromCopies(), _currentChildForm);
        }

        private void btnBorrowed_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Red);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FromBorrowed(), _currentChildForm);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Peru);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FromBooks(), _currentChildForm);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            _btnCurrent = HandleActivateButton(sender, Color.Green);
            ChildFormOpener childFormOpener = new ChildFormOpener(panelToFill);
            _currentChildForm = childFormOpener.OpenChildForm(new FormStaff(), _currentChildForm);
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
using Library.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Net;
using Library.Forms;
using System.Windows.Forms;
using System.Xml;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            bool x = false;
            using (var dbContext = new AppDbContext())
            {
                try
                {
                    dbContext.Database.OpenConnection();
                    dbContext.Database.CloseConnection();
                }
                catch (Exception e)
                {
                    label2.Text = "No connection to database";
                    textBox1.Text = "error lol";
                    errorProvider1.SetError(textBox1, e.Message);
                    x = true;

                }
            }

            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Library/Data/App.config");

            if (!File.Exists(configFilePath) || x)
            {
                textBox1.Text = "This likely occurs due to App.config file missing, please specify connection detail below and restart the app.";
                textBox1.Visible = true;
                tbHost.Visible = true;
                tbDB.Visible = true;
                tbUser.Visible = true;
                tbPassword.Visible = true;
                button1.Visible = true;
                button1.Enabled = true;
            }
        }

        public Form currentChildForm;
        public Button btnCurrent;

        private void btnCopies_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Aqua);
            OpenChildForm(new FromCopies());
        }

        private void btnBorrowed_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Red);
            OpenChildForm(new FromBorrowed());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Peru);
            OpenChildForm(new FromBooks());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Green);
            OpenChildForm(new FormStaff());
        }

        public void ActivateButton(object btnSender, Color color)
        {
            if (btnSender != null)
            {
                DisableButton();
                btnCurrent = btnSender as Button;
                btnCurrent.BackColor = Color.BlueViolet;
                btnCurrent.ForeColor = color;
                btnCurrent.TextAlign = ContentAlignment.MiddleCenter;
                btnCurrent.TextImageRelation = TextImageRelation.TextBeforeImage;
                btnCurrent.ImageAlign = ContentAlignment.MiddleRight;
            }
        }
        public void DisableButton()
        {
            if (btnCurrent != null)
            {
                btnCurrent.BackColor = Color.SlateBlue;
                btnCurrent.ForeColor = Color.Black;
                btnCurrent.TextAlign = ContentAlignment.MiddleLeft;
                btnCurrent.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnCurrent.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelToFill.Controls.Add(childForm);
            panelToFill.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            currentChildForm.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Library/Data/App.config");



            XmlDocument doc = new XmlDocument();

            XmlElement configurationElement = doc.CreateElement("configuration");
            doc.AppendChild(configurationElement);

            XmlElement connectionStringsElement = doc.CreateElement("connectionStrings");
            configurationElement.AppendChild(connectionStringsElement);

            XmlElement addElement = doc.CreateElement("add");
            addElement.SetAttribute("name", "DefaultConnection");

            string host = tbHost.Text;
            string database = tbDB.Text;
            string username = tbUser.Text;
            string password = tbPassword.Text;

            addElement.SetAttribute("connectionString", $"Host={host}; Database={database}; Username={username}; Password={password}");
            addElement.SetAttribute("providerName", "System.Data.SqlClient");
            connectionStringsElement.AppendChild(addElement);

            doc.Save(configFilePath);

        }


    }

}
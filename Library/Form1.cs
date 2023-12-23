using Library.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Net;
using Library.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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


    }

}
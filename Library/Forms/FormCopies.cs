using Library.Components;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Library.Form1;

namespace Library.Forms
{
    public partial class FromCopies : Form
    {
        public FromCopies()
        {
            InitializeComponent();

            using (var context = new AppDbContext())
            {
                comboBoxBranches.DisplayMember = "BranchName";
                comboBoxBranches.ValueMember = "BranchId";
                comboBoxBranches.DataSource = context.LibraryBranches.ToList();
            }
            DataGridStyle.DefaultStyle(dataGridView1);

            dataGridView1.Columns["CopyId"]!.ReadOnly = true;
            dataGridView1.Columns["BookId"]!.ReadOnly = true;
        }
        private bool _changesMade = false;

        private void comboBoxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxHandler comboBoxHandler = new ComboBoxHandler(comboBoxBranches, dataGridView1);
            comboBoxBranches.SelectedIndexChanged += comboBoxHandler.HandleSelectedIndexChanged;

            //initial call of the event handler
            comboBoxHandler.HandleSelectedIndexChanged(comboBoxBranches, EventArgs.Empty);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _changesMade = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ButtonHandler buttonHandler = new ButtonHandler(btnSave, dataGridView1, _changesMade);
            btnSave.Click += buttonHandler.HandleSaveClick;
        }
    }
}

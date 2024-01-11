using Library.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Library.Components;
using Library.Components.FromStaff;
using static Library.Forms.FromCopies;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library.Forms
{
    public partial class FormStaff : Form
    {
        public FormStaff()
        {
            InitializeComponent();
            DataGridStyle.DefaultStyle(dataGridView1);

            var binder = new DataGridBinder();
            binder.BindDataToGrid(
                queryFunc: context => context.Staffs.Include(lb => lb.LibraryBranch),
                whereFunc: null,
                selectFunc: s => new StaffViewModel
                {
                    StaffId = s.StaffId,
                    BranchId = s.BranchId,
                    BranchName = s.LibraryBranch.BranchName,
                    StaffName = s.StaffFirstName + " " + s.StaffLastName,
                    Possition = s.StaffPosition,
                    Salary = s.StaffSalary,
                },
                dataGridView: dataGridView1
            );
        }

        // handles staff selection
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            StaffSelection.HandleStaffSelection(dataGridView1, textBox1);
        }

        // deletes selected row
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete staff?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            var deleteDataGridRow = new DeleteDataGridRow();
            deleteDataGridRow.DeleteSelectedRow<Staff, StaffViewModel>(dataGridView1, viewModel => viewModel.StaffId);
        }

        // changes salary of selected staff
        private void button1_Click(object sender, EventArgs e)
        {
            StaffEdit.HandleStaffSalaryChange(dataGridView1, textBox1);
        }
    }
}

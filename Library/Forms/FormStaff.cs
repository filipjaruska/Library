using Library.Data;
using Microsoft.EntityFrameworkCore;
using Library.Components;
using Library.Components.FromStaff;

namespace Library.Forms
{
    public partial class FormStaff : Form
    {
        // The constructor initializes the form and sets up the DataGridView.
        public FormStaff()
        {
            InitializeComponent();
            DataGridStyle.DefaultStyle(dataGridView1);

            // Create a DataGridBinder and bind the staff data to the DataGridView.
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

        // Handles staff selection
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            StaffSelection.HandleStaffSelection(dataGridView1, textBox1);
        }

        // Deletes selected row
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete staff?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            var deleteDataGridRow = new DeleteDataGridRow();
            deleteDataGridRow.DeleteSelectedRow<Staff, StaffViewModel>(dataGridView1, viewModel => viewModel.StaffId);
        }

        // Changes salary of selected staff
        private void button1_Click(object sender, EventArgs e)
        {
            StaffEdit.HandleStaffSalaryChange(dataGridView1, textBox1);
        }
    }
}

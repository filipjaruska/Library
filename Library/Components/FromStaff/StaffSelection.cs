using System.ComponentModel;
using Library.Data;

namespace Library.Components.FromStaff
{
    internal static class StaffSelection
    {
        // The HandleStaffSelection method displays the salary of the selected staff member in a TextBox.
        // The DataGridView should display a list of staff members, and the TextBox is used to display the salary of the selected staff member.
        public static void HandleStaffSelection(DataGridView dataGridView1, TextBox textBox1)
        {
            // Check if any row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                BindingList<StaffViewModel>? data = dataGridView1.DataSource as BindingList<StaffViewModel>;
                if (data != null)
                {
                    // Get the index of the selected row
                    var selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    if (selectedRowIndex >= 0 && selectedRowIndex < data.Count)
                    {
                        // Get the selected staff member
                        var selectedStaff = data[selectedRowIndex];
                        textBox1.Text = selectedStaff.Salary.ToString();
                    }
                }
            }
        }
    }
}
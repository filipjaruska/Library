using System.ComponentModel;
using Library.Data;

namespace Library.Components.FromStaff
{
    internal static class StaffEdit
    {
        // The HandleStaffSalaryChange method updates the salary of the selected staff member in the DataGridView.
        // The DataGridView should display a list of staff members, and the TextBox should contain the new salary.
        public static void HandleStaffSalaryChange(DataGridView dataGridView1, TextBox textBox1)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Cast the DataGridView's data source to a BindingList of StaffViewModel
                BindingList<StaffViewModel>? data = dataGridView1.DataSource as BindingList<StaffViewModel>;
                if (data != null)
                {
                    // Get the index of the selected row
                    var selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    // Check if the selected row index is valid
                    if (selectedRowIndex >= 0 && selectedRowIndex < data.Count)
                    {
                        // Get the selected staff member
                        var selectedStaff = data[selectedRowIndex];
                        double newSalary;
                        // Parse the new salary from the TextBox
                        if (double.TryParse(textBox1.Text, out newSalary))
                        {
                            // Update the salary of the selected staff member
                            selectedStaff.Salary = newSalary;
                            dataGridView1.Refresh();
                        }
                    }
                }
            }
        }
    }
}
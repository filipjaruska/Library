using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Forms;

namespace Library.Components.FromStaff
{
    internal static class StaffEdit
    {
        public static void HandleStaffSalaryChange(DataGridView dataGridView1, TextBox textBox1)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                BindingList<StaffViewModel>? data = dataGridView1.DataSource as BindingList<StaffViewModel>;
                if (data != null)
                {
                    var selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    if (selectedRowIndex >= 0 && selectedRowIndex < data.Count)
                    {
                        var selectedStaff = data[selectedRowIndex];
                        double newSalary;
                        if (double.TryParse(textBox1.Text, out newSalary))
                        {
                            selectedStaff.Salary = newSalary;
                            dataGridView1.Refresh();
                        }
                    }
                }
            }
        }
    }
}

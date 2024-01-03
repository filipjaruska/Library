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
using static Library.Forms.FromCopies;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Library.Forms
{
    public partial class FormStaff : Form
    {
        public FormStaff()
        {
            InitializeComponent();

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Silver;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

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

        public class StaffViewModel
        {
            public int StaffId { get; set; }
            public int BranchId { get; set; }
            public string BranchName { get; set; }
            public string StaffName { get; set; }
            public string Possition { get; set; }
            public double Salary { get; set; }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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
                        textBox1.Text = selectedStaff.Salary.ToString();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var deleteDataGridRow = new DeleteDataGridRow();
            deleteDataGridRow.DeleteSelectedRow<Staff, StaffViewModel>(dataGridView1, viewModel => viewModel.StaffId);
            
        }


        private void button1_Click(object sender, EventArgs e)
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
                        else
                        {
                            //error
                        }
                    }
                }
            }
        }
    }
}

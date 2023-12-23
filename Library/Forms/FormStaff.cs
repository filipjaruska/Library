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

namespace Library.Forms
{
    public partial class FormStaff : Form
    {
        public FormStaff()
        {
            InitializeComponent();

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

        
    }
}

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
using static Library.Forms.FromCopies;

namespace Library.Forms
{
    public partial class FormStaff : Form
    {
        public FormStaff()
        {
            InitializeComponent();

            using (var context = new AppDbContext())
            {
                var StaffQuery = context.Staffs
                    .Include(lb => lb.LibraryBranch)
                    .Select(s => new StaffViewModel
                    {
                        StaffId = s.StaffId,
                        BranchId = s.BranchId,
                        BranchName = s.LibraryBranch.BranchName,
                        StaffName = s.StaffFirstName + " " + s.StaffLastName,
                        Possition = s.StaffPosition,
                        Salary = s.StaffSalary,
                    });

                var bookCopiesList = new BindingList<StaffViewModel>(StaffQuery.ToList());
                dataGridView1.DataSource = bookCopiesList;
            }
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

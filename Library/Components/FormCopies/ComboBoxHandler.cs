using System;
using System.Windows.Forms;
using Library.Components;
using Library.Data;
using Library.Forms;
using Microsoft.EntityFrameworkCore;

public class ComboBoxHandler
{
    private ComboBox comboBoxBranches;
    private DataGridView dataGridView1;

    public ComboBoxHandler(ComboBox comboBox, DataGridView dataGridView)
    {
        comboBoxBranches = comboBox;
        dataGridView1 = dataGridView;
    }

    public void HandleSelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxBranches.SelectedIndex > -1)
        {
            int branchId = (int)comboBoxBranches.SelectedValue!;
            var binder = new DataGridBinder();
            binder.BindDataToGrid(
                queryFunc: context => context.BookCopies.Include(bc => bc.Book),
                whereFunc: bc => bc.BranchId == branchId && bc.CopyAvailable == true,
                selectFunc: bc => new BookCopyViewModel
                {
                    CopyId = bc.CopyId,
                    BookId = bc.BookId,
                    Title = bc.Book.BookTitle,
                    Condition = bc.CopyCondition,
                    Acquisition = bc.CopyAcquisitionYear,
                    Available = bc.CopyAvailable,
                },
                dataGridView: dataGridView1
            );
        }
    }
}
using System;
using System.Windows.Forms;
using Library.Components;
using Library.Data;
using Library.Forms;
using Microsoft.EntityFrameworkCore;

public class ComboBoxHandler
{
    private ComboBox _comboBoxBranches;
    private DataGridView _dataGridView1;

    // The constructor takes a ComboBox and a DataGridView as parameters and stores them in the comboBoxBranches and dataGridView1 fields.
    public ComboBoxHandler(ComboBox comboBox, DataGridView dataGridView)
    {
        _comboBoxBranches = comboBox;
        _dataGridView1 = dataGridView;
    }

    // The HandleSelectedIndexChanged method is intended to be used as an event handler for the SelectedIndexChanged event of the ComboBox.
    // It updates the DataGridView to display the book copies that are available at the selected branch.
    public void HandleSelectedIndexChanged(object sender, EventArgs e)
    {
        // Check if any branch is selected in the ComboBox
        if (_comboBoxBranches.SelectedIndex > -1)
        {
            // Get the ID of the selected branch
            int branchId = (int)_comboBoxBranches.SelectedValue!;
            // Create a new DataGridBinder
            var binder = new DataGridBinder();
            // Bind the DataGridView to the book copies that are available at the selected branch
            binder.BindDataToGrid(
                // Query function to include the Book of each BookCopy
                queryFunc: context => context.BookCopies.Include(bc => bc.Book),
                // Where function to filter the book copies by branch ID and availability
                whereFunc: bc => bc.BranchId == branchId && bc.CopyAvailable == true,
                // Select function to project each BookCopy to a BookCopyViewModel
                selectFunc: bc => new BookCopyViewModel
                {
                    CopyId = bc.CopyId,
                    BookId = bc.BookId,
                    Title = bc.Book.BookTitle,
                    Condition = bc.CopyCondition,
                    Acquisition = bc.CopyAcquisitionYear,
                    Available = bc.CopyAvailable,
                },
                // The DataGridView to bind the data to
                dataGridView: _dataGridView1
            );
        }
    }
}
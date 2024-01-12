using Library.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Library.Components
{
    internal class DeleteDataGridRow
    {
        // The DeleteSelectedRow method deletes the selected row from the DataGridView and the corresponding record from the database.
        // It takes a DataGridView and a key selector function as parameters.
        // The key selector function is used to find the corresponding record in the database.
        // The method is (hopefully) generic and can be used with any entity type and corresponding view model type.
        public void DeleteSelectedRow<T, TViewModel>(DataGridView dataGridView, Func<TViewModel, object> keySelector)
            where T : class
            where TViewModel : class
        {
            // Check if any row is selected in the DataGridView
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Check if the DataGridView's data source is a BindingList of TViewModel
                if (dataGridView.DataSource is BindingList<TViewModel> data)
                {
                    using var context = new AppDbContext();
                    var selectedRowIndex = dataGridView.SelectedRows[0].Index;
                    // Check if the selected row index is valid
                    if (selectedRowIndex >= 0 && selectedRowIndex < data.Count)
                    {
                        var selectedItem = data[selectedRowIndex];
                        // Find the corresponding record in the database
                        var item = context.Set<T>().Find(keySelector(selectedItem));
                        if (item != null)
                        {
                            // Remove the record from the database and save changes
                            context.Set<T>().Remove(item);
                            context.SaveChanges();

                            // Remove the selected row from the DataGridView
                            data.RemoveAt(selectedRowIndex);
                            dataGridView.Refresh();
                        }
                    }
                }
            }
        }
    }
}
using Library.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Forms.FormStaff;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Library.Components
{
    internal class DeleteDataGridRow
    {
        public void DeleteSelectedRow<T, TViewModel>(DataGridView dataGridView, Func<TViewModel, object> keySelector)
            where T : class
            where TViewModel : class
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                if (dataGridView.DataSource is BindingList<TViewModel> data)
                {
                    using var context = new AppDbContext();
                    var selectedRowIndex = dataGridView.SelectedRows[0].Index;
                    if (selectedRowIndex >= 0 && selectedRowIndex < data.Count)
                    {
                        var selectedItem = data[selectedRowIndex];
                        var item = context.Set<T>().Find(keySelector(selectedItem));
                        if (item != null)
                        {
                            context.Set<T>().Remove(item);
                            context.SaveChanges();

                            data.RemoveAt(selectedRowIndex);

                            dataGridView.Refresh();
                        }
                    }
                }
            }
        }
    }
}

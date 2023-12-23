using Library.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Components
{
    internal class DataGridBinder
    {
        /*
         * Binds data to a DataGridView control.
         * 
         * For more info or notes, see: README.md under the section "DataGridBinder" in the "Components" chapter.
         * NOTE: Consider making the BindDataToGrid method static. Research more about static methods.
         */

        //  "T" is the type of the data in the database.
        //  "TViewModel" is The type of the view model that the data will be converted to.
        public void BindDataToGrid<T, TViewModel>(
            // A function that takes the database context and returns an IQueryable of the data.
            Func<AppDbContext, IQueryable<T>> queryFunc,

            // A function that filters the data. If null, no filtering is applied.
            Func<T, bool> whereFunc, 

            // A function that converts the data to the view model.
            Func<T, TViewModel> selectFunc, 
            DataGridView dataGridView)
        {
            using (var context = new AppDbContext())
            {
                // Execute the query function to get the data from the database.
                var query = queryFunc(context);

                // If a where function is provided, apply it to filter the data.
                // If no where function is provided, use a function that always returns true.
                var filteredQuery = query.Where(whereFunc ?? (_ => true));

                // Convert the data to the view model using the select function.
                var viewModelList = filteredQuery.Select(selectFunc).ToList();

                //Create a binding list from the view model list.
                // Then bind the data to the DataGridView control.
                var bindingList = new BindingList<TViewModel>(viewModelList);
                dataGridView.DataSource = bindingList;
            }
        }
    }
}

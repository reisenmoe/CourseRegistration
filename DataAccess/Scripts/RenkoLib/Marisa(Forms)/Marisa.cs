/*
 * ===============
 * IMPORTANT NOTES
 * ===============
 * 
 * Because of System.Configuration.ConfigurationManager, you must add the following reference
 * In Solutions & Project folder -> Right click on References -> Add Reference -> System.Configuration
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Forms;

namespace Renko
{
    public class Marisa
    {
        #region Getters
        public static string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        #endregion
    }

    #region Extension methods
    public static class MarisaExtension
    {
        #region DataGridView
        public static void Sort(this DataGridView gridView, string columnName, ListSortDirection direction)
        {
            gridView.Sort(gridView.Columns[columnName], direction);
        }
        public static void Sort(this DataGridView gridView, int columnInx, ListSortDirection direction)
        {
            gridView.Sort(gridView.Columns[columnInx], direction);
        }
        public static BindingSource GetBindingSource(this DataGridView gridView)
        {
            return gridView.DataSource as BindingSource;
        }
        #endregion

        #region Form
        /**
         * Hides the context form and display the other form.
         * callback is called with the parameter (context) when the other form is closed.
         */
        public static void SwitchFormTo<T>(this Form context, Action<Form> callback) where T : Form, new()
        {
            context.Hide();
            T otherForm = new T();
            otherForm.Closed += (sender, args) => callback(context);
            otherForm.Show();
        }
        #endregion
    }
    #endregion
}

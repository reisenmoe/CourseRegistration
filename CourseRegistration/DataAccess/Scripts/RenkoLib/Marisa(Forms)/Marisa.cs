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
        public static void ToggleColumnSort(this DataGridView context, bool on)
        {
            for (int i = 0; i < context.Columns.Count; i++)
            {
                context.Columns[i].SortMode = (on ? DataGridViewColumnSortMode.Automatic | DataGridViewColumnSortMode.NotSortable);
            }
        }
        public static void ToggleColumnSort(this DataGridView context, int targetColumnIndex, bool on)
        {
            context.Columns[targetColumnIndex].SortMode = (on ? DataGridViewColumnSortMode.Automatic | DataGridViewColumnSortMode.NotSortable);
        }
        public static bool SelectedRow(this DataGridView context)
        {
            return context.SelectedRows.Count > 0;
        }
        public static int SelectedRowIndex(this DataGridView context)
        {
            return context.CurrentCell.RowIndex;
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
        /**
         * Does NOT hide the current context form and display the other form over the context.
         * callback is called with the parameter (context) when the other form is closed.
         */
        public static void OverlayForm<T>(this Form context, bool allowMultiInteraction, Action<Form> callback) where T : Form, new()
        {
            T otherForm = new T();
            otherForm.Closed += (sender, args) => callback(context);
            if (allowMultiInteraction)
                otherForm.Show();
            else
                otherForm.ShowDialog();
        }
        #endregion
    }
    #endregion
}

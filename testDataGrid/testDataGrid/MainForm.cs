/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 5/13/2014
 * Time: 1:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace testDataGrid
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            fillDataGrid();
        }
        
        private void fillDataGrid()
        {
            var table = new DataTable("tbl");
            table.Columns.AddRange(
                new DataColumn[] {
                    new DataColumn("col01"),
                    new DataColumn("col02"),
                    new DataColumn("col03")
                });
            table.Rows.Add("01", "02", "03");
            table.Rows.Add("001", "002", "003");
            table.Rows.Add("0001", "0002", "0003");
            this.dataGrid1.DataSource = table;
        }
    }
}

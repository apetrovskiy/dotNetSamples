/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/3/2014
 * Time: 2:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace testBigList
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
            
            for (int i = 0; i < 1000; i++) {
                this.listBox1.Items.Add(i.ToString());
            }
        }
    }
}

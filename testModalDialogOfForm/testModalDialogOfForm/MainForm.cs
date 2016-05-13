/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 14/02/2016
 * Time: 07:09 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testModalDialogOfForm
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
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
        }
        void Button1Click(object sender, EventArgs e)
        {
            var dialog = new Dialog();
            this.Hide();
            dialog.Show();
        }
    }
}

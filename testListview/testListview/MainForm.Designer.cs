/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 5/13/2014
 * Time: 1:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace testListview
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Group01", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Group02", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Group03", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "item01",
            "subItem01",
            "subItem02",
            "subItem03",
            "subItem04",
            "subItem05",
            "subItem06"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "item02",
            "subItem01",
            "subItem02",
            "subItem03",
            "subItem04",
            "subItem05"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "item03",
            "subItem01",
            "subItem02",
            "subItem03",
            "subItem04"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "item04",
            "subItem01",
            "subItem02",
            "subItem03"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "item05",
            "subItem01",
            "subItem02"}, -1);
            this.listView1 = new System.Windows.Forms.ListView();
            this.column01 = new System.Windows.Forms.ColumnHeader();
            this.column02 = new System.Windows.Forms.ColumnHeader();
            this.column03 = new System.Windows.Forms.ColumnHeader();
            this.column04 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column01,
            this.column02,
            this.column03,
            this.column04});
            this.listView1.GridLines = true;
            listViewGroup1.Header = "Group01";
            listViewGroup1.Name = "Group01";
            listViewGroup2.Header = "Group02";
            listViewGroup2.Name = "Group02";
            listViewGroup3.Header = "Group03";
            listViewGroup3.Name = "Group03";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            listViewItem1.Group = listViewGroup1;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.Group = listViewGroup1;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.Group = listViewGroup2;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.Group = listViewGroup3;
            listViewItem4.StateImageIndex = 0;
            listViewItem5.Group = listViewGroup3;
            listViewItem5.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listView1.Location = new System.Drawing.Point(12, 23);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(492, 466);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column01
            // 
            this.column01.Width = 82;
            // 
            // column02
            // 
            this.column02.Width = 82;
            // 
            // column03
            // 
            this.column03.Width = 85;
            // 
            // column04
            // 
            this.column04.Width = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 501);
            this.Controls.Add(this.listView1);
            this.Name = "MainForm";
            this.Text = "testListview";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader column01;
        private System.Windows.Forms.ColumnHeader column02;
        private System.Windows.Forms.ColumnHeader column03;
        private System.Windows.Forms.ColumnHeader column04;
    }
}

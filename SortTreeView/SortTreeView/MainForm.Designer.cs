/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 7/18/2013
 * Time: 11:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SortTreeView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("aaa");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("aaä");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("aää");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("webapp");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("WebApp");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("webApp");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("webapp_");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("webapp_1");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("webapp1");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("webapp_2");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("WEBAPP_3");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("webapp3");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 9);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "aaa";
            treeNode2.Name = "Node1";
            treeNode2.Text = "aaä";
            treeNode3.Name = "Node2";
            treeNode3.Text = "aää";
            treeNode4.Name = "Node0";
            treeNode4.Text = "webapp";
            treeNode5.Name = "Node1";
            treeNode5.Text = "WebApp";
            treeNode6.Name = "Node2";
            treeNode6.Text = "webApp";
            treeNode7.Name = "Node3";
            treeNode7.Text = "webapp_";
            treeNode8.Name = "Node4";
            treeNode8.Text = "webapp_1";
            treeNode9.Name = "Node5";
            treeNode9.Text = "webapp1";
            treeNode10.Name = "Node0";
            treeNode10.Text = "webapp_2";
            treeNode11.Name = "Node0";
            treeNode11.Text = "WEBAPP_3";
            treeNode12.Name = "Node1";
            treeNode12.Text = "webapp3";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                    treeNode1,
                                    treeNode2,
                                    treeNode3,
                                    treeNode4,
                                    treeNode5,
                                    treeNode6,
                                    treeNode7,
                                    treeNode8,
                                    treeNode9,
                                    treeNode10,
                                    treeNode11,
                                    treeNode12});
            this.treeView1.Size = new System.Drawing.Size(464, 504);
            this.treeView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 18);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 552);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "MainForm";
            this.Text = "SortTreeView";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
    }
}

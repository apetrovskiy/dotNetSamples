/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2/5/2014
 * Time: 1:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace testCMenu
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lkjgftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu211ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu221ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu212ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.hToolStripMenuItem,
                                    this.jnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(85, 48);
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.jhToolStripMenuItem});
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.hToolStripMenuItem.Text = "h";
            // 
            // jhToolStripMenuItem
            // 
            this.jhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.lkjgftToolStripMenuItem});
            this.jhToolStripMenuItem.Name = "jhToolStripMenuItem";
            this.jhToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.jhToolStripMenuItem.Text = "jh";
            // 
            // lkjgftToolStripMenuItem
            // 
            this.lkjgftToolStripMenuItem.Name = "lkjgftToolStripMenuItem";
            this.lkjgftToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.lkjgftToolStripMenuItem.Text = "lkjgft";
            // 
            // jnToolStripMenuItem
            // 
            this.jnToolStripMenuItem.Name = "jnToolStripMenuItem";
            this.jnToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.jnToolStripMenuItem.Text = "jn";
            // 
            // panel1
            // 
            this.panel1.ContextMenuStrip = this.contextMenuStrip2;
            this.panel1.Location = new System.Drawing.Point(234, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 546);
            this.panel1.TabIndex = 1;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menu211ToolStripMenuItem,
                                    this.menu212ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(134, 48);
            // 
            // menu211ToolStripMenuItem
            // 
            this.menu211ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.menu221ToolStripMenuItem});
            this.menu211ToolStripMenuItem.Name = "menu211ToolStripMenuItem";
            this.menu211ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.menu211ToolStripMenuItem.Text = "Menu2-1-1";
            // 
            // menu221ToolStripMenuItem
            // 
            this.menu221ToolStripMenuItem.Name = "menu221ToolStripMenuItem";
            this.menu221ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.menu221ToolStripMenuItem.Text = "Menu2-2-1";
            // 
            // menu212ToolStripMenuItem
            // 
            this.menu212ToolStripMenuItem.Name = "menu212ToolStripMenuItem";
            this.menu212ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.menu212ToolStripMenuItem.Text = "Menu2-1-2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 550);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "testCMenu";
            this.Click += new System.EventHandler(this.MainFormClick);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripMenuItem menu212ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu221ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu211ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem jnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lkjgftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

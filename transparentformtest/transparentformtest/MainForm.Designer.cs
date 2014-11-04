using System.Windows.Forms;
/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 3/22/2013
 * Time: 6:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace transparentformtest
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = this.BackColor;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(800, 80);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Добавлена страница в 'new MO' wizard 'How to deploy SPCR package'";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 35);
            this.Controls.Add(this.lblMessage);
            this.Name = "MainForm";
            this.Opacity = 0.7D;
            //this.Opacity = 0.5D;
            //this.Opacity = 0.3D;
            this.TopMost = true;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Left = 100;
            this.Top = 100;
            this.Width = 800;
            this.Height = 80;
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblMessage;
    }
}

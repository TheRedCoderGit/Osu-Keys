using System;
using System.IO;
namespace Osu_Keys {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NoFocus = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tickTimer = new System.Windows.Forms.Timer(this.components);
            this.toggleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dontDrawBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoFocus
            // 
            this.NoFocus.AccessibleDescription = "NoFocus";
            this.NoFocus.AccessibleName = "NoFocus";
            this.NoFocus.AutoSize = true;
            this.NoFocus.BackColor = System.Drawing.Color.Transparent;
            this.NoFocus.Cursor = System.Windows.Forms.Cursors.Default;
            this.NoFocus.ForeColor = System.Drawing.Color.Fuchsia;
            this.NoFocus.Location = new System.Drawing.Point(12, 38);
            this.NoFocus.Name = "NoFocus";
            this.NoFocus.Size = new System.Drawing.Size(53, 13);
            this.NoFocus.TabIndex = 1;
            this.NoFocus.Text = "No Focus";
            this.NoFocus.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tickTimer
            // 
            this.tickTimer.Enabled = true;
            this.tickTimer.Interval = 8;
            this.tickTimer.Tick += new System.EventHandler(this.tickTimer_Tick);
            // 
            // toggleToolStripMenuItem
            // 
            this.toggleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeyToolStripMenuItem,
            this.removeKeyToolStripMenuItem,
            this.axisToolStripMenuItem,
            this.borderToolStripMenuItem});
            this.toggleToolStripMenuItem.Name = "toggleToolStripMenuItem";
            this.toggleToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.toggleToolStripMenuItem.Text = "Keys";
            // 
            // axisToolStripMenuItem
            // 
            this.axisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verticalToolStripMenuItem,
            this.horizontalToolStripMenuItem});
            this.axisToolStripMenuItem.Name = "axisToolStripMenuItem";
            this.axisToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.axisToolStripMenuItem.Text = "Axis";
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // borderToolStripMenuItem
            // 
            this.borderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawBorderToolStripMenuItem,
            this.dontDrawBorderToolStripMenuItem});
            this.borderToolStripMenuItem.Name = "borderToolStripMenuItem";
            this.borderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.borderToolStripMenuItem.Text = "Border";
            // 
            // drawBorderToolStripMenuItem
            // 
            this.drawBorderToolStripMenuItem.Name = "drawBorderToolStripMenuItem";
            this.drawBorderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.drawBorderToolStripMenuItem.Text = "Draw Border";
            this.drawBorderToolStripMenuItem.Click += new System.EventHandler(this.drawBorderToolStripMenuItem_Click);
            // 
            // dontDrawBorderToolStripMenuItem
            // 
            this.dontDrawBorderToolStripMenuItem.Name = "dontDrawBorderToolStripMenuItem";
            this.dontDrawBorderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.dontDrawBorderToolStripMenuItem.Text = "Don\'t Draw Border";
            this.dontDrawBorderToolStripMenuItem.Click += new System.EventHandler(this.dontDrawBorderToolStripMenuItem_Click);
            // 
            // addKeyToolStripMenuItem
            // 
            this.addKeyToolStripMenuItem.Name = "addKeyToolStripMenuItem";
            this.addKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addKeyToolStripMenuItem.Text = "Add Key";
            this.addKeyToolStripMenuItem.Click += new System.EventHandler(this.addButtonToolStripMenuItem_Click);
            // 
            // removeKeyToolStripMenuItem
            // 
            this.removeKeyToolStripMenuItem.Name = "removeKeyToolStripMenuItem";
            this.removeKeyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeKeyToolStripMenuItem.Text = "Remove Key";
            this.removeKeyToolStripMenuItem.Click += new System.EventHandler(this.removeButtonToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(370, 261);
            this.Controls.Add(this.NoFocus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu!Keys";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NoFocus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer tickTimer;
        private System.Windows.Forms.ToolStripMenuItem toggleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem axisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dontDrawBorderToolStripMenuItem;
    }
}


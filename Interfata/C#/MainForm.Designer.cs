﻿namespace Xsi0
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jocNouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.primulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.omToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxBoard = new System.Windows.Forms.PictureBox();
            this.jucatorTextBox = new System.Windows.Forms.TextBox();
            this.numericUpDown_depth = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_depth)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jocToolStripMenuItem,
            this.ajutorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(927, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jocToolStripMenuItem
            // 
            this.jocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jocNouToolStripMenuItem,
            this.iesireToolStripMenuItem,
            this.primulToolStripMenuItem});
            this.jocToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.jocToolStripMenuItem.Name = "jocToolStripMenuItem";
            this.jocToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.jocToolStripMenuItem.Text = "&Joc";
            // 
            // jocNouToolStripMenuItem
            // 
            this.jocNouToolStripMenuItem.Name = "jocNouToolStripMenuItem";
            this.jocNouToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.jocNouToolStripMenuItem.Text = "Joc &nou";
            this.jocNouToolStripMenuItem.Click += new System.EventHandler(this.jocNouToolStripMenuItem_Click);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.iesireToolStripMenuItem.Text = "&Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // primulToolStripMenuItem
            // 
            this.primulToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computerToolStripMenuItem,
            this.omToolStripMenuItem});
            this.primulToolStripMenuItem.Name = "primulToolStripMenuItem";
            this.primulToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.primulToolStripMenuItem.Text = "&Primul";
            // 
            // computerToolStripMenuItem
            // 
            this.computerToolStripMenuItem.Name = "computerToolStripMenuItem";
            this.computerToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.computerToolStripMenuItem.Text = "Computer";
            this.computerToolStripMenuItem.Click += new System.EventHandler(this.computerToolStripMenuItem_Click);
            // 
            // omToolStripMenuItem
            // 
            this.omToolStripMenuItem.Name = "omToolStripMenuItem";
            this.omToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.omToolStripMenuItem.Text = "Om";
            this.omToolStripMenuItem.Click += new System.EventHandler(this.omToolStripMenuItem_Click);
            // 
            // ajutorToolStripMenuItem
            // 
            this.ajutorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despreToolStripMenuItem});
            this.ajutorToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ajutorToolStripMenuItem.Name = "ajutorToolStripMenuItem";
            this.ajutorToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.ajutorToolStripMenuItem.Text = "&Ajutor";
            // 
            // despreToolStripMenuItem
            // 
            this.despreToolStripMenuItem.Name = "despreToolStripMenuItem";
            this.despreToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.despreToolStripMenuItem.Text = "&Despre...";
            this.despreToolStripMenuItem.Click += new System.EventHandler(this.despreToolStripMenuItem_Click);
            // 
            // pictureBoxBoard
            // 
            this.pictureBoxBoard.Location = new System.Drawing.Point(213, 63);
            this.pictureBoxBoard.Name = "pictureBoxBoard";
            this.pictureBoxBoard.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxBoard.TabIndex = 1;
            this.pictureBoxBoard.TabStop = false;
            this.pictureBoxBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxBoard_Paint);
            this.pictureBoxBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoard_MouseUp);
            // 
            // jucatorTextBox
            // 
            this.jucatorTextBox.Location = new System.Drawing.Point(12, 160);
            this.jucatorTextBox.Name = "jucatorTextBox";
            this.jucatorTextBox.ReadOnly = true;
            this.jucatorTextBox.Size = new System.Drawing.Size(127, 22);
            this.jucatorTextBox.TabIndex = 2;
            this.jucatorTextBox.TabStop = false;
            this.jucatorTextBox.Text = "Jucator: Computer";
            this.jucatorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_depth
            // 
            this.numericUpDown_depth.Location = new System.Drawing.Point(12, 356);
            this.numericUpDown_depth.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_depth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_depth.Name = "numericUpDown_depth";
            this.numericUpDown_depth.Size = new System.Drawing.Size(127, 22);
            this.numericUpDown_depth.TabIndex = 4;
            this.numericUpDown_depth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(927, 600);
            this.Controls.Add(this.numericUpDown_depth);
            this.Controls.Add(this.jucatorTextBox);
            this.Controls.Add(this.pictureBoxBoard);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "X si 0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_depth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem jocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jocNouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxBoard;
        private System.Windows.Forms.ToolStripMenuItem ajutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem primulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omToolStripMenuItem;
        private System.Windows.Forms.TextBox jucatorTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown_depth;
    }
}


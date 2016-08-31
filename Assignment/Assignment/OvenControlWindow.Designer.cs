﻿namespace Assignment
{
    partial class OvenControlWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OvenControlWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timerDial = new KnobControl.KnobControl();
            this.temperatureDial = new KnobControl.KnobControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Temperature:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "0 minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "0 Degrees";
            // 
            // timerDial
            // 
            this.timerDial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.timerDial.ImeMode = System.Windows.Forms.ImeMode.On;
            this.timerDial.LargeChange = 15;
            this.timerDial.Location = new System.Drawing.Point(15, 35);
            this.timerDial.Maximum = 120;
            this.timerDial.Minimum = 0;
            this.timerDial.Name = "timerDial";
            this.timerDial.ShowLargeScale = true;
            this.timerDial.ShowSmallScale = true;
            this.timerDial.Size = new System.Drawing.Size(124, 117);
            this.timerDial.SmallChange = 5;
            this.timerDial.TabIndex = 3;
            this.timerDial.Value = 0;
            this.timerDial.ValueChanged += new KnobControl.ValueChangedEventHandler(this.timerDial_ValueChanged);
            this.timerDial.Click += new System.EventHandler(this.timerDial_Click);
            // 
            // temperatureDial
            // 
            this.temperatureDial.BackColor = System.Drawing.SystemColors.Control;
            this.temperatureDial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.temperatureDial.ImeMode = System.Windows.Forms.ImeMode.On;
            this.temperatureDial.LargeChange = 50;
            this.temperatureDial.Location = new System.Drawing.Point(213, 35);
            this.temperatureDial.Maximum = 250;
            this.temperatureDial.Minimum = 0;
            this.temperatureDial.Name = "temperatureDial";
            this.temperatureDial.ShowLargeScale = true;
            this.temperatureDial.ShowSmallScale = true;
            this.temperatureDial.Size = new System.Drawing.Size(124, 117);
            this.temperatureDial.SmallChange = 25;
            this.temperatureDial.TabIndex = 2;
            this.temperatureDial.Value = 0;
            this.temperatureDial.ValueChanged += new KnobControl.ValueChangedEventHandler(this.temperatureDial_ValueChanged);
            this.temperatureDial.Click += new System.EventHandler(this.temperatureDial_Click);
            // 
            // OvenControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 154);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timerDial);
            this.Controls.Add(this.temperatureDial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OvenControlWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OvenControlWindow_FormClosing);
            this.Load += new System.EventHandler(this.OvenControlWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private KnobControl.KnobControl temperatureDial;
        private KnobControl.KnobControl timerDial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
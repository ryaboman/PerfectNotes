namespace RMPerfectNotes 
{
    partial class PerfectNotes
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
            this.DeviceList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.ViewerNote = new RMControls.ViewNotes.ViewerNote();
            this.ShowComposition = new System.Windows.Forms.Button();
            this.BtnWriteComposition = new System.Windows.Forms.Button();
            this.BtnCleat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeviceList
            // 
            this.DeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceList.FormattingEnabled = true;
            this.DeviceList.Location = new System.Drawing.Point(12, 34);
            this.DeviceList.Name = "DeviceList";
            this.DeviceList.Size = new System.Drawing.Size(151, 21);
            this.DeviceList.TabIndex = 4;
            this.DeviceList.SelectedIndexChanged += new System.EventHandler(this.DeviceList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Девайс";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(693, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(12, 61);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(1094, 474);
            this.elementHost1.TabIndex = 6;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.ViewerNote;
            // 
            // ShowComposition
            // 
            this.ShowComposition.Location = new System.Drawing.Point(494, 18);
            this.ShowComposition.Name = "ShowComposition";
            this.ShowComposition.Size = new System.Drawing.Size(106, 37);
            this.ShowComposition.TabIndex = 9;
            this.ShowComposition.Text = "ReadComposition";
            this.ShowComposition.UseVisualStyleBackColor = true;
            this.ShowComposition.Click += new System.EventHandler(this.ShowComposition_Click);
            // 
            // BtnWriteComposition
            // 
            this.BtnWriteComposition.Location = new System.Drawing.Point(183, 18);
            this.BtnWriteComposition.Name = "BtnWriteComposition";
            this.BtnWriteComposition.Size = new System.Drawing.Size(106, 37);
            this.BtnWriteComposition.TabIndex = 10;
            this.BtnWriteComposition.Text = "WriteComposition";
            this.BtnWriteComposition.UseVisualStyleBackColor = true;
            this.BtnWriteComposition.Click += new System.EventHandler(this.BtnWriteComposition_Click);
            // 
            // BtnCleat
            // 
            this.BtnCleat.Location = new System.Drawing.Point(344, 18);
            this.BtnCleat.Name = "BtnCleat";
            this.BtnCleat.Size = new System.Drawing.Size(75, 37);
            this.BtnCleat.TabIndex = 11;
            this.BtnCleat.Text = "Clear";
            this.BtnCleat.UseVisualStyleBackColor = true;
            this.BtnCleat.Click += new System.EventHandler(this.BtnCleat_Click);
            // 
            // PerfectNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 548);
            this.Controls.Add(this.BtnCleat);
            this.Controls.Add(this.BtnWriteComposition);
            this.Controls.Add(this.ShowComposition);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeviceList);
            this.MinimumSize = new System.Drawing.Size(242, 174);
            this.Name = "PerfectNotes";
            this.Text = "PerfectNotes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox DeviceList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ShowComposition;
        private System.Windows.Forms.Button BtnWriteComposition;
        private System.Windows.Forms.Button BtnCleat;
        private RMControls.ViewNotes.ViewerNote ViewerNote;
    }
}


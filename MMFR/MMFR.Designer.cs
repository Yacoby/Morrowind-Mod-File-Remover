namespace MMFR
{
    partial class frmMain
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
            this.btnDel = new System.Windows.Forms.Button();
            this.prgMain = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFilesDel = new System.Windows.Forms.TextBox();
            this.lblFilesProc = new System.Windows.Forms.TextBox();
            this.lblTotalFiles = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(123, 79);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "Delete Files";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // prgMain
            // 
            this.prgMain.Location = new System.Drawing.Point(12, 108);
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(267, 23);
            this.prgMain.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Files Processed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Files Deleted";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFilesDel);
            this.groupBox1.Controls.Add(this.lblFilesProc);
            this.groupBox1.Controls.Add(this.lblTotalFiles);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // lblFilesDel
            // 
            this.lblFilesDel.Location = new System.Drawing.Point(190, 38);
            this.lblFilesDel.Name = "lblFilesDel";
            this.lblFilesDel.ReadOnly = true;
            this.lblFilesDel.Size = new System.Drawing.Size(65, 20);
            this.lblFilesDel.TabIndex = 8;
            // 
            // lblFilesProc
            // 
            this.lblFilesProc.Location = new System.Drawing.Point(94, 38);
            this.lblFilesProc.Name = "lblFilesProc";
            this.lblFilesProc.ReadOnly = true;
            this.lblFilesProc.Size = new System.Drawing.Size(78, 20);
            this.lblFilesProc.TabIndex = 7;
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.Location = new System.Drawing.Point(7, 38);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.ReadOnly = true;
            this.lblTotalFiles.Size = new System.Drawing.Size(77, 20);
            this.lblTotalFiles.TabIndex = 6;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(204, 79);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Cancel";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(291, 139);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.prgMain);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Morrowind Mod File Remover";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ProgressBar prgMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox lblFilesDel;
        private System.Windows.Forms.TextBox lblFilesProc;
        private System.Windows.Forms.TextBox lblTotalFiles;
    }
}


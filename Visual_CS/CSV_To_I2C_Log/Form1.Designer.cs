namespace CSV_To_I2C_Log
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnConvert = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ChkTimestamp = new System.Windows.Forms.CheckBox();
            this.LblSCL = new System.Windows.Forms.Label();
            this.Rbtn250 = new System.Windows.Forms.RadioButton();
            this.GrpSamplingRate = new System.Windows.Forms.GroupBox();
            this.Rbtn1000 = new System.Windows.Forms.RadioButton();
            this.Rbtn500 = new System.Windows.Forms.RadioButton();
            this.NumSCL = new System.Windows.Forms.NumericUpDown();
            this.LblSDA = new System.Windows.Forms.Label();
            this.LblColumn = new System.Windows.Forms.Label();
            this.NumSDA = new System.Windows.Forms.NumericUpDown();
            this.LblDelimiter = new System.Windows.Forms.Label();
            this.TxtDelimiter = new System.Windows.Forms.TextBox();
            this.PbarConvert = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GrpSamplingRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumSCL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSDA)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnConvert
            // 
            this.BtnConvert.Location = new System.Drawing.Point(122, 81);
            this.BtnConvert.Name = "BtnConvert";
            this.BtnConvert.Size = new System.Drawing.Size(57, 40);
            this.BtnConvert.TabIndex = 0;
            this.BtnConvert.Text = "Convert";
            this.BtnConvert.UseVisualStyleBackColor = true;
            this.BtnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Enabled = false;
            this.BtnCancel.Location = new System.Drawing.Point(122, 127);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(57, 40);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // ChkTimestamp
            // 
            this.ChkTimestamp.AutoSize = true;
            this.ChkTimestamp.Checked = true;
            this.ChkTimestamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkTimestamp.Location = new System.Drawing.Point(12, 51);
            this.ChkTimestamp.Name = "ChkTimestamp";
            this.ChkTimestamp.Size = new System.Drawing.Size(77, 17);
            this.ChkTimestamp.TabIndex = 2;
            this.ChkTimestamp.Text = "Timestamp";
            this.ChkTimestamp.UseVisualStyleBackColor = true;
            this.ChkTimestamp.CheckedChanged += new System.EventHandler(this.ChkTimestamp_CheckedChanged);
            // 
            // LblSCL
            // 
            this.LblSCL.AutoSize = true;
            this.LblSCL.Location = new System.Drawing.Point(65, 9);
            this.LblSCL.Name = "LblSCL";
            this.LblSCL.Size = new System.Drawing.Size(27, 13);
            this.LblSCL.TabIndex = 3;
            this.LblSCL.Text = "SCL";
            // 
            // Rbtn250
            // 
            this.Rbtn250.AutoSize = true;
            this.Rbtn250.Checked = true;
            this.Rbtn250.Location = new System.Drawing.Point(6, 19);
            this.Rbtn250.Name = "Rbtn250";
            this.Rbtn250.Size = new System.Drawing.Size(63, 17);
            this.Rbtn250.TabIndex = 4;
            this.Rbtn250.TabStop = true;
            this.Rbtn250.Text = "250KHz";
            this.Rbtn250.UseVisualStyleBackColor = true;
            // 
            // GrpSamplingRate
            // 
            this.GrpSamplingRate.Controls.Add(this.Rbtn1000);
            this.GrpSamplingRate.Controls.Add(this.Rbtn500);
            this.GrpSamplingRate.Controls.Add(this.Rbtn250);
            this.GrpSamplingRate.Location = new System.Drawing.Point(12, 74);
            this.GrpSamplingRate.Name = "GrpSamplingRate";
            this.GrpSamplingRate.Size = new System.Drawing.Size(104, 93);
            this.GrpSamplingRate.TabIndex = 5;
            this.GrpSamplingRate.TabStop = false;
            this.GrpSamplingRate.Text = "Sampling Rate";
            // 
            // Rbtn1000
            // 
            this.Rbtn1000.AutoSize = true;
            this.Rbtn1000.Location = new System.Drawing.Point(6, 65);
            this.Rbtn1000.Name = "Rbtn1000";
            this.Rbtn1000.Size = new System.Drawing.Size(53, 17);
            this.Rbtn1000.TabIndex = 6;
            this.Rbtn1000.Text = "1MHz";
            this.Rbtn1000.UseVisualStyleBackColor = true;
            // 
            // Rbtn500
            // 
            this.Rbtn500.AutoSize = true;
            this.Rbtn500.Location = new System.Drawing.Point(6, 42);
            this.Rbtn500.Name = "Rbtn500";
            this.Rbtn500.Size = new System.Drawing.Size(63, 17);
            this.Rbtn500.TabIndex = 5;
            this.Rbtn500.Text = "500KHz";
            this.Rbtn500.UseVisualStyleBackColor = true;
            // 
            // NumSCL
            // 
            this.NumSCL.Location = new System.Drawing.Point(68, 25);
            this.NumSCL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSCL.Name = "NumSCL";
            this.NumSCL.Size = new System.Drawing.Size(50, 20);
            this.NumSCL.TabIndex = 6;
            this.NumSCL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblSDA
            // 
            this.LblSDA.AutoSize = true;
            this.LblSDA.Location = new System.Drawing.Point(126, 9);
            this.LblSDA.Name = "LblSDA";
            this.LblSDA.Size = new System.Drawing.Size(29, 13);
            this.LblSDA.TabIndex = 7;
            this.LblSDA.Text = "SDA";
            // 
            // LblColumn
            // 
            this.LblColumn.AutoSize = true;
            this.LblColumn.Location = new System.Drawing.Point(17, 27);
            this.LblColumn.Name = "LblColumn";
            this.LblColumn.Size = new System.Drawing.Size(45, 13);
            this.LblColumn.TabIndex = 8;
            this.LblColumn.Text = "Column:";
            // 
            // NumSDA
            // 
            this.NumSDA.Location = new System.Drawing.Point(129, 25);
            this.NumSDA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumSDA.Name = "NumSDA";
            this.NumSDA.Size = new System.Drawing.Size(50, 20);
            this.NumSDA.TabIndex = 9;
            this.NumSDA.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LblDelimiter
            // 
            this.LblDelimiter.AutoSize = true;
            this.LblDelimiter.Location = new System.Drawing.Point(95, 52);
            this.LblDelimiter.Name = "LblDelimiter";
            this.LblDelimiter.Size = new System.Drawing.Size(50, 13);
            this.LblDelimiter.TabIndex = 10;
            this.LblDelimiter.Text = "Delimiter:";
            // 
            // TxtDelimiter
            // 
            this.TxtDelimiter.Location = new System.Drawing.Point(151, 49);
            this.TxtDelimiter.MaxLength = 1;
            this.TxtDelimiter.Name = "TxtDelimiter";
            this.TxtDelimiter.Size = new System.Drawing.Size(28, 20);
            this.TxtDelimiter.TabIndex = 11;
            this.TxtDelimiter.Text = ",";
            // 
            // PbarConvert
            // 
            this.PbarConvert.Location = new System.Drawing.Point(12, 173);
            this.PbarConvert.Name = "PbarConvert";
            this.PbarConvert.Size = new System.Drawing.Size(167, 23);
            this.PbarConvert.TabIndex = 12;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 206);
            this.Controls.Add(this.PbarConvert);
            this.Controls.Add(this.TxtDelimiter);
            this.Controls.Add(this.LblDelimiter);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.NumSDA);
            this.Controls.Add(this.LblColumn);
            this.Controls.Add(this.LblSDA);
            this.Controls.Add(this.NumSCL);
            this.Controls.Add(this.GrpSamplingRate);
            this.Controls.Add(this.LblSCL);
            this.Controls.Add(this.ChkTimestamp);
            this.Controls.Add(this.BtnConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CSV To I2C Log Converter";
            this.GrpSamplingRate.ResumeLayout(false);
            this.GrpSamplingRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumSCL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSDA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConvert;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.CheckBox ChkTimestamp;
        private System.Windows.Forms.Label LblSCL;
        private System.Windows.Forms.RadioButton Rbtn250;
        private System.Windows.Forms.GroupBox GrpSamplingRate;
        private System.Windows.Forms.RadioButton Rbtn1000;
        private System.Windows.Forms.RadioButton Rbtn500;
        private System.Windows.Forms.Label LblSDA;
        private System.Windows.Forms.Label LblColumn;
        private System.Windows.Forms.NumericUpDown NumSDA;
        private System.Windows.Forms.Label LblDelimiter;
        private System.Windows.Forms.TextBox TxtDelimiter;
        private System.Windows.Forms.NumericUpDown NumSCL;
        private System.Windows.Forms.ProgressBar PbarConvert;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}


namespace FS.Tool
{
    partial class Tools
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
            this.tabMessageCreate = new System.Windows.Forms.TabPage();
            this.gpOperation = new System.Windows.Forms.GroupBox();
            this.btnCreate503L = new System.Windows.Forms.Button();
            this.btnCreate503R = new System.Windows.Forms.Button();
            this.btnCreate501 = new System.Windows.Forms.Button();
            this.tboxOrderNoFake = new System.Windows.Forms.TextBox();
            this.labOrderNoFake = new System.Windows.Forms.Label();
            this.btnCreate601 = new System.Windows.Forms.Button();
            this.btnCreate301 = new System.Windows.Forms.Button();
            this.tboxLogisticsNo = new System.Windows.Forms.TextBox();
            this.tboxOrderNo = new System.Windows.Forms.TextBox();
            this.labLogisticsNo = new System.Windows.Forms.Label();
            this.labOrderNo = new System.Windows.Forms.Label();
            this.gpRequestUrl = new System.Windows.Forms.GroupBox();
            this.tboxRequestUrl = new System.Windows.Forms.TextBox();
            this.labRequestUrl = new System.Windows.Forms.Label();
            this.tabImportFile = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gpFolderPath = new System.Windows.Forms.GroupBox();
            this.labFolder = new System.Windows.Forms.Label();
            this.tboxFolder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabMessageCreate.SuspendLayout();
            this.gpOperation.SuspendLayout();
            this.gpRequestUrl.SuspendLayout();
            this.tabImportFile.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gpFolderPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMessageCreate
            // 
            this.tabMessageCreate.Controls.Add(this.gpOperation);
            this.tabMessageCreate.Controls.Add(this.gpRequestUrl);
            this.tabMessageCreate.Location = new System.Drawing.Point(4, 22);
            this.tabMessageCreate.Name = "tabMessageCreate";
            this.tabMessageCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessageCreate.Size = new System.Drawing.Size(490, 293);
            this.tabMessageCreate.TabIndex = 0;
            this.tabMessageCreate.Text = "Create Messages ";
            this.tabMessageCreate.UseVisualStyleBackColor = true;
            // 
            // gpOperation
            // 
            this.gpOperation.Controls.Add(this.btnCreate503L);
            this.gpOperation.Controls.Add(this.btnCreate503R);
            this.gpOperation.Controls.Add(this.btnCreate501);
            this.gpOperation.Controls.Add(this.tboxOrderNoFake);
            this.gpOperation.Controls.Add(this.labOrderNoFake);
            this.gpOperation.Controls.Add(this.btnCreate601);
            this.gpOperation.Controls.Add(this.btnCreate301);
            this.gpOperation.Controls.Add(this.tboxLogisticsNo);
            this.gpOperation.Controls.Add(this.tboxOrderNo);
            this.gpOperation.Controls.Add(this.labLogisticsNo);
            this.gpOperation.Controls.Add(this.labOrderNo);
            this.gpOperation.Location = new System.Drawing.Point(17, 102);
            this.gpOperation.Name = "gpOperation";
            this.gpOperation.Size = new System.Drawing.Size(454, 179);
            this.gpOperation.TabIndex = 1;
            this.gpOperation.TabStop = false;
            this.gpOperation.Text = "Operation";
            // 
            // btnCreate503L
            // 
            this.btnCreate503L.Enabled = false;
            this.btnCreate503L.Location = new System.Drawing.Point(359, 137);
            this.btnCreate503L.Name = "btnCreate503L";
            this.btnCreate503L.Size = new System.Drawing.Size(75, 20);
            this.btnCreate503L.TabIndex = 10;
            this.btnCreate503L.Text = "Create503L";
            this.btnCreate503L.UseVisualStyleBackColor = true;
            this.btnCreate503L.Click += new System.EventHandler(this.btnCreate503L_Click);
            // 
            // btnCreate503R
            // 
            this.btnCreate503R.Enabled = false;
            this.btnCreate503R.Location = new System.Drawing.Point(250, 137);
            this.btnCreate503R.Name = "btnCreate503R";
            this.btnCreate503R.Size = new System.Drawing.Size(75, 20);
            this.btnCreate503R.TabIndex = 9;
            this.btnCreate503R.Text = "Create503R";
            this.btnCreate503R.UseVisualStyleBackColor = true;
            this.btnCreate503R.Click += new System.EventHandler(this.btnCreate503R_Click);
            // 
            // btnCreate501
            // 
            this.btnCreate501.Enabled = false;
            this.btnCreate501.Location = new System.Drawing.Point(359, 67);
            this.btnCreate501.Name = "btnCreate501";
            this.btnCreate501.Size = new System.Drawing.Size(75, 20);
            this.btnCreate501.TabIndex = 8;
            this.btnCreate501.Text = "Create501";
            this.btnCreate501.UseVisualStyleBackColor = true;
            this.btnCreate501.Click += new System.EventHandler(this.btnCreate501_Click);
            // 
            // tboxOrderNoFake
            // 
            this.tboxOrderNoFake.Location = new System.Drawing.Point(108, 67);
            this.tboxOrderNoFake.Name = "tboxOrderNoFake";
            this.tboxOrderNoFake.Size = new System.Drawing.Size(217, 20);
            this.tboxOrderNoFake.TabIndex = 7;
            // 
            // labOrderNoFake
            // 
            this.labOrderNoFake.AutoSize = true;
            this.labOrderNoFake.Location = new System.Drawing.Point(20, 70);
            this.labOrderNoFake.Name = "labOrderNoFake";
            this.labOrderNoFake.Size = new System.Drawing.Size(77, 13);
            this.labOrderNoFake.TabIndex = 6;
            this.labOrderNoFake.Text = "OrderNoFake :";
            // 
            // btnCreate601
            // 
            this.btnCreate601.Enabled = false;
            this.btnCreate601.Location = new System.Drawing.Point(359, 102);
            this.btnCreate601.Name = "btnCreate601";
            this.btnCreate601.Size = new System.Drawing.Size(75, 20);
            this.btnCreate601.TabIndex = 5;
            this.btnCreate601.Text = "Create601";
            this.btnCreate601.UseVisualStyleBackColor = true;
            this.btnCreate601.Click += new System.EventHandler(this.btnCreate601_Click);
            // 
            // btnCreate301
            // 
            this.btnCreate301.Location = new System.Drawing.Point(359, 32);
            this.btnCreate301.Name = "btnCreate301";
            this.btnCreate301.Size = new System.Drawing.Size(75, 20);
            this.btnCreate301.TabIndex = 4;
            this.btnCreate301.Text = "Create301";
            this.btnCreate301.UseVisualStyleBackColor = true;
            this.btnCreate301.Click += new System.EventHandler(this.btnCreate301_Click);
            // 
            // tboxLogisticsNo
            // 
            this.tboxLogisticsNo.Location = new System.Drawing.Point(108, 102);
            this.tboxLogisticsNo.Name = "tboxLogisticsNo";
            this.tboxLogisticsNo.Size = new System.Drawing.Size(217, 20);
            this.tboxLogisticsNo.TabIndex = 3;
            // 
            // tboxOrderNo
            // 
            this.tboxOrderNo.Location = new System.Drawing.Point(108, 32);
            this.tboxOrderNo.Name = "tboxOrderNo";
            this.tboxOrderNo.Size = new System.Drawing.Size(217, 20);
            this.tboxOrderNo.TabIndex = 2;
            // 
            // labLogisticsNo
            // 
            this.labLogisticsNo.AutoSize = true;
            this.labLogisticsNo.Location = new System.Drawing.Point(20, 105);
            this.labLogisticsNo.Name = "labLogisticsNo";
            this.labLogisticsNo.Size = new System.Drawing.Size(68, 13);
            this.labLogisticsNo.TabIndex = 1;
            this.labLogisticsNo.Text = "LogisticsNo :";
            // 
            // labOrderNo
            // 
            this.labOrderNo.AutoSize = true;
            this.labOrderNo.Location = new System.Drawing.Point(20, 35);
            this.labOrderNo.Name = "labOrderNo";
            this.labOrderNo.Size = new System.Drawing.Size(53, 13);
            this.labOrderNo.TabIndex = 0;
            this.labOrderNo.Text = "OrderNo :";
            // 
            // gpRequestUrl
            // 
            this.gpRequestUrl.Controls.Add(this.tboxRequestUrl);
            this.gpRequestUrl.Controls.Add(this.labRequestUrl);
            this.gpRequestUrl.Location = new System.Drawing.Point(17, 16);
            this.gpRequestUrl.Name = "gpRequestUrl";
            this.gpRequestUrl.Size = new System.Drawing.Size(454, 66);
            this.gpRequestUrl.TabIndex = 0;
            this.gpRequestUrl.TabStop = false;
            this.gpRequestUrl.Text = "Request Url";
            // 
            // tboxRequestUrl
            // 
            this.tboxRequestUrl.Location = new System.Drawing.Point(92, 26);
            this.tboxRequestUrl.Name = "tboxRequestUrl";
            this.tboxRequestUrl.Size = new System.Drawing.Size(342, 20);
            this.tboxRequestUrl.TabIndex = 1;
            // 
            // labRequestUrl
            // 
            this.labRequestUrl.AutoSize = true;
            this.labRequestUrl.Location = new System.Drawing.Point(17, 29);
            this.labRequestUrl.Name = "labRequestUrl";
            this.labRequestUrl.Size = new System.Drawing.Size(69, 13);
            this.labRequestUrl.TabIndex = 0;
            this.labRequestUrl.Text = "Request Url :";
            // 
            // tabImportFile
            // 
            this.tabImportFile.Controls.Add(this.tabMessageCreate);
            this.tabImportFile.Controls.Add(this.tabPage1);
            this.tabImportFile.Location = new System.Drawing.Point(12, 12);
            this.tabImportFile.Name = "tabImportFile";
            this.tabImportFile.SelectedIndex = 0;
            this.tabImportFile.Size = new System.Drawing.Size(498, 319);
            this.tabImportFile.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.gpFolderPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(490, 293);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Import File";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gpFolderPath
            // 
            this.gpFolderPath.Controls.Add(this.tboxFolder);
            this.gpFolderPath.Controls.Add(this.labFolder);
            this.gpFolderPath.Location = new System.Drawing.Point(12, 12);
            this.gpFolderPath.Name = "gpFolderPath";
            this.gpFolderPath.Size = new System.Drawing.Size(463, 67);
            this.gpFolderPath.TabIndex = 0;
            this.gpFolderPath.TabStop = false;
            this.gpFolderPath.Text = "Folder Path";
            // 
            // labFolder
            // 
            this.labFolder.AutoSize = true;
            this.labFolder.Location = new System.Drawing.Point(18, 28);
            this.labFolder.Name = "labFolder";
            this.labFolder.Size = new System.Drawing.Size(64, 13);
            this.labFolder.TabIndex = 0;
            this.labFolder.Text = "Folder Path:";
            // 
            // tboxFolder
            // 
            this.tboxFolder.Location = new System.Drawing.Point(100, 25);
            this.tboxFolder.Name = "tboxFolder";
            this.tboxFolder.Size = new System.Drawing.Size(215, 20);
            this.tboxFolder.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 343);
            this.Controls.Add(this.tabImportFile);
            this.Name = "Tools";
            this.Text = "Tools";
            this.tabMessageCreate.ResumeLayout(false);
            this.gpOperation.ResumeLayout(false);
            this.gpOperation.PerformLayout();
            this.gpRequestUrl.ResumeLayout(false);
            this.gpRequestUrl.PerformLayout();
            this.tabImportFile.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gpFolderPath.ResumeLayout(false);
            this.gpFolderPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabMessageCreate;
        private System.Windows.Forms.GroupBox gpRequestUrl;
        private System.Windows.Forms.TabControl tabImportFile;
        private System.Windows.Forms.Label labRequestUrl;
        private System.Windows.Forms.TextBox tboxRequestUrl;
        private System.Windows.Forms.GroupBox gpOperation;
        private System.Windows.Forms.Label labLogisticsNo;
        private System.Windows.Forms.Label labOrderNo;
        private System.Windows.Forms.Button btnCreate601;
        private System.Windows.Forms.Button btnCreate301;
        private System.Windows.Forms.TextBox tboxLogisticsNo;
        private System.Windows.Forms.TextBox tboxOrderNo;
        private System.Windows.Forms.TextBox tboxOrderNoFake;
        private System.Windows.Forms.Label labOrderNoFake;
        private System.Windows.Forms.Button btnCreate501;
        private System.Windows.Forms.Button btnCreate503R;
        private System.Windows.Forms.Button btnCreate503L;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gpFolderPath;
        private System.Windows.Forms.Label labFolder;
        private System.Windows.Forms.TextBox tboxFolder;
        private System.Windows.Forms.Button button1;
    }
}


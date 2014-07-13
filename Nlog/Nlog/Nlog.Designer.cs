namespace Nlog
{
    partial class Nlog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.cbxFileList = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStuff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportView = new System.Windows.Forms.Button();
            this.lbController = new System.Windows.Forms.ListBox();
            this.lbItemText = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(25, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(100, 21);
            this.txtFolder.TabIndex = 2;
            // 
            // cbxFileList
            // 
            this.cbxFileList.FormattingEnabled = true;
            this.cbxFileList.Location = new System.Drawing.Point(132, 12);
            this.cbxFileList.Name = "cbxFileList";
            this.cbxFileList.Size = new System.Drawing.Size(382, 20);
            this.cbxFileList.TabIndex = 3;
            this.cbxFileList.Enter += new System.EventHandler(this.cbxFileList_Enter);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(677, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 42);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStuff
            // 
            this.btnStuff.Location = new System.Drawing.Point(520, 38);
            this.btnStuff.Name = "btnStuff";
            this.btnStuff.Size = new System.Drawing.Size(75, 23);
            this.btnStuff.TabIndex = 5;
            this.btnStuff.Text = "Stuff";
            this.btnStuff.UseVisualStyleBackColor = true;
            this.btnStuff.Click += new System.EventHandler(this.btnStuff_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Item\'s txt";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(677, 67);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(542, 498);
            this.dgvList.TabIndex = 12;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1144, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 42);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportView
            // 
            this.btnExportView.Location = new System.Drawing.Point(1054, 19);
            this.btnExportView.Name = "btnExportView";
            this.btnExportView.Size = new System.Drawing.Size(75, 42);
            this.btnExportView.TabIndex = 14;
            this.btnExportView.Text = "ExportView";
            this.btnExportView.UseVisualStyleBackColor = true;
            this.btnExportView.Click += new System.EventHandler(this.btnExportView_Click);
            // 
            // lbController
            // 
            this.lbController.FormattingEnabled = true;
            this.lbController.ItemHeight = 12;
            this.lbController.Location = new System.Drawing.Point(131, 38);
            this.lbController.Name = "lbController";
            this.lbController.ScrollAlwaysVisible = true;
            this.lbController.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbController.Size = new System.Drawing.Size(383, 244);
            this.lbController.Sorted = true;
            this.lbController.TabIndex = 15;
            // 
            // lbItemText
            // 
            this.lbItemText.FormattingEnabled = true;
            this.lbItemText.ItemHeight = 12;
            this.lbItemText.Location = new System.Drawing.Point(132, 309);
            this.lbItemText.Name = "lbItemText";
            this.lbItemText.ScrollAlwaysVisible = true;
            this.lbItemText.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbItemText.Size = new System.Drawing.Size(382, 256);
            this.lbItemText.Sorted = true;
            this.lbItemText.TabIndex = 16;
            // 
            // Nlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 605);
            this.Controls.Add(this.lbItemText);
            this.Controls.Add(this.lbController);
            this.Controls.Add(this.btnExportView);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStuff);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbxFileList);
            this.Controls.Add(this.txtFolder);
            this.Name = "Nlog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nlog";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.ComboBox cbxFileList;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStuff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportView;
        private System.Windows.Forms.ListBox lbController;
        private System.Windows.Forms.ListBox lbItemText;
    }
}


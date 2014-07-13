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
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbxController = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxItemsTxt = new System.Windows.Forms.ComboBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
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
            this.cbxFileList.Size = new System.Drawing.Size(474, 20);
            this.cbxFileList.TabIndex = 3;
            this.cbxFileList.Enter += new System.EventHandler(this.cbxFileList_Enter);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(920, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 42);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(612, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "填充";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbxController
            // 
            this.cbxController.FormattingEnabled = true;
            this.cbxController.Location = new System.Drawing.Point(132, 54);
            this.cbxController.Name = "cbxController";
            this.cbxController.Size = new System.Drawing.Size(457, 20);
            this.cbxController.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Item\'s txt";
            // 
            // cbxItemsTxt
            // 
            this.cbxItemsTxt.FormattingEnabled = true;
            this.cbxItemsTxt.Location = new System.Drawing.Point(132, 99);
            this.cbxItemsTxt.Name = "cbxItemsTxt";
            this.cbxItemsTxt.Size = new System.Drawing.Size(457, 20);
            this.cbxItemsTxt.TabIndex = 10;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 135);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(1020, 350);
            this.dgvList.TabIndex = 12;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(920, 87);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 42);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Nlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 497);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxItemsTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxController);
            this.Controls.Add(this.btnAdd);
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbxController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxItemsTxt;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnExport;
    }
}


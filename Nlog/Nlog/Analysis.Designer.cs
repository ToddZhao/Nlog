namespace Nlog
{
    partial class Analysis
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
            this.dgNLog = new System.Windows.Forms.DataGridView();
            this.dtPicket = new System.Windows.Forms.DateTimePicker();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgCheckChange = new System.Windows.Forms.DataGridView();
            this.btnLoadCheckChange = new System.Windows.Forms.Button();
            this.dtPicketEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnLoadAllCheckChange = new System.Windows.Forms.Button();
            this.btnAnalysis = new System.Windows.Forms.Button();
            this.btnAbacus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgNLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckChange)).BeginInit();
            this.SuspendLayout();
            // 
            // dgNLog
            // 
            this.dgNLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNLog.Location = new System.Drawing.Point(12, 56);
            this.dgNLog.Name = "dgNLog";
            this.dgNLog.RowTemplate.Height = 23;
            this.dgNLog.Size = new System.Drawing.Size(623, 596);
            this.dgNLog.TabIndex = 0;
            // 
            // dtPicket
            // 
            this.dtPicket.Location = new System.Drawing.Point(22, 12);
            this.dtPicket.Name = "dtPicket";
            this.dtPicket.Size = new System.Drawing.Size(106, 21);
            this.dtPicket.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(560, 13);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgCheckChange
            // 
            this.dgCheckChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCheckChange.Location = new System.Drawing.Point(661, 56);
            this.dgCheckChange.Name = "dgCheckChange";
            this.dgCheckChange.RowTemplate.Height = 23;
            this.dgCheckChange.Size = new System.Drawing.Size(623, 596);
            this.dgCheckChange.TabIndex = 3;
            // 
            // btnLoadCheckChange
            // 
            this.btnLoadCheckChange.Location = new System.Drawing.Point(661, 13);
            this.btnLoadCheckChange.Name = "btnLoadCheckChange";
            this.btnLoadCheckChange.Size = new System.Drawing.Size(112, 23);
            this.btnLoadCheckChange.TabIndex = 4;
            this.btnLoadCheckChange.Text = "LoadCheckChange";
            this.btnLoadCheckChange.UseVisualStyleBackColor = true;
            this.btnLoadCheckChange.Click += new System.EventHandler(this.btnLoadCheckChange_Click);
            // 
            // dtPicketEndDate
            // 
            this.dtPicketEndDate.Location = new System.Drawing.Point(173, 13);
            this.dtPicketEndDate.Name = "dtPicketEndDate";
            this.dtPicketEndDate.Size = new System.Drawing.Size(106, 21);
            this.dtPicketEndDate.TabIndex = 5;
            // 
            // btnLoadAllCheckChange
            // 
            this.btnLoadAllCheckChange.Location = new System.Drawing.Point(883, 14);
            this.btnLoadAllCheckChange.Name = "btnLoadAllCheckChange";
            this.btnLoadAllCheckChange.Size = new System.Drawing.Size(147, 23);
            this.btnLoadAllCheckChange.TabIndex = 6;
            this.btnLoadAllCheckChange.Text = "LoadAllCheckChange";
            this.btnLoadAllCheckChange.UseVisualStyleBackColor = true;
            this.btnLoadAllCheckChange.Click += new System.EventHandler(this.btnLoadAllCheckChange_Click);
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.Location = new System.Drawing.Point(1066, 14);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(96, 23);
            this.btnAnalysis.TabIndex = 7;
            this.btnAnalysis.Text = "Analysis";
            this.btnAnalysis.UseVisualStyleBackColor = true;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnAbacus
            // 
            this.btnAbacus.Location = new System.Drawing.Point(1188, 14);
            this.btnAbacus.Name = "btnAbacus";
            this.btnAbacus.Size = new System.Drawing.Size(96, 23);
            this.btnAbacus.TabIndex = 8;
            this.btnAbacus.Text = "AnalysisAbacus";
            this.btnAbacus.UseVisualStyleBackColor = true;
            this.btnAbacus.Click += new System.EventHandler(this.btnAbacus_Click);
            // 
            // Analysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 654);
            this.Controls.Add(this.btnAbacus);
            this.Controls.Add(this.btnAnalysis);
            this.Controls.Add(this.btnLoadAllCheckChange);
            this.Controls.Add(this.dtPicketEndDate);
            this.Controls.Add(this.btnLoadCheckChange);
            this.Controls.Add(this.dgCheckChange);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.dtPicket);
            this.Controls.Add(this.dgNLog);
            this.Name = "Analysis";
            this.Text = "Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.dgNLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheckChange)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNLog;
        private System.Windows.Forms.DateTimePicker dtPicket;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgCheckChange;
        private System.Windows.Forms.Button btnLoadCheckChange;
        private System.Windows.Forms.DateTimePicker dtPicketEndDate;
        private System.Windows.Forms.Button btnLoadAllCheckChange;
        private System.Windows.Forms.Button btnAnalysis;
        private System.Windows.Forms.Button btnAbacus;
    }
}
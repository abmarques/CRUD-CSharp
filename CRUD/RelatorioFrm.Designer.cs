namespace CRUD {
    partial class RelatorioFrm {
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtgFunc = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtgFunc
            // 
            this.dtgFunc.AllowUserToDeleteRows = false;
            this.dtgFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFunc.Location = new System.Drawing.Point(12, 80);
            this.dtgFunc.Name = "dtgFunc";
            this.dtgFunc.ReadOnly = true;
            this.dtgFunc.Size = new System.Drawing.Size(644, 284);
            this.dtgFunc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RELATÓRIO DOS FUNCIONÁRIOS";
            // 
            // RelatorioFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgFunc);
            this.Name = "RelatorioFrm";
            this.Text = "RelatorioFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dtgFunc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridView dtgFunc;
        private System.Windows.Forms.Label label1;
    }
}
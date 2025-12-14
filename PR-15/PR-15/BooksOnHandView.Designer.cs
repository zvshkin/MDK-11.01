namespace PR_15
{
    partial class BooksOnHandView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblSumFine = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblMinFine = new System.Windows.Forms.Label();
            this.lblAvgFine = new System.Windows.Forms.Label();
            this.lblMaxFine = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 474);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 27);
            this.lblCount.TabIndex = 0;
            // 
            // lblSumFine
            // 
            this.lblSumFine.AutoSize = true;
            this.lblSumFine.Location = new System.Drawing.Point(12, 524);
            this.lblSumFine.Name = "lblSumFine";
            this.lblSumFine.Size = new System.Drawing.Size(0, 27);
            this.lblSumFine.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.ColumnHeadersHeight = 36;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.RowTemplate.Height = 36;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1733, 450);
            this.dgvData.TabIndex = 2;
            // 
            // lblMinFine
            // 
            this.lblMinFine.AutoSize = true;
            this.lblMinFine.Location = new System.Drawing.Point(12, 624);
            this.lblMinFine.Name = "lblMinFine";
            this.lblMinFine.Size = new System.Drawing.Size(0, 27);
            this.lblMinFine.TabIndex = 4;
            // 
            // lblAvgFine
            // 
            this.lblAvgFine.AutoSize = true;
            this.lblAvgFine.Location = new System.Drawing.Point(12, 574);
            this.lblAvgFine.Name = "lblAvgFine";
            this.lblAvgFine.Size = new System.Drawing.Size(0, 27);
            this.lblAvgFine.TabIndex = 3;
            // 
            // lblMaxFine
            // 
            this.lblMaxFine.AutoSize = true;
            this.lblMaxFine.Location = new System.Drawing.Point(12, 674);
            this.lblMaxFine.Name = "lblMaxFine";
            this.lblMaxFine.Size = new System.Drawing.Size(0, 27);
            this.lblMaxFine.TabIndex = 5;
            // 
            // BooksOnHandView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 741);
            this.Controls.Add(this.lblMaxFine);
            this.Controls.Add(this.lblMinFine);
            this.Controls.Add(this.lblAvgFine);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lblSumFine);
            this.Controls.Add(this.lblCount);
            this.Font = new System.Drawing.Font("Times New Roman", 18F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BooksOnHandView";
            this.Text = "BooksOnHandView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblSumFine;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblMinFine;
        private System.Windows.Forms.Label lblAvgFine;
        private System.Windows.Forms.Label lblMaxFine;
    }
}
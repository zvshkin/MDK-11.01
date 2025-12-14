namespace PR_15
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnReaders = new System.Windows.Forms.Button();
            this.btnLoans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(677, 123);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выберите необходимую для вас форму:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBooks
            // 
            this.btnBooks.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBooks.Location = new System.Drawing.Point(12, 338);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(653, 100);
            this.btnBooks.TabIndex = 6;
            this.btnBooks.Text = "Просмотр книг";
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnReaders
            // 
            this.btnReaders.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReaders.Location = new System.Drawing.Point(12, 232);
            this.btnReaders.Name = "btnReaders";
            this.btnReaders.Size = new System.Drawing.Size(653, 100);
            this.btnReaders.TabIndex = 5;
            this.btnReaders.Text = "Просмотр читателей";
            this.btnReaders.UseVisualStyleBackColor = true;
            this.btnReaders.Click += new System.EventHandler(this.btnReaders_Click);
            // 
            // btnLoans
            // 
            this.btnLoans.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoans.Location = new System.Drawing.Point(12, 126);
            this.btnLoans.Name = "btnLoans";
            this.btnLoans.Size = new System.Drawing.Size(653, 100);
            this.btnLoans.TabIndex = 4;
            this.btnLoans.Text = "Просмотр книг на руках";
            this.btnLoans.UseVisualStyleBackColor = true;
            this.btnLoans.Click += new System.EventHandler(this.btnLoans_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBooks);
            this.Controls.Add(this.btnReaders);
            this.Controls.Add(this.btnLoans);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Практическая работа 15";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnReaders;
        private System.Windows.Forms.Button btnLoans;
    }
}


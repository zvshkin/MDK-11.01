namespace PR_14
{
    partial class MoreInfo
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
            this.gbPatient = new System.Windows.Forms.GroupBox();
            this.lblPBirth = new System.Windows.Forms.Label();
            this.lblPAddress = new System.Windows.Forms.Label();
            this.lblPPolicy = new System.Windows.Forms.Label();
            this.lblPName = new System.Windows.Forms.Label();
            this.gbDoctor = new System.Windows.Forms.GroupBox();
            this.lblDCab = new System.Windows.Forms.Label();
            this.lblDSpec = new System.Windows.Forms.Label();
            this.lblDName = new System.Windows.Forms.Label();
            this.gbTicket = new System.Windows.Forms.GroupBox();
            this.lblTType = new System.Windows.Forms.Label();
            this.lblTTime = new System.Windows.Forms.Label();
            this.gbPatient.SuspendLayout();
            this.gbDoctor.SuspendLayout();
            this.gbTicket.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPatient
            // 
            this.gbPatient.Controls.Add(this.lblPBirth);
            this.gbPatient.Controls.Add(this.lblPAddress);
            this.gbPatient.Controls.Add(this.lblPPolicy);
            this.gbPatient.Controls.Add(this.lblPName);
            this.gbPatient.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbPatient.Location = new System.Drawing.Point(12, 12);
            this.gbPatient.Name = "gbPatient";
            this.gbPatient.Size = new System.Drawing.Size(380, 205);
            this.gbPatient.TabIndex = 0;
            this.gbPatient.TabStop = false;
            this.gbPatient.Text = "Детали Пациента";
            // 
            // lblPBirth
            // 
            this.lblPBirth.AutoSize = true;
            this.lblPBirth.Location = new System.Drawing.Point(18, 80);
            this.lblPBirth.Name = "lblPBirth";
            this.lblPBirth.Size = new System.Drawing.Size(156, 26);
            this.lblPBirth.TabIndex = 3;
            this.lblPBirth.Text = "Дата рождения:";
            // 
            // lblPAddress
            // 
            this.lblPAddress.AutoSize = true;
            this.lblPAddress.Location = new System.Drawing.Point(18, 111);
            this.lblPAddress.Name = "lblPAddress";
            this.lblPAddress.Size = new System.Drawing.Size(72, 26);
            this.lblPAddress.TabIndex = 2;
            this.lblPAddress.Text = "Адрес:";
            // 
            // lblPPolicy
            // 
            this.lblPPolicy.AutoSize = true;
            this.lblPPolicy.Location = new System.Drawing.Point(18, 53);
            this.lblPPolicy.Name = "lblPPolicy";
            this.lblPPolicy.Size = new System.Drawing.Size(129, 26);
            this.lblPPolicy.TabIndex = 1;
            this.lblPPolicy.Text = "Полис ОМС:";
            // 
            // lblPName
            // 
            this.lblPName.AutoSize = true;
            this.lblPName.Location = new System.Drawing.Point(18, 26);
            this.lblPName.Name = "lblPName";
            this.lblPName.Size = new System.Drawing.Size(59, 26);
            this.lblPName.TabIndex = 0;
            this.lblPName.Text = "ФИО:";
            // 
            // gbDoctor
            // 
            this.gbDoctor.Controls.Add(this.lblDCab);
            this.gbDoctor.Controls.Add(this.lblDSpec);
            this.gbDoctor.Controls.Add(this.lblDName);
            this.gbDoctor.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDoctor.Location = new System.Drawing.Point(12, 223);
            this.gbDoctor.Name = "gbDoctor";
            this.gbDoctor.Size = new System.Drawing.Size(725, 205);
            this.gbDoctor.TabIndex = 4;
            this.gbDoctor.TabStop = false;
            this.gbDoctor.Text = "Детали Врача";
            // 
            // lblDCab
            // 
            this.lblDCab.AutoSize = true;
            this.lblDCab.Location = new System.Drawing.Point(18, 80);
            this.lblDCab.Name = "lblDCab";
            this.lblDCab.Size = new System.Drawing.Size(92, 26);
            this.lblDCab.TabIndex = 3;
            this.lblDCab.Text = "Кабинет:";
            // 
            // lblDSpec
            // 
            this.lblDSpec.AutoSize = true;
            this.lblDSpec.Location = new System.Drawing.Point(18, 53);
            this.lblDSpec.Name = "lblDSpec";
            this.lblDSpec.Size = new System.Drawing.Size(156, 26);
            this.lblDSpec.TabIndex = 1;
            this.lblDSpec.Text = "Специальность:";
            // 
            // lblDName
            // 
            this.lblDName.AutoSize = true;
            this.lblDName.Location = new System.Drawing.Point(18, 26);
            this.lblDName.Name = "lblDName";
            this.lblDName.Size = new System.Drawing.Size(59, 26);
            this.lblDName.TabIndex = 0;
            this.lblDName.Text = "ФИО:";
            // 
            // gbTicket
            // 
            this.gbTicket.Controls.Add(this.lblTType);
            this.gbTicket.Controls.Add(this.lblTTime);
            this.gbTicket.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbTicket.Location = new System.Drawing.Point(398, 12);
            this.gbTicket.Name = "gbTicket";
            this.gbTicket.Size = new System.Drawing.Size(342, 205);
            this.gbTicket.TabIndex = 4;
            this.gbTicket.TabStop = false;
            this.gbTicket.Text = "Детали Талона";
            // 
            // lblTType
            // 
            this.lblTType.AutoSize = true;
            this.lblTType.Location = new System.Drawing.Point(18, 53);
            this.lblTType.Name = "lblTType";
            this.lblTType.Size = new System.Drawing.Size(122, 26);
            this.lblTType.TabIndex = 1;
            this.lblTType.Text = "Тип визита:";
            // 
            // lblTTime
            // 
            this.lblTTime.AutoSize = true;
            this.lblTTime.Location = new System.Drawing.Point(18, 26);
            this.lblTTime.Name = "lblTTime";
            this.lblTTime.Size = new System.Drawing.Size(148, 26);
            this.lblTTime.TabIndex = 0;
            this.lblTTime.Text = "Время приема:";
            // 
            // MoreInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 438);
            this.Controls.Add(this.gbTicket);
            this.Controls.Add(this.gbDoctor);
            this.Controls.Add(this.gbPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoreInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Больше Информации";
            this.gbPatient.ResumeLayout(false);
            this.gbPatient.PerformLayout();
            this.gbDoctor.ResumeLayout(false);
            this.gbDoctor.PerformLayout();
            this.gbTicket.ResumeLayout(false);
            this.gbTicket.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPatient;
        private System.Windows.Forms.Label lblPBirth;
        private System.Windows.Forms.Label lblPAddress;
        private System.Windows.Forms.Label lblPPolicy;
        private System.Windows.Forms.Label lblPName;
        private System.Windows.Forms.GroupBox gbDoctor;
        private System.Windows.Forms.Label lblDCab;
        private System.Windows.Forms.Label lblDSpec;
        private System.Windows.Forms.Label lblDName;
        private System.Windows.Forms.GroupBox gbTicket;
        private System.Windows.Forms.Label lblTType;
        private System.Windows.Forms.Label lblTTime;
    }
}
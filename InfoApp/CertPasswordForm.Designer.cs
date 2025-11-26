namespace InfoApp
{
    partial class CertPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertPasswordForm));
            this.btnShowPass = new System.Windows.Forms.Button();
            this.btnAuth = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShowPass
            // 
            this.btnShowPass.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPass.Image")));
            this.btnShowPass.Location = new System.Drawing.Point(228, 47);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(22, 20);
            this.btnShowPass.TabIndex = 18;
            this.btnShowPass.UseVisualStyleBackColor = true;
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(51, 80);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(149, 23);
            this.btnAuth.TabIndex = 16;
            this.btnAuth.Text = "Подтвердить";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(14, 47);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(212, 20);
            this.txtPass.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 35);
            this.label1.TabIndex = 19;
            this.label1.Text = "Введите ключ (пароль) для выбранного сертификата";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CertPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowPass);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.txtPass);
            this.Name = "CertPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowPass;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
    }
}
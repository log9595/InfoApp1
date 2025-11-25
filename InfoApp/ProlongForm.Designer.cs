namespace InfoApp
{
    partial class ProlongForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProlongForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddCenter = new System.Windows.Forms.Button();
            this.btnAddOrg = new System.Windows.Forms.Button();
            this.btnAddPost = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCenter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbOrgStruct = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPost = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreatePass = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCreatePass);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnApply);
            this.groupBox1.Controls.Add(this.txtBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnAddCenter);
            this.groupBox1.Controls.Add(this.btnAddOrg);
            this.groupBox1.Controls.Add(this.btnAddPost);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbCenter);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtRoom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbOrgStruct);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbPost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFIO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(669, 479);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Пользовательские данные";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(144, 424);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(349, 28);
            this.btnApply.TabIndex = 36;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(155, 158);
            this.txtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(132, 22);
            this.txtBox.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "№ носителя:";
            // 
            // btnAddCenter
            // 
            this.btnAddCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCenter.Location = new System.Drawing.Point(423, 252);
            this.btnAddCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddCenter.Name = "btnAddCenter";
            this.btnAddCenter.Size = new System.Drawing.Size(33, 26);
            this.btnAddCenter.TabIndex = 31;
            this.btnAddCenter.Text = "+";
            this.btnAddCenter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddCenter.UseVisualStyleBackColor = true;
            this.btnAddCenter.Click += new System.EventHandler(this.BtnAddCenter_Click);
            // 
            // btnAddOrg
            // 
            this.btnAddOrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddOrg.Location = new System.Drawing.Point(423, 94);
            this.btnAddOrg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddOrg.Name = "btnAddOrg";
            this.btnAddOrg.Size = new System.Drawing.Size(33, 26);
            this.btnAddOrg.TabIndex = 30;
            this.btnAddOrg.Text = "+";
            this.btnAddOrg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddOrg.UseVisualStyleBackColor = true;
            this.btnAddOrg.Visible = false;
            this.btnAddOrg.Click += new System.EventHandler(this.BtnAddOrg_Click);
            // 
            // btnAddPost
            // 
            this.btnAddPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddPost.Location = new System.Drawing.Point(423, 60);
            this.btnAddPost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddPost.Name = "btnAddPost";
            this.btnAddPost.Size = new System.Drawing.Size(33, 26);
            this.btnAddPost.TabIndex = 29;
            this.btnAddPost.Text = "+";
            this.btnAddPost.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddPost.UseVisualStyleBackColor = true;
            this.btnAddPost.Visible = false;
            this.btnAddPost.Click += new System.EventHandler(this.BtnAddPost_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(155, 314);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(324, 100);
            this.txtComment.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 328);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Комментарий:";
            // 
            // cbCenter
            // 
            this.cbCenter.FormattingEnabled = true;
            this.cbCenter.Location = new System.Drawing.Point(155, 252);
            this.cbCenter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCenter.Name = "cbCenter";
            this.cbCenter.Size = new System.Drawing.Size(259, 24);
            this.cbCenter.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 255);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Удостов. центр:";
            // 
            // txtRoom
            // 
            this.txtRoom.Enabled = false;
            this.txtRoom.Location = new System.Drawing.Point(155, 127);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(132, 22);
            this.txtRoom.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Кабинет:";
            // 
            // cbOrgStruct
            // 
            this.cbOrgStruct.Enabled = false;
            this.cbOrgStruct.FormattingEnabled = true;
            this.cbOrgStruct.Location = new System.Drawing.Point(155, 95);
            this.cbOrgStruct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbOrgStruct.Name = "cbOrgStruct";
            this.cbOrgStruct.Size = new System.Drawing.Size(259, 24);
            this.cbOrgStruct.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Отдел/отделение:";
            // 
            // cbPost
            // 
            this.cbPost.Enabled = false;
            this.cbPost.FormattingEnabled = true;
            this.cbPost.Location = new System.Drawing.Point(155, 60);
            this.cbPost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPost.Name = "cbPost";
            this.cbPost.Size = new System.Drawing.Size(259, 24);
            this.cbPost.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Должность:";
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(155, 220);
            this.dateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(161, 22);
            this.dateTo.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Дата окончания:";
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(155, 188);
            this.dateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(161, 22);
            this.dateFrom.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Дата начала:";
            // 
            // txtFIO
            // 
            this.txtFIO.Enabled = false;
            this.txtFIO.Location = new System.Drawing.Point(155, 28);
            this.txtFIO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFIO.Name = "txtFIO";
            this.txtFIO.Size = new System.Drawing.Size(473, 22);
            this.txtFIO.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ф.И.О.:";
            // 
            // btnCreatePass
            // 
            this.btnCreatePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreatePass.Location = new System.Drawing.Point(341, 282);
            this.btnCreatePass.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreatePass.Name = "btnCreatePass";
            this.btnCreatePass.Size = new System.Drawing.Size(139, 26);
            this.btnCreatePass.TabIndex = 39;
            this.btnCreatePass.Text = "Сгенерировать";
            this.btnCreatePass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCreatePass.UseVisualStyleBackColor = true;
            this.btnCreatePass.Click += new System.EventHandler(this.btnCreatePass_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(155, 284);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(177, 22);
            this.txtPassword.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 287);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 16);
            this.label10.TabIndex = 38;
            this.label10.Text = "Пароль ЭЦП:";
            // 
            // ProlongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 508);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProlongForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пролонгация ключа пользователя";
            this.Load += new System.EventHandler(this.AddClientForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbOrgStruct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPost;
        private System.Windows.Forms.Button btnAddCenter;
        private System.Windows.Forms.Button btnAddOrg;
        private System.Windows.Forms.Button btnAddPost;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCreatePass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label10;
    }
}
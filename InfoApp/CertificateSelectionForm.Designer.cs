namespace InfoApp
{
    partial class CertificateSelectionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbOrgStruct = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numbContainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrgStructure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Поиск по фамилии:";
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSearch.Location = new System.Drawing.Point(124, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 20);
            this.txtSearch.TabIndex = 34;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(330, 9);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 21);
            this.btnApply.TabIndex = 33;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // cbOrgStruct
            // 
            this.cbOrgStruct.FormattingEnabled = true;
            this.cbOrgStruct.Location = new System.Drawing.Point(124, 9);
            this.cbOrgStruct.Name = "cbOrgStruct";
            this.cbOrgStruct.Size = new System.Drawing.Size(195, 21);
            this.cbOrgStruct.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Отдел/отделение:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.numbContainer,
            this.dateFrom,
            this.dateTo,
            this.FIO,
            this.postName,
            this.OrgStructure});
            this.dataGridView1.Location = new System.Drawing.Point(12, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(715, 328);
            this.dataGridView1.TabIndex = 30;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(562, 405);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(113, 21);
            this.btnSelect.TabIndex = 36;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // numbContainer
            // 
            this.numbContainer.DataPropertyName = "numbContainer";
            this.numbContainer.HeaderText = "№ носителя";
            this.numbContainer.Name = "numbContainer";
            this.numbContainer.ReadOnly = true;
            this.numbContainer.Visible = false;
            // 
            // dateFrom
            // 
            this.dateFrom.DataPropertyName = "dateFrom";
            this.dateFrom.HeaderText = "Дата начала";
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.ReadOnly = true;
            this.dateFrom.Visible = false;
            // 
            // dateTo
            // 
            this.dateTo.DataPropertyName = "dateTo";
            this.dateTo.HeaderText = "Дата окончания";
            this.dateTo.Name = "dateTo";
            this.dateTo.ReadOnly = true;
            this.dateTo.Visible = false;
            // 
            // FIO
            // 
            this.FIO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FIO.DataPropertyName = "FIO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FIO.DefaultCellStyle = dataGridViewCellStyle3;
            this.FIO.FillWeight = 60F;
            this.FIO.HeaderText = "Ф.И.О.";
            this.FIO.Name = "FIO";
            this.FIO.ReadOnly = true;
            // 
            // postName
            // 
            this.postName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.postName.DataPropertyName = "postName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.postName.DefaultCellStyle = dataGridViewCellStyle4;
            this.postName.FillWeight = 40F;
            this.postName.HeaderText = "Должность";
            this.postName.Name = "postName";
            this.postName.ReadOnly = true;
            // 
            // OrgStructure
            // 
            this.OrgStructure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrgStructure.DataPropertyName = "OrgStructure";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OrgStructure.DefaultCellStyle = dataGridViewCellStyle5;
            this.OrgStructure.FillWeight = 40F;
            this.OrgStructure.HeaderText = "Отдел/отделение";
            this.OrgStructure.Name = "OrgStructure";
            this.OrgStructure.ReadOnly = true;
            // 
            // CertificateSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 434);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbOrgStruct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CertificateSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор сертификата";
            this.Load += new System.EventHandler(this.CertificateSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cbOrgStruct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn numbContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn postName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrgStructure;
    }
}
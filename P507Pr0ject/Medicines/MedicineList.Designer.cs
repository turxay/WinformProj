namespace P507Pr0ject.Medicines
{
    partial class MedicineList
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
            this.txtMedicineName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTypeMedicine = new System.Windows.Forms.ComboBox();
            this.nmMedicineAmout = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nmPriceMedicine = new System.Windows.Forms.NumericUpDown();
            this.dgvMedicineList = new System.Windows.Forms.DataGridView();
            this.btnCreateOrUpdateMed = new System.Windows.Forms.Button();
            this.btnDeleteMedicine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmMedicineAmout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPriceMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMedicineName
            // 
            this.txtMedicineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedicineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedicineName.Location = new System.Drawing.Point(43, 238);
            this.txtMedicineName.Name = "txtMedicineName";
            this.txtMedicineName.Size = new System.Drawing.Size(277, 35);
            this.txtMedicineName.TabIndex = 5;
            this.txtMedicineName.TextChanged += new System.EventHandler(this.txtMedicineName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(38, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Medicine Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(38, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select type:";
            // 
            // cmbTypeMedicine
            // 
            this.cmbTypeMedicine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeMedicine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeMedicine.FormattingEnabled = true;
            this.cmbTypeMedicine.Location = new System.Drawing.Point(43, 112);
            this.cmbTypeMedicine.Name = "cmbTypeMedicine";
            this.cmbTypeMedicine.Size = new System.Drawing.Size(277, 37);
            this.cmbTypeMedicine.TabIndex = 6;
            // 
            // nmMedicineAmout
            // 
            this.nmMedicineAmout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmMedicineAmout.Location = new System.Drawing.Point(436, 238);
            this.nmMedicineAmout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmMedicineAmout.Name = "nmMedicineAmout";
            this.nmMedicineAmout.Size = new System.Drawing.Size(120, 35);
            this.nmMedicineAmout.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(431, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(620, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "Price:";
            // 
            // nmPriceMedicine
            // 
            this.nmPriceMedicine.DecimalPlaces = 2;
            this.nmPriceMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmPriceMedicine.Location = new System.Drawing.Point(625, 238);
            this.nmPriceMedicine.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmPriceMedicine.Name = "nmPriceMedicine";
            this.nmPriceMedicine.Size = new System.Drawing.Size(120, 35);
            this.nmPriceMedicine.TabIndex = 10;
            // 
            // dgvMedicineList
            // 
            this.dgvMedicineList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicineList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMedicineList.Location = new System.Drawing.Point(0, 473);
            this.dgvMedicineList.Name = "dgvMedicineList";
            this.dgvMedicineList.RowHeadersWidth = 62;
            this.dgvMedicineList.RowTemplate.Height = 28;
            this.dgvMedicineList.Size = new System.Drawing.Size(1237, 274);
            this.dgvMedicineList.TabIndex = 12;
            this.dgvMedicineList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicineList_CellDoubleClick);
            // 
            // btnCreateOrUpdateMed
            // 
            this.btnCreateOrUpdateMed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrUpdateMed.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnCreateOrUpdateMed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOrUpdateMed.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreateOrUpdateMed.Location = new System.Drawing.Point(769, 234);
            this.btnCreateOrUpdateMed.Name = "btnCreateOrUpdateMed";
            this.btnCreateOrUpdateMed.Size = new System.Drawing.Size(249, 47);
            this.btnCreateOrUpdateMed.TabIndex = 13;
            this.btnCreateOrUpdateMed.Text = "Create && Update";
            this.btnCreateOrUpdateMed.UseVisualStyleBackColor = false;
            this.btnCreateOrUpdateMed.Click += new System.EventHandler(this.btnCreateOrUpdateMed_Click);
            // 
            // btnDeleteMedicine
            // 
            this.btnDeleteMedicine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteMedicine.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMedicine.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteMedicine.Location = new System.Drawing.Point(1051, 232);
            this.btnDeleteMedicine.Name = "btnDeleteMedicine";
            this.btnDeleteMedicine.Size = new System.Drawing.Size(174, 49);
            this.btnDeleteMedicine.TabIndex = 14;
            this.btnDeleteMedicine.Text = "Delete";
            this.btnDeleteMedicine.UseVisualStyleBackColor = false;
            this.btnDeleteMedicine.Click += new System.EventHandler(this.btnDeleteMedicine_Click);
            // 
            // MedicineList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 747);
            this.Controls.Add(this.btnDeleteMedicine);
            this.Controls.Add(this.btnCreateOrUpdateMed);
            this.Controls.Add(this.dgvMedicineList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nmPriceMedicine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nmMedicineAmout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTypeMedicine);
            this.Controls.Add(this.txtMedicineName);
            this.Controls.Add(this.label1);
            this.Name = "MedicineList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "z";
            this.Load += new System.EventHandler(this.MedicineList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmMedicineAmout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPriceMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMedicineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTypeMedicine;
        private System.Windows.Forms.NumericUpDown nmMedicineAmout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmPriceMedicine;
        private System.Windows.Forms.DataGridView dgvMedicineList;
        private System.Windows.Forms.Button btnCreateOrUpdateMed;
        private System.Windows.Forms.Button btnDeleteMedicine;
    }
}
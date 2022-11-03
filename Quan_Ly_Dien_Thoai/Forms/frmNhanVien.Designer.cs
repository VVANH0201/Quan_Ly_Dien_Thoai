namespace Quan_Ly_Dien_Thoai.From
{
    partial class frmNhanVien
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
            this.GBData = new System.Windows.Forms.GroupBox();
            this.GBInfo = new System.Windows.Forms.GroupBox();
            this.GBFunction = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.LBID = new System.Windows.Forms.Label();
            this.LBEmail = new System.Windows.Forms.Label();
            this.LBName = new System.Windows.Forms.Label();
            this.LBGender = new System.Windows.Forms.Label();
            this.LBBirth = new System.Windows.Forms.Label();
            this.LBPhone = new System.Windows.Forms.Label();
            this.LBAddress = new System.Windows.Forms.Label();
            this.dTPBirth = new System.Windows.Forms.DateTimePicker();
            this.rBtnMale = new System.Windows.Forms.RadioButton();
            this.rBtnFemale = new System.Windows.Forms.RadioButton();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.DGVEmployee = new System.Windows.Forms.DataGridView();
            this.GBData.SuspendLayout();
            this.GBInfo.SuspendLayout();
            this.GBFunction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // GBData
            // 
            this.GBData.Controls.Add(this.DGVEmployee);
            this.GBData.Controls.Add(this.btnSearch);
            this.GBData.Controls.Add(this.txtSearch);
            this.GBData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GBData.Location = new System.Drawing.Point(0, 328);
            this.GBData.Name = "GBData";
            this.GBData.Size = new System.Drawing.Size(941, 250);
            this.GBData.TabIndex = 4;
            this.GBData.TabStop = false;
            // 
            // GBInfo
            // 
            this.GBInfo.Controls.Add(this.txtAddress);
            this.GBInfo.Controls.Add(this.txtPhone);
            this.GBInfo.Controls.Add(this.txtName);
            this.GBInfo.Controls.Add(this.txtEmail);
            this.GBInfo.Controls.Add(this.txtID);
            this.GBInfo.Controls.Add(this.rBtnFemale);
            this.GBInfo.Controls.Add(this.rBtnMale);
            this.GBInfo.Controls.Add(this.dTPBirth);
            this.GBInfo.Controls.Add(this.LBAddress);
            this.GBInfo.Controls.Add(this.LBPhone);
            this.GBInfo.Controls.Add(this.LBBirth);
            this.GBInfo.Controls.Add(this.LBGender);
            this.GBInfo.Controls.Add(this.LBName);
            this.GBInfo.Controls.Add(this.LBEmail);
            this.GBInfo.Controls.Add(this.LBID);
            this.GBInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.GBInfo.Location = new System.Drawing.Point(0, 0);
            this.GBInfo.Name = "GBInfo";
            this.GBInfo.Size = new System.Drawing.Size(619, 328);
            this.GBInfo.TabIndex = 5;
            this.GBInfo.TabStop = false;
            // 
            // GBFunction
            // 
            this.GBFunction.Controls.Add(this.btnExit);
            this.GBFunction.Controls.Add(this.btnDelete);
            this.GBFunction.Controls.Add(this.btnUpdate);
            this.GBFunction.Controls.Add(this.btnAdd);
            this.GBFunction.Dock = System.Windows.Forms.DockStyle.Right;
            this.GBFunction.Location = new System.Drawing.Point(652, 0);
            this.GBFunction.Name = "GBFunction";
            this.GBFunction.Size = new System.Drawing.Size(289, 328);
            this.GBFunction.TabIndex = 6;
            this.GBFunction.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(84, 21);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 48);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(84, 103);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 48);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(84, 180);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 48);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(84, 256);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 48);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // LBID
            // 
            this.LBID.AutoSize = true;
            this.LBID.Location = new System.Drawing.Point(45, 37);
            this.LBID.Name = "LBID";
            this.LBID.Size = new System.Drawing.Size(23, 16);
            this.LBID.TabIndex = 0;
            this.LBID.Text = "ID:";
            // 
            // LBEmail
            // 
            this.LBEmail.AutoSize = true;
            this.LBEmail.Location = new System.Drawing.Point(327, 37);
            this.LBEmail.Name = "LBEmail";
            this.LBEmail.Size = new System.Drawing.Size(44, 16);
            this.LBEmail.TabIndex = 1;
            this.LBEmail.Text = "Email:";
            // 
            // LBName
            // 
            this.LBName.AutoSize = true;
            this.LBName.Location = new System.Drawing.Point(45, 119);
            this.LBName.Name = "LBName";
            this.LBName.Size = new System.Drawing.Size(67, 16);
            this.LBName.TabIndex = 2;
            this.LBName.Text = "Họ và tên:";
            // 
            // LBGender
            // 
            this.LBGender.AutoSize = true;
            this.LBGender.Location = new System.Drawing.Point(327, 119);
            this.LBGender.Name = "LBGender";
            this.LBGender.Size = new System.Drawing.Size(57, 16);
            this.LBGender.TabIndex = 3;
            this.LBGender.Text = "Giới tính:";
            // 
            // LBBirth
            // 
            this.LBBirth.AutoSize = true;
            this.LBBirth.Location = new System.Drawing.Point(45, 196);
            this.LBBirth.Name = "LBBirth";
            this.LBBirth.Size = new System.Drawing.Size(70, 16);
            this.LBBirth.TabIndex = 4;
            this.LBBirth.Text = "Ngày sinh:";
            // 
            // LBPhone
            // 
            this.LBPhone.AutoSize = true;
            this.LBPhone.Location = new System.Drawing.Point(327, 196);
            this.LBPhone.Name = "LBPhone";
            this.LBPhone.Size = new System.Drawing.Size(37, 16);
            this.LBPhone.TabIndex = 5;
            this.LBPhone.Text = "SĐT:";
            // 
            // LBAddress
            // 
            this.LBAddress.AutoSize = true;
            this.LBAddress.Location = new System.Drawing.Point(45, 272);
            this.LBAddress.Name = "LBAddress";
            this.LBAddress.Size = new System.Drawing.Size(50, 16);
            this.LBAddress.TabIndex = 6;
            this.LBAddress.Text = "Địa chỉ:";
            // 
            // dTPBirth
            // 
            this.dTPBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTPBirth.Location = new System.Drawing.Point(121, 191);
            this.dTPBirth.Name = "dTPBirth";
            this.dTPBirth.Size = new System.Drawing.Size(170, 22);
            this.dTPBirth.TabIndex = 7;
            // 
            // rBtnMale
            // 
            this.rBtnMale.AutoSize = true;
            this.rBtnMale.Location = new System.Drawing.Point(414, 115);
            this.rBtnMale.Name = "rBtnMale";
            this.rBtnMale.Size = new System.Drawing.Size(57, 20);
            this.rBtnMale.TabIndex = 8;
            this.rBtnMale.TabStop = true;
            this.rBtnMale.Text = "Nam";
            this.rBtnMale.UseVisualStyleBackColor = true;
            // 
            // rBtnFemale
            // 
            this.rBtnFemale.AutoSize = true;
            this.rBtnFemale.Location = new System.Drawing.Point(515, 115);
            this.rBtnFemale.Name = "rBtnFemale";
            this.rBtnFemale.Size = new System.Drawing.Size(45, 20);
            this.rBtnFemale.TabIndex = 9;
            this.rBtnFemale.TabStop = true;
            this.rBtnFemale.Text = "Nữ";
            this.rBtnFemale.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(121, 31);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(170, 22);
            this.txtID.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(390, 31);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(188, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 116);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(170, 22);
            this.txtName.TabIndex = 12;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(390, 191);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(188, 22);
            this.txtPhone.TabIndex = 13;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(121, 269);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(457, 22);
            this.txtAddress.TabIndex = 14;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(121, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 22);
            this.txtSearch.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(330, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 32);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // DGVEmployee
            // 
            this.DGVEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVEmployee.Location = new System.Drawing.Point(3, 73);
            this.DGVEmployee.Name = "DGVEmployee";
            this.DGVEmployee.RowHeadersWidth = 51;
            this.DGVEmployee.RowTemplate.Height = 24;
            this.DGVEmployee.Size = new System.Drawing.Size(935, 174);
            this.DGVEmployee.TabIndex = 14;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 578);
            this.Controls.Add(this.GBFunction);
            this.Controls.Add(this.GBInfo);
            this.Controls.Add(this.GBData);
            this.Name = "frmNhanVien";
            this.Text = "frmNhanVien";
            this.GBData.ResumeLayout(false);
            this.GBData.PerformLayout();
            this.GBInfo.ResumeLayout(false);
            this.GBInfo.PerformLayout();
            this.GBFunction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GBData;
        private System.Windows.Forms.GroupBox GBInfo;
        private System.Windows.Forms.GroupBox GBFunction;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label LBGender;
        private System.Windows.Forms.Label LBName;
        private System.Windows.Forms.Label LBEmail;
        private System.Windows.Forms.Label LBID;
        private System.Windows.Forms.Label LBAddress;
        private System.Windows.Forms.Label LBPhone;
        private System.Windows.Forms.Label LBBirth;
        private System.Windows.Forms.RadioButton rBtnFemale;
        private System.Windows.Forms.RadioButton rBtnMale;
        private System.Windows.Forms.DateTimePicker dTPBirth;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView DGVEmployee;
    }
}
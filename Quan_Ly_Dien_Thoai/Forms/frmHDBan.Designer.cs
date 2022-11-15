namespace Quan_Ly_Dien_Thoai.From
{
    partial class frmHDBan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBNew = new Guna.UI2.WinForms.Guna2Button();
            this.CbxBSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtBSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBSearch = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnBExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnBDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnBEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnBAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnBPrint = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvHDB = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHDB = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbMaKH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbMaNV = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTenNV = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaHD = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDB)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBNew);
            this.panel1.Controls.Add(this.CbxBSearch);
            this.panel1.Controls.Add(this.txtBSearch);
            this.panel1.Controls.Add(this.btnBSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 82);
            this.panel1.TabIndex = 0;
            // 
            // btnBNew
            // 
            this.btnBNew.BorderRadius = 10;
            this.btnBNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBNew.ForeColor = System.Drawing.Color.White;
            this.btnBNew.Location = new System.Drawing.Point(619, 15);
            this.btnBNew.Name = "btnBNew";
            this.btnBNew.Size = new System.Drawing.Size(111, 45);
            this.btnBNew.TabIndex = 3;
            this.btnBNew.Text = "New";
            this.btnBNew.Click += new System.EventHandler(this.btnBNew_Click);
            // 
            // CbxBSearch
            // 
            this.CbxBSearch.BackColor = System.Drawing.Color.Transparent;
            this.CbxBSearch.BorderRadius = 10;
            this.CbxBSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbxBSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxBSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbxBSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbxBSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CbxBSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CbxBSearch.ItemHeight = 30;
            this.CbxBSearch.Location = new System.Drawing.Point(12, 20);
            this.CbxBSearch.Name = "CbxBSearch";
            this.CbxBSearch.Size = new System.Drawing.Size(205, 36);
            this.CbxBSearch.TabIndex = 2;
            // 
            // txtBSearch
            // 
            this.txtBSearch.BorderRadius = 10;
            this.txtBSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBSearch.DefaultText = "";
            this.txtBSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBSearch.Location = new System.Drawing.Point(224, 20);
            this.txtBSearch.Name = "txtBSearch";
            this.txtBSearch.PasswordChar = '\0';
            this.txtBSearch.PlaceholderText = "";
            this.txtBSearch.SelectedText = "";
            this.txtBSearch.Size = new System.Drawing.Size(245, 40);
            this.txtBSearch.TabIndex = 1;
            // 
            // btnBSearch
            // 
            this.btnBSearch.BorderRadius = 10;
            this.btnBSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBSearch.ForeColor = System.Drawing.Color.White;
            this.btnBSearch.Location = new System.Drawing.Point(490, 15);
            this.btnBSearch.Name = "btnBSearch";
            this.btnBSearch.Size = new System.Drawing.Size(111, 45);
            this.btnBSearch.TabIndex = 0;
            this.btnBSearch.Text = "Search";
            this.btnBSearch.Click += new System.EventHandler(this.btnBSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBCancel);
            this.panel2.Controls.Add(this.btnBExit);
            this.panel2.Controls.Add(this.btnBDelete);
            this.panel2.Controls.Add(this.btnBEdit);
            this.panel2.Controls.Add(this.btnBAdd);
            this.panel2.Controls.Add(this.btnBPrint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 94);
            this.panel2.TabIndex = 1;
            // 
            // btnBCancel
            // 
            this.btnBCancel.BorderRadius = 10;
            this.btnBCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBCancel.ForeColor = System.Drawing.Color.White;
            this.btnBCancel.Location = new System.Drawing.Point(978, 25);
            this.btnBCancel.Name = "btnBCancel";
            this.btnBCancel.Size = new System.Drawing.Size(111, 45);
            this.btnBCancel.TabIndex = 5;
            this.btnBCancel.Text = "Cancel";
            this.btnBCancel.Click += new System.EventHandler(this.btnBCancel_Click);
            // 
            // btnBExit
            // 
            this.btnBExit.BorderRadius = 10;
            this.btnBExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBExit.ForeColor = System.Drawing.Color.White;
            this.btnBExit.Location = new System.Drawing.Point(160, 25);
            this.btnBExit.Name = "btnBExit";
            this.btnBExit.Size = new System.Drawing.Size(111, 45);
            this.btnBExit.TabIndex = 1;
            this.btnBExit.Text = "Exit";
            this.btnBExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBDelete
            // 
            this.btnBDelete.BorderRadius = 10;
            this.btnBDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBDelete.ForeColor = System.Drawing.Color.White;
            this.btnBDelete.Location = new System.Drawing.Point(848, 25);
            this.btnBDelete.Name = "btnBDelete";
            this.btnBDelete.Size = new System.Drawing.Size(111, 45);
            this.btnBDelete.TabIndex = 4;
            this.btnBDelete.Text = "Delete";
            this.btnBDelete.Click += new System.EventHandler(this.btnBDelete_Click);
            // 
            // btnBEdit
            // 
            this.btnBEdit.BorderRadius = 10;
            this.btnBEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBEdit.ForeColor = System.Drawing.Color.White;
            this.btnBEdit.Location = new System.Drawing.Point(714, 25);
            this.btnBEdit.Name = "btnBEdit";
            this.btnBEdit.Size = new System.Drawing.Size(111, 45);
            this.btnBEdit.TabIndex = 3;
            this.btnBEdit.Text = "Edit";
            this.btnBEdit.Click += new System.EventHandler(this.btnBEdit_Click);
            // 
            // btnBAdd
            // 
            this.btnBAdd.BorderRadius = 10;
            this.btnBAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBAdd.ForeColor = System.Drawing.Color.White;
            this.btnBAdd.Location = new System.Drawing.Point(572, 25);
            this.btnBAdd.Name = "btnBAdd";
            this.btnBAdd.Size = new System.Drawing.Size(111, 45);
            this.btnBAdd.TabIndex = 2;
            this.btnBAdd.Text = "ADD";
            this.btnBAdd.Click += new System.EventHandler(this.btnBAdd_Click);
            // 
            // btnBPrint
            // 
            this.btnBPrint.BorderRadius = 10;
            this.btnBPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBPrint.ForeColor = System.Drawing.Color.White;
            this.btnBPrint.Location = new System.Drawing.Point(23, 25);
            this.btnBPrint.Name = "btnBPrint";
            this.btnBPrint.Size = new System.Drawing.Size(111, 45);
            this.btnBPrint.TabIndex = 0;
            this.btnBPrint.Text = "Print";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1113, 418);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvHDB);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 207);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1113, 211);
            this.panel5.TabIndex = 25;
            // 
            // dgvHDB
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDB.ColumnHeadersHeight = 30;
            this.dgvHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvHDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHDB.Location = new System.Drawing.Point(0, 0);
            this.dgvHDB.Name = "dgvHDB";
            this.dgvHDB.RowHeadersWidth = 51;
            this.dgvHDB.RowTemplate.Height = 24;
            this.dgvHDB.Size = new System.Drawing.Size(1113, 211);
            this.dgvHDB.TabIndex = 24;
            this.dgvHDB.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHDB_CellContentClick);
            this.dgvHDB.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHDB_CellContentDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaHDB";
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenKhachHang";
            this.Column2.HeaderText = "Customer";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 180;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TenNhanVien";
            this.Column3.HeaderText = "Employee";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 180;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NgayBan";
            this.Column4.HeaderText = "Date";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 180;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TongTien";
            this.Column5.HeaderText = "Total";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 180;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.dtpHDB);
            this.panel4.Controls.Add(this.cbMaKH);
            this.panel4.Controls.Add(this.cbMaNV);
            this.panel4.Controls.Add(this.txtTenNV);
            this.panel4.Controls.Add(this.txtTenKH);
            this.panel4.Controls.Add(this.txtMaHD);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1113, 207);
            this.panel4.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(807, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 25);
            this.label6.TabIndex = 34;
            this.label6.Text = "Tên nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(458, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 25);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tên khách hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 32;
            this.label4.Text = "Ngày bán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(807, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 31;
            this.label3.Text = "Mã nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(458, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Mã khách hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Mã hóa đơn";
            // 
            // dtpHDB
            // 
            this.dtpHDB.Checked = true;
            this.dtpHDB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHDB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHDB.Location = new System.Drawing.Point(106, 145);
            this.dtpHDB.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHDB.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHDB.Name = "dtpHDB";
            this.dtpHDB.Size = new System.Drawing.Size(200, 36);
            this.dtpHDB.TabIndex = 28;
            this.dtpHDB.Value = new System.DateTime(2022, 11, 14, 9, 36, 57, 483);
            // 
            // cbMaKH
            // 
            this.cbMaKH.BackColor = System.Drawing.Color.Transparent;
            this.cbMaKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaKH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMaKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMaKH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMaKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbMaKH.ItemHeight = 30;
            this.cbMaKH.Location = new System.Drawing.Point(463, 46);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(200, 36);
            this.cbMaKH.TabIndex = 27;
            this.cbMaKH.SelectedIndexChanged += new System.EventHandler(this.cbMaKH_SelectedIndexChanged);
            // 
            // cbMaNV
            // 
            this.cbMaNV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMaNV.BackColor = System.Drawing.Color.Transparent;
            this.cbMaNV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMaNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMaNV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMaNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbMaNV.ItemHeight = 30;
            this.cbMaNV.Location = new System.Drawing.Point(812, 46);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(200, 36);
            this.cbMaNV.TabIndex = 26;
            this.cbMaNV.SelectedIndexChanged += new System.EventHandler(this.cbMaNV_SelectedIndexChanged_1);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenNV.DefaultText = "";
            this.txtTenNV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenNV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenNV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenNV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenNV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenNV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenNV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenNV.Location = new System.Drawing.Point(812, 145);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.PasswordChar = '\0';
            this.txtTenNV.PlaceholderText = "";
            this.txtTenNV.SelectedText = "";
            this.txtTenNV.Size = new System.Drawing.Size(200, 36);
            this.txtTenNV.TabIndex = 25;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKH.DefaultText = "";
            this.txtTenKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKH.Location = new System.Drawing.Point(463, 145);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.PasswordChar = '\0';
            this.txtTenKH.PlaceholderText = "";
            this.txtTenKH.SelectedText = "";
            this.txtTenKH.Size = new System.Drawing.Size(200, 36);
            this.txtTenKH.TabIndex = 24;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHD.DefaultText = "";
            this.txtMaHD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaHD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaHD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaHD.Location = new System.Drawing.Point(106, 46);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.PasswordChar = '\0';
            this.txtMaHD.PlaceholderText = "";
            this.txtMaHD.SelectedText = "";
            this.txtMaHD.Size = new System.Drawing.Size(200, 36);
            this.txtMaHD.TabIndex = 23;
            // 
            // frmHDBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 594);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmHDBan";
            this.Text = "frmHDBan";
            this.Load += new System.EventHandler(this.frmHDBan_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDB)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ComboBox CbxBSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtBSearch;
        private Guna.UI2.WinForms.Guna2Button btnBSearch;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnBCancel;
        private Guna.UI2.WinForms.Guna2Button btnBExit;
        private Guna.UI2.WinForms.Guna2Button btnBDelete;
        private Guna.UI2.WinForms.Guna2Button btnBEdit;
        private Guna.UI2.WinForms.Guna2Button btnBAdd;
        private Guna.UI2.WinForms.Guna2Button btnBPrint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvHDB;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHDB;
        private Guna.UI2.WinForms.Guna2ComboBox cbMaKH;
        private Guna.UI2.WinForms.Guna2ComboBox cbMaNV;
        private Guna.UI2.WinForms.Guna2TextBox txtTenNV;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKH;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private Guna.UI2.WinForms.Guna2Button btnBNew;
    }
}
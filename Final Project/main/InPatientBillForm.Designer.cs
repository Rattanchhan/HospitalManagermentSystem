namespace Final_Project.main
{
    partial class InPatientBillForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InPatientBillForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.LabelLabNo = new System.Windows.Forms.Label();
            this.LabelPatientID = new System.Windows.Forms.Label();
            this.LabelDoctorID = new System.Windows.Forms.Label();
            this.LabelCategory = new System.Windows.Forms.Label();
            this.LabelDate = new System.Windows.Forms.Label();
            this.comboBoxPatientID = new System.Windows.Forms.ComboBox();
            this.dateOfDescharge = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateOfAdmission = new System.Windows.Forms.DateTimePicker();
            this.textBoxBillNo = new System.Windows.Forms.TextBox();
            this.textBoxRoomCharge = new System.Windows.Forms.TextBox();
            this.textBoxLabCharge = new System.Windows.Forms.TextBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this._BillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._PatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._DateAdmission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._DateDescharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._LabNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 874);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 76);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panel4.Size = new System.Drawing.Size(1366, 555);
            this.panel4.TabIndex = 15;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.65619F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.34381F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1344, 531);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.43946F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.56054F));
            this.tableLayoutPanel2.Controls.Add(this.LabelDescription, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LabelLabNo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LabelPatientID, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LabelDoctorID, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.LabelCategory, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.LabelDate, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxPatientID, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dateOfDescharge, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.dateOfAdmission, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBoxBillNo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxRoomCharge, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBoxLabCharge, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBoxTotal, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxStatus, 1, 7);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1338, 388);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // LabelDescription
            // 
            this.LabelDescription.AutoSize = true;
            this.LabelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDescription.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDescription.Location = new System.Drawing.Point(3, 174);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(320, 56);
            this.LabelDescription.TabIndex = 2;
            this.LabelDescription.Text = "RoomCharge";
            // 
            // LabelLabNo
            // 
            this.LabelLabNo.AutoSize = true;
            this.LabelLabNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelLabNo.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLabNo.Location = new System.Drawing.Point(3, 0);
            this.LabelLabNo.Name = "LabelLabNo";
            this.LabelLabNo.Size = new System.Drawing.Size(320, 56);
            this.LabelLabNo.TabIndex = 0;
            this.LabelLabNo.Text = "Bill No";
            this.LabelLabNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelPatientID
            // 
            this.LabelPatientID.AutoSize = true;
            this.LabelPatientID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelPatientID.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPatientID.Location = new System.Drawing.Point(3, 56);
            this.LabelPatientID.Name = "LabelPatientID";
            this.LabelPatientID.Size = new System.Drawing.Size(320, 41);
            this.LabelPatientID.TabIndex = 0;
            this.LabelPatientID.Text = "Patient ID";
            this.LabelPatientID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelDoctorID
            // 
            this.LabelDoctorID.AutoSize = true;
            this.LabelDoctorID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDoctorID.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDoctorID.Location = new System.Drawing.Point(3, 97);
            this.LabelDoctorID.Name = "LabelDoctorID";
            this.LabelDoctorID.Size = new System.Drawing.Size(320, 38);
            this.LabelDoctorID.TabIndex = 0;
            this.LabelDoctorID.Text = "Date Of Admission";
            this.LabelDoctorID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelCategory
            // 
            this.LabelCategory.AutoSize = true;
            this.LabelCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelCategory.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCategory.Location = new System.Drawing.Point(3, 135);
            this.LabelCategory.Name = "LabelCategory";
            this.LabelCategory.Size = new System.Drawing.Size(320, 39);
            this.LabelCategory.TabIndex = 0;
            this.LabelCategory.Text = "Date Of Descharge";
            this.LabelCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelDate
            // 
            this.LabelDate.AutoSize = true;
            this.LabelDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelDate.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDate.Location = new System.Drawing.Point(3, 338);
            this.LabelDate.Name = "LabelDate";
            this.LabelDate.Size = new System.Drawing.Size(320, 50);
            this.LabelDate.TabIndex = 11;
            this.LabelDate.Text = "Status";
            this.LabelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxPatientID
            // 
            this.comboBoxPatientID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPatientID.FormattingEnabled = true;
            this.comboBoxPatientID.Location = new System.Drawing.Point(329, 58);
            this.comboBoxPatientID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPatientID.Name = "comboBoxPatientID";
            this.comboBoxPatientID.Size = new System.Drawing.Size(1006, 34);
            this.comboBoxPatientID.TabIndex = 18;
            this.comboBoxPatientID.Text = "Select";
            this.comboBoxPatientID.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatientID_SelectedIndexChanged);
            // 
            // dateOfDescharge
            // 
            this.dateOfDescharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateOfDescharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfDescharge.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfDescharge.Location = new System.Drawing.Point(329, 137);
            this.dateOfDescharge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateOfDescharge.Name = "dateOfDescharge";
            this.dateOfDescharge.Size = new System.Drawing.Size(1006, 32);
            this.dateOfDescharge.TabIndex = 20;
            this.dateOfDescharge.ValueChanged += new System.EventHandler(this.dateOfDescharge_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 54);
            this.label2.TabIndex = 2;
            this.label2.Text = "LabCharge";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Poppins", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 54);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total";
            // 
            // dateOfAdmission
            // 
            this.dateOfAdmission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateOfAdmission.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfAdmission.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateOfAdmission.Location = new System.Drawing.Point(329, 99);
            this.dateOfAdmission.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateOfAdmission.Name = "dateOfAdmission";
            this.dateOfAdmission.Size = new System.Drawing.Size(1006, 32);
            this.dateOfAdmission.TabIndex = 20;
            this.dateOfAdmission.ValueChanged += new System.EventHandler(this.dateOfAdmission_ValueChanged);
            // 
            // textBoxBillNo
            // 
            this.textBoxBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBillNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBillNo.Location = new System.Drawing.Point(329, 4);
            this.textBoxBillNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxBillNo.Multiline = true;
            this.textBoxBillNo.Name = "textBoxBillNo";
            this.textBoxBillNo.Size = new System.Drawing.Size(1006, 48);
            this.textBoxBillNo.TabIndex = 15;
            // 
            // textBoxRoomCharge
            // 
            this.textBoxRoomCharge.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxRoomCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRoomCharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRoomCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRoomCharge.Location = new System.Drawing.Point(329, 178);
            this.textBoxRoomCharge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRoomCharge.Multiline = true;
            this.textBoxRoomCharge.Name = "textBoxRoomCharge";
            this.textBoxRoomCharge.ReadOnly = true;
            this.textBoxRoomCharge.Size = new System.Drawing.Size(1006, 48);
            this.textBoxRoomCharge.TabIndex = 15;
            this.textBoxRoomCharge.Text = "0.0000";
            // 
            // textBoxLabCharge
            // 
            this.textBoxLabCharge.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxLabCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLabCharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLabCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLabCharge.Location = new System.Drawing.Point(329, 234);
            this.textBoxLabCharge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxLabCharge.Multiline = true;
            this.textBoxLabCharge.Name = "textBoxLabCharge";
            this.textBoxLabCharge.ReadOnly = true;
            this.textBoxLabCharge.Size = new System.Drawing.Size(1006, 46);
            this.textBoxLabCharge.TabIndex = 15;
            this.textBoxLabCharge.Text = "0.0000";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(329, 288);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTotal.Multiline = true;
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(1006, 46);
            this.textBoxTotal.TabIndex = 15;
            this.textBoxTotal.Text = "0.0000";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Sent",
            "Paid"});
            this.comboBoxStatus.Location = new System.Drawing.Point(329, 340);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(1006, 34);
            this.comboBoxStatus.TabIndex = 18;
            this.comboBoxStatus.Text = "Select";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ClearButton);
            this.panel3.Controls.Add(this.SearchButton);
            this.panel3.Controls.Add(this.TextBoxSearch);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.UpdateButton);
            this.panel3.Controls.Add(this.AddButton);
            this.panel3.Controls.Add(this.ResetButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 400);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1338, 127);
            this.panel3.TabIndex = 1;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.ForestGreen;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ClearButton.Location = new System.Drawing.Point(1244, 78);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(92, 41);
            this.ClearButton.TabIndex = 13;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.ForestGreen;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.ForeColor = System.Drawing.SystemColors.Control;
            this.SearchButton.Location = new System.Drawing.Point(1132, 78);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(92, 41);
            this.SearchButton.TabIndex = 13;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxSearch.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxSearch.Location = new System.Drawing.Point(794, 78);
            this.TextBoxSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TextBoxSearch.Multiline = true;
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(315, 41);
            this.TextBoxSearch.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(351, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.ForestGreen;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(237, 28);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(107, 49);
            this.UpdateButton.TabIndex = 0;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = false;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.ForestGreen;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.ForeColor = System.Drawing.Color.White;
            this.AddButton.Location = new System.Drawing.Point(124, 28);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(107, 49);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.ResetButton.Location = new System.Drawing.Point(10, 28);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(107, 49);
            this.ResetButton.TabIndex = 0;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 626);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panel2.Size = new System.Drawing.Size(1366, 248);
            this.panel2.TabIndex = 13;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 25;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._BillNo,
            this._PatientID,
            this._DateAdmission,
            this._DateDescharge,
            this._RoomNo,
            this._LabNo,
            this._Total,
            this._Status,
            this.print});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView.Location = new System.Drawing.Point(11, 12);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 32;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1344, 228);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // _BillNo
            // 
            this._BillNo.HeaderText = "BillNo";
            this._BillNo.MinimumWidth = 8;
            this._BillNo.Name = "_BillNo";
            this._BillNo.ReadOnly = true;
            // 
            // _PatientID
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this._PatientID.DefaultCellStyle = dataGridViewCellStyle2;
            this._PatientID.HeaderText = "PatientID";
            this._PatientID.MinimumWidth = 6;
            this._PatientID.Name = "_PatientID";
            this._PatientID.ReadOnly = true;
            // 
            // _DateAdmission
            // 
            this._DateAdmission.HeaderText = "Date Of Admission";
            this._DateAdmission.MinimumWidth = 6;
            this._DateAdmission.Name = "_DateAdmission";
            this._DateAdmission.ReadOnly = true;
            // 
            // _DateDescharge
            // 
            this._DateDescharge.HeaderText = "Date Of Descharge";
            this._DateDescharge.MinimumWidth = 6;
            this._DateDescharge.Name = "_DateDescharge";
            this._DateDescharge.ReadOnly = true;
            // 
            // _RoomNo
            // 
            this._RoomNo.HeaderText = "RoomNo";
            this._RoomNo.MinimumWidth = 6;
            this._RoomNo.Name = "_RoomNo";
            this._RoomNo.ReadOnly = true;
            // 
            // _LabNo
            // 
            this._LabNo.HeaderText = "LabNo";
            this._LabNo.MinimumWidth = 6;
            this._LabNo.Name = "_LabNo";
            this._LabNo.ReadOnly = true;
            // 
            // _Total
            // 
            this._Total.HeaderText = "Total";
            this._Total.MinimumWidth = 8;
            this._Total.Name = "_Total";
            this._Total.ReadOnly = true;
            // 
            // _Status
            // 
            this._Status.HeaderText = "Status";
            this._Status.MinimumWidth = 6;
            this._Status.Name = "_Status";
            this._Status.ReadOnly = true;
            // 
            // print
            // 
            this.print.HeaderText = "Print";
            this.print.Image = ((System.Drawing.Image)(resources.GetObject("print.Image")));
            this.print.MinimumWidth = 6;
            this.print.Name = "print";
            this.print.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1366, 76);
            this.label1.TabIndex = 12;
            this.label1.Text = "InPatientBill Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InPatientBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 874);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InPatientBillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InPatientBillForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InPatientBillForm_Closed);
            this.Load += new System.EventHandler(this.InPatientBillForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LabelDescription;
        private System.Windows.Forms.Label LabelLabNo;
        private System.Windows.Forms.Label LabelPatientID;
        private System.Windows.Forms.Label LabelDoctorID;
        private System.Windows.Forms.Label LabelCategory;
        private System.Windows.Forms.Label LabelDate;
        private System.Windows.Forms.ComboBox comboBoxPatientID;
        private System.Windows.Forms.DateTimePicker dateOfDescharge;
        private System.Windows.Forms.DateTimePicker dateOfAdmission;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBillNo;
        private System.Windows.Forms.TextBox textBoxRoomCharge;
        private System.Windows.Forms.TextBox textBoxLabCharge;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn _BillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _PatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _DateAdmission;
        private System.Windows.Forms.DataGridViewTextBoxColumn _DateDescharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn _RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _LabNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Status;
        private System.Windows.Forms.DataGridViewImageColumn print;
        private System.Windows.Forms.Button button1;
    }
}
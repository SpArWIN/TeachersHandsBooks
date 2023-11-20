
namespace TeachersHandsBooks
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.HomePage = new System.Windows.Forms.TabPage();
            this.GridRaspisanie = new Guna.UI2.WinForms.Guna2DataGridView();
            this.GroupAddBOx = new Guna.UI2.WinForms.Guna2GroupBox();
            this.BoxUpdate = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FormRasp = new System.Windows.Forms.PictureBox();
            this.BtnDispAdd = new System.Windows.Forms.PictureBox();
            this.BtnConnectionDispGroup = new System.Windows.Forms.PictureBox();
            this.BtnAddGroup = new System.Windows.Forms.PictureBox();
            this.Theory = new System.Windows.Forms.TabPage();
            this.Practice = new System.Windows.Forms.TabPage();
            this.KTpPages = new System.Windows.Forms.TabPage();
            this.PageMarks = new System.Windows.Forms.TabPage();
            this.PageSettings = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.BtnGreenRad = new MaterialSkin.Controls.MaterialRadioButton();
            this.BtnSaveChangeTheme = new MaterialSkin.Controls.MaterialButton();
            this.BtnOrangeRad = new MaterialSkin.Controls.MaterialRadioButton();
            this.BtnRedRad = new MaterialSkin.Controls.MaterialRadioButton();
            this.BtnBlueRad = new MaterialSkin.Controls.MaterialRadioButton();
            this.LabelSmen = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SwitchTheme = new MaterialSkin.Controls.MaterialSwitch();
            this.AboutProgramm = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainTabControl.SuspendLayout();
            this.HomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridRaspisanie)).BeginInit();
            this.GroupAddBOx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormRasp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDispAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConnectionDispGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddGroup)).BeginInit();
            this.PageSettings.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.HomePage);
            this.MainTabControl.Controls.Add(this.Theory);
            this.MainTabControl.Controls.Add(this.Practice);
            this.MainTabControl.Controls.Add(this.KTpPages);
            this.MainTabControl.Controls.Add(this.PageMarks);
            this.MainTabControl.Controls.Add(this.PageSettings);
            this.MainTabControl.Controls.Add(this.AboutProgramm);
            this.MainTabControl.Depth = 0;
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainTabControl.ImageList = this.imageList1;
            this.MainTabControl.Location = new System.Drawing.Point(3, 64);
            this.MainTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.MainTabControl.Multiline = true;
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1131, 597);
            this.MainTabControl.TabIndex = 0;
            // 
            // HomePage
            // 
            this.HomePage.Controls.Add(this.GridRaspisanie);
            this.HomePage.Controls.Add(this.GroupAddBOx);
            this.HomePage.ImageKey = "home.png";
            this.HomePage.Location = new System.Drawing.Point(4, 30);
            this.HomePage.Name = "HomePage";
            this.HomePage.Size = new System.Drawing.Size(1123, 563);
            this.HomePage.TabIndex = 0;
            this.HomePage.Text = "Главная";
            this.HomePage.UseVisualStyleBackColor = true;
            // 
            // GridRaspisanie
            // 
            this.GridRaspisanie.AllowUserToAddRows = false;
            this.GridRaspisanie.AllowUserToDeleteRows = false;
            this.GridRaspisanie.AllowUserToOrderColumns = true;
            this.GridRaspisanie.AllowUserToResizeColumns = false;
            this.GridRaspisanie.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridRaspisanie.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridRaspisanie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridRaspisanie.BackgroundColor = System.Drawing.Color.White;
            this.GridRaspisanie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridRaspisanie.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridRaspisanie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRaspisanie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridRaspisanie.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridRaspisanie.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridRaspisanie.EnableHeadersVisualStyles = false;
            this.GridRaspisanie.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridRaspisanie.Location = new System.Drawing.Point(3, 111);
            this.GridRaspisanie.Name = "GridRaspisanie";
            this.GridRaspisanie.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridRaspisanie.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridRaspisanie.RowHeadersVisible = false;
            this.GridRaspisanie.RowTemplate.Height = 35;
            this.GridRaspisanie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridRaspisanie.Size = new System.Drawing.Size(1117, 438);
            this.GridRaspisanie.TabIndex = 2;
            this.GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.GridRaspisanie.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GridRaspisanie.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridRaspisanie.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridRaspisanie.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridRaspisanie.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridRaspisanie.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GridRaspisanie.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridRaspisanie.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GridRaspisanie.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridRaspisanie.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridRaspisanie.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GridRaspisanie.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GridRaspisanie.ThemeStyle.HeaderStyle.Height = 29;
            this.GridRaspisanie.ThemeStyle.ReadOnly = false;
            this.GridRaspisanie.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GridRaspisanie.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridRaspisanie.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridRaspisanie.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridRaspisanie.ThemeStyle.RowsStyle.Height = 35;
            this.GridRaspisanie.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridRaspisanie.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridRaspisanie.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.GridRaspisanie_RowPrePaint);
            // 
            // GroupAddBOx
            // 
            this.GroupAddBOx.BackColor = System.Drawing.Color.Transparent;
            this.GroupAddBOx.BorderColor = System.Drawing.Color.DarkGray;
            this.GroupAddBOx.BorderRadius = 6;
            this.GroupAddBOx.BorderThickness = 2;
            this.GroupAddBOx.Controls.Add(this.BoxUpdate);
            this.GroupAddBOx.Controls.Add(this.label2);
            this.GroupAddBOx.Controls.Add(this.label1);
            this.GroupAddBOx.Controls.Add(this.FormRasp);
            this.GroupAddBOx.Controls.Add(this.BtnDispAdd);
            this.GroupAddBOx.Controls.Add(this.BtnConnectionDispGroup);
            this.GroupAddBOx.Controls.Add(this.BtnAddGroup);
            this.GroupAddBOx.CustomBorderColor = System.Drawing.Color.Silver;
            this.GroupAddBOx.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupAddBOx.FillColor = System.Drawing.SystemColors.ControlLight;
            this.GroupAddBOx.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupAddBOx.ForeColor = System.Drawing.Color.Transparent;
            this.GroupAddBOx.Location = new System.Drawing.Point(0, 0);
            this.GroupAddBOx.Name = "GroupAddBOx";
            this.GroupAddBOx.ShadowDecoration.Parent = this.GroupAddBOx;
            this.GroupAddBOx.Size = new System.Drawing.Size(1123, 105);
            this.GroupAddBOx.TabIndex = 1;
            this.GroupAddBOx.Text = "Формирование учебного процесса";
            this.GroupAddBOx.UseTransparentBackground = true;
            this.GroupAddBOx.Click += new System.EventHandler(this.GroupAddBOx_Click);
            // 
            // BoxUpdate
            // 
            this.BoxUpdate.BackColor = System.Drawing.Color.Transparent;
            this.BoxUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoxUpdate.Location = new System.Drawing.Point(269, 54);
            this.BoxUpdate.Name = "BoxUpdate";
            this.BoxUpdate.Size = new System.Drawing.Size(51, 39);
            this.BoxUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BoxUpdate.TabIndex = 6;
            this.BoxUpdate.TabStop = false;
            this.BoxUpdate.Click += new System.EventHandler(this.BoxUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(425, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(428, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // FormRasp
            // 
            this.FormRasp.BackColor = System.Drawing.Color.Transparent;
            this.FormRasp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormRasp.Image = ((System.Drawing.Image)(resources.GetObject("FormRasp.Image")));
            this.FormRasp.Location = new System.Drawing.Point(212, 54);
            this.FormRasp.Name = "FormRasp";
            this.FormRasp.Size = new System.Drawing.Size(51, 37);
            this.FormRasp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FormRasp.TabIndex = 4;
            this.FormRasp.TabStop = false;
            this.FormRasp.Click += new System.EventHandler(this.FormRasp_Click_1);
            this.FormRasp.MouseEnter += new System.EventHandler(this.FormRasp_MouseEnter);
            this.FormRasp.MouseLeave += new System.EventHandler(this.FormRasp_MouseLeave);
            // 
            // BtnDispAdd
            // 
            this.BtnDispAdd.BackColor = System.Drawing.Color.Transparent;
            this.BtnDispAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDispAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnDispAdd.Image")));
            this.BtnDispAdd.Location = new System.Drawing.Point(87, 54);
            this.BtnDispAdd.Name = "BtnDispAdd";
            this.BtnDispAdd.Size = new System.Drawing.Size(51, 37);
            this.BtnDispAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnDispAdd.TabIndex = 3;
            this.BtnDispAdd.TabStop = false;
            this.BtnDispAdd.Click += new System.EventHandler(this.BtnDispAdd_Click_1);
            this.BtnDispAdd.MouseEnter += new System.EventHandler(this.BtnDispAdd_MouseEnter);
            this.BtnDispAdd.MouseLeave += new System.EventHandler(this.BtnDispAdd_MouseLeave);
            // 
            // BtnConnectionDispGroup
            // 
            this.BtnConnectionDispGroup.BackColor = System.Drawing.Color.Transparent;
            this.BtnConnectionDispGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnConnectionDispGroup.Image = ((System.Drawing.Image)(resources.GetObject("BtnConnectionDispGroup.Image")));
            this.BtnConnectionDispGroup.Location = new System.Drawing.Point(144, 54);
            this.BtnConnectionDispGroup.Name = "BtnConnectionDispGroup";
            this.BtnConnectionDispGroup.Size = new System.Drawing.Size(51, 37);
            this.BtnConnectionDispGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnConnectionDispGroup.TabIndex = 2;
            this.BtnConnectionDispGroup.TabStop = false;
            this.BtnConnectionDispGroup.Click += new System.EventHandler(this.BtnConnectionDispGroup_Click);
            this.BtnConnectionDispGroup.MouseEnter += new System.EventHandler(this.BtnConnectionDispGroup_MouseEnter);
            this.BtnConnectionDispGroup.MouseLeave += new System.EventHandler(this.BtnConnectionDispGroup_MouseLeave);
            // 
            // BtnAddGroup
            // 
            this.BtnAddGroup.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddGroup.Image")));
            this.BtnAddGroup.Location = new System.Drawing.Point(20, 54);
            this.BtnAddGroup.Name = "BtnAddGroup";
            this.BtnAddGroup.Size = new System.Drawing.Size(51, 37);
            this.BtnAddGroup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnAddGroup.TabIndex = 1;
            this.BtnAddGroup.TabStop = false;
            this.BtnAddGroup.Click += new System.EventHandler(this.BtnAddGroup_Click_1);
            this.BtnAddGroup.MouseEnter += new System.EventHandler(this.BtnAddGroup_MouseEnter);
            this.BtnAddGroup.MouseLeave += new System.EventHandler(this.BtnAddGroup_MouseLeave);
            // 
            // Theory
            // 
            this.Theory.ImageKey = "border-color.png";
            this.Theory.Location = new System.Drawing.Point(4, 30);
            this.Theory.Name = "Theory";
            this.Theory.Size = new System.Drawing.Size(1123, 563);
            this.Theory.TabIndex = 1;
            this.Theory.Text = "Теория";
            this.Theory.UseVisualStyleBackColor = true;
            // 
            // Practice
            // 
            this.Practice.ImageKey = "address-book-open.png";
            this.Practice.Location = new System.Drawing.Point(4, 30);
            this.Practice.Name = "Practice";
            this.Practice.Size = new System.Drawing.Size(1123, 563);
            this.Practice.TabIndex = 2;
            this.Practice.Text = "Практика";
            this.Practice.UseVisualStyleBackColor = true;
            // 
            // KTpPages
            // 
            this.KTpPages.ImageKey = "application-detail.png";
            this.KTpPages.Location = new System.Drawing.Point(4, 30);
            this.KTpPages.Name = "KTpPages";
            this.KTpPages.Size = new System.Drawing.Size(1123, 563);
            this.KTpPages.TabIndex = 3;
            this.KTpPages.Text = "КТП";
            this.KTpPages.UseVisualStyleBackColor = true;
            // 
            // PageMarks
            // 
            this.PageMarks.ImageKey = "plus-button.png";
            this.PageMarks.Location = new System.Drawing.Point(4, 30);
            this.PageMarks.Name = "PageMarks";
            this.PageMarks.Size = new System.Drawing.Size(1123, 563);
            this.PageMarks.TabIndex = 4;
            this.PageMarks.Text = "Оценки";
            this.PageMarks.UseVisualStyleBackColor = true;
            // 
            // PageSettings
            // 
            this.PageSettings.Controls.Add(this.materialCard1);
            this.PageSettings.ImageKey = "setting_tools.png";
            this.PageSettings.Location = new System.Drawing.Point(4, 30);
            this.PageSettings.Name = "PageSettings";
            this.PageSettings.Size = new System.Drawing.Size(1123, 563);
            this.PageSettings.TabIndex = 5;
            this.PageSettings.Text = "Настройки";
            this.PageSettings.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.BtnGreenRad);
            this.materialCard1.Controls.Add(this.BtnSaveChangeTheme);
            this.materialCard1.Controls.Add(this.BtnOrangeRad);
            this.materialCard1.Controls.Add(this.BtnRedRad);
            this.materialCard1.Controls.Add(this.BtnBlueRad);
            this.materialCard1.Controls.Add(this.LabelSmen);
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Controls.Add(this.SwitchTheme);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(14, 14);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(463, 268);
            this.materialCard1.TabIndex = 1;
            // 
            // BtnGreenRad
            // 
            this.BtnGreenRad.AutoSize = true;
            this.BtnGreenRad.Depth = 0;
            this.BtnGreenRad.Location = new System.Drawing.Point(24, 169);
            this.BtnGreenRad.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGreenRad.MouseLocation = new System.Drawing.Point(-1, -1);
            this.BtnGreenRad.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnGreenRad.Name = "BtnGreenRad";
            this.BtnGreenRad.Ripple = true;
            this.BtnGreenRad.Size = new System.Drawing.Size(100, 37);
            this.BtnGreenRad.TabIndex = 10;
            this.BtnGreenRad.TabStop = true;
            this.BtnGreenRad.Text = "Зеленый";
            this.BtnGreenRad.UseVisualStyleBackColor = true;
            this.BtnGreenRad.CheckedChanged += new System.EventHandler(this.BtnGreenRad_CheckedChanged_1);
            // 
            // BtnSaveChangeTheme
            // 
            this.BtnSaveChangeTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSaveChangeTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSaveChangeTheme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnSaveChangeTheme.Depth = 0;
            this.BtnSaveChangeTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveChangeTheme.HighEmphasis = true;
            this.BtnSaveChangeTheme.Icon = null;
            this.BtnSaveChangeTheme.Location = new System.Drawing.Point(91, 212);
            this.BtnSaveChangeTheme.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnSaveChangeTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnSaveChangeTheme.Name = "BtnSaveChangeTheme";
            this.BtnSaveChangeTheme.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnSaveChangeTheme.Size = new System.Drawing.Size(203, 36);
            this.BtnSaveChangeTheme.TabIndex = 9;
            this.BtnSaveChangeTheme.Text = "Сохранить изменения";
            this.BtnSaveChangeTheme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnSaveChangeTheme.UseAccentColor = false;
            this.BtnSaveChangeTheme.UseVisualStyleBackColor = true;
            this.BtnSaveChangeTheme.Click += new System.EventHandler(this.BtnSaveChangeTheme_Click_1);
            // 
            // BtnOrangeRad
            // 
            this.BtnOrangeRad.AutoSize = true;
            this.BtnOrangeRad.Depth = 0;
            this.BtnOrangeRad.Location = new System.Drawing.Point(24, 134);
            this.BtnOrangeRad.Margin = new System.Windows.Forms.Padding(0);
            this.BtnOrangeRad.MouseLocation = new System.Drawing.Point(-1, -1);
            this.BtnOrangeRad.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnOrangeRad.Name = "BtnOrangeRad";
            this.BtnOrangeRad.Ripple = true;
            this.BtnOrangeRad.Size = new System.Drawing.Size(123, 37);
            this.BtnOrangeRad.TabIndex = 8;
            this.BtnOrangeRad.TabStop = true;
            this.BtnOrangeRad.Text = "Оранжевый";
            this.BtnOrangeRad.UseVisualStyleBackColor = true;
            this.BtnOrangeRad.CheckedChanged += new System.EventHandler(this.BtnOrangeRad_CheckedChanged);
            // 
            // BtnRedRad
            // 
            this.BtnRedRad.AutoSize = true;
            this.BtnRedRad.Depth = 0;
            this.BtnRedRad.Location = new System.Drawing.Point(24, 97);
            this.BtnRedRad.Margin = new System.Windows.Forms.Padding(0);
            this.BtnRedRad.MouseLocation = new System.Drawing.Point(-1, -1);
            this.BtnRedRad.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnRedRad.Name = "BtnRedRad";
            this.BtnRedRad.Ripple = true;
            this.BtnRedRad.Size = new System.Drawing.Size(101, 37);
            this.BtnRedRad.TabIndex = 7;
            this.BtnRedRad.TabStop = true;
            this.BtnRedRad.Text = "Красный";
            this.BtnRedRad.UseVisualStyleBackColor = true;
            this.BtnRedRad.CheckedChanged += new System.EventHandler(this.BtnRedRad_CheckedChanged);
            // 
            // BtnBlueRad
            // 
            this.BtnBlueRad.AutoSize = true;
            this.BtnBlueRad.Depth = 0;
            this.BtnBlueRad.Location = new System.Drawing.Point(24, 60);
            this.BtnBlueRad.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBlueRad.MouseLocation = new System.Drawing.Point(-1, -1);
            this.BtnBlueRad.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnBlueRad.Name = "BtnBlueRad";
            this.BtnBlueRad.Ripple = true;
            this.BtnBlueRad.Size = new System.Drawing.Size(81, 37);
            this.BtnBlueRad.TabIndex = 6;
            this.BtnBlueRad.TabStop = true;
            this.BtnBlueRad.Text = "Синий";
            this.BtnBlueRad.UseVisualStyleBackColor = true;
            this.BtnBlueRad.CheckedChanged += new System.EventHandler(this.BtnBlueRad_CheckedChanged);
            // 
            // LabelSmen
            // 
            this.LabelSmen.AutoSize = true;
            this.LabelSmen.Depth = 0;
            this.LabelSmen.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LabelSmen.Location = new System.Drawing.Point(112, 25);
            this.LabelSmen.MouseState = MaterialSkin.MouseState.HOVER;
            this.LabelSmen.Name = "LabelSmen";
            this.LabelSmen.Size = new System.Drawing.Size(121, 19);
            this.LabelSmen.TabIndex = 2;
            this.LabelSmen.Text = "на тёмную тему";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(8, 25);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(97, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Смена темы:";
            // 
            // SwitchTheme
            // 
            this.SwitchTheme.AutoSize = true;
            this.SwitchTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchTheme.Depth = 0;
            this.SwitchTheme.Location = new System.Drawing.Point(341, 25);
            this.SwitchTheme.Margin = new System.Windows.Forms.Padding(0);
            this.SwitchTheme.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SwitchTheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.SwitchTheme.Name = "SwitchTheme";
            this.SwitchTheme.Ripple = true;
            this.SwitchTheme.Size = new System.Drawing.Size(58, 37);
            this.SwitchTheme.TabIndex = 0;
            this.SwitchTheme.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SwitchTheme.UseVisualStyleBackColor = true;
            this.SwitchTheme.CheckedChanged += new System.EventHandler(this.SwitchTheme_CheckedChanged);
            // 
            // AboutProgramm
            // 
            this.AboutProgramm.ImageKey = "block.png";
            this.AboutProgramm.Location = new System.Drawing.Point(4, 30);
            this.AboutProgramm.Name = "AboutProgramm";
            this.AboutProgramm.Size = new System.Drawing.Size(1123, 563);
            this.AboutProgramm.TabIndex = 6;
            this.AboutProgramm.Text = "О программе";
            this.AboutProgramm.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "home.png");
            this.imageList1.Images.SetKeyName(1, "border-color.png");
            this.imageList1.Images.SetKeyName(2, "address-book-open.png");
            this.imageList1.Images.SetKeyName(3, "application-detail.png");
            this.imageList1.Images.SetKeyName(4, "plus-button.png");
            this.imageList1.Images.SetKeyName(5, "setting_tools.png");
            this.imageList1.Images.SetKeyName(6, "block.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 664);
            this.Controls.Add(this.MainTabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.MainTabControl;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainTabControl.ResumeLayout(false);
            this.HomePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridRaspisanie)).EndInit();
            this.GroupAddBOx.ResumeLayout(false);
            this.GroupAddBOx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormRasp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDispAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnConnectionDispGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddGroup)).EndInit();
            this.PageSettings.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl MainTabControl;
        private System.Windows.Forms.TabPage HomePage;
        private System.Windows.Forms.TabPage Theory;
        private System.Windows.Forms.TabPage Practice;
        private System.Windows.Forms.TabPage KTpPages;
        private System.Windows.Forms.TabPage PageMarks;
        private System.Windows.Forms.TabPage PageSettings;
        private System.Windows.Forms.TabPage AboutProgramm;
        private System.Windows.Forms.ImageList imageList1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialRadioButton BtnGreenRad;
        private MaterialSkin.Controls.MaterialButton BtnSaveChangeTheme;
        private MaterialSkin.Controls.MaterialRadioButton BtnOrangeRad;
        private MaterialSkin.Controls.MaterialRadioButton BtnRedRad;
        private MaterialSkin.Controls.MaterialRadioButton BtnBlueRad;
        private MaterialSkin.Controls.MaterialLabel LabelSmen;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSwitch SwitchTheme;
        private Guna.UI2.WinForms.Guna2GroupBox GroupAddBOx;
        private System.Windows.Forms.PictureBox FormRasp;
        private System.Windows.Forms.PictureBox BtnDispAdd;
        private System.Windows.Forms.PictureBox BtnConnectionDispGroup;
        private System.Windows.Forms.PictureBox BtnAddGroup;
        private Guna.UI2.WinForms.Guna2DataGridView GridRaspisanie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox BoxUpdate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}


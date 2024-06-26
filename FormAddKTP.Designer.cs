﻿
namespace TeachersHandsBooks
{
    partial class FormAddKTP
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
            this.KTPPath = new MaterialSkin.Controls.MaterialCard();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenDialog = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnCreateAdd = new MaterialSkin.Controls.MaterialButton();
            this.GridKTPControll = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KTPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Displines = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridKTPControll)).BeginInit();
            this.guna2CircleProgressBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KTPPath
            // 
            this.KTPPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KTPPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.KTPPath.Depth = 0;
            this.KTPPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.KTPPath.Location = new System.Drawing.Point(142, 78);
            this.KTPPath.Margin = new System.Windows.Forms.Padding(14);
            this.KTPPath.MouseState = MaterialSkin.MouseState.HOVER;
            this.KTPPath.Name = "KTPPath";
            this.KTPPath.Padding = new System.Windows.Forms.Padding(14);
            this.KTPPath.Size = new System.Drawing.Size(488, 20);
            this.KTPPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите КТП";
            // 
            // OpenDialog
            // 
            this.OpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenDialog.AutoSize = true;
            this.OpenDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenDialog.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenDialog.Location = new System.Drawing.Point(633, 78);
            this.OpenDialog.Name = "OpenDialog";
            this.OpenDialog.Size = new System.Drawing.Size(27, 25);
            this.OpenDialog.TabIndex = 6;
            this.OpenDialog.Text = "...";
            this.OpenDialog.Click += new System.EventHandler(this.label4_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtnCreateAdd
            // 
            this.BtnCreateAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnCreateAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCreateAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnCreateAdd.Depth = 0;
            this.BtnCreateAdd.Enabled = false;
            this.BtnCreateAdd.HighEmphasis = true;
            this.BtnCreateAdd.Icon = null;
            this.BtnCreateAdd.Location = new System.Drawing.Point(326, 405);
            this.BtnCreateAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnCreateAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnCreateAdd.Name = "BtnCreateAdd";
            this.BtnCreateAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnCreateAdd.Size = new System.Drawing.Size(104, 36);
            this.BtnCreateAdd.TabIndex = 8;
            this.BtnCreateAdd.Text = "Загрузить";
            this.BtnCreateAdd.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BtnCreateAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnCreateAdd.UseAccentColor = false;
            this.BtnCreateAdd.UseVisualStyleBackColor = true;
            this.BtnCreateAdd.Click += new System.EventHandler(this.BtnCreateAdd_Click);
            // 
            // GridKTPControll
            // 
            this.GridKTPControll.AllowUserToAddRows = false;
            this.GridKTPControll.AllowUserToDeleteRows = false;
            this.GridKTPControll.AllowUserToOrderColumns = true;
            this.GridKTPControll.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridKTPControll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridKTPControll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridKTPControll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridKTPControll.BackgroundColor = System.Drawing.Color.White;
            this.GridKTPControll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridKTPControll.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridKTPControll.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridKTPControll.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridKTPControll.ColumnHeadersHeight = 21;
            this.GridKTPControll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.GroupNameColumn,
            this.KTPS,
            this.Displines});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridKTPControll.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridKTPControll.EnableHeadersVisualStyles = false;
            this.GridKTPControll.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridKTPControll.Location = new System.Drawing.Point(18, 115);
            this.GridKTPControll.Name = "GridKTPControll";
            this.GridKTPControll.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridKTPControll.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridKTPControll.RowHeadersVisible = false;
            this.GridKTPControll.RowTemplate.Height = 26;
            this.GridKTPControll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridKTPControll.Size = new System.Drawing.Size(759, 264);
            this.GridKTPControll.TabIndex = 9;
            this.GridKTPControll.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.GridKTPControll.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GridKTPControll.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridKTPControll.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridKTPControll.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridKTPControll.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridKTPControll.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GridKTPControll.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridKTPControll.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.GridKTPControll.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridKTPControll.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.GridKTPControll.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GridKTPControll.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GridKTPControll.ThemeStyle.HeaderStyle.Height = 21;
            this.GridKTPControll.ThemeStyle.ReadOnly = false;
            this.GridKTPControll.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GridKTPControll.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridKTPControll.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.GridKTPControll.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridKTPControll.ThemeStyle.RowsStyle.Height = 26;
            this.GridKTPControll.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridKTPControll.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridKTPControll.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GridKTPControll_DataError);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID_Группы";
            this.Column1.MaxInputLength = 40;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // GroupNameColumn
            // 
            this.GroupNameColumn.HeaderText = "Наименование группы";
            this.GroupNameColumn.MaxInputLength = 40;
            this.GroupNameColumn.Name = "GroupNameColumn";
            // 
            // KTPS
            // 
            this.KTPS.HeaderText = "КТП";
            this.KTPS.MaxInputLength = 50;
            this.KTPS.Name = "KTPS";
            // 
            // Displines
            // 
            this.Displines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Displines.HeaderText = "Дисциплина";
            this.Displines.Name = "Displines";
            this.Displines.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Displines.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.Animated = true;
            this.guna2CircleProgressBar1.AnimationSpeed = 0.8F;
            this.guna2CircleProgressBar1.Controls.Add(this.label5);
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(799, 144);
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.Green;
            this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.Lime;
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.ShadowDecoration.Parent = this.guna2CircleProgressBar1;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(214, 185);
            this.guna2CircleProgressBar1.TabIndex = 10;
            this.guna2CircleProgressBar1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(65, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Загрузка...";
            // 
            // FormAddKTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2CircleProgressBar1);
            this.Controls.Add(this.GridKTPControll);
            this.Controls.Add(this.BtnCreateAdd);
            this.Controls.Add(this.OpenDialog);
            this.Controls.Add(this.KTPPath);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "FormAddKTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прочная связь";
            this.Load += new System.EventHandler(this.FormAddKTP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridKTPControll)).EndInit();
            this.guna2CircleProgressBar1.ResumeLayout(false);
            this.guna2CircleProgressBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard KTPPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OpenDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialButton BtnCreateAdd;
        private Guna.UI2.WinForms.Guna2DataGridView GridKTPControll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTPS;
        private System.Windows.Forms.DataGridViewComboBoxColumn Displines;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private System.Windows.Forms.Label label5;
    }
}
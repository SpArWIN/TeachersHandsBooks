
namespace TeachersHandsBooks
{
    partial class Replacement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Replacement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnAddRows = new System.Windows.Forms.PictureBox();
            this.BtnDelRows = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GridTransmitt = new Guna.UI2.WinForms.Guna2DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDelRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTransmitt)).BeginInit();
            this.guna2CircleProgressBar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAddRows
            // 
            this.BtnAddRows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddRows.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddRows.Image")));
            this.BtnAddRows.Location = new System.Drawing.Point(6, 67);
            this.BtnAddRows.Name = "BtnAddRows";
            this.BtnAddRows.Size = new System.Drawing.Size(32, 32);
            this.BtnAddRows.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BtnAddRows.TabIndex = 0;
            this.BtnAddRows.TabStop = false;
            this.BtnAddRows.Click += new System.EventHandler(this.BtnAddRows_Click);
            this.BtnAddRows.MouseEnter += new System.EventHandler(this.BtnAddRows_MouseEnter);
            this.BtnAddRows.MouseLeave += new System.EventHandler(this.BtnAddRows_MouseLeave);
            // 
            // BtnDelRows
            // 
            this.BtnDelRows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelRows.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelRows.Image")));
            this.BtnDelRows.Location = new System.Drawing.Point(56, 67);
            this.BtnDelRows.Name = "BtnDelRows";
            this.BtnDelRows.Size = new System.Drawing.Size(32, 32);
            this.BtnDelRows.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BtnDelRows.TabIndex = 1;
            this.BtnDelRows.TabStop = false;
            this.BtnDelRows.Click += new System.EventHandler(this.BtnDelRows_Click);
            this.BtnDelRows.MouseEnter += new System.EventHandler(this.BtnDelRows_MouseEnter);
            this.BtnDelRows.MouseLeave += new System.EventHandler(this.BtnDelRows_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(354, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(498, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // GridTransmitt
            // 
            this.GridTransmitt.AllowUserToAddRows = false;
            this.GridTransmitt.AllowUserToDeleteRows = false;
            this.GridTransmitt.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridTransmitt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridTransmitt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridTransmitt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridTransmitt.BackgroundColor = System.Drawing.Color.White;
            this.GridTransmitt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridTransmitt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridTransmitt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridTransmitt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridTransmitt.ColumnHeadersHeight = 26;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridTransmitt.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridTransmitt.EnableHeadersVisualStyles = false;
            this.GridTransmitt.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridTransmitt.Location = new System.Drawing.Point(6, 105);
            this.GridTransmitt.Name = "GridTransmitt";
            this.GridTransmitt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridTransmitt.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridTransmitt.RowHeadersVisible = false;
            this.GridTransmitt.RowTemplate.Height = 30;
            this.GridTransmitt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridTransmitt.Size = new System.Drawing.Size(670, 239);
            this.GridTransmitt.TabIndex = 4;
            this.GridTransmitt.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.GridTransmitt.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GridTransmitt.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridTransmitt.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GridTransmitt.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridTransmitt.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridTransmitt.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GridTransmitt.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridTransmitt.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GridTransmitt.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GridTransmitt.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.GridTransmitt.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GridTransmitt.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GridTransmitt.ThemeStyle.HeaderStyle.Height = 26;
            this.GridTransmitt.ThemeStyle.ReadOnly = false;
            this.GridTransmitt.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GridTransmitt.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GridTransmitt.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.GridTransmitt.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridTransmitt.ThemeStyle.RowsStyle.Height = 30;
            this.GridTransmitt.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GridTransmitt.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GridTransmitt.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GridTransmitt_CellFormatting);
            // 
            // guna2CircleProgressBar1
            // 
            this.guna2CircleProgressBar1.Animated = true;
            this.guna2CircleProgressBar1.AnimationSpeed = 0.8F;
            this.guna2CircleProgressBar1.Controls.Add(this.label5);
            this.guna2CircleProgressBar1.Location = new System.Drawing.Point(163, 77);
            this.guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            this.guna2CircleProgressBar1.ProgressColor = System.Drawing.Color.Green;
            this.guna2CircleProgressBar1.ProgressColor2 = System.Drawing.Color.Lime;
            this.guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar1.ShadowDecoration.Parent = this.guna2CircleProgressBar1;
            this.guna2CircleProgressBar1.Size = new System.Drawing.Size(214, 185);
            this.guna2CircleProgressBar1.TabIndex = 12;
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
            // Replacement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 350);
            this.Controls.Add(this.guna2CircleProgressBar1);
            this.Controls.Add(this.GridTransmitt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDelRows);
            this.Controls.Add(this.BtnAddRows);
            this.Name = "Replacement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование расписания на";
            this.Load += new System.EventHandler(this.Replacement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnAddRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnDelRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridTransmitt)).EndInit();
            this.guna2CircleProgressBar1.ResumeLayout(false);
            this.guna2CircleProgressBar1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BtnAddRows;
        private System.Windows.Forms.PictureBox BtnDelRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView GridTransmitt;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private System.Windows.Forms.Label label5;
    }
}
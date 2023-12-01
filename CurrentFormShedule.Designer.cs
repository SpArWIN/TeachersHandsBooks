
namespace TeachersHandsBooks
{
    partial class CurrentFormShedule
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
            this.label1 = new System.Windows.Forms.Label();
            this.TimePicerCurrentDay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.TimePickerNext = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboxFormingItems = new Guna.UI2.WinForms.Guna2ComboBox();
            this.BtnForming = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(718, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "На какой промежуток времени, начиная с текущей даты необходимо сформировать распи" +
    "сание";
            // 
            // TimePicerCurrentDay
            // 
            this.TimePicerCurrentDay.BorderRadius = 4;
            this.TimePicerCurrentDay.CheckedState.Parent = this.TimePicerCurrentDay;
            this.TimePicerCurrentDay.Enabled = false;
            this.TimePicerCurrentDay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimePicerCurrentDay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.TimePicerCurrentDay.HoverState.Parent = this.TimePicerCurrentDay;
            this.TimePicerCurrentDay.Location = new System.Drawing.Point(40, 124);
            this.TimePicerCurrentDay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.TimePicerCurrentDay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.TimePicerCurrentDay.Name = "TimePicerCurrentDay";
            this.TimePicerCurrentDay.ShadowDecoration.Parent = this.TimePicerCurrentDay;
            this.TimePicerCurrentDay.Size = new System.Drawing.Size(200, 36);
            this.TimePicerCurrentDay.TabIndex = 1;
            this.TimePicerCurrentDay.Value = new System.DateTime(2023, 12, 2, 0, 0, 0, 0);
            // 
            // TimePickerNext
            // 
            this.TimePickerNext.BorderRadius = 4;
            this.TimePickerNext.CheckedState.Parent = this.TimePickerNext;
            this.TimePickerNext.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimePickerNext.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.TimePickerNext.HoverState.Parent = this.TimePickerNext;
            this.TimePickerNext.Location = new System.Drawing.Point(475, 124);
            this.TimePickerNext.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.TimePickerNext.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.TimePickerNext.Name = "TimePickerNext";
            this.TimePickerNext.ShadowDecoration.Parent = this.TimePickerNext;
            this.TimePickerNext.Size = new System.Drawing.Size(200, 36);
            this.TimePickerNext.TabIndex = 2;
            this.TimePickerNext.Value = new System.DateTime(2023, 12, 2, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(78, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Текущая дата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(439, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Окончательная дата формирования";
            // 
            // ComboxFormingItems
            // 
            this.ComboxFormingItems.BackColor = System.Drawing.Color.Transparent;
            this.ComboxFormingItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboxFormingItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboxFormingItems.FillColor = System.Drawing.Color.Transparent;
            this.ComboxFormingItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboxFormingItems.FocusedColor = System.Drawing.Color.Empty;
            this.ComboxFormingItems.FocusedState.Parent = this.ComboxFormingItems;
            this.ComboxFormingItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboxFormingItems.ForeColor = System.Drawing.Color.Black;
            this.ComboxFormingItems.FormattingEnabled = true;
            this.ComboxFormingItems.HoverState.Parent = this.ComboxFormingItems;
            this.ComboxFormingItems.ItemHeight = 30;
            this.ComboxFormingItems.ItemsAppearance.Parent = this.ComboxFormingItems;
            this.ComboxFormingItems.Location = new System.Drawing.Point(258, 158);
            this.ComboxFormingItems.Name = "ComboxFormingItems";
            this.ComboxFormingItems.ShadowDecoration.Parent = this.ComboxFormingItems;
            this.ComboxFormingItems.Size = new System.Drawing.Size(189, 36);
            this.ComboxFormingItems.TabIndex = 5;
            this.ComboxFormingItems.SelectedIndexChanged += new System.EventHandler(this.ComboxFormingItems_SelectedIndexChanged);
            // 
            // BtnForming
            // 
            this.BtnForming.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnForming.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnForming.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnForming.Depth = 0;
            this.BtnForming.Enabled = false;
            this.BtnForming.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnForming.HighEmphasis = true;
            this.BtnForming.Icon = null;
            this.BtnForming.Location = new System.Drawing.Point(270, 279);
            this.BtnForming.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnForming.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnForming.Name = "BtnForming";
            this.BtnForming.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnForming.Size = new System.Drawing.Size(142, 36);
            this.BtnForming.TabIndex = 6;
            this.BtnForming.Text = "Сформировать";
            this.BtnForming.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnForming.UseAccentColor = false;
            this.BtnForming.UseVisualStyleBackColor = true;
            // 
            // CurrentFormShedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 376);
            this.Controls.Add(this.BtnForming);
            this.Controls.Add(this.ComboxFormingItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimePickerNext);
            this.Controls.Add(this.TimePicerCurrentDay);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(745, 376);
            this.Name = "CurrentFormShedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование Расписания";
            this.Load += new System.EventHandler(this.CurrentFormShedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker TimePicerCurrentDay;
        private Guna.UI2.WinForms.Guna2DateTimePicker TimePickerNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox ComboxFormingItems;
        private MaterialSkin.Controls.MaterialButton BtnForming;
    }
}

namespace TeachersHandsBooks
{
    partial class FormDisplineAdd
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
            this.DispBoxAdd = new MaterialSkin.Controls.MaterialTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnDeleteDispline = new MaterialSkin.Controls.MaterialButton();
            this.BtnAddDisp = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // DispBoxAdd
            // 
            this.DispBoxAdd.AnimateReadOnly = false;
            this.DispBoxAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DispBoxAdd.Depth = 0;
            this.DispBoxAdd.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DispBoxAdd.Hint = "Введите дисциплину";
            this.DispBoxAdd.LeadingIcon = null;
            this.DispBoxAdd.Location = new System.Drawing.Point(182, 67);
            this.DispBoxAdd.MaxLength = 50;
            this.DispBoxAdd.MouseState = MaterialSkin.MouseState.OUT;
            this.DispBoxAdd.Multiline = false;
            this.DispBoxAdd.Name = "DispBoxAdd";
            this.DispBoxAdd.Size = new System.Drawing.Size(399, 50);
            this.DispBoxAdd.TabIndex = 1;
            this.DispBoxAdd.Text = "";
            this.DispBoxAdd.TrailingIcon = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(34, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Список дисциплин";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 132);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(728, 255);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // BtnDeleteDispline
            // 
            this.BtnDeleteDispline.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDeleteDispline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeleteDispline.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnDeleteDispline.Depth = 0;
            this.BtnDeleteDispline.HighEmphasis = true;
            this.BtnDeleteDispline.Icon = null;
            this.BtnDeleteDispline.Location = new System.Drawing.Point(376, 396);
            this.BtnDeleteDispline.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnDeleteDispline.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnDeleteDispline.Name = "BtnDeleteDispline";
            this.BtnDeleteDispline.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnDeleteDispline.Size = new System.Drawing.Size(91, 36);
            this.BtnDeleteDispline.TabIndex = 6;
            this.BtnDeleteDispline.Text = "Удалить";
            this.BtnDeleteDispline.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnDeleteDispline.UseAccentColor = false;
            this.BtnDeleteDispline.UseVisualStyleBackColor = true;
            this.BtnDeleteDispline.Visible = false;
            // 
            // BtnAddDisp
            // 
            this.BtnAddDisp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnAddDisp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddDisp.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnAddDisp.Depth = 0;
            this.BtnAddDisp.HighEmphasis = true;
            this.BtnAddDisp.Icon = null;
            this.BtnAddDisp.Location = new System.Drawing.Point(232, 396);
            this.BtnAddDisp.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnAddDisp.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnAddDisp.Name = "BtnAddDisp";
            this.BtnAddDisp.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnAddDisp.Size = new System.Drawing.Size(100, 36);
            this.BtnAddDisp.TabIndex = 5;
            this.BtnAddDisp.Text = "Добавить";
            this.BtnAddDisp.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnAddDisp.UseAccentColor = false;
            this.BtnAddDisp.UseVisualStyleBackColor = true;
            // 
            // FormDisplineAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnDeleteDispline);
            this.Controls.Add(this.BtnAddDisp);
            this.Controls.Add(this.DispBoxAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormDisplineAdd";
            this.Text = "Добавление дисциплин";
            this.Load += new System.EventHandler(this.FormDisplineAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MaterialSkin.Controls.MaterialTextBox DispBoxAdd;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton BtnDeleteDispline;
        private MaterialSkin.Controls.MaterialButton BtnAddDisp;
    }
}
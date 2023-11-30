
namespace TeachersHandsBooks
{
    partial class FormAddGroup
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
            this.BoxAddGroup = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.GroupPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnDeleteGroup = new MaterialSkin.Controls.MaterialButton();
            this.BtnSaveGroup = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // BoxAddGroup
            // 
            this.BoxAddGroup.AllowPromptAsInput = false;
            this.BoxAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BoxAddGroup.AnimateReadOnly = true;
            this.BoxAddGroup.AsciiOnly = false;
            this.BoxAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BoxAddGroup.BeepOnError = false;
            this.BoxAddGroup.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.BoxAddGroup.Depth = 0;
            this.BoxAddGroup.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BoxAddGroup.HidePromptOnLeave = false;
            this.BoxAddGroup.HideSelection = true;
            this.BoxAddGroup.Hint = "Введите группу";
            this.BoxAddGroup.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.BoxAddGroup.LeadingIcon = null;
            this.BoxAddGroup.Location = new System.Drawing.Point(174, 83);
            this.BoxAddGroup.Mask = "";
            this.BoxAddGroup.MaxLength = 32767;
            this.BoxAddGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.BoxAddGroup.Name = "BoxAddGroup";
            this.BoxAddGroup.PasswordChar = '\0';
            this.BoxAddGroup.PrefixSuffixText = null;
            this.BoxAddGroup.PromptChar = '_';
            this.BoxAddGroup.ReadOnly = false;
            this.BoxAddGroup.RejectInputOnFirstFailure = false;
            this.BoxAddGroup.ResetOnPrompt = true;
            this.BoxAddGroup.ResetOnSpace = true;
            this.BoxAddGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BoxAddGroup.SelectedText = "";
            this.BoxAddGroup.SelectionLength = 0;
            this.BoxAddGroup.SelectionStart = 0;
            this.BoxAddGroup.ShortcutsEnabled = true;
            this.BoxAddGroup.Size = new System.Drawing.Size(331, 48);
            this.BoxAddGroup.SkipLiterals = true;
            this.BoxAddGroup.TabIndex = 4;
            this.BoxAddGroup.TabStop = false;
            this.BoxAddGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BoxAddGroup.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.BoxAddGroup.TrailingIcon = null;
            this.BoxAddGroup.UseSystemPasswordChar = false;
            this.BoxAddGroup.ValidatingType = null;
            // 
            // GroupPanel
            // 
            this.GroupPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GroupPanel.Location = new System.Drawing.Point(21, 137);
            this.GroupPanel.Name = "GroupPanel";
            this.GroupPanel.Size = new System.Drawing.Size(699, 251);
            this.GroupPanel.TabIndex = 5;
            // 
            // BtnDeleteGroup
            // 
            this.BtnDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnDeleteGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDeleteGroup.BackColor = System.Drawing.Color.Transparent;
            this.BtnDeleteGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeleteGroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnDeleteGroup.Depth = 0;
            this.BtnDeleteGroup.HighEmphasis = true;
            this.BtnDeleteGroup.Icon = null;
            this.BtnDeleteGroup.Location = new System.Drawing.Point(457, 397);
            this.BtnDeleteGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnDeleteGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnDeleteGroup.Name = "BtnDeleteGroup";
            this.BtnDeleteGroup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnDeleteGroup.Size = new System.Drawing.Size(91, 36);
            this.BtnDeleteGroup.TabIndex = 8;
            this.BtnDeleteGroup.Text = "Удалить";
            this.BtnDeleteGroup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnDeleteGroup.UseAccentColor = false;
            this.BtnDeleteGroup.UseVisualStyleBackColor = false;
            this.BtnDeleteGroup.Visible = false;
            this.BtnDeleteGroup.Click += new System.EventHandler(this.BtnDeleteGroup_Click);
            // 
            // BtnSaveGroup
            // 
            this.BtnSaveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSaveGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSaveGroup.BackColor = System.Drawing.Color.Transparent;
            this.BtnSaveGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSaveGroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnSaveGroup.Depth = 0;
            this.BtnSaveGroup.HighEmphasis = true;
            this.BtnSaveGroup.Icon = null;
            this.BtnSaveGroup.Location = new System.Drawing.Point(292, 397);
            this.BtnSaveGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.BtnSaveGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.BtnSaveGroup.Name = "BtnSaveGroup";
            this.BtnSaveGroup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.BtnSaveGroup.Size = new System.Drawing.Size(100, 36);
            this.BtnSaveGroup.TabIndex = 7;
            this.BtnSaveGroup.Text = "Добавить";
            this.BtnSaveGroup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnSaveGroup.UseAccentColor = false;
            this.BtnSaveGroup.UseVisualStyleBackColor = false;
            this.BtnSaveGroup.Click += new System.EventHandler(this.BtnSaveGroup_Click);
            // 
            // FormAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 468);
            this.Controls.Add(this.BtnDeleteGroup);
            this.Controls.Add(this.BtnSaveGroup);
            this.Controls.Add(this.GroupPanel);
            this.Controls.Add(this.BoxAddGroup);
            this.MinimumSize = new System.Drawing.Size(787, 468);
            this.Name = "FormAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление групп";
            this.Load += new System.EventHandler(this.FormAddGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialMaskedTextBox BoxAddGroup;
        private System.Windows.Forms.FlowLayoutPanel GroupPanel;
        private MaterialSkin.Controls.MaterialButton BtnDeleteGroup;
        private MaterialSkin.Controls.MaterialButton BtnSaveGroup;
    }
}
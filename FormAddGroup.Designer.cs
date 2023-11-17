
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
            this.BoxAddGroups = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.GroupPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnDeleteGroup = new MaterialSkin.Controls.MaterialButton();
            this.BtnSaveGroup = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // BoxAddGroups
            // 
            this.BoxAddGroups.AllowPromptAsInput = false;
            this.BoxAddGroups.AnimateReadOnly = true;
            this.BoxAddGroups.AsciiOnly = false;
            this.BoxAddGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BoxAddGroups.BeepOnError = false;
            this.BoxAddGroups.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.BoxAddGroups.Depth = 0;
            this.BoxAddGroups.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.BoxAddGroups.HidePromptOnLeave = false;
            this.BoxAddGroups.HideSelection = true;
            this.BoxAddGroups.Hint = "Введите группу";
            this.BoxAddGroups.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.BoxAddGroups.LeadingIcon = null;
            this.BoxAddGroups.Location = new System.Drawing.Point(174, 83);
            this.BoxAddGroups.Mask = "";
            this.BoxAddGroups.MaxLength = 32767;
            this.BoxAddGroups.MouseState = MaterialSkin.MouseState.OUT;
            this.BoxAddGroups.Name = "BoxAddGroups";
            this.BoxAddGroups.PasswordChar = '\0';
            this.BoxAddGroups.PrefixSuffixText = null;
            this.BoxAddGroups.PromptChar = '_';
            this.BoxAddGroups.ReadOnly = false;
            this.BoxAddGroups.RejectInputOnFirstFailure = false;
            this.BoxAddGroups.ResetOnPrompt = true;
            this.BoxAddGroups.ResetOnSpace = true;
            this.BoxAddGroups.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BoxAddGroups.SelectedText = "";
            this.BoxAddGroups.SelectionLength = 0;
            this.BoxAddGroups.SelectionStart = 0;
            this.BoxAddGroups.ShortcutsEnabled = true;
            this.BoxAddGroups.Size = new System.Drawing.Size(331, 48);
            this.BoxAddGroups.SkipLiterals = true;
            this.BoxAddGroups.TabIndex = 4;
            this.BoxAddGroups.TabStop = false;
            this.BoxAddGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.BoxAddGroups.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.BoxAddGroups.TrailingIcon = null;
            this.BoxAddGroups.UseSystemPasswordChar = false;
            this.BoxAddGroups.ValidatingType = null;
            // 
            // GroupPanel
            // 
            this.GroupPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GroupPanel.Location = new System.Drawing.Point(21, 137);
            this.GroupPanel.Name = "GroupPanel";
            this.GroupPanel.Size = new System.Drawing.Size(699, 251);
            this.GroupPanel.TabIndex = 5;
            // 
            // BtnDeleteGroup
            // 
            this.BtnDeleteGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnDeleteGroup.BackColor = System.Drawing.Color.Transparent;
            this.BtnDeleteGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDeleteGroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnDeleteGroup.Depth = 0;
            this.BtnDeleteGroup.HighEmphasis = true;
            this.BtnDeleteGroup.Icon = null;
            this.BtnDeleteGroup.Location = new System.Drawing.Point(275, 397);
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
            // 
            // BtnSaveGroup
            // 
            this.BtnSaveGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnSaveGroup.BackColor = System.Drawing.Color.Transparent;
            this.BtnSaveGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSaveGroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.BtnSaveGroup.Depth = 0;
            this.BtnSaveGroup.HighEmphasis = true;
            this.BtnSaveGroup.Icon = null;
            this.BtnSaveGroup.Location = new System.Drawing.Point(158, 397);
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
            // 
            // FormAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 468);
            this.Controls.Add(this.BtnDeleteGroup);
            this.Controls.Add(this.BtnSaveGroup);
            this.Controls.Add(this.GroupPanel);
            this.Controls.Add(this.BoxAddGroups);
            this.Name = "FormAddGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление групп";
            this.Load += new System.EventHandler(this.FormAddGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialMaskedTextBox BoxAddGroups;
        private System.Windows.Forms.FlowLayoutPanel GroupPanel;
        private MaterialSkin.Controls.MaterialButton BtnDeleteGroup;
        private MaterialSkin.Controls.MaterialButton BtnSaveGroup;
    }
}
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using TeachersHandsBooks.Core.Tables;

namespace TeachersHandsBooks
{
    public partial class FormAddGroup : MaterialForm
    {
        DatabaseContext context = new DatabaseContext();
        private readonly ThemeSettings themeSettings;
     

        public FormAddGroup(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;

        }

        private MaterialCard CreateMaterialCard(string groupName)
        {
            MaterialCard card = new MaterialCard();
            card.Margin = new Padding(10);
            card.Size = new Size(124, 37);

            Label grouplabel = new Label();
            grouplabel.Text = groupName;
            grouplabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            grouplabel.Margin = new Padding(5, 10, 0, 10);
            grouplabel.Cursor = Cursors.Hand;
            grouplabel.Click += Grouplabel_Click;

            card.Controls.Add(grouplabel);
            GroupPanel.Controls.Add(card);

            return card;
        }

        private void Grouplabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            BoxAddGroups.Text = lbl.Text;
            BoxAddGroups.Hint = "Редактирование группы";

            BtnDeleteGroup.Visible = true;
            BtnDeleteGroup.Enabled = true;

        }

        private void VisGroup()
        {
            var group = context.Groups.ToList();
            foreach (var gr in group)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    CreateMaterialCard(gr.NameGroup);
                });
            }
        }

        private async void FormAddGroup_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                VisGroup();
            });
        }
    }
}

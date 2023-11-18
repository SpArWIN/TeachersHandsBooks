using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachersHandsBooks.Core;

namespace TeachersHandsBooks
{
    public partial class FormDisplineAdd : MaterialForm
    {
        private ThemeSettings themeSettings;
        private DatabaseContext context = new DatabaseContext();
        public FormDisplineAdd(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;

        }

        private MaterialCard CreateMaterialCard(string DisplineName)
        {
            MaterialCard card = new MaterialCard();
            card.Margin = new Padding(10);
            card.Size = new Size(124, 37);

            Label grouplabel = new Label();
            grouplabel.Text = DisplineName;
            grouplabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            grouplabel.Margin = new Padding(5, 10, 0, 10);
            grouplabel.Cursor = Cursors.Hand;
            grouplabel.Click += Grouplabel_Click;

            card.Controls.Add(grouplabel);
            flowLayoutPanel1.Controls.Add(card);

            return card;
        }

        private void Grouplabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            DispBoxAdd.Text = lbl.Text;
            DispBoxAdd.Hint = "Редактирование дисциплины";

            BtnDeleteDispline.Visible = true;
            BtnDeleteDispline.Enabled = true;
        }

        private void VisDispline()
        {
            var Displine = context.Displines.ToList();
            foreach (var Ds in Displine)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    CreateMaterialCard(Ds.NameDispline);
                });
            }
        }
        private async void FormDisplineAdd_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                VisDispline();
            });
        }
    }
}

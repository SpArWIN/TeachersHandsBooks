using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using Displine = TeachersHandsBooks.Core.Tables.Displine;

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
            grouplabel.AutoSize = true;
            grouplabel.Click += Grouplabel_Click;
            Size textSize = TextRenderer.MeasureText(DisplineName, grouplabel.Font);
            card.Size = new Size(textSize.Width + 20, 37);
            card.Controls.Add(grouplabel);
            GroupDisplinePanel.Controls.Add(card);

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
        private bool Validations()
        {
            string InputGroup = DispBoxAdd.Text;
            bool isValid = Regex.IsMatch(InputGroup, @"^[\sа-яА-Яa-zA-Z0-9\.\-]+$");

            if (!isValid)
            {
                MaterialMessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, false, FlexibleMaterialForm.ButtonsPosition.Center); ;
                //MessageBox.Show("Некорректный ввод. Разрешены только символы, тире и цифры.");
                DispBoxAdd.Text = Regex.Replace(DispBoxAdd.Text, @"[^а-яА-Яa-zA-Z0-9\\\-]+", "");
                DispBoxAdd.SelectionStart = DispBoxAdd.Text.Length;
                DispBoxAdd.Clear();
            }
            return isValid;
        }
        private bool IsGroupExists(string DisplineName)
        {
            var existingGroup = context.Displines.FirstOrDefault(g => g.NameDispline == DisplineName);

            return existingGroup != null;
        }

        private void RefreshGroupDisplay()
        {
            GroupDisplinePanel.Controls.Clear();


            var Displine = context.Displines.ToList();

            foreach (var Disp in Displine)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    CreateMaterialCard(Disp.NameDispline);
                });
            }
        }


        private void BtnAddDisp_Click(object sender, EventArgs e)
        {
            string InputTextBox = DispBoxAdd.Text;
            if (string.IsNullOrWhiteSpace(InputTextBox))
            {
                MessageBox.Show("Поле не может быть пустым", "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InputTextBox = InputTextBox.Trim();

            bool Correct = Validations();
            if (!Correct)
            {
                return;
            }
            else if (IsGroupExists(InputTextBox))
            {
                MessageBox.Show("Дисциплина с наименованием '" + InputTextBox + "' уже существует.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DispBoxAdd.Clear();
                DispBoxAdd.Focus();
                //  DispBoxAdd.Enabled = false;



            }
            else
            {

                MessageBox.Show("Дисциплина " + InputTextBox + " была успешно добавлена в базу данных", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DispBoxAdd.Clear();
                Displine.AddDispline(InputTextBox);
                RefreshGroupDisplay();


            }
        }

        private void BtnDeleteDispline_Click(object sender, EventArgs e)
        {
            string GrN = DispBoxAdd.Text;
            DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту дисциплину?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                Displine.RemoveDispline(GrN);
                RefreshGroupDisplay();
                DispBoxAdd.Clear();
                MessageBox.Show("Дисциплина успешно удалена.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
        }
    }
}

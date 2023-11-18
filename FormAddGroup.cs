using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using Group = TeachersHandsBooks.Core.Tables.Group;

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
        private void RefreshGroupDisplay()
        {
            GroupPanel.Controls.Clear();


            var groups = context.Groups.ToList();

            foreach (var group in groups)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    CreateMaterialCard(group.NameGroup);
                });
            }
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
            BoxAddGroup.Text = lbl.Text;
            BoxAddGroup.Hint = "Редактирование группы";

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
        private bool Validations()
        {
            string InputGroup = BoxAddGroup.Text;
            bool isValid = Regex.IsMatch(InputGroup, @"^[а-яА-Яa-zA-Z0-9\\\^]+$");
            if (!isValid)
            {
                MaterialMessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, false, FlexibleMaterialForm.ButtonsPosition.Center); ;
                //MessageBox.Show("Некорректный ввод. Разрешены только символы, тире и цифры.");
                BoxAddGroup.Text = Regex.Replace(BoxAddGroup.Text, @"^[а-яА-Яa-zA-Z0-9\-]+$", "");
                BoxAddGroup.SelectionStart = BoxAddGroup.Text.Length;
                BoxAddGroup.Clear();
            }
            return isValid;
        }
        private bool IsGroupExists(string GroupName)
        {
            var existingGroup = context.Groups.FirstOrDefault(g => g.NameGroup == GroupName);

            return existingGroup != null;
        }


        private void BtnSaveGroup_Click(object sender, EventArgs e)
        {
            string InputTextBox = BoxAddGroup.Text;
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
                MessageBox.Show("Группа с наименованием '" + InputTextBox + "' уже существует.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BoxAddGroup.Clear();
                BtnDeleteGroup.Enabled = false;

            }
            else
            {
                Group.AddGroupToDatabase(InputTextBox);
                MessageBox.Show("Группа " + InputTextBox + " была успешно добавлена в базу данных", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGroupDisplay();

            }

        }
        private void BtnDeleteGroup_Click(object sender, EventArgs e)
        {
            string GrN = BoxAddGroup.Text;
            DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту группу?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                Group.RemoveToDatabase(GrN);
                RefreshGroupDisplay();
                BoxAddGroup.Clear();
                MessageBox.Show("Группа успешно удалена.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }

        }




    }

}

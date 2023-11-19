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
    public partial class FormationRasp : MaterialForm
    {
        private ThemeSettings themeSettings;

        DatabaseContext context = new DatabaseContext();
        private int selectedGroupId = -1;
        public FormationRasp(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;

        }

        private DataGridViewCellStyle SetDataGridViewStyleFromTheme(DataGridView dataGridView, ThemeSettings setting)
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            if (!string.IsNullOrEmpty(setting.ColorTheme) && setting.ColorTheme != "Transparent")
            {
                Color selectedColor;
                try
                {
                    selectedColor = ColorTranslator.FromHtml(setting.ColorTheme);



                    headerStyle.BackColor = selectedColor;


                    dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            return headerStyle;
        }


        private Color GetColorFromTheme(ThemeSettings setting)
        {
            Color selectedColor = Color.White;

            if (!string.IsNullOrEmpty(setting.ColorTheme) && setting.ColorTheme != "Transparent")
            {
                try
                {
                    selectedColor = Color.FromName(setting.ColorTheme);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // Если возникла ошибка, установим цвет по умолчанию
                    selectedColor = Color.White;
                }
            }

            return selectedColor;
        }


        private void ShowsPairsANDDay(int selectGroup)
        {
            var pairs = context.Pairs.Select(p => p.Pair).ToList();

            // Получаем дни недели из базы данных
            var daysOfWeek = context.DayTables.Select(d => d.Day).ToList();

            // Очистить все предыдущие столбцы и строки, если нужно
            GridRasp.Columns.Clear();
            GridRasp.Rows.Clear();

            // Добавляем столбец для номеров пар
            DataGridViewTextBoxColumn pairsColumn = new DataGridViewTextBoxColumn();
            pairsColumn.HeaderText = "Пары";
            pairsColumn.Name = "PairsColumn";
            GridRasp.Columns.Add(pairsColumn);





            //А это ниже для заполнения  Combox дисциплин, связанных
            var selectedGroupDisciplines = context.ConnectWithGroup
        .Where(dwg => dwg.Group.ID == selectedGroupId)
        .Select(dwg => dwg.Displine.NameDispline)
        .ToList();




            // Добавляем заголовки дней недели как столбцы
            foreach (var day in daysOfWeek)
            {
                DataGridViewComboBoxCell cel = new DataGridViewComboBoxCell();
                foreach (var discipline in selectedGroupDisciplines)
                {
                    cel.Items.Add(discipline);
                    cel.FlatStyle = FlatStyle.Popup;
                }

                DataGridViewColumn column = new DataGridViewColumn();
               
                column.CellTemplate = cel;
                column.Name = day;
                column.HeaderText = day;
                column.Visible = true;
                GridRasp.Columns.Add(column);
          


            }

            // Добавляем пары в столбец "Пары"
            foreach (var pair in pairs)
            {
                // int rowIndex = GridRasp.Rows.Add(pair);
                GridRasp.Rows.Add(pair);


            }
            GridRasp.Columns["PairsColumn"].ReadOnly = true;
        }
        private void FillCombox()
        {
            try
            {
                // Получение уникальных групп из таблицы DisplineWithGroup
                var uniqueGroups = context.ConnectWithGroup.Select(d => d.Group.NameGroup).Distinct().ToList();

                // Заполнение ComboBox уникальными группами
                BoxGroup.DataSource = uniqueGroups;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при заполнении списка групп: " + ex.Message);
            }
        }
       private void BtnDinamicAdd()
        {
            MaterialButton btnFormRasp = new MaterialButton();
            btnFormRasp.Name = "BtnFormRasp";
            btnFormRasp.Text = "Сформировать";
            btnFormRasp.Location = new Point(20, 70); // Укажите координаты положения кнопки на форме
            btnFormRasp.Enabled = false;
            // Добавление обработчика события нажатия на кнопку
            btnFormRasp.Click += BtnFormRasp_Click;

            // Добавление кнопки на форму
            this.Controls.Add(btnFormRasp);
        }

        private void BtnFormRasp_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FormationRasp_Load(object sender, EventArgs e)
        {
            FillCombox();
            BtnDinamicAdd();
            ShowsPairsANDDay(selectedGroupId);
            GridRasp.AllowUserToAddRows = false;
            GridRasp.Font = new Font("Arial", 12);
            GridRasp.ColumnHeadersDefaultCellStyle = SetDataGridViewStyleFromTheme(GridRasp, themeSettings);
            GridRasp.ColumnHeadersDefaultCellStyle.SelectionBackColor = GetColorFromTheme(themeSettings);

        }

        private void BoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = BoxGroup.SelectedItem.ToString();

            // Получение ID выбранной группы из базы данных
            var groupId = context.ConnectWithGroup
                                .Where(d => d.Group.NameGroup == selectedGroup)
                                .Select(d => d.Group.ID)
                                .FirstOrDefault();

            // Сохранение выбранного ID группы
            selectedGroupId = groupId;
            ShowsPairsANDDay(selectedGroupId);
        }

        private void GridRasp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }
    }
}

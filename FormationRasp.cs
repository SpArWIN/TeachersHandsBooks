using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using TeachersHandsBooks.Core.Tables;

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


        private void ShowsPairsANDDay()
        {
            var pairs = context.Pairs.Select(p => p.Pair).ToList();

            // Получаем дни недели из базы данных
            var daysOfWeek = context.DayTables.Select(d => d.Day).ToList();

            // Очистить все предыдущие столбцы и строки, если нужно
            GridRasp.Columns.Clear();
            GridRasp.Rows.Clear();

            //А это ниже для заполнения  Combox дисциплин, связанных
            /*     var selectedGroupDisciplines = context.ConnectWithGroup
             .Where(dwg => dwg.Group.ID == selectedGroupId)
             .Select(dwg => dwg.Displine.NameDispline)
             .ToList();
            */

            DataGridViewTextBoxColumn pairsColumn = new DataGridViewTextBoxColumn();
            pairsColumn.HeaderText = "Пары";
            pairsColumn.Name = "PairsColumn";
            GridRasp.Columns.Add(pairsColumn);

            // Добавление заголовков для дней недели в DataGridView
            foreach (var day in daysOfWeek)
            {
                DataGridViewTextBoxColumn dayColumn = new DataGridViewTextBoxColumn();
                dayColumn.HeaderText = day; // Установка заголовка как имя дня недели
                dayColumn.Name = $"{day}Column"; // Имя для обращения к столбцу по дню недели
                GridRasp.Columns.Add(dayColumn);
            }

            // Добавление строк (ячеек) в DataGridView для всех пар
            foreach (var pair in pairs)
            {
                int rowIndex = GridRasp.Rows.Add(); // Добавление новой строки

                // Задание имени строки для обращения к ней
                GridRasp.Rows[rowIndex].HeaderCell.Value = $"Pair {pair}";

                // Добавление пары в столбец "Пары" для соответствующей строки
                GridRasp.Rows[rowIndex].Cells["PairsColumn"].Value = pair;

                // Добавление комбо-боксов в ячейки соответствующих дней недели
                for (int i = 1; i < GridRasp.Columns.Count; i++)
                {

                    var cell = new DataGridViewComboBoxCell();
                    cell.DropDownWidth = 100;

                    // Получение списка значений из базы данных для данного дня недели (selectedGroupDisciplines)
                    var selectedGroupDisciplines = context.ConnectWithGroup
                        .Where(dwg => dwg.Group.ID == selectedGroupId)
                        .Select(dwg => dwg.Displine.NameDispline)
                        .ToList();
                    cell.FlatStyle = FlatStyle.Popup;
                    // Установка элементов для комбо-бокса напрямую из запроса
                    cell.Items.AddRange(selectedGroupDisciplines.ToArray());
                    //  GridRasp.Rows[rowIndex].Cells["DisplineS"].Value = cell;

                    cell.Tag = "DisplineS";
                    GridRasp[i, rowIndex] = cell;
                }
            }








            //// Добавляем заголовки дней недели как столбцы
            //foreach (var day in daysOfWeek)
            //{
            //    DataGridViewComboBoxCell cel = new DataGridViewComboBoxCell();

            //    foreach (var discipline in selectedGroupDisciplines)
            //    {
            //        cel.Items.Add(discipline);
            //        cel.FlatStyle = FlatStyle.Popup;
            //        cel.Tag = discipline;

            //    }


            //    DataGridViewColumn column = new DataGridViewColumn();

            //    column.CellTemplate = cel;
            //    column.Name = "Displine";
            //    column.HeaderText = day;
            //    column.Visible = true;
            //    cel.DropDownWidth = 100;
            //    GridRasp.Columns.Add(column);

            //}








            //// Добавляем пары в столбец "Пары"
            //foreach (var pair in pairs)
            //{
            //     int rowIndex = GridRasp.Rows.Add(pair);
            //  //  GridRasp.Rows.Add(pair);
            //    GridRasp.Rows[rowIndex].Cells["PairsColumn"].Value = pair;

            //}
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
        private MaterialButton btnFormRasp = new MaterialButton();
        private void BtnDinamicAdd()
        {

            btnFormRasp.Name = "BtnFormRasp";
            btnFormRasp.Text = "Сформировать";
            btnFormRasp.Location = new Point(20, 70); // Укажите координаты положения кнопки на форме
            btnFormRasp.Cursor = Cursors.Hand;
            // Добавление обработчика события нажатия на кнопку
            btnFormRasp.Click += BtnFormRasp_Click;

            // Добавление кнопки на форму
            this.Controls.Add(btnFormRasp);
        }

        private void BtnFormRasp_Click(object sender, EventArgs e)
        {


            bool isAnyCellFilled = false;

            foreach (DataGridViewRow row in GridRasp.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        isAnyCellFilled = true;
                        break;
                    }
                }
            }

            if (!isAnyCellFilled)
            {
                MessageBox.Show("Расписание вообще никак не заполненно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (isAnyCellFilled)
            {
                CollectDataGridViewData(GridRasp);
                MessageBox.Show("Возможно, расписание было сформировано успешно");
            }
        }
        private List<DisplineWithGroup> GetDisplineWithGroupById(int disciplineId)
        {
            var disciplineWithGroupList = context.ConnectWithGroup
                .Where(dwg => dwg.Displine.ID == disciplineId)
                .ToList();

            return disciplineWithGroupList;
        }

        private List<DayTable> GetDayTableByName(List<string> daysOfWeek)
        {
            var days = context.DayTables.Where(d => daysOfWeek.Contains(d.Day)).ToList();
            return days;
        }

        /// <summary>
        /// Получение дня недели из таблицы DataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        private List<string> GetDaysOfWeekFromDataGridView(DataGridView dataGridView)
        {
            List<string> daysOfWeek = new List<string>();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Index > 0) // Пропустить первый столбец, если это необходимо
                {
                    string dayOfWeek = column.HeaderText; // Получаем текст заголовка столбца
                    daysOfWeek.Add(dayOfWeek);
                }
            }

            return daysOfWeek;
        }


        private void CollectDataGridViewData(DataGridView datagrid)
        {
            List<int> disciplineIds = new List<int>();
            List<string> Displines = new List<string>();
            List<string> pairs = new List<string>();
            List<string> daysOfWeek = new List<string>();

            // Цикл по столбцам
            for (int columnIndex = 1; columnIndex < datagrid.Columns.Count; columnIndex++)
            {
                // Цикл по строкам для каждого столбца
                for (int rowIndex = 0; rowIndex < datagrid.Rows.Count; rowIndex++)
                {
                    // Получаем ячейку
                    DataGridViewCell cell = datagrid.Rows[rowIndex].Cells[columnIndex];

                    // Проверяем, является ли ячейка ComboBoxCell
                    if (cell is DataGridViewComboBoxCell comboBoxCell)
                    {
                        // Получаем значение из ComboBoxCell (дисциплину)
                        string Discipline = comboBoxCell.FormattedValue?.ToString();

                        // Если значение не пустое (т.е., там есть дисциплина)
                        if (!string.IsNullOrEmpty(Discipline))
                        {
                            // Добавляем день недели
                            string DayOfWeek = datagrid.Columns[columnIndex].HeaderText;
                            daysOfWeek.Add(DayOfWeek);

                            // Добавляем дисциплину
                            Displines.Add(Discipline);

                            // Определяем пару на этом дне
                            pairs.Add(datagrid.Rows[rowIndex].Cells["PairsColumn"].Value?.ToString());

                            // Получаем ID дисциплины
                            int disciplineId = GetDisciplineIdByName(Discipline);
                            disciplineIds.Add(disciplineId);
                        }
                    }

                    
                }

            }
            AddTimeTableRecords(disciplineIds, daysOfWeek, pairs);
        }



        private int GetDisciplineIdByName(string disciplines)
        {
            var discipline = context.Displines
     .Where(d => d.NameDispline == disciplines)
     .Select(d => d.ID)
     .FirstOrDefault();

            return discipline;
        }

        private List<NumberPair> GetNumberPairByName(List<string> pairs)
        {
            var pairss = context.Pairs.Where(p => pairs.Contains(p.Pair)).ToList();
            return pairss;
        }

        public void AddTimeTableRecords(List<int> disciplineIds, List<string> daysOfWeek, List<string> pairs)
        {
            foreach (var disciplineId in disciplineIds)
            {
                var disciplineWithGroup = GetDisplineWithGroupById(disciplineId);
                var dayTable = GetDayTableByName(daysOfWeek);
                var numberPair = GetNumberPairByName(pairs);

                foreach (var disciplineGroup in disciplineWithGroup)
                {
                    foreach (var day in dayTable)
                    {
                        foreach (var pair in numberPair)
                        {
                            // Создаем новую запись в таблице TimeTable
                            TimeTable newRecord = new TimeTable
                            {
                                // Связываем с DisplineWithGroup по IDW
                                DisplineWithGroup = disciplineGroup,
                                Day = day,
                                Pair = pair
                            };

                            context.TimeTables.Add(newRecord);
                        }
                    }
                }
            }

            // Сохраняем все изменения в базе данных
            context.SaveChanges();
        }
        private void FormationRasp_Load(object sender, EventArgs e)
        {
            FillCombox();
            BtnDinamicAdd();
            ShowsPairsANDDay();
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
            ShowsPairsANDDay();
        }

        private void GridRasp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void GridRasp_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore
        }
    }
}

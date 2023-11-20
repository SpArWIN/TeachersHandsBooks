﻿using MaterialSkin;
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
        private MainForm _mainFormInstance;
        private ThemeSettings themeSettings;

        DatabaseContext context = new DatabaseContext();
        private int selectedGroupId = -1;
        public FormationRasp(ThemeSettings theme,MainForm Main)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;
            _mainFormInstance = Main;


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
            //  var daysOfWeek = context.DayTables.Select(d => d.Day).ToList();
            var daysOfWeek = context.DayTables.Select(d => d.Day).ToList();

            // Очистить все предыдущие столбцы и строки, если нужно
            GridRasp.Columns.Clear();
            GridRasp.Rows.Clear();



            DataGridViewTextBoxColumn pairsColumn = new DataGridViewTextBoxColumn();
            pairsColumn.HeaderText = "Пары";
            pairsColumn.Name = "PairsColumn";
            GridRasp.Columns.Add(pairsColumn);

            // Добавление заголовков для дней недели в DataGridView
            foreach (var day in daysOfWeek)
            {
                DataGridViewTextBoxColumn dayColumn = new DataGridViewTextBoxColumn();
                dayColumn.HeaderText = day; // Установка заголовка как имя дня недели
                dayColumn.Name = "Columnes"; // Имя для обращения к столбцу по дню недели
                dayColumn.Width = 120;

                GridRasp.Columns.Add(dayColumn);
            }
            // Установка шрифта для заголовков столбцов
            foreach (DataGridViewColumn column in GridRasp.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                column.HeaderCell.Style.ForeColor = Color.White; // Установка белого цвета шрифта для заголовков столбцов
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            GridRasp.AllowUserToOrderColumns = false;


            // Добавление строк (ячеек) в DataGridView для всех пар
            foreach (var pair in pairs)
            {
                int OutRowIndex = GridRasp.Rows.Add(); // Добавление новой строки

                // Задание имени строки для обращения к ней
                GridRasp.Rows[OutRowIndex].HeaderCell.Value = $"Pair {pair}";

                // Добавление пары в столбец "Пары" для соответствующей строки
                GridRasp.Rows[OutRowIndex].Cells["PairsColumn"].Value = pair;

                // Добавление комбо-боксов в ячейки соответствующих дней недели
                for (int columnIndex = 1; columnIndex < GridRasp.Columns.Count; columnIndex++)
                {
                    for (int innerRowIndex = 0; innerRowIndex < GridRasp.Rows.Count; innerRowIndex++)
                    {
                        var cell = new DataGridViewComboBoxCell();
                        cell.Style.Font = new Font("Arial", 12, FontStyle.Regular);
                        // Получение списка значений из базы данных для данного дня недели (selectedGroupDisciplines)
                        var selectedGroupDisciplines = context.ConnectWithGroup
                            .Where(dwg => dwg.Group.ID == selectedGroupId)
                            .Select(dwg => dwg.Displine.NameDispline)
                            .ToList();

                        // Установка элементов для комбо-бокса напрямую из запроса
                        cell.Items.AddRange(selectedGroupDisciplines.ToArray());
                        cell.FlatStyle = FlatStyle.Popup;
                        //  GridRasp.Rows[innerRowIndex].Cells["DisplineS"].Value = cell;
                        cell.DropDownWidth = 120;

                        cell.Tag = "DisplineS";
                        GridRasp[columnIndex, innerRowIndex] = cell;
                    }
                }
            }

          //  DisableOccupiedCells(GridRasp);

            GridRasp.Columns["PairsColumn"].ReadOnly = true;
           

        }
        private void FillCombox()
        {
            try
            {
                // Получение уникальных групп из таблицы DisplineWithGroup
                var uniqueGroups = context.ConnectWithGroup.Select(d => d.Group.NameGroup).Distinct().ToList();
                if (uniqueGroups.Count == 0)
                {
                    btnFormRasp.Enabled = false;
                }
                else
                {
                    btnFormRasp.Enabled = true;
                    BoxGroup.DataSource = uniqueGroups;
                }
                // Заполнение ComboBox уникальными группами
               
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
        /// Метод проверки доступности, возвращает истину, если для конкретной и в конкретный день не было записано пары
        /// </summary>
        
        /// <param name="dayOfWeek"></param>
        /// <param name="pair"></param>
        /// <returns></returns>
        private bool CheckIfSlotIsOccupied(string dayOfWeek, string pair)
        {
         
                // Получаем все уникальные ID групп из базы данных
                var groupIds = context.ConnectWithGroup.Select(g => g.Group.ID).Distinct().ToList();

                // Проверяем, существует ли запись для любой группы с указанными параметрами
                foreach (var groupId in groupIds)
                {
                    bool isSlotOccupied = context.TimeTables
                        .Any(c => c.DisplineWithGroup.Group.ID == groupId &&
                                  c.Day.Day == dayOfWeek &&
                                  c.Pair.Pair == pair);

                    if (isSlotOccupied)
                    {
                        return true; // Если хотя бы для одной группы есть запись, возвращаем true
                    }
                }

                return false; // Если запись не найдена для ни одной группы, возвращаем false
            
        }
        private List<(string DayOfWeek, string Discipline, string Pair)> previouslySelectedEntries = new List<(string, string, string)>();
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
            for (int i = 0; i < disciplineIds.Count; i++)
            {
                var disciplineId = disciplineIds[i];
                var disciplineWithGroup = GetDisplineWithGroupById(disciplineId);
                var dayTable = GetDayTableByName(new List<string> { daysOfWeek[i] });
                var numberPair = GetNumberPairByName(new List<string> { pairs[i] });
                foreach (var disciplineGroup in disciplineWithGroup)
                {
                    foreach (var pair in numberPair)
                    {
                        TimeTable newRecord = new TimeTable
                        {
                            DisplineWithGroup = disciplineGroup,
                            Day = dayTable.FirstOrDefault(), 
                            Pair = pair
                        };

                        context.TimeTables.Add(newRecord);
                    }
                }
            }

            context.SaveChanges();


            // Сохраняем все изменения в базе данных

        }

        /// <summary>
        /// Метод отключения занятых ячеек, в качестве параметра ID группы, и DataGrid
        /// </summary>

        /// <param name="dataGridView"></param>
        private void DisableOccupiedCells(DataGridView dataGridView)
        {
            Color occupiedColor = Color.Brown;

            for (int columnIndex = 1; columnIndex < dataGridView.Columns.Count; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < dataGridView.Rows.Count; rowIndex++)
                {
                    string pair = dataGridView.Rows[rowIndex].Cells["PairsColumn"].Value?.ToString();
                    string dayOfWeek = dataGridView.Columns[columnIndex].HeaderText;

                    bool isSlotOccupied = false;

                    // Проверяем занятость ячейки для любой группы
                    foreach (var group in context.ConnectWithGroup)
                    {
                        int GroupDID = group.Group.ID;
                        isSlotOccupied |= CheckIfSlotIsOccupied( dayOfWeek, pair);
                    }

                    dataGridView.Rows[rowIndex].Cells[columnIndex].ReadOnly = isSlotOccupied;

                    // Устанавливаем цвет фона для занятых ячеек
                    if (isSlotOccupied)
                    {
                        dataGridView.Rows[rowIndex].Cells[columnIndex].Style.BackColor = occupiedColor;
                    }
                }
            }
        }

        private void FormationRasp_Load(object sender, EventArgs e)
        {
           
            FillCombox();
           
            BtnDinamicAdd();
            ShowsPairsANDDay();
            GridRasp.AllowUserToAddRows = false;
            GridRasp.AllowUserToOrderColumns = false;
            GridRasp.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //  GridRasp.Font = new Font("Arial", 12);
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
            DisableOccupiedCells(GridRasp);


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

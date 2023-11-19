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
                    cel.Tag = discipline;
                    
                }

              
                DataGridViewColumn column = new DataGridViewColumn();

                column.CellTemplate = cel;
                column.Name = "Day";
                column.HeaderText = day;
                column.Visible = true;
                cel.DropDownWidth = 100;
                GridRasp.Columns.Add(column);

            }

               

              


            

            // Добавляем пары в столбец "Пары"
            foreach (var pair in pairs)
            {
                 int rowIndex = GridRasp.Rows.Add(pair);
              //  GridRasp.Rows.Add(pair);
                GridRasp.Rows[rowIndex].Cells["PairsColumn"].Value = pair;

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
        private void CollectDataGridViewData(DataGridView  datagrid)
        {
            List<int> disciplineIds = new List<int>();
            List<string> daysOfWeek = new List<string>();
            List<string> pairs = new List<string>();

            foreach (DataGridViewRow row in datagrid.Rows)
            {
                // Получение значений из ячеек в соответствии с вашими столбцами
                string dayOfWeek = row.Cells["Day"].Value.ToString();
                daysOfWeek.Add(dayOfWeek);

                string pair = row.Cells["PairsColumn"].Value.ToString();
                pairs.Add(pair);
                DataGridViewComboBoxCell disciplineCell = row.Cells["ColumnDiscipline"] as DataGridViewComboBoxCell;

                string discipline = disciplineCell.Tag?.ToString();
                int disciplineId = GetDisciplineIdByName(discipline);
                disciplineIds.Add(disciplineId);
            }

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
                                TeacherLoad_ID = disciplineGroup,
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

        private void GridRasp_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore
        }
    }
}

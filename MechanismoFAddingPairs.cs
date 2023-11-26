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
    public partial class MechanismoFAddingPairs : MaterialForm
    {
        private DatabaseContext context = new DatabaseContext();
        private ThemeSettings themeSettings;
        private EdingFormValue eding = new EdingFormValue();
        //Для анимации загрузки

        private int currentProgress = 0;
        private Timer progressTimer;
        public List<string> EmptyPairsForDay { get; set; } = new List<string>();
        public string Pair { get; set; }
        public string Discipline { get; set; }
        public string Group { get; set; }
        public bool IsThemeChecked { get; set; }


        public MechanismoFAddingPairs(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;
            progressTimer = new Timer();
            progressTimer.Interval = 100; // Интервал обновления анимации (в миллисекундах)
            progressTimer.Tick += ProgressTimer_Tick;
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            currentProgress += 10;
            if (currentProgress > guna2CircleProgressBar1.Maximum)
            {
                // Если достигнут максимум, останавливаем анимацию
                progressTimer.Stop();
                guna2CircleProgressBar1.Visible = false;
            }
            else
            {
                guna2CircleProgressBar1.Value = currentProgress;
            }
        }

        private void LoadGetData()
        {
            DataLabel.Text = TransmissionOfInformation.Data;
            DayWeekLabel.Text = TransmissionOfInformation.DayWeek;
            DataGridViewComboBoxColumn pairColumn = new DataGridViewComboBoxColumn();
            pairColumn.HeaderText = "Пары";
            pairColumn.Name = "PairColumn";
            pairColumn.DataSource = EmptyPairsForDay;
            pairColumn.DataPropertyName = "Pair";
            pairColumn.DefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            pairColumn.FlatStyle = FlatStyle.Popup;
            pairColumn.DropDownWidth = 150;
            GridAddPair.Columns.Add(pairColumn);


            DataGridViewComboBoxColumn disciplineColumn = new DataGridViewComboBoxColumn();
            disciplineColumn.HeaderText = "Дисциплина";
            disciplineColumn.Name = "DisciplineColumn";
            disciplineColumn.DataSource = null;
            disciplineColumn.DataPropertyName = "Discipline";
            disciplineColumn.FlatStyle = FlatStyle.Popup;
            disciplineColumn.DropDownWidth = 150;
            disciplineColumn.DefaultCellStyle.Font = new Font("Arial", 14);
            GridAddPair.Columns.Add(disciplineColumn);

            DataGridViewComboBoxColumn groupColumn = new DataGridViewComboBoxColumn();
            groupColumn.HeaderText = "Группа";
            groupColumn.Name = "GroupColumn";
            groupColumn.DataSource = FillCombox();
            groupColumn.DataPropertyName = "Group";
            groupColumn.FlatStyle = FlatStyle.Popup;
            groupColumn.DefaultCellStyle.Font = new Font("Arial", 14);
            groupColumn.DropDownWidth = 150;
            GridAddPair.Columns.Add(groupColumn);
            GridAddPair.AutoGenerateColumns = false;

        }
        private void LoadSetting()
        {
            if (IsThemeChecked)
            {
                GridAddPair.BackgroundColor = Color.FromArgb(50, 50, 50);
                GridAddPair.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            }
            else if (!IsThemeChecked)
            {
                GridAddPair.BackgroundColor = Color.WhiteSmoke;
                GridAddPair.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            }

        }

        private List<string> FillCombox()
        {

            // Получение уникальных групп из таблицы DisplineWithGroup
            var uniqueGroups = context.ConnectWithGroup.Select(d => d.Group.NameGroup).Distinct().ToList();

            return uniqueGroups;



        }



        private void MechanismoFAddingPairs_Load(object sender, EventArgs e)
        {
            DataLabel.Font = new Font("Segui UI", 12, FontStyle.Bold);
            DayWeekLabel.Font = new Font("Segui UI", 12, FontStyle.Bold);
            LoadGetData();
            GridAddPair.ColumnHeadersDefaultCellStyle.SelectionBackColor = eding.GetColorFromTheme(themeSettings);
            LoadSetting();
        }
        public int GetTimeTableId(string pairName, string disciplineName, string groupName)
        {


            var timeTableId = (from tt in context.TimeTables
                               where tt.Pair.Pair == pairName &&
                                     tt.DisplineWithGroup.Displine.NameDispline == disciplineName &&
                                     tt.DisplineWithGroup.Group.NameGroup == groupName
                               select tt.ID).FirstOrDefault();

            return timeTableId;
        }
        private void BtnAddPairs_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите добавить пару на " + DataLabel.Text, "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string pairName = GridAddPair.Rows[0].Cells[0].Value?.ToString();
            string disciplineName = GridAddPair.Rows[0].Cells[1].Value?.ToString();
            string groupName = GridAddPair.Rows[0].Cells[2].Value?.ToString();

            int TimeTableID = GetTimeTableId(pairName, disciplineName, groupName);



            if (res == DialogResult.Yes)
            {
                // Проверка наличия записи в ModifiedSchedule
                var existingEntry = context.Modifieds.FirstOrDefault(entry =>
                    entry.TimeTable.ID == TimeTableID &&
                    entry.Data == DataLabel.Text &&
                    entry.isAdded == true);
                if (existingEntry != null)
                {
                    MessageBox.Show("Повторная попытка добавления уже добавленной пары", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    var TimetablesAdd = context.TimeTables.FirstOrDefault(Tt => Tt.ID == TimeTableID);
                    ModifiedSchedule AddEntry = new ModifiedSchedule
                    {
                        TimeTable = TimetablesAdd,
                        Data = DataLabel.Text,
                        isAdded = true

                    };
                    context.Modifieds.Add(AddEntry);
                    context.SaveChanges();
                    guna2CircleProgressBar1.Visible = true;
                    currentProgress = 0;
                    guna2CircleProgressBar1.Value = currentProgress;
                    progressTimer.Start();
                    MessageBox.Show("Пара была добавлена на " + DataLabel.Text + "обновите таблицу", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void GridAddPair_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что изменение произошло в нужной колонке с группами
            if (e.ColumnIndex == GridAddPair.Columns["GroupColumn"].Index && e.RowIndex >= 0)
            {
                GridAddPair.AllowUserToAddRows = false;
                DataGridViewComboBoxCell disciplineCell = (DataGridViewComboBoxCell)GridAddPair.Rows[e.RowIndex].Cells["DisciplineColumn"];
                DataGridViewComboBoxCell groupCell = (DataGridViewComboBoxCell)GridAddPair.Rows[e.RowIndex].Cells["GroupColumn"];
                // Получаем выбранную группу в ячейке
                string selectedGroup = groupCell.Value as string;

                // Получаем ID выбранной группы из базы данных
                var groupId = context.ConnectWithGroup
                                    .Where(d => d.Group.NameGroup == selectedGroup)
                                    .Select(d => d.Group.ID)
                                    .FirstOrDefault();

                // Получаем дисциплины для выбранной группы
                var selectedGroupDisciplines = context.ConnectWithGroup
                                            .Where(dwg => dwg.Group.ID == groupId)
                                            .Select(dwg => dwg.Displine.NameDispline)
                                            .ToList();


                // Обновляем список дисциплин в ячейке с дисциплинами
                disciplineCell.DataSource = selectedGroupDisciplines;


            }
        }
        //Все ли ячейки заполнены
        private bool AreAllComboBoxesFilled()
        {
            foreach (DataGridViewRow row in GridAddPair.Rows)
            {
                foreach (DataGridViewColumn column in GridAddPair.Columns)
                {
                    if (column is DataGridViewComboBoxColumn comboBoxColumn && row.Cells[column.Index] is DataGridViewComboBoxCell comboBoxCell)
                    {
                        if (string.IsNullOrWhiteSpace(comboBoxCell.Value?.ToString()))
                        {
                            return false; // Если хотя бы одна ячейка не заполнена, возвращаем false
                        }
                    }
                }
            }
            return true; // Если все ячейки заполнены, возвращаем true
        }
        private void GridAddPair_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            BtnAddPairs.Enabled = AreAllComboBoxesFilled();
        }
    }
}

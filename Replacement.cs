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
    public partial class Replacement : MaterialForm
    {
        private DatabaseContext context = new DatabaseContext();
        private ThemeSettings themeSettings;
        //ДЛя анимации загрузки

        private int currentProgress = 0;
        private Timer progressTimer;
        EdingFormValue editingForm = new EdingFormValue();
        //ДЛя передачи в форму
        public List<string> EmptyForAddForm { get; set; } = new List<string>();
        // Добавляем свойства для передачи данных
        public string Pair { get; set; }
        public string Discipline { get; set; }
        public string Group { get; set; }
        public bool IsThemeChecked { get; set; }


        public Replacement(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;
            toolTip1.SetToolTip(BtnAddRows, "Добавить пару");
            toolTip1.SetToolTip(BtnDelRows, "Отменить пару");
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

        private void LoadSetting()
        {
            if (IsThemeChecked)
            {
                GridTransmitt.BackgroundColor = Color.FromArgb(50, 50, 50);
                GridTransmitt.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            }
            else if (!IsThemeChecked)
            {
                GridTransmitt.BackgroundColor = Color.WhiteSmoke;
                GridTransmitt.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            }
        }
        private void LoadGetData()
        {
            DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
            pairColumn.HeaderText = "Пара";
            pairColumn.DataPropertyName = "Pair"; // Свойство данных для отображения в этой колонке
            pairColumn.Name = "Pair"; // Имя колонки
            GridTransmitt.Columns.Add(pairColumn);

            DataGridViewColumn DisplineColumn = new DataGridViewTextBoxColumn();
            DisplineColumn.HeaderText = "Дисциплина";
            DisplineColumn.DataPropertyName = "Displine"; // Свойство данных для отображения в этой колонке
            DisplineColumn.Name = "Displine"; // Имя колонки
            GridTransmitt.Columns.Add(DisplineColumn);

            DataGridViewColumn GroupColumn = new DataGridViewTextBoxColumn();
            GroupColumn.HeaderText = "Группа";
            GroupColumn.DataPropertyName = "Group"; // Свойство данных для отображения в этой колонке
            GroupColumn.Name = "Group"; // Имя колонки
            GridTransmitt.Columns.Add(GroupColumn);

            int rowIndex = GridTransmitt.Rows.Add(Pair, Discipline, Group);
            GridTransmitt.AutoGenerateColumns = false;
            GridTransmitt.ReadOnly = true;

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
        public int GetPairId(string pairName)
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Pairs.FirstOrDefault(p => p.Pair == pairName)?.ID ?? 0;
            }
        }

        // Метод получения ID дисциплины
        public int GetDisciplineId(string disciplineName)
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Displines.FirstOrDefault(d => d.NameDispline == disciplineName)?.ID ?? 0;
            }
        }

        // Метод получения ID группы
        public int GetGroupId(string groupName)
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Groups.FirstOrDefault(g => g.NameGroup == groupName)?.ID ?? 0;
            }
        }
        private void Replacement_Load(object sender, EventArgs e)
        {
            label1.Text = TransmissionOfInformation.Data;
            label2.Text = TransmissionOfInformation.DayWeek;
            label1.Font = new Font("Segui UI", 12, FontStyle.Bold);
            label2.Font = new Font("Segui UI", 12, FontStyle.Bold);
            LoadGetData();
            LoadSetting();
            GridTransmitt.ColumnHeadersDefaultCellStyle.SelectionBackColor = editingForm.GetColorFromTheme(themeSettings);
        }

        private void BtnAddRows_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnAddRows, themeSettings);
        }

        private void BtnAddRows_MouseLeave(object sender, EventArgs e)
        {
            BtnAddRows.BackColor = Color.Transparent;
        }

        private void BtnDelRows_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnDelRows, themeSettings);
        }

        private void BtnDelRows_MouseLeave(object sender, EventArgs e)
        {
            BtnDelRows.BackColor = Color.Transparent;
        }

        private void GridTransmitt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.GridTransmitt.Columns[e.ColumnIndex].DataPropertyName == "Pair" ||
               this.GridTransmitt.Columns[e.ColumnIndex].DataPropertyName == "Displine" ||
               this.GridTransmitt.Columns[e.ColumnIndex].DataPropertyName == "Group")
            {

                e.CellStyle.Font = new Font("Segui UI", 13, FontStyle.Bold);
            }
        }

        private void BtnDelRows_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите убрать урок на " + label1.Text, "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int pairId = GetPairId(Pair);
                int disciplineId = GetDisciplineId(Discipline);
                int groupId = GetGroupId(Group);


                var ChangesID = context.CurrentsShedules
       .Where(Rows => Rows.Data == label1.Text && Rows.TimeTables.Pair.Pair == Pair)
       .ToList();
                foreach(var D in ChangesID)
                {
                    context.CurrentsShedules.Remove(D);
                }
                context.SaveChanges();
                //int TimeTableID = GetTimeTableId(Pair, Discipline, Group);


                guna2CircleProgressBar1.Visible = true;
                currentProgress = 0;
                guna2CircleProgressBar1.Value = currentProgress;
                progressTimer.Start();
                MessageBox.Show("Пара была отменена на " + label1.Text + " обновите таблицу ", "Информирование", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();



            }
            
        }

        private void BtnAddRows_Click(object sender, EventArgs e)
        {
            MechanismoFAddingPairs mech = new MechanismoFAddingPairs(themeSettings);
            mech.IsThemeChecked = IsThemeChecked;
            mech.EmptyPairsForDay = EmptyForAddForm;
            mech.ShowDialog();


        }
    }
}

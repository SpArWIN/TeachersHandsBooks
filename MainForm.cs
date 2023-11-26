using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TeachersHandsBooks.Core;

namespace TeachersHandsBooks
{
    public partial class MainForm : MaterialForm
    {

        private readonly ThemeSettings ThemSet = new ThemeSettings();
        readonly MaterialSkinManager ThemeSkin = MaterialSkinManager.Instance;
        EdingFormValue editingForm = new EdingFormValue();
        private DatabaseContext context = new DatabaseContext();
        // для гифки
        private Image gifImage;
        private DateTime currentDate;
        private LinkedList<(DayOfWeek WeekDay, DateTime Date)> daysAndDatesList; //Даты вперед
        private LinkedList<(DayOfWeek WeekDay, DateTime Date)> daysAndDatesPrevious; // Даты назад

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Blue400, TextShade.WHITE);
            LoadSettings();
            gifImage = Properties.Resources.dsds;
            toolTip1.SetToolTip(BtnAddGroup, "Добавление групп");
            toolTip1.SetToolTip(BtnDispAdd, "Добавление дисциплин");
            toolTip1.SetToolTip(BtnConnectionDispGroup, "Добавление КТП");
            toolTip1.SetToolTip(FormRasp, "Формирование расписания ");
            toolTip1.SetToolTip(BoxUpdate, "Обновление таблицы");
            toolTip1.SetToolTip(BtnChangePairs, "Изменение расписания");

            GroupAddBOx.Font = new Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Italic);
            currentDate = DateTime.Now;
            daysAndDatesList = GenerateDaysAndDates(currentDate);
            daysAndDatesPrevious = GenerateDaysAndDatesPrevious(currentDate);





        }
        public void SaveSettings()
        {

            Properties.Settings.Default.Theme = ThemeSkin.Theme.ToString();

            // Сохраняем выбор пользователя по цветовой схеме
            if (BtnBlueRad.Checked)
            {

                ThemSet.ColorTheme = "Blue";
            }
            else if (BtnRedRad.Checked)
            {

                ThemSet.ColorTheme = "Red";
            }
            else if (BtnOrangeRad.Checked)
            {

                ThemSet.ColorTheme = "Orange";
            }
            else if (BtnGreenRad.Checked)
            {
                ThemSet.ColorTheme = "Green";
            }
            else
            {
                ThemSet.ColorTheme = "Blue";
            }
            SwitchTheme.Checked = (ThemeSkin.Theme == MaterialSkinManager.Themes.DARK);
            if (SwitchTheme.Checked)
            {
                GroupAddBOx.FillColor = Color.Transparent;
                GridRaspisanie.BackgroundColor = Color.FromArgb(50, 50, 50);
                GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;




            }
            else if (!SwitchTheme.Checked)
            {
                GroupAddBOx.FillColor = Color.WhiteSmoke;
                GridRaspisanie.BackgroundColor = Color.WhiteSmoke;
                GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Teal;
            }



            Properties.Settings.Default.ColorTheme = ThemSet.ColorTheme;
            editingForm.SetBorderColorFromTheme(GroupAddBOx, ThemSet);
            Properties.Settings.Default.Save();
            MainTabControl.SelectedTab = HomePage;


        }
       
        //Метод загрузки
        private void LoadSettings()
        {
            string theme = Properties.Settings.Default.Theme;

            //Сохраняем тему
            if (!string.IsNullOrEmpty(theme))
            {
                ThemeSkin.Theme = (MaterialSkinManager.Themes)Enum.Parse(typeof(MaterialSkinManager.Themes), theme);
            }
            //Цвет
            string colorScheme = Properties.Settings.Default.ColorTheme;
            if (!string.IsNullOrEmpty(colorScheme))
            {
                if (colorScheme == "Blue")
                {
                    BtnBlueRad.Checked = true;

                }
                else if (colorScheme == "Red")
                {
                    BtnRedRad.Checked = true;
                }
                else if (colorScheme == "Orange")
                {
                    BtnOrangeRad.Checked = true;
                }
                else if (colorScheme == "Green")
                {
                    BtnGreenRad.Checked = true;
                }

            }

            SwitchTheme.Checked = (ThemeSkin.Theme == MaterialSkinManager.Themes.DARK);
            if (SwitchTheme.Checked)
            {
                GroupAddBOx.FillColor = Color.Transparent;
                GridRaspisanie.BackgroundColor = Color.FromArgb(50, 50, 50);
                GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;




            }
            else if (!SwitchTheme.Checked)
            {
                GroupAddBOx.FillColor = Color.WhiteSmoke;
                GridRaspisanie.BackgroundColor = Color.WhiteSmoke;
                GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Teal;
            }
        }


        private void MarkRowsForCurrentDate()
        {
            // Проверка наличия записи для текущей даты в базе данных
            var entryForCurrentDate = context.Modifieds.FirstOrDefault(entry => entry.Data == label2.Text);

            if (entryForCurrentDate != null)
            {
                foreach (DataGridViewRow row in GridRaspisanie.Rows)
                {
                    string pair = row.Cells["Pair"].Value?.ToString();
                    string discipline = row.Cells["Discipline"].Value?.ToString();
                    string group = row.Cells["Group"].Value?.ToString();

                    // Сравнение записи в DataGridView с найденной записью для текущей даты
                    if (pair == entryForCurrentDate.TimeTable.Pair.Pair &&
                        discipline == entryForCurrentDate.TimeTable.DisplineWithGroup.Displine.NameDispline &&
                        group == entryForCurrentDate.TimeTable.DisplineWithGroup.Group.NameGroup)
                    {
                        row.DefaultCellStyle.BackColor = Color.Brown; 
                       // row.Visible = false;
                        row.ReadOnly = true; 
                       
                        
                    }
                }
            }
        }
        public void TodayDay()
        {


            DateTime Data = currentDate.Date;
            label2.Text = Data.ToString("d", new CultureInfo("ru-RU"));
            string dayOfWeekRussian = currentDate.ToString("dddd", new CultureInfo("ru-RU"));


                var dayId = context.DayTables.FirstOrDefault(day => day.Day.Equals(dayOfWeekRussian, StringComparison.OrdinalIgnoreCase))?.ID;
                if (dayId != null)
                {
                    GridRaspisanie.Columns.Clear();
                    var todayEntries = context.TimeTables
              .Where(entry => entry.Day.ID == dayId)
              .OrderBy(entry => entry.Pair.ID) // Сортировка по ID пары из таблицы Pairs
              .Select(entry => new
              {
                  Group = entry.DisplineWithGroup.Group.NameGroup,
                  Discipline = entry.DisplineWithGroup.Displine.NameDispline,
                  Pair = entry.Pair.Pair
              })

              .ToList();


                    DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
                    pairColumn.HeaderText = "Пары";
                    pairColumn.DataPropertyName = "Pair";
                    pairColumn.Name = "Pair";
                    GridRaspisanie.Columns.Add(pairColumn);

                    DataGridViewColumn disciplineColumn = new DataGridViewTextBoxColumn();
                    disciplineColumn.HeaderText = "Дисциплина";
                    disciplineColumn.DataPropertyName = "Discipline";
                    disciplineColumn.Name = "Discipline";
                    GridRaspisanie.Columns.Add(disciplineColumn);

                    DataGridViewColumn groupColumn = new DataGridViewTextBoxColumn();
                    groupColumn.HeaderText = "Группа";
                    groupColumn.DataPropertyName = "Group";
                    groupColumn.Name = "Group";
                    GridRaspisanie.Columns.Add(groupColumn);




                    GridRaspisanie.AutoGenerateColumns = false;
                    GridRaspisanie.DataSource = todayEntries;
                    label1.Text = dayOfWeekRussian;
                    label1.Font = new Font("Segui UI", 14);
                label1.BackColor = Color.Transparent;
                MarkRowsForCurrentDate();
            }
            else
                {
                    if (dayOfWeekRussian.Equals("воскресенье", StringComparison.OrdinalIgnoreCase))
                    {
                        GridRaspisanie.Columns.Clear(); // Очищаем столбцы

                        label1.Text = "Воскресенье"; // Устанавливаем текст метки как "Воскресенье"
                        label1.Font = new Font("Segui UI", 14);
                        label1.BackColor = Color.Transparent;



                        DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
                        pairColumn.HeaderText = "Выходной";
                        GridRaspisanie.Columns.Add(pairColumn);


                    }
                    else
                    {
                        // Действия при отсутствии данных для других дней недели (не Воскресенье)
                        MessageBox.Show("Нет данных для этого дня.");
                    }
                }
            }
        


        public void DisplayScheduleForDay(DayOfWeek dayOfWeek, DateTime date)
        {
            DateTime Data = date.Date;
            label2.Text = Data.ToString("d", new CultureInfo("ru-RU"));
            string dayOfWeekRussian = date.ToString("dddd", new CultureInfo("ru-RU"));



                var dayId = context.DayTables.FirstOrDefault(day => day.Day.Equals(dayOfWeekRussian, StringComparison.OrdinalIgnoreCase))?.ID;
                if (dayId != null)
                {
                    GridRaspisanie.Columns.Clear();
                    var todayEntries = context.TimeTables
                        .Where(entry => entry.Day.ID == dayId)
                        .OrderBy(entry => entry.Pair.ID)
                        .Select(entry => new
                        {
                            Group = entry.DisplineWithGroup.Group.NameGroup,
                            Discipline = entry.DisplineWithGroup.Displine.NameDispline,
                            Pair = entry.Pair.Pair
                        })
                        .ToList();

                    DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
                    pairColumn.HeaderText = "Пары";
                    pairColumn.DataPropertyName = "Pair";
                    pairColumn.Name = "Pair";
                    GridRaspisanie.Columns.Add(pairColumn);

                    DataGridViewColumn disciplineColumn = new DataGridViewTextBoxColumn();
                    disciplineColumn.HeaderText = "Дисциплина";
                    disciplineColumn.DataPropertyName = "Discipline";
                    disciplineColumn.Name = "Discipline";
                    GridRaspisanie.Columns.Add(disciplineColumn);

                    DataGridViewColumn groupColumn = new DataGridViewTextBoxColumn();
                    groupColumn.HeaderText = "Группа";
                    groupColumn.DataPropertyName = "Group";
                    groupColumn.Name = "Group";
                    GridRaspisanie.Columns.Add(groupColumn);




                    // Привязываем результаты к DataGridView
                    GridRaspisanie.AutoGenerateColumns = false;
                    GridRaspisanie.DataSource = todayEntries;
                    label1.Text = dayOfWeekRussian;
                    label1.Font = new Font("Segui UI", 14);
                    label1.BackColor = Color.Transparent;
                MarkRowsForCurrentDate();

            }
                else
                {
                    if (dayOfWeekRussian.Equals("воскресенье", StringComparison.OrdinalIgnoreCase))
                    {
                        DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
                        pairColumn.HeaderText = "Выходной";
                        // Значение прочерка
                        GridRaspisanie.Columns.Add(pairColumn);
                        GridRaspisanie.AutoGenerateColumns = false;
                        GridRaspisanie.DataSource = null;
                    }
                }
            
        }

      
        /// <summary>
        /// Формирование дат, относительно текущего дня
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns></returns>
        public LinkedList<(DayOfWeek WeekDay, DateTime Date)> GenerateDaysAndDates(DateTime currentDate)
        {
            DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

            LinkedList<(DayOfWeek, DateTime)> daysAndDatesList = new LinkedList<(DayOfWeek, DateTime)>();

            daysAndDatesList.AddLast((currentDayOfWeek, currentDate));

            for (int i = 1; i <= 14; i++)
            {
                currentDate = currentDate.AddDays(1);
                currentDayOfWeek = currentDate.DayOfWeek;

                if (currentDayOfWeek != DayOfWeek.Sunday)
                {
                    daysAndDatesList.AddLast((currentDayOfWeek, currentDate));
                }
            }

            return daysAndDatesList;
        }


        public LinkedList<(DayOfWeek WeekDay, DateTime Date)> GenerateDaysAndDatesPrevious(DateTime currentDate)
        {
            DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

            LinkedList<(DayOfWeek, DateTime)> daysAndDatesList = new LinkedList<(DayOfWeek, DateTime)>();

            // Добавляем текущую дату и день недели в список
            daysAndDatesList.AddLast((currentDayOfWeek, currentDate));

            // Добавляем предыдущие дни относительно текущей даты
            for (int i = 1; i <= 14; i++)
            {
                currentDate = currentDate.AddDays(-1); // Уменьшаем дату на один день
                currentDayOfWeek = currentDate.DayOfWeek;

                if (currentDayOfWeek != DayOfWeek.Sunday)
                {
                    daysAndDatesList.AddFirst((currentDayOfWeek, currentDate)); // Добавляем день в начало списка
                }
            }

            // Возвращаем список дней
            return daysAndDatesList;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            GridRaspisanie.ClearSelection();
         
            BtnChangePairs.Enabled = false;
            TodayDay();

           

            gifImage = Properties.Resources.LoadPicture;
            BoxUpdate.Image = gifImage;
           // SetFontStyleForAllCells(GridRaspisanie, FontStyle.Bold);
            label1.Font = new Font("Arial", 12, FontStyle.Bold);
            label2.Font = new Font("Arial", 10, FontStyle.Bold);
            label1.Text = label1.Text.ToUpper();
            



            SaveSettings();
        }





        private void BtnSaveChangeTheme_Click_1(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SwitchTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchTheme.Checked)
            {
                ThemeSkin.Theme = MaterialSkinManager.Themes.DARK;
                LabelSmen.Text = " на светлую тему";

            }
            else
            {
                ThemeSkin.Theme = MaterialSkinManager.Themes.LIGHT;
                LabelSmen.Text = " на тёмную тему";
            }
        }

        private void BtnBlueRad_CheckedChanged(object sender, EventArgs e)
        {
            ThemeSkin.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue700, Primary.Blue600, Accent.LightBlue700, TextShade.WHITE);
        }

        private void BtnRedRad_CheckedChanged(object sender, EventArgs e)
        {
            ThemeSkin.ColorScheme = new ColorScheme(Primary.Red700, Primary.Red600, Primary.Red500, Accent.Red200, TextShade.WHITE);
        }

        private void BtnOrangeRad_CheckedChanged(object sender, EventArgs e)
        {
            ThemeSkin.ColorScheme = new ColorScheme(Primary.Orange800, Primary.Orange700, Primary.Orange500, Accent.Orange200, TextShade.WHITE);
        }

        private void BtnGreenRad_CheckedChanged_1(object sender, EventArgs e)
        {
            ThemeSkin.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green500, Primary.LightGreen700, Accent.Green700, TextShade.WHITE);
        }

        private void FormRasp_Click(object sender, EventArgs e)
        {

        }

        private void FormRasp_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(FormRasp, ThemSet);
        }

        private void FormRasp_MouseLeave(object sender, EventArgs e)
        {
            FormRasp.BackColor = Color.Transparent;
        }

        private void BtnDispAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnDispAdd_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnDispAdd, ThemSet);
        }

        private void BtnDispAdd_MouseLeave(object sender, EventArgs e)
        {
            BtnDispAdd.BackColor = Color.Transparent;
        }



        private void BtnAddGroup_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnAddGroup, ThemSet);
        }

        private void BtnAddGroup_MouseLeave(object sender, EventArgs e)
        {
            BtnAddGroup.BackColor = Color.Transparent;
        }

        private void BtnConnectionDispGroup_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnConnectionDispGroup, ThemSet);
        }

        private void BtnConnectionDispGroup_MouseLeave(object sender, EventArgs e)
        {
            BtnConnectionDispGroup.BackColor = Color.Transparent;
        }

        private void BtnAddGroup_Click_1(object sender, EventArgs e)
        {
            FormAddGroup Group = new FormAddGroup(ThemSet);
            Group.ShowDialog();
        }

        private void BtnDispAdd_Click_1(object sender, EventArgs e)
        {
            FormDisplineAdd AddDispline = new FormDisplineAdd(ThemSet);
            AddDispline.ShowDialog();
        }

        private void BtnConnectionDispGroup_Click(object sender, EventArgs e)
        {
            FormAddKTP Ktp = new FormAddKTP(ThemSet);
            Ktp.ShowDialog();
        }

        private void FormRasp_Click_1(object sender, EventArgs e)
        {
            MainForm mainFormInstance = new MainForm();
            FormationRasp Rasp = new FormationRasp(ThemSet, mainFormInstance);
            Rasp.Show();
        }

        private void GridRaspisanie_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

        }

        private void GroupAddBOx_Click(object sender, EventArgs e)
        {

        }
        private void StartAnimate()
        {
            if (BoxUpdate.Image == gifImage)
            {
                Timer timer = new Timer();
                timer.Interval = 5000; // 5000 миллисекунд = 5 секунд

                // Воспроизводим анимацию в течение 5 секунд
                BoxUpdate.Image = Properties.Resources.dsds; // Очищаем изображение
                timer.Tick += (s, args) =>
                {
                    BoxUpdate.Image = gifImage; // Останавливаем анимацию
                    timer.Stop(); // Останавливаем таймер
                    timer.Dispose(); // Освобождаем ресурсы таймера
                };
                timer.Start(); // Запускаем таймер
            }
        }
        private void BoxUpdate_Click(object sender, EventArgs e)
        {
            StartAnimate();
            currentDate = DateTime.Now; // Обновляем текущую дату
            daysAndDatesList = GenerateDaysAndDates(currentDate); // Обновляем список дней и дат начиная с новой текущей даты
            daysAndDatesPrevious = GenerateDaysAndDatesPrevious(currentDate);
            DisplayScheduleForDay(currentDate.DayOfWeek, currentDate); // Показываем расписание для текущего дня
            TodayDay();
          
            foreach (var node in daysAndDatesList)
            {
                if (node.Date.Date == currentDate.Date)
                {
                    currentNode = daysAndDatesList.Find(node);
                    break;
                }
            }
        }

        private void BtnPreviev_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnPreviev, ThemSet);
        }

        private void BtnNext_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnNext, ThemSet);
        }

        private void BtnPreviev_MouseLeave(object sender, EventArgs e)
        {
            BtnPreviev.BackColor = Color.Transparent;
        }

        private void BtnNext_MouseLeave(object sender, EventArgs e)
        {
            BtnNext.BackColor = Color.Transparent;
        }
        private LinkedListNode<(DayOfWeek WeekDay, DateTime Date)> currentNode; // Создаем переменную для хранения текущего узла

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentNode?.Next != null)
            {
                currentNode = currentNode.Next; // Переходим к следующему узлу
                var nextDay = currentNode.Value;
                
                // Вызываем метод для отображения расписания для следующего дня
                DisplayScheduleForDay(nextDay.WeekDay, nextDay.Date);
            }
            else
            {


                currentNode = daysAndDatesList.First;
            }
        }

        private void GridRaspisanie_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Проверяем столбец, для которого мы хотим установить стиль
            if (this.GridRaspisanie.Columns[e.ColumnIndex].DataPropertyName == "Pair" ||
                this.GridRaspisanie.Columns[e.ColumnIndex].DataPropertyName == "Discipline" ||
                this.GridRaspisanie.Columns[e.ColumnIndex].DataPropertyName == "Group")
            {
               
                e.CellStyle.Font = new Font("Segui UI", 13, FontStyle.Bold);
            }
            Color textColor = SwitchTheme.Checked ? Color.White : Color.Black;
            e.CellStyle.ForeColor = textColor;
        }

        private void BtnPreviev_Click(object sender, EventArgs e)
        {
            if (currentNode?.Previous != null)
            {
                currentNode = currentNode.Previous; // Переходим к следующему узлу
                var previousDay = currentNode.Value;

                // Вызываем метод для отображения расписания для следующего дня
                DisplayScheduleForDay(previousDay.WeekDay, previousDay.Date);
            }
            else
            {

              
                currentNode = daysAndDatesList.First;
            }
        }

        private void BtnChangePairs_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnChangePairs, ThemSet);
        }

        private void BtnChangePairs_MouseLeave(object sender, EventArgs e)
        {
            BtnChangePairs.BackColor = Color.Transparent;
        }

        private void GridRaspisanie_SelectionChanged(object sender, EventArgs e)
        {
            if (GridRaspisanie.SelectedRows.Count > 0)
            {
                // Если выбрана хотя бы одна строка, включаем кнопку замены
                BtnChangePairs.Enabled = true;
            }
            else
            {
                // Если ничего не выбрано, отключаем кнопку замены
                BtnChangePairs.Enabled = false;
            }
        }

        private void BtnChangePairs_Click(object sender, EventArgs e)
        {
          if(  GridRaspisanie.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridRaspisanie.SelectedRows[0];
                string pairValue = selectedRow.Cells["pair"].Value?.ToString();
                string disciplineValue = selectedRow.Cells["Discipline"].Value?.ToString();
                string groupValue = selectedRow.Cells["Group"].Value?.ToString();
                /*На основе полученных значений, открываю форму и передаю их туда,для дальнейшего изменение, добавления
                 * или удаления
                */

                Replacement replacement = new Replacement(ThemSet);
                TransmissionOfInformation.Data = label2.Text;
                TransmissionOfInformation.DayWeek = label1.Text;
                replacement.Pair = pairValue;
                replacement.Discipline = disciplineValue;
                replacement.Group = groupValue;
                replacement.IsThemeChecked = SwitchTheme.Checked;

                replacement.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите строку для дальнейшего взаимодействия", "Ошибка выполнения команды", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }


}



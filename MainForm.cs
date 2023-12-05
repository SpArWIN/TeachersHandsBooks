using MaterialSkin;
using MaterialSkin.Controls;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using TeachersHandsBooks.Core.Tables;


namespace TeachersHandsBooks
{
    public partial class MainForm : MaterialForm
    {
        public string KtpPath { get; set; }
        //О программе
        private Timer PrintTimer;
        private string TextToPrint;
        private int CurrentIndex = 0;
        private Control OutputControl;
       

        private readonly ThemeSettings ThemSet = new ThemeSettings();
        readonly MaterialSkinManager ThemeSkin = MaterialSkinManager.Instance;
        EdingFormValue editingForm = new EdingFormValue();
        //Для пустых пар
        private List<string> emptyPairsForDay { get; set; } = new List<string>();

        private DatabaseContext context = new DatabaseContext();
        // для гифки
        private Image gifImage;
        private DateTime currentDate;
        private LinkedList<(DayOfWeek WeekDay, DateTime Date)> daysAndDatesList ; //Даты вперед
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
            toolTip1.SetToolTip(FormRasp, "Формирование шаблона расписания ");
            toolTip1.SetToolTip(BoxUpdate, "Обновление таблицы");
            toolTip1.SetToolTip(BtnChangePairs, "Изменение расписания");

            GroupAddBOx.Font = new Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Italic);
            currentDate = DateTime.Now;
           
            currentNode = GenerateDaysAndDates();
           
            PrintTimer = new Timer();
            PrintTimer.Interval = 50; // Интервал между печатью символов (в миллисекундах)
            PrintTimer.Tick += PrintTimer_Tick;
            OutputControl = PrintedText;
            OutputControl.Font = new Font("Segui UI", 14, FontStyle.Regular);



        }

        private void PrintTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentIndex < TextToPrint.Length)
            {
                // Печать текста посимвольно
                OutputControl.Text += TextToPrint[CurrentIndex];
                CurrentIndex++;
            }
            else
            {
                // Когда весь текст напечатан, останавливаем таймер
                PrintTimer.Stop();
            }
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
                TheoryDataGrid.BackgroundColor = Color.FromArgb(50, 50, 50);
                GridRaspisanie.BackgroundColor = Color.FromArgb(50, 50, 50);
                GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
                TheoryDataGrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;





            }
            else if (!SwitchTheme.Checked)
            {
                GroupAddBOx.FillColor = Color.WhiteSmoke;
                GridRaspisanie.BackgroundColor = Color.WhiteSmoke;
                GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
                TheoryDataGrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
                TheoryDataGrid.BackgroundColor = Color.WhiteSmoke;
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
                //  GridRaspisanie.BackgroundColor = Color.FromArgb(214, 214, 214);
                //   GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;




            }
            else if (!SwitchTheme.Checked)
            {
                GroupAddBOx.FillColor = Color.WhiteSmoke;
                //  GridRaspisanie.BackgroundColor = Color.FromArgb(214, 214, 214);
                //  GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            }
        }

        private void MarkRowsCur()
        {
            var changesForCurrentDate = context.ChangesTables
    .Where(change => change.Data == label2.Text)
    .ToList();

            // Проходимся по записям из таблицы Changes и отмечаем соответствующие строки в GridRaspisanie
            foreach (var change in changesForCurrentDate)
            {
                for (int i = 0; i < GridRaspisanie.Rows.Count; i++)
                {
                    DataGridViewRow row = GridRaspisanie.Rows[i];
                    string pair = row.Cells["Pair"].Value?.ToString();
                    string group = row.Cells["Group"].Value?.ToString();
                    string discipline = row.Cells["Discipline"].Value?.ToString();

                    // Сравниваем данные из GridRaspisanie с данными из таблицы Changes для текущей даты
                    if (pair == change.Pair.Pair
                        && discipline == change.WithGroup.Displine.NameDispline
                        && group == change.WithGroup.Group.NameGroup)
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
        }
        

          
        public void TodayDay()
        {


            DateTime Data = currentDate.Date;
            label2.Text = Data.ToString("d", new CultureInfo("ru-RU"));
            string dayOfWeekRussian = currentDate.ToString("dddd", new CultureInfo("ru-RU"));
            label1.Text = dayOfWeekRussian;
            string formattedDate = currentDate.ToString("d", new CultureInfo("ru-RU"));

            var dayId = context.DayTables.FirstOrDefault(day => day.Day.Equals(dayOfWeekRussian, StringComparison.OrdinalIgnoreCase))?.ID;

            if (dayId != null)
            {
                GridRaspisanie.Columns.Clear();

                var currentScheduleEntry = context.CurrentsShedules
                    .FirstOrDefault(schedule => schedule.Data == formattedDate);

                if (currentScheduleEntry != null)
                {
                    
                      
                    //Все пары
                      var allPairs = context.Pairs
                        .Select(entry => entry.Pair)
                        .ToList();
                    //пары текущие
                    var existingPairs = context.CurrentsShedules
    .Where(entry => entry.Data == formattedDate)
    .Select(entry => entry.TimeTables.Pair.Pair)
    .ToList();


                    //Вытянутые текущие данные бд
                    var temporaryEntries = context.CurrentsShedules
                    .Where(entry => entry.Data == formattedDate)
                    .Select(entry => new
                    {
                        Pair = entry.TimeTables.Pair.Pair,
                        Group = entry.TimeTables.DisplineWithGroup.Group.NameGroup,
                        Discipline = entry.TimeTables.DisplineWithGroup.Displine.NameDispline,
                    })
                    .ToList();

                    // Запрос на получение отмененных пар для определенного дня
                    var CancelledPair = context.TimeTables
                        .Where(pair => pair.Day.Day == formattedDate)
                        .Select(pair => pair.Pair.Pair)
                        .ToList();

               

                     emptyPairsForDay = allPairs.Except(existingPairs).Union(CancelledPair).ToList();

                    // Добавление столбцов в DataGridView
                    AddDataGridViewColumns();

                 
                    //Добавление
                    var changesForCurrentDate = context.ChangesTables
 .Where(change => change.Data == label2.Text)
 .ToList();
                    if (changesForCurrentDate.Count > 0)
                    {
                        var additionalEntries = changesForCurrentDate
                            .Select(change => new
                            {
                                Pair = change.Pair.Pair,
                                Group = change.WithGroup.Group.NameGroup,
                                Discipline = change.WithGroup.Displine.NameDispline,
                            })
                            .ToList();

                        temporaryEntries.AddRange(additionalEntries);
                    }

                    GridRaspisanie.DataSource = temporaryEntries;
                    GridRaspisanie.ResetBindings();

                    GridRaspisanie.AutoGenerateColumns = false;

                    label1.Text = dayOfWeekRussian;
                    label1.Font = new Font("Segui UI", 14);
                    label1.BackColor = Color.Transparent;
                    GridRaspisanie.ClearSelection();
                   
                    MarkRowsCur();
                }
                else
                {
                    //   HandleNoDataForDayOfWeek(dayOfWeekRussian);
                    BtnNext.Enabled = false;
                    BtnPreviev.Enabled = false;

                }
            }
            else
            {
                if (dayOfWeekRussian.Equals("воскресенье", StringComparison.OrdinalIgnoreCase))
                {
                    GridRaspisanie.Columns.Clear();
                    label1.Text = "Воскресенье";
                    label1.Font = new Font("Segui UI", 14);
                    label1.BackColor = Color.Transparent;

                    DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
                    pairColumn.HeaderText = "Выходной";
                    GridRaspisanie.Columns.Add(pairColumn);
                }
                else
                {
                    MessageBox.Show("Нет данных для этого дня.");
                }
            }
        }

            private void AddDataGridViewColumns()
            {
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
            }
            private void HandleNoDataForDayOfWeek(string dayOfWeekRussian)
            {
                if (dayOfWeekRussian.Equals("воскресенье", StringComparison.OrdinalIgnoreCase))
                {
                    GridRaspisanie.Columns.Clear();
                    label1.Text = "Воскресенье";
                    label1.Font = new Font("Segui UI", 14);
                    label1.BackColor = Color.Transparent;

                    DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
                    pairColumn.HeaderText = "Выходной";
                    GridRaspisanie.Columns.Add(pairColumn);
                }
            }

        public void DisplayScheduleForDay(LinkedListNode<(DayOfWeek WeekDay, DateTime Date)> currentNode)
        {

            if (currentNode != null)
            {
                DayOfWeek dayOfWeek = currentNode.Value.WeekDay;
                DateTime date = currentNode.Value.Date;

                DateTime Data = date.Date;
                label2.Text = Data.ToString("d", new CultureInfo("ru-RU"));
                string dayOfWeekRussian = date.ToString("dddd", new CultureInfo("ru-RU"));

                var dayId = context.DayTables.FirstOrDefault(day => day.Day.Equals(dayOfWeekRussian, StringComparison.OrdinalIgnoreCase))?.ID;

                if (dayId != null)
                {
                    GridRaspisanie.Columns.Clear();

                    var temporaryEntries = context.CurrentsShedules
                        .Where(entry => entry.Data == label2.Text && entry.TimeTables.Day.Day == dayOfWeekRussian)
                        .Select(entry => new
                        {
                            Pair = entry.TimeTables.Pair.Pair,
                            Group = entry.TimeTables.DisplineWithGroup.Group.NameGroup,
                            Discipline = entry.TimeTables.DisplineWithGroup.Displine.NameDispline,
                        })
                        .ToList();
                    //Все пары
                    var allPairs = context.Pairs
                        .Select(entry => entry.Pair)
                        .ToList();


                    var existingPairs = context.CurrentsShedules
.Where(entry => entry.Data == label2.Text)
.Select(entry => entry.TimeTables.Pair.Pair)
.ToList();
                    //Отмененные пары
                    var CancelledPair = context.TimeTables
                        .Where(pair => pair.Day.Day == label2.Text)
                        .Select(pair => pair.Pair.Pair)
                        .ToList();
                    emptyPairsForDay = allPairs.Except(existingPairs).Union(CancelledPair).ToList();

                    var changesForCurrentDate = context.ChangesTables
.Where(change => change.Data == label2.Text)
.ToList();
                    if (changesForCurrentDate.Count > 0)
                    {
                        var additionalEntries = changesForCurrentDate
                            .Select(change => new
                            {
                                Pair = change.Pair.Pair,
                                Group = change.WithGroup.Group.NameGroup,
                                Discipline = change.WithGroup.Displine.NameDispline,
                            })
                            .ToList();

                        temporaryEntries.AddRange(additionalEntries);
                    }



                    GridRaspisanie.AutoGenerateColumns = false;

                    label1.Text = dayOfWeekRussian;
                    label1.Font = new Font("Segui UI", 14);
                    label1.BackColor = Color.Transparent;
                    AddDataGridViewColumns();

                    GridRaspisanie.DataSource = temporaryEntries;
                    GridRaspisanie.ResetBindings();
                    GridRaspisanie.Refresh();

                    // Проверяем, если пары уже есть на этот день
                    //var existingPairs = todayEntries.Select(entry => entry.Pair).ToList();
                    //// Проверяем наличие отмененных пар для указанной даты
                    //var cancelledPairs = context.Modifieds
                    //                        .Where(modified => modified.Data == label2.Text && modified.isAdded == false)
                    //                        .Select(modified => modified.TimeTable.Pair.Pair)
                    //                        .ToList();
                    //// Формируем список доступных пар на этот день (пары, которые не заняты и не отменены)
                    //emptyPairsForDay = allPairs.Except(existingPairs).Union(cancelledPairs).ToList();


                    //if (temporaryEntries != null)
                    //{
                    //    todayEntries.AddRange(temporaryEntries);

                    //}



                    MarkRowsCur();
                  //  MarkRowsForCurrentDate();
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


        }

            /// <summary>
            /// Формирование дат, относительно текущего дня
            /// </summary>
            /// <param name="currentDate"></param>
            /// <returns></returns>
            public LinkedListNode<(DayOfWeek WeekDay, DateTime Date)> GenerateDaysAndDates()
            {
               daysAndDatesList = new LinkedList<(DayOfWeek, DateTime)>();

            // Получаем уникальные даты из таблицы CurrentShedule
            var uniqueDates = context.CurrentsShedules
      .Select(x => x.Data)
      .Distinct()
      .OrderBy(dateString => dateString) // Сохраняем уникальные даты в том порядке, в котором они появляются в базе данных
      .ToList();
            foreach (var dateString in uniqueDates)
                {
                    if (DateTime.TryParse(dateString, out DateTime date))
                    {
                        DayOfWeek currentDayOfWeek = date.DayOfWeek;
                        daysAndDatesList.AddLast((currentDayOfWeek, date));
                    }
                    else
                    {
                        // Обработка ошибок преобразования даты
                    }
                }

                // Создаем LinkedList из списка дней и дат
                var linkedList = new LinkedList<(DayOfWeek WeekDay, DateTime Date)>(daysAndDatesList);

                // Возвращаем первый узел списка
                return linkedList.First;
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
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                BtnChangePairs.Enabled = false;
                TodayDay();

                TheoryDataGrid.ColumnHeadersDefaultCellStyle = editingForm.SetDataGridViewStyleFromThemes(TheoryDataGrid, ThemSet);

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
                
             
               
                TodayDay();
            currentNode = daysAndDatesList.First;
            while (currentNode != null && currentNode.Value.Date.Date != currentDate.Date)
            {
                currentNode = currentNode.Next;
                BtnNext.Enabled = true;
            }

            // Если узел не найден, устанавливаем текущий узел в начало списка
            if (currentNode == null)
            {
                currentNode = daysAndDatesList.First;
                BtnNext.Enabled = true;
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
        private LinkedListNode<(DayOfWeek WeekDay, DateTime Date)> currentNode;  // Создаем переменную для хранения текущего узла

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentNode?.Next != null)
            {
                
                currentNode = currentNode.Next; // Переходим к следующему узлу
                
                
                // Вызываем метод для отображения расписания для следующего дня
                DisplayScheduleForDay(currentNode);
                BtnPreviev.Enabled = true;
            }
            else
            {
                // Если достигнут конец списка, вернемся в самое начало
                if (currentNode == null)
                {
                    currentNode = GenerateDaysAndDates(); // Переходим в начало списка
                    
                }
                else
                {
                    currentNode = currentNode.List.First; // Переходим к первому узлу списка
                }

                DisplayScheduleForDay(currentNode);
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
                DisplayScheduleForDay(currentNode);
            }
            if (currentNode == null)
            {
                currentNode = GenerateDaysAndDates().List.Last; // Переходим в конец списка
            }
            else
            {
                currentNode = currentNode.List.Last; // Переходим к последнему узлу списка
            }

            DisplayScheduleForDay(currentNode);
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
            if (GridRaspisanie.SelectedRows.Count > 0)
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
                replacement.EmptyForAddForm = emptyPairsForDay;

                replacement.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите строку для дальнейшего взаимодействия", "Ошибка выполнения команды", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (MainTabControl.SelectedTab == AboutProgramm)
            {
                TextToPrint = "Программный продукт создан в рамках курсового проектирования по МДК03.01 " +
                    "\nТехнология разработки программного обеспечения\nСтудентом группы П-20\nБалыкиным Николаем Александровичем.\nРуководитель курсового проекта: Фролова Г.Н\nПреподаватель-консультант:Данилов Д.М";
                CurrentIndex = 0;
                OutputControl.Text = string.Empty;
                PrintTimer.Start();

            }
            if(MainTabControl.SelectedTab == HomePage)
            {
                TheoryDataGrid.Rows.Clear();
             
            }
        }

        //метод получения ID из TimeTable
        public int GetTimeTableId(string pairName, string disciplineName, string groupName)
        {


            var timeTableId = (from tt in context.TimeTables
                               where tt.Pair.Pair == pairName &&
                                     tt.DisplineWithGroup.Displine.NameDispline == disciplineName &&
                                     tt.DisplineWithGroup.Group.NameGroup == groupName
                               select tt.ID).FirstOrDefault();

            return timeTableId;
        }


        private void GridRaspisanie_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.RowIndex < GridRaspisanie.RowCount)
            {
                GridRaspisanie.ClearSelection();
                GridRaspisanie.Rows[e.RowIndex].Selected = true;
                var cancelledPairs = context.Modifieds
           .Where(modified => modified.Data == label2.Text && modified.isAdded == false)
           .Select(modified => modified.TimeTable.Pair.Pair)
           .ToList();

                // Показать контекстное меню с измененным текстом

                string pairName = GridRaspisanie.Rows[e.RowIndex].Cells["Pair"].Value.ToString();
                string disciplineName = GridRaspisanie.Rows[e.RowIndex].Cells["Discipline"].Value.ToString();
                string groupName = GridRaspisanie.Rows[e.RowIndex].Cells["Group"].Value.ToString();

                int TimeTablesID = GetTimeTableId(pairName, disciplineName, groupName);

                if (TimeTablesID != 0)
                {
                    // Получение значения поля isAdded для записи, соответствующей выбранной паре
                    var modifiedRecord = context.Modifieds.FirstOrDefault(modified => modified.TimeTable.ID == TimeTablesID);

                    if (modifiedRecord != null)
                    {
                        if (modifiedRecord.isAdded == false)
                        {
                            ContextChangeData.Items[0].Text = "Снять отмену пары";
                        }
                        else if (modifiedRecord.isAdded == true)
                        {
                            ContextChangeData.Items[0].Text = "Снять добавление пары";
                        }
                    }
                    else
                    {
                        ContextChangeData.Items[0].Text = "Отменить пару";
                    }

                }
                DataRows.GroupName = groupName;
                DataRows.DisplineName = disciplineName;
                DataRows.PairName = pairName;
                ContextChangeData.Show(Cursor.Position);

            }
        }

        private void ContextChangeData_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Снять отмену пары":
                    string Pair = DataRows.PairName;
                    string Displine = DataRows.DisplineName;
                    string Group = DataRows.GroupName;
                    int TimeTablesID = GetTimeTableId(Pair, Displine, Group);

                    if (TimeTablesID != 0)
                    {
                        var modifiedRecord = context.Modifieds.FirstOrDefault(modified => modified.TimeTable.ID == TimeTablesID);
                        DialogResult res = MessageBox.Show("Вы действительно хотите снять отметку отмены пары на " + label2.Text, "Уточнение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            context.Modifieds.Remove(modifiedRecord);
                            context.SaveChanges();
                            MessageBox.Show("Пометка об удалении пары на " + label2.Text + " была снята, обновите таблицу", "Операция", MessageBoxButtons.OK, MessageBoxIcon.Information);






                        }
                        else
                        {
                            MessageBox.Show("Запись для снятия отметки отмены не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Не найдено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Отменить пару":
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
                    replacement.EmptyForAddForm = emptyPairsForDay;

                    replacement.ShowDialog();
                    break;


            }

        }
        private void ProcessExcelFileAndPopulateDataGridView(string filePath, Guna.UI2.WinForms.Guna2DataGridView dataGridView)
        {
            // Открываем файл Excel с помощью EPPlus
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                try
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    int rowNumber = 4; // Начальная строка, где хранятся даты (N4, N5, и так далее)


                    DataGridViewTextBoxColumn topicColumn = new DataGridViewTextBoxColumn();
                    topicColumn.HeaderText = "Тема занятия";
                    topicColumn.Name = "Topic";
                    topicColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns.Add(topicColumn);

                    DataGridViewTextBoxColumn HomeQUest = new DataGridViewTextBoxColumn();
                    HomeQUest.HeaderText = "Домашнее задание";
                    HomeQUest.Name = "HomeQuest";
                    dataGridView.Columns.Add(HomeQUest);


                    DataGridViewTextBoxColumn VidColumn = new DataGridViewTextBoxColumn();
                    VidColumn.HeaderText = "Вид занятия";
                    VidColumn.Name = "Vid";
                    dataGridView.Columns.Add(VidColumn);

                    DataGridViewTextBoxColumn notesColumn = new DataGridViewTextBoxColumn();
                    notesColumn.HeaderText = "Примечания";
                    notesColumn.Name = "Prim";
                    notesColumn.Width = 300;
                    dataGridView.Columns.Add(notesColumn);
                    dataGridView.AutoResizeColumn(topicColumn.Index, DataGridViewAutoSizeColumnMode.AllCells);
                    dataGridView.AutoResizeColumn(HomeQUest.Index, DataGridViewAutoSizeColumnMode.AllCells);
                    dataGridView.AutoResizeColumn(VidColumn.Index, DataGridViewAutoSizeColumnMode.AllCells);
                    dataGridView.AutoResizeColumn(notesColumn.Index, DataGridViewAutoSizeColumnMode.AllCells);

                    while (true)
                    {
                        string cellValue = worksheet.Cells[$"N{rowNumber}"].Text;

                        // Если ячейка пустая и Prosmotr == true, записываем значение из label2.Text
                        if (Prosmotr && string.IsNullOrEmpty(cellValue))
                        {
                            worksheet.Cells[$"N{rowNumber}"].Value = label2.Text;
                            cellValue = worksheet.Cells[$"N{rowNumber}"].Text;
                        }

                        // Отобразить значение из ячейки N в dataGridView, если оно соответствует label2.Text
                        if (cellValue == label2.Text)
                        {
                            string lessonTopic = worksheet.Cells[$"D{rowNumber}"].Value?.ToString();
                            string HomeQuest = worksheet.Cells[$"G{rowNumber}"].Value?.ToString();
                            string lessonType = worksheet.Cells[$"F{rowNumber}"].Value?.ToString();

                            dataGridView.Rows.Add(lessonTopic, HomeQuest, lessonType);
                            break;
                        }

                        rowNumber++;
                        package.Save();
                        if (!Prosmotr)
                        {

                            break;
                        }


                    }
                }
                
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Не удаётся получить доступ к нужному листу, убедитесь в корректности файла", "Ошибка операции чтения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
           
            
        }
        private bool Prosmotr = false;
        private void GridRaspisanie_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {




            DataGridViewRow selectedRow = GridRaspisanie.SelectedRows[0];
            string pairValue = selectedRow.Cells["pair"].Value?.ToString();
            string disciplineValue = selectedRow.Cells["Discipline"].Value?.ToString();
            string groupValue = selectedRow.Cells["Group"].Value?.ToString();

           

           

                var ktpInfo = context.ConnectWithGroup
                    .Where(d => d.Displine.NameDispline == disciplineValue && d.Group.NameGroup == groupValue)
                    .Select(d => new
                    {
                        KTP_Name = d.KTP.NameKTP // Предположим, что KTP - это свойство навигации к таблице KTP
                    })
        .FirstOrDefault();

           

            

                Prosmotr = true;
                if (ktpInfo != null)
                {
                    string ktpName = ktpInfo.KTP_Name;
                    KtpPath = DisplineWithGroup.GetPathKTP(groupValue, disciplineValue, ktpName);


                }
                else
                {
                    MessageBox.Show($"КТП для выбранной группы '{groupValue}' и дисциплины '{disciplineValue}' не найдено.");
                }


            if (KtpPath != null)
            {

                DialogResult res = MessageBox.Show("Открыть урок или открыть в режиме просмотра?", "Уточнение", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {


                    MainTabControl.SelectTab(Theory);
                    TheoryDataGrid.Visible = true;

                    ProcessExcelFileAndPopulateDataGridView(KtpPath, TheoryDataGrid);
                    TheoryDataGrid.Enabled = true;
                }
                else
                {
                    Prosmotr = false;
                    MainTabControl.SelectTab(Theory);
                    TheoryDataGrid.Visible = true;
                    ProcessExcelFileAndPopulateDataGridView(KtpPath, TheoryDataGrid);
                    TheoryDataGrid.Enabled = false;
                }


               


            }
            else
            {
                TheoryDataGrid.Visible = false;
            }
            
           
            
        }

        private void GridRaspisanie_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore
        }

        private void TheoryDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore
        }

        private void BoxFormingShedule_MouseEnter(object sender, EventArgs e)
        {
            editingForm.SetBorderColorFromTheme(BtnFormingShedule, ThemSet);
        }

        private void BtnFormingShedule_MouseLeave(object sender, EventArgs e)
        {
            BtnFormingShedule.BackColor = Color.Transparent;
        }

        private void BtnFormingShedule_Click(object sender, EventArgs e)
        {
            CurrentFormShedule currentFormShedule = new CurrentFormShedule(ThemSet);
            currentFormShedule.ShowDialog();
        }

       
    }


}



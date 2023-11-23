using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
            GroupAddBOx.Font = new Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Italic);


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
        private void SetFontStyleForAllCells(DataGridView dataGridView, FontStyle fontStyle)
        {
            Color textColor = SwitchTheme.Checked ? Color.White : Color.Black;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is DataGridViewTextBoxCell || cell is DataGridViewComboBoxCell)
                    {
                        cell.Style.Font = new Font("Arial", 12, fontStyle);
                        cell.Style.ForeColor = textColor;
                    }
                }
            }
        }
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
            else if(!SwitchTheme.Checked)
            {
                GroupAddBOx.FillColor = Color.WhiteSmoke;
                GridRaspisanie.BackgroundColor = Color.WhiteSmoke;
                GridRaspisanie.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Teal;
            }
        }
        DateTime currentDate = DateTime.Now;
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
        .Select(entry => new
        {
            Group = entry.DisplineWithGroup.Group.NameGroup,
            Discipline = entry.DisplineWithGroup.Displine.NameDispline,
            Pair = entry.Pair.Pair
        })
         // Выбрать уникальные записи
         .Distinct()
        .ToList();

                DataGridViewColumn groupColumn = new DataGridViewTextBoxColumn();
                groupColumn.HeaderText = "Группа"; // Название столбца
                groupColumn.DataPropertyName = "Group"; // Указание свойства объекта данных для этого столбца
                GridRaspisanie.Columns.Add(groupColumn); // Добавление столбца в DataGridView

                DataGridViewColumn disciplineColumn = new DataGridViewTextBoxColumn();
                disciplineColumn.HeaderText = "Дисциплина";
                disciplineColumn.DataPropertyName = "Discipline";
                GridRaspisanie.Columns.Add(disciplineColumn);

                DataGridViewColumn pairColumn = new DataGridViewTextBoxColumn();
                pairColumn.HeaderText = "Пары";
                pairColumn.DataPropertyName = "Pair";
                GridRaspisanie.Columns.Add(pairColumn);

                // Привязываем результаты к DataGridView
                GridRaspisanie.AutoGenerateColumns = false;
                GridRaspisanie.DataSource = todayEntries;
                label1.Text = dayOfWeekRussian;
                label1.Font = new Font("Segui UI", 14);
                label1.BackColor = Color.Transparent;
            }

        }
        private Color GetColorFromTheme(ThemeSettings setting)
        {
            Color selectedColor = Color.White; // Устанавливаем белый цвет по умолчанию

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
        private DataGridViewCellStyle SetDataGridViewStyleFromTheme(DataGridView dataGridView, ThemeSettings setting)
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            if (!string.IsNullOrEmpty(setting.ColorTheme) && setting.ColorTheme != "Transparent")
            {
                Color selectedColor;
                try
                {
                    selectedColor = ColorTranslator.FromHtml(setting.ColorTheme); // Преобразование цвета из HTML/HEX в Color

                    // Создание нового стиля для заголовков столбцов

                    headerStyle.BackColor = selectedColor;

                    // Применение стиля к заголовкам столбцов
                    dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // Обработка ошибки, если есть
                }

            }
            return headerStyle;
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

            for (int i = 1; i <= 6; i++)
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
        private void Form1_Load(object sender, EventArgs e)
        {

            TodayDay();
            LinkedList<(DayOfWeek WeekDay, DateTime Date)> daysAndDatesList = GenerateDaysAndDates(currentDate);
           
            gifImage = Properties.Resources.LoadPicture;
            BoxUpdate.Image = gifImage;
            SetFontStyleForAllCells(GridRaspisanie, FontStyle.Bold);
            label1.Font = new Font("Arial", 12, FontStyle.Bold);
            label2.Font = new Font("Arial", 10, FontStyle.Bold);
            label1.Text = label1.Text.ToUpper();
            //GridRaspisanie.ColumnHeadersDefaultCellStyle = SetDataGridViewStyleFromTheme(GridRaspisanie, ThemSet);
            //GridRaspisanie.ColumnHeadersDefaultCellStyle.SelectionBackColor = GetColorFromTheme(ThemSet);
            //GridRaspisanie.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Transparent;
            //GridRaspisanie.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.GrayText;



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
            TodayDay();
            SetFontStyleForAllCells(GridRaspisanie, FontStyle.Bold);
        }

    }

       
    }
    


using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using TeachersHandsBooks.Core;

namespace TeachersHandsBooks
{
    public partial class MainForm : MaterialForm
    {
        private readonly ThemeSettings ThemSet = new ThemeSettings();
        readonly MaterialSkinManager ThemeSkin = MaterialSkinManager.Instance;
        EdingFormValue editingForm = new EdingFormValue();
        private DatabaseContext context = new DatabaseContext();

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Blue400, TextShade.WHITE);
            LoadSettings();
            Dictionary<string, string> dayOfWeekTranslations = new Dictionary<string, string>
        {
            { "Monday", "Понедельник" },
            { "Tuesday", "Вторник" },
            { "Wednesday", "Среда" },
            { "Thursday", "Четверг" },
            { "Friday", "Пятница" },
            { "Saturday", "Суббота" },

        };



        }
        private void SaveSettings()
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

            Properties.Settings.Default.ColorTheme = ThemSet.ColorTheme;
            editingForm.SetBorderColorFromTheme(GroupAddBOx, ThemSet);
            Properties.Settings.Default.Save();
            MainTabControl.SelectedTab = HomePage;


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

            }
            else
            {
                GroupAddBOx.FillColor = Color.WhiteSmoke;

            }
        }
        private  void TodayDay()
        {
            DateTime currentDate = DateTime.Now;
            string dayOfWeekRussian = currentDate.ToString("dddd", new CultureInfo("ru-RU"));
            var dayId = context.DayTables.FirstOrDefault(day => day.Day.Equals(dayOfWeekRussian, StringComparison.OrdinalIgnoreCase))?.ID;
            if (dayId != null)
            {
                var todayEntries = context.TimeTables
                           .Where(entry => entry.Day.ID == dayId)
                           .Select(entry => new
                           {
                               Group = entry.DisplineWithGroup.Group.NameGroup, // Предположим, что внешний ключ Teacher_ID ссылается на группу
                                Discipline = entry.DisplineWithGroup.Displine.NameDispline, // Поле с дисциплиной в таблице TimeTables
                                Pair = entry.Pair.Pair // Поле с парой в таблице TimeTables
                            })
                           .ToList();

                // Привязываем результаты к DataGridView
                GridRaspisanie.DataSource = todayEntries;

            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TodayDay();


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
            FormationRasp Rasp = new FormationRasp(ThemSet);
            Rasp.ShowDialog();
        }
    }
}

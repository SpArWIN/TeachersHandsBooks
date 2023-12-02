using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using TeachersHandsBooks.Core.Tables;

namespace TeachersHandsBooks
{
    public partial class CurrentFormShedule : MaterialForm
    {
        DatabaseContext context = new DatabaseContext();

        private int currentProgress = 0;
        private Timer progressTimer;


        public enum WeekRange
        {
            [Description("7 дней")]
            OneWeek = 7,

            [Description("14 дней")]
            TwoWeeks = 14,

            [Description("30 дней")]
            OneMonth = 30
        }



        private readonly ThemeSettings themeSettings;
        public CurrentFormShedule(ThemeSettings theme)
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
                this.Close();
                MessageBox.Show($"Расписание с {TimePicerCurrentDay.Value.Date.ToShortDateString()} по {TimePickerNext.Value.Date.ToShortDateString()} было успешно сформировано", "Создание расписания", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                guna2CircleProgressBar1.Value = currentProgress;
            }
        }
    

        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
        //Получение значение из описания 7 дней,14 дней,30 дней.
        private TEnum GetEnumValueFromDescription<TEnum>(string description)
        {
            foreach (var field in typeof(TEnum).GetFields())
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                if (attribute != null && attribute.Description == description)
                {
                    return (TEnum)field.GetValue(null);
                }
            }

            throw new ArgumentException($"Значение \"{description}\" не найдено.");
        }
        readonly MaterialSkinManager ThemeSkin = MaterialSkinManager.Instance;
        private void Themeset(MaterialSkinManager skin)
        {

            if (skin.Theme == MaterialSkinManager.Themes.DARK)
            {
                ComboxFormingItems.FillColor = Color.FromArgb(50, 50, 50);
            }
            else
            {
                ComboxFormingItems.FillColor = Color.DimGray;
            }

        }



        private void ShowDiap()
        {
            foreach (WeekRange weekRange in Enum.GetValues(typeof(WeekRange)))
            {
                string description = GetEnumDescription(weekRange);
                ComboxFormingItems.Items.Add(description);
            }
            Themeset(ThemeSkin);
        }
        private void CurrentFormShedule_Load(object sender, EventArgs e)
        {
            TimePicerCurrentDay.Value = DateTime.Now.Date;
            ShowDiap();

        }
        private int GetNonSundayDatesCountForWeekRange(WeekRange weekRange, DateTime baseDate)
        {
            int count = 0;

            DateTime currentDate = baseDate;

            switch (weekRange)
            {
                case WeekRange.OneWeek:
                    for (int i = 0; i <= 7; i++)
                    {
                        if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            count++;
                        }
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                case WeekRange.TwoWeeks:
                    for (int i = 0; i <= 14; i++)
                    {
                        if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            count++;
                        }
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                case WeekRange.OneMonth:
                    for (int i = 0; i <= 30; i++)
                    {
                        if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            count++;
                        }
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                default:
                    break;
            }

            return count;
        }

        // Метод для получения следующей даты, исключая воскресенье

        private List<DateTime> GetNonSundayDatesList(DateTime startDate, int numberOfDays)
        {
            List<DateTime> datesList = new List<DateTime>();
            DateTime currentDate = startDate;

            for (int i = 0; i < numberOfDays; i++)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    datesList.Add(currentDate);
                }
                currentDate = currentDate.AddDays(1);
            }

            return datesList;
        }



        private void ComboxFormingItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboxFormingItems.SelectedIndex != -1)
            {
                TimePickerNext.Enabled = true;
                //получаем значения диапазона
                string selectedDescription = ComboxFormingItems.SelectedItem.ToString();
                WeekRange selectedRange = GetEnumValueFromDescription<WeekRange>(selectedDescription);
                // Получение даты для выбранного диапазона

                int NumberShift = GetNonSundayDatesCountForWeekRange(selectedRange, TimePicerCurrentDay.Value);
                // Установка даты в TimePickerNext, пропуская воскресенье

                TransmissionOfInformation.DateList = GetNonSundayDatesList(TimePicerCurrentDay.Value, NumberShift);
                string datesString = "Список дат без воскресений:\n";

                foreach (DateTime date in TransmissionOfInformation.DateList)
                {
                    datesString += date.ToShortDateString() + "\n";
                }

                // Отображение списка дат в MessageBox
                DialogResult res = MessageBox.Show(datesString, "Список дат без воскресений", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    TimePickerNext.Enabled = false;
                }


                TimePickerNext.Value = TimePicerCurrentDay.Value.AddDays(NumberShift-1);
                BtnForming.Enabled = true;
            }
        }
        private bool CheckResponse()
        {
            bool HasRecords;
            HasRecords = context.TimeTables.Any();

            return HasRecords;
        }

        private bool OneRows = false;
        //Если запись в TimeTable отсуствует в таблице CurrentShedule, возвращаем истину
        private bool AreEntriesMissing(List<DateTime> datelist)
        {
            DateTime startDate = TimePicerCurrentDay.Value.Date; // Начальная дата
            DateTime endDate = TimePickerNext.Value.Date; // Конечная дата

            foreach (var timeTableEntry in context.TimeTables)
            {
                DayOfWeek day = CurrentShedule.GetDayOfWeekFromRussian(timeTableEntry.Day.Day);
                var filteredDates = datelist.Where(date =>
                    date.DayOfWeek == day && date.Date >= startDate && date.Date <= endDate).ToList();
                foreach (DateTime date in filteredDates)
                {
                    string formattedDate = date.ToString("dd.MM.yyyy"); // Форматируем дату в строку

                    if (!context.CurrentsShedules.Any(c =>
                        c.Data == formattedDate && c.TimeTables.ID == timeTableEntry.ID))
                    {
                        return true; // Возвращаем true при обнаружении отсутствующей записи
                    }
                }
            }

            return false; // Если все записи присутствуют, возвращаем false
        }
        private void CheckEmtyResponse(List<DateTime> datelist)
        {
            DateTime startDate = TimePicerCurrentDay.Value.Date; // Начальная дата
            DateTime endDate = TimePickerNext.Value.Date; // Конечная дата

            foreach (var timeTableEntry in context.TimeTables)
            {
                DayOfWeek day = CurrentShedule.GetDayOfWeekFromRussian(timeTableEntry.Day.Day);
                var filteredDates = datelist.Where(date =>
                    date.DayOfWeek == day && date.Date >= startDate && date.Date <= endDate).ToList();
                foreach (DateTime date in filteredDates)
                {
                
                    string formattedDate = date.ToString("dd.MM.yyyy");

                    // Проверяем, есть ли уже запись для данной даты и timeTableEntry в CurrentShedule
                    var existingEntry = context.CurrentsShedules.FirstOrDefault(c =>
                        c.Data == formattedDate && c.TimeTables.ID == timeTableEntry.ID);

                    if (existingEntry == null)
                    {
                        // Если записи нет, создаем новую запись в CurrentShedule для данной даты и timeTableEntry
                        CurrentShedule currentSchedule = new CurrentShedule
                        {
                            TimeTables = timeTableEntry,
                            Data = formattedDate // Используем преобразованную дату
                        };
                        OneRows = true;
                        context.CurrentsShedules.Add(currentSchedule);
                    }
                }
            }


            context.SaveChanges();

        }

        private bool AreEntriesExistingForRange(List<DateTime> datelist)
        {
            DateTime startDate = TimePicerCurrentDay.Value.Date; // Начальная дата
            DateTime endDate = TimePickerNext.Value.Date; // Конечная дата

            foreach (var timeTableEntry in context.TimeTables)
            {
                DayOfWeek day = CurrentShedule.GetDayOfWeekFromRussian(timeTableEntry.Day.Day);
                var filteredDates = datelist.Where(date =>
                    date.DayOfWeek == day && date.Date >= startDate && date.Date <= endDate).ToList();
                foreach (DateTime date in filteredDates)
                {
                    string formattedDate = date.ToString("dd.MM.yyyy");

                    // Проверяем, есть ли уже запись для данной даты и timeTableEntry в CurrentShedule
                    if (context.CurrentsShedules.Any(c =>
                        c.Data == formattedDate && c.TimeTables.ID == timeTableEntry.ID))
                    {
                        return true; // Возвращаем true при обнаружении хотя бы одной существующей записи
                    }
                }
            }

            return false; // Если не найдены существующие записи, возвращаем false
        }




        [Obsolete]
        private void BtnForming_Click(object sender, EventArgs e)
        {
            bool record = CheckResponse();
            if (!record)
            {
                MessageBox.Show("Шаблон не был загружен", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (AreEntriesExistingForRange(TransmissionOfInformation.DateList))
            {
                MessageBox.Show("Для текущего диапазона дат уже существуют записи", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (AreEntriesMissing(TransmissionOfInformation.DateList))
            {
                CheckEmtyResponse(TransmissionOfInformation.DateList);

                guna2CircleProgressBar1.Visible = true;
                currentProgress = 0;
                guna2CircleProgressBar1.Value = currentProgress;
                progressTimer.Start();

            }
            else
            {
                CurrentShedule.InsertCurrentData(TransmissionOfInformation.DateList);

                guna2CircleProgressBar1.Visible = true;
                currentProgress = 0;
                guna2CircleProgressBar1.Value = currentProgress;
                progressTimer.Start();
            }
        }
    }
}

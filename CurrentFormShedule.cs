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
            TimePickerNext.Value = DateTime.Now.Date;
            TimePickerNext.Enabled = false;
            ShowDiap();

        }
        private int GetNonSundayDatesCountForWeekRange(WeekRange weekRange, DateTime baseDate)
        {
            int count = 0;

            DateTime currentDate = baseDate;
            int daysToAdd = 0;

            switch (weekRange)
            {
                case WeekRange.OneWeek:
                    daysToAdd = 7;
                    break;
                case WeekRange.TwoWeeks:
                    daysToAdd = 14;
                    break;
                case WeekRange.OneMonth:
                    daysToAdd = 30;
                    break;
                default:
                    break;
            }

            for (int i = 0; i <= daysToAdd; i++)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
                currentDate = currentDate.AddDays(1);
            }

            return count;
        }


        // Метод для получения следующей даты, исключая воскресенье

        private List<DateTime> GetNonSundayDatesList(DateTime startDate, int numberOfDays)
        {
            List<DateTime> datesList = new List<DateTime>();
            DateTime currentDate = startDate;

            for (int i = 0; i <= numberOfDays; i++)
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
                BtnForming.Enabled = true;
                // Получаем значения диапазона
                string selectedDescription = ComboxFormingItems.SelectedItem.ToString();
                WeekRange selectedRange = GetEnumValueFromDescription<WeekRange>(selectedDescription);

                // Получаем предыдущий диапазон дат
                int previousNumberShift = GetNonSundayDatesCountForWeekRange(selectedRange, TimePicerCurrentDay.Value);
                List<DateTime> previousDateList = GetNonSundayDatesList(TimePicerCurrentDay.Value, previousNumberShift);

                // Проверяем наличие записей для предыдущего диапазона дат в таблице CurrentShedule
                bool existingRecordsForPreviousRange = AreEntriesExistingForRange(previousDateList);

                if (existingRecordsForPreviousRange)
                {
                    // Используем последнюю дату из предыдущего диапазона для нового диапазона
                    DateTime lastDateOfPreviousRange = previousDateList.Last();
                    int NumberShift = GetNonSundayDatesCountForWeekRange(selectedRange, lastDateOfPreviousRange.AddDays(1));

                    // Устанавливаем дату в TimePickerNext, пропуская воскресенье
                    TransmissionOfInformation.DateList = GetNonSundayDatesList(lastDateOfPreviousRange.AddDays(1), NumberShift);
                    TimePickerNext.Value = lastDateOfPreviousRange.AddDays(NumberShift);


                }
                else
                {
                    // Передаем новый диапазон дат
                    int NumberShift = GetNonSundayDatesCountForWeekRange(selectedRange, TimePicerCurrentDay.Value);
                    TransmissionOfInformation.DateList = GetNonSundayDatesList(TimePicerCurrentDay.Value, NumberShift);
                    TimePickerNext.Value = TransmissionOfInformation.DateList.Last();
                }


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
            HashSet<string> uniqueDates = new HashSet<string>();

            foreach (var timeTableEntry in context.TimeTables)
            {
                DayOfWeek day = CurrentShedule.GetDayOfWeekFromRussian(timeTableEntry.Day.Day);
                var filteredDates = datelist.Where(date =>
                    date.DayOfWeek == day && date.Date >= startDate && date.Date <= endDate).ToList();
                foreach (DateTime date in filteredDates)
                {

                    string formattedDate = date.ToString("dd.MM.yyyy");

                    uniqueDates.Add(formattedDate);
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
            string uniqueDatesString = "Даты включенные в диапазон:\n";
            foreach (var date in uniqueDates)
            {
                uniqueDatesString += date + "\n";
            }
            MessageBox.Show(uniqueDatesString, "Даты включенные в диапазон", MessageBoxButtons.OK, MessageBoxIcon.Information);


            context.SaveChanges();

        }
        // Возвращаем true при обнаружении хотя бы одной существующей записи
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
            else
            {
                // Получаем выбранный диапазон дат из TransmissionOfInformation.DateList
                List<DateTime> selectedDateList = TransmissionOfInformation.DateList;

                if (selectedDateList != null && selectedDateList.Count > 0)
                {




                    // Проверяем наличие записей в таблице CurrentShedule для выбранного диапазона
                    bool entriesExistForSelectedRange = AreEntriesExistingForRange(selectedDateList);

                    if (!entriesExistForSelectedRange)
                    {
                        // Если записей нет, добавляем их
                        CurrentShedule.InsertCurrentData(selectedDateList);
                        MessageBox.Show($"Расписание с {TimePicerCurrentDay.Value.Date.ToShortDateString()} по {TimePickerNext.Value.Date.ToShortDateString()} было успешно сформировано", "Создание расписания", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Расписание успешно сформировано.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Проверяем наличие новых записей в таблице TimeTable
                        bool newEntriesExistInTimeTable = AreEntriesMissing(selectedDateList);

                        if (newEntriesExistInTimeTable)
                        {
                            // Если есть новые записи в TimeTable, добавляем их в CurrentShedule
                            CheckEmtyResponse(selectedDateList);
                            MessageBox.Show("На новые записи сформированы даты ", "Обновление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Проверяем повторный ввод данных для избежания дублирования
                            bool isDuplicateInput = CheckForDuplicateInput(selectedDateList);

                            if (isDuplicateInput)
                            {

                                MessageBox.Show("Для текущего диапазона дат уже существуют записи", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Диапазон дат пуст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckForDuplicateInput(List<DateTime> selectedDateList)
        {
            // Проходимся по каждой дате из выбранного диапазона
            foreach (var date in selectedDateList)
            {
                string formattedDate = date.ToString("dd.MM.yyyy");

                // Проверяем, есть ли запись в таблице CurrentShedule для каждой даты
                var existingEntry = context.CurrentsShedules.FirstOrDefault(c =>
                                        c.Data == formattedDate);

                // Если запись для текущей даты найдена, возвращаем true (дубликат найден)
                if (existingEntry != null)
                {
                    return true;
                }
            }

            // Если не найдены дубликаты для всех дат из выбранного диапазона, возвращаем false
            return false;
        }
    }
}



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

namespace TeachersHandsBooks
{
    public partial class CurrentFormShedule : MaterialForm
    {
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


        }

        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }

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
                ComboxFormingItems.FillColor = Color.FromArgb(50,50,50);
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
           
            ShowDiap();
           
        }
        private int GetNonSundayDatesCountForWeekRange(WeekRange weekRange, DateTime baseDate)
        {
            int count = 0;
   
            DateTime currentDate = baseDate;

            switch (weekRange)
            {
                case WeekRange.OneWeek:
                    for (int i = 0; i < 7; i++)
                    {
                        if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            count++;
                        }
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                case WeekRange.TwoWeeks:
                    for (int i = 0; i < 14; i++)
                    {
                        if (currentDate.DayOfWeek != DayOfWeek.Sunday)
                        {
                            count++;
                        }
                        currentDate = currentDate.AddDays(1);
                    }
                    break;
                case WeekRange.OneMonth:
                    for (int i = 0; i < 30; i++)
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
            if(ComboxFormingItems.SelectedIndex != -1)
            {
                //получаем значения диапазона
                string selectedDescription = ComboxFormingItems.SelectedItem.ToString();
                WeekRange selectedRange = GetEnumValueFromDescription<WeekRange>(selectedDescription);
                // Получение даты для выбранного диапазона
                
                //  DateTime selectedDate = GetStartDateForWeekRange(selectedRange, TimePicerCurrentDay.Value);
                int NumberShift = GetNonSundayDatesCountForWeekRange(selectedRange, TimePicerCurrentDay.Value);
                // Установка даты в TimePickerNext, пропуская воскресенье

                TransmissionOfInformation.DateList = GetNonSundayDatesList(TimePicerCurrentDay.Value, NumberShift);
                string datesString = "Список дат без воскресений:\n";

                foreach (DateTime date in TransmissionOfInformation.DateList)
                {
                    datesString += date.ToShortDateString() + "\n";
                }

                // Отображение списка дат в MessageBox
                MessageBox.Show(datesString, "Список дат без воскресений", MessageBoxButtons.OK, MessageBoxIcon.Information);


                TimePickerNext.Value =TimePicerCurrentDay.Value.AddDays(NumberShift-1); 
                BtnForming.Enabled = true;
            }
        }
    }
}

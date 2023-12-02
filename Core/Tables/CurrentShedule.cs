using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachersHandsBooks.Core.Tables
{
  public  class CurrentShedule
    {
      
        [Key] public int ID { get; set; }
        public virtual TimeTable TimeTables { get; set; }
        public string  Data { get; set; }

        [Obsolete]
        public static  void InsertCurrentData(List<DateTime> datelist )
        {
            using(var context = new DatabaseContext())
            {


                foreach (DateTime date in datelist)
                {
                    DayOfWeek day = date.DayOfWeek;
                    string dayOfWeekRussian = GetRussianDayOfWeek(day);
                    TimeTable DayEntry = context.TimeTables.FirstOrDefault(g => g.Day.Day == dayOfWeekRussian);
                    if (DayEntry != null)
                    {


                        CurrentShedule CurrentSchedule = new CurrentShedule
                        {
                            TimeTables = DayEntry,
                            Data = date.ToShortDateString()

                        };
                        context.CurrentsShedules.Add(CurrentSchedule);
                        //GO FUCK YOUR SELF
                       

                    }
                    else
                    {
                        MessageBox.Show($"Для даты {date.ToShortDateString()} нет записи ", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    context.SaveChanges();
                }
            }


         

        }

        private static string GetRussianDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return "понедельник";
                case DayOfWeek.Tuesday:
                    return "вторник";
                case DayOfWeek.Wednesday:
                    return "среда";
                case DayOfWeek.Thursday:
                    return "четверг";
                case DayOfWeek.Friday:
                    return "пятница";
                case DayOfWeek.Saturday:
                    return "суббота";
                case DayOfWeek.Sunday:
                    return "воскресенье";
                default:
                    throw new ArgumentOutOfRangeException(nameof(day), "Неподдерживаемый день недели");
            }
        }
    }
}

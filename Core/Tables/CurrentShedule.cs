using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachersHandsBooks.Core.Tables
{
    public class CurrentShedule
    {

        [Key] public int ID { get; set; }
        public virtual TimeTable TimeTables { get; set; }
        public string Data { get; set; }

        [Obsolete]
        /*
         * Метод добавления в Реальное расписание
         * Проходимся по всей базе шаблона, получаем значения дней и по дням формируем расписание.
         */
        public static void InsertCurrentData(List<DateTime> datelist)
        {
            using (var context = new DatabaseContext())
            {
                foreach (var timeTableEntry in context.TimeTables)
                {
                    // Получаем день недели из текущей записи таблицы TimeTables
                    DayOfWeek day = GetDayOfWeekFromRussian(timeTableEntry.Day.Day);

                    foreach (DateTime date in datelist)
                    {
                        // Проверяем, соответствует ли текущий день недели дню недели в текущей записи
                        if (date.DayOfWeek == day)
                        {
                            CurrentShedule currentSchedule = new CurrentShedule
                            {
                                TimeTables = timeTableEntry,
                                Data = date.ToShortDateString()
                            };

                            context.CurrentsShedules.Add(currentSchedule);
                        }
                    }
                }

                // Сохраняем изменения в базе данных после завершения цикла
                context.SaveChanges();
            }
        }







        //Метод получения дней недели из БД
        public static DayOfWeek GetDayOfWeekFromRussian(string dayOfWeekRussian)
        {
            switch (dayOfWeekRussian.ToLower()) // Приводим к нижнему регистру для унификации
            {
                case "понедельник":
                    return DayOfWeek.Monday;
                case "вторник":
                    return DayOfWeek.Tuesday;
                case "среда":
                    return DayOfWeek.Wednesday;
                case "четверг":
                    return DayOfWeek.Thursday;
                case "пятница":
                    return DayOfWeek.Friday;
                case "суббота":
                    return DayOfWeek.Saturday;
                case "воскресенье":
                    return DayOfWeek.Sunday;
                default:

                    return DayOfWeek.Monday;
            }
        }
    }
}


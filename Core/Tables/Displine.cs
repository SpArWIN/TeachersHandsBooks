using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
   
    public class Displine
    {
        [Key] public int Id_Displine { get; set; }

        public string NameDispline { get; set; }

        public static void AddDispline(string NewDispline)
        {
            using (var context = new DatabaseContext())
            {
                // Создание новой записи в базе данных через EF
                var newDispline = new Displine { NameDispline = NewDispline };

                context.Displines.Add(newDispline);
                context.SaveChanges();
            }
        }
        public static void RemoveDispline(string Displine)
        {
            using(var context = new DatabaseContext())
            {
                var DisplineRemove = context.Displines.FirstOrDefault(g => g.NameDispline == Displine);

                if (DisplineRemove != null)
                {
                    context.Displines.Remove(DisplineRemove);
                    context.SaveChanges();
                }
                else
                {
                    return;

                }
            }
        }
    }
}

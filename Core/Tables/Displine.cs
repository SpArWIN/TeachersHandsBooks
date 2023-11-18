using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace TeachersHandsBooks.Core.Tables


{
    public class Displine
    {
        [Key] public int ID { get; set; }
        public string NameDispline { get; set; }
        public static void FillDisciplinesComboBoxColumn(DataGridViewComboBoxColumn comboBoxColumn)
        {
            using (var context = new DatabaseContext())
            {
                var disciplines = context.Displines.ToList();
                comboBoxColumn.DataSource = disciplines;
                comboBoxColumn.DisplayMember = "NameDispline"; // Устанавливаем поле, которое будет отображаться в ComboBox
                comboBoxColumn.ValueMember = "ID";


            }
        }
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
            using (var context = new DatabaseContext())
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

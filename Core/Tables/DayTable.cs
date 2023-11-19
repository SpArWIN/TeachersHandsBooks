using System.ComponentModel.DataAnnotations;

namespace TeachersHandsBooks.Core.Tables
{
    public class DayTable
    {
        [Key] public int ID { get; set; }
        public string Day { get; set; }
    }
}

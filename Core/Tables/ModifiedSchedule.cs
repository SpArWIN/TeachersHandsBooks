using System.ComponentModel.DataAnnotations;

namespace TeachersHandsBooks.Core.Tables
{
    public class ModifiedSchedule
    {
        [Key] public int ID { get; set; }

        public virtual TimeTable TimeTable { get; set; }
        public virtual DisplineWithGroup DisplineWithGroup { get; set; }

    }
}

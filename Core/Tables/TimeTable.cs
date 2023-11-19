using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersHandsBooks.Core.Tables
{
    public class TimeTable
    {
        [Key] public int ID { get; set; }

        [ForeignKey("DisplineWithGroup")]
        public int TeacherLoad_ID { get; set; }
        public virtual DisplineWithGroup DisplineWithGroup { get; set; }
        public virtual DayTable Day { get; set; }
        public virtual NumberPair Pair { get; set; }

    }
}

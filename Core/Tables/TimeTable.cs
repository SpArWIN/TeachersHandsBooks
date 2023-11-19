using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
  public  class TimeTable
    {
        [Key] public int ID { get; set; }
        public virtual DisplineWithGroup TeacherLoad_ID { get; set; }
        public virtual DayTable Day { get; set; }
        public virtual NumberPair Pair { get; set; }

    }
}

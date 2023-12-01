using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
  public  class CurrentSchedule
    {
        [Key] public int ID { get; set; }
        public virtual TimeTable TimeTables_ID { get; set; }
        public string  Data { get; set; }

    }
}

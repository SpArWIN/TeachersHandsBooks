using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
  public  class ModifiedSchedule
    {
        [Key] public int ID { get; set; }

        public virtual TimeTable TimeTable { get; set; }
        public virtual DisplineWithGroup DisplineWithGroup { get; set; }

    }
}

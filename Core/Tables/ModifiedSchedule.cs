using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersHandsBooks.Core.Tables
{
    public class ModifiedSchedule
    {
        [Key] public int ID { get; set; }

    
        public virtual TimeTable TimeTable { get; set; }
      //  public virtual DisplineWithGroup DisplineWithGroup { get; set; }
        public string Data { get; set; }
        public bool isAdded { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
  public  class DayTable
    {
        [Key] public int ID { get; set; }
        public string Day { get; set; }
    }
}

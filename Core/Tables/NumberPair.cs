using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
 public   class NumberPair
    {
        [Key]  public int ID { get; set; }
        public string Pair { get; set; }
    }
}

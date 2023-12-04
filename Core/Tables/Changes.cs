using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
 public   class Changes
    {
        [Key] public int ID { get; set; }
        public string Data { get; set; }
        public virtual DisplineWithGroup DW_ID { get; set; }
        public virtual NumberPair Pair_ID { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
 public   class Changes
    {
        [Key] public int ID { get; set; }
        public string Data { get; set; }
        [ForeignKey("WithGroup")] 
        public int With_ID { get; set; } 

        public virtual DisplineWithGroup WithGroup { get; set; }

        [ForeignKey("Pair")]
        public int Pair_ID { get; set; } 

        public virtual NumberPair Pair { get; set; }
    }
}


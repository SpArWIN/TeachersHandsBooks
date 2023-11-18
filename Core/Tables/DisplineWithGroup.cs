using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
 public   class DisplineWithGroup
    {
        [Key]
        public int IDW { get; set; }

        [ForeignKey("Group")]
        public int ID_Group { get; set; }
        public Group Group { get; set; }

        [ForeignKey("Displine")]
        public int ID_Displine { get; set; }
        public Displine Displine { get; set; }

        [ForeignKey("KTP")]
        public int ID_KTP { get; set; }
        public KTP KTP { get; set; }
    }
}

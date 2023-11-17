using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
   public class KTP
    {
        [Key] public int ID_KTP { get; set; }
        public string NameKTP { get; set; }
        public string Subject { get; set; }
        public string TypeOccupation { get; set; }

    }
}

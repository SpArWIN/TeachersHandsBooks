using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
   
    public class Displine
    {
        [Key] public int Id_Displine { get; set; }

        public string NameDispline { get; set; }
    }
}

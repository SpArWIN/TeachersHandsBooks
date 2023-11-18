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
        [Key] public int ID { get; set; }
        public string NameKTP { get; set; }
        public string Subject { get; set; }
        public string TypeOccupation { get; set; }
        public static void AddKTP (string KTP)
        {
            using(var context = new DatabaseContext())
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
    [Table("User")]
    public class User
    {
        [Key] public int Id { get; set; }

        public string Fio { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Designation { get; set; }
    }
}

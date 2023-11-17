using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachersHandsBooks.Core.Tables
{
  public  class Group
    {
        [Key] public int ID_Group { get; set; }
        public string NameGroup { get; set; }


    }
}

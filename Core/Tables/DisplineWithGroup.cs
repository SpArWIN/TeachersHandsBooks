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

        [Key] public int IDW { get; set; }
       

     
        public virtual Group Group { get; set; }

     
 
        public  virtual Displine Displine { get; set; }

     
  
        public virtual KTP KTP { get; set; }

        public static void AddCon(int IDGroup,int IdDispline,int IDKTP)
        {
            using(var context = new DatabaseContext())
            {

                var group = context.Groups.FirstOrDefault(g => g.ID == IDGroup);
                var discipline = context.Displines.FirstOrDefault(d => d.ID == IdDispline);
                var ktp = context.kTPs.FirstOrDefault(k => k.ID == IDKTP);



                var newDisplineWithGroup = new DisplineWithGroup
                {
                    Group = group,
                    Displine = discipline,
                    KTP = ktp
                };

                context.ConnectWithGroup.Add(newDisplineWithGroup);
                context.SaveChanges();
            }
        }

    }
}

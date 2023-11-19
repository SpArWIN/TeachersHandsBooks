using System.ComponentModel.DataAnnotations;

namespace TeachersHandsBooks.Core.Tables
{
    public class KTP
    {
        [Key] public int ID { get; set; }
        public string NameKTP { get; set; }
        public string Subject { get; set; }
        public string TypeOccupation { get; set; }

    }
}

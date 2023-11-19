using System.ComponentModel.DataAnnotations;

namespace TeachersHandsBooks.Core.Tables
{
    public class NumberPair
    {
        [Key] public int ID { get; set; }
        public string Pair { get; set; }
    }
}

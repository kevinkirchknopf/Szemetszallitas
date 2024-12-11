using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szemetszallitas.Models
{
    public class Naptar
    {
        
        public int Id { get; set; }
        [DataType(DataType.Date)]

        public DateTime? datum { get; set; }
        [ForeignKey("Szolgaltatas")]
        public int SzolgId { get; set; }
        public virtual Szolgaltatas? Szolgaltatas { get; set; }


    }
}

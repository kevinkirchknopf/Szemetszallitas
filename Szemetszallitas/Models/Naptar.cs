using System.ComponentModel.DataAnnotations;

namespace Szemetszallitas.Models
{
    public class Naptar
    {
        
        public int Id { get; set; }
        public DateTime? datum { get; set; }
        public virtual Szolgaltatas? Szolgaltatas {  get; set; }
        public int SzolgId { get; set; }


    }
}

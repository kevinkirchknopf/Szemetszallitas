using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szemetszallitas.Models
{
    public class Lakig
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]

        public DateTime igeny { get; set; }
        public virtual Szolgaltatas? Szolgaltatas { get; set; }

        [ForeignKey("Szolgaltatas")]
        public int Szolgid { get; set; }
        public int mennyiseg {  get; set; }
    }
}

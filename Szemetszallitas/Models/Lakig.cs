namespace Szemetszallitas.Models
{
    public class Lakig
    {
        public int Id { get; set; }
        public DateTime igeny { get; set; }
        public virtual Szolgaltatas? Szolgaltatas { get; set; }
        public int Szolgid { get; set; }
        public int mennyiseg {  get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Szemetszallitas.Models
{
    public class Szolgaltatas
    {
       
        public int Id { get; set; }
        public string? tipus { get; set; }
        public string? jelentes { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Szemetszallitas.Data;

namespace Szemetszallitas.Controllers
{
    public class CustomController : Controller
    {
        private readonly SzemetszallitasContext _context;

        public CustomController(SzemetszallitasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> LastKomDate()
        {
            var lastKomDate = await _context.Naptar
                .Include(n => n.Szolgaltatas)
                .Where(n => n.Szolgaltatas.tipus == "kom")
                .OrderByDescending(n => n.datum)
                .Select(n => n.datum)
                .FirstOrDefaultAsync();

            return View(lastKomDate);
        }
        public async Task<IActionResult> JanuarGreen()
{
    var januarGreenDates = await _context.Naptar
        .Include(n => n.Szolgaltatas)
        .Where(n => n.Szolgaltatas.tipus == "zold" && n.datum.Month == 1)
        .OrderBy(n => n.datum) // Dátum szerint rendezzük
        .Select(n => n.datum)
        .ToListAsync();

    return View(januarGreenDates);
}

        public async Task<IActionResult> GreenCount()
        {
            int lastKomDate = await _context.Lakig
                .Include(n => n.Szolgaltatas)
               .Where(l => l.Szolgaltatas.tipus == "zold" && l.igeny.Year == DateTime.Now.Year)
                .CountAsync();

            return View(lastKomDate);
        }

    }
}

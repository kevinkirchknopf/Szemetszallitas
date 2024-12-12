using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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

        //public async Task<IActionResult> MonthlyStat() { var monthlyStats = await _context.Lakig.Include(l => l.Szolgaltatas).GroupBy(l => new { l.igeny.Year, l.igeny.Month, l.Szolgaltatas.tipus }).Select(g => new MonthlyStat { Year = g.Key.Year, Month = g.Key.Month, MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month), WasteType = g.Key.tipus, Count = g.Count() }).OrderByDescending(g => g.Count).ToListAsync(); return View(monthlyStats); }


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
              .Where(n => n.Szolgaltatas.tipus == "zold" && n.igeny.Month == 1)
                .CountAsync();

            return View(lastKomDate);
        }

        public async Task<IActionResult> PaMuaDay()
        {
            var paMuaDays = await _context.Lakig
                .Include(l => l.Szolgaltatas)
                .Where(l => l.Szolgaltatas.tipus == "pa" || l.Szolgaltatas.tipus == "mua")
                .GroupBy(l => l.igeny.Date)
                .Where(g => g.Count(t => t.Szolgaltatas.tipus == "pa") > 0 && g.Count(t => t.Szolgaltatas.tipus == "mua") > 0)
                .Select(g => g.Key)
                .OrderBy(d => d)
                .ToListAsync();

            return View(paMuaDays);
        }


        public async Task<IActionResult> MostCountMonth() { var mostCountMonth = await _context.Lakig.GroupBy(l => new { Year = l.igeny.Year, Month = l.igeny.Month }).Select(g => new { Year = g.Key.Year, Month = g.Key.Month, TotalAmount = g.Sum(l => l.mennyiseg) }).OrderByDescending(g => g.TotalAmount).FirstOrDefaultAsync(); return View(mostCountMonth); }
    }
}

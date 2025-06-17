using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.Reservas
{
    [Authorize]  // autenticaçao
    public class IndexModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public IndexModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reserva { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.PacoteTuristico)
                .ToListAsync();
        }
    }
}

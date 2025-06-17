using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.CidadesDestino
{
    public class IndexModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public IndexModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public IList<CidadeDestino> CidadeDestino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CidadeDestino = await _context.CidadesDestino
                .Include(c => c.PaisDestino).ToListAsync();
        }
    }
}

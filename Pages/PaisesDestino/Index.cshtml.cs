using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.PaisesDestino
{
    public class IndexModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public IndexModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public IList<PaisDestino> PaisDestino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PaisDestino = await _context.PaisesDestino.ToListAsync();
        }
    }
}

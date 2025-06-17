using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.PacotesTuristicos
{
    public class IndexModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public IndexModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PacoteTuristico = await _context.PacotesTuristicos.ToListAsync();
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public DetailsModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public PaisDestino PaisDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisdestino = await _context.PaisesDestino.FirstOrDefaultAsync(m => m.Id == id);
            if (paisdestino == null)
            {
                return NotFound();
            }
            else
            {
                PaisDestino = paisdestino;
            }
            return Page();
        }
    }
}

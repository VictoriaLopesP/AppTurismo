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
    public class DetailsModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public DetailsModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.CidadesDestino.FirstOrDefaultAsync(m => m.Id == id);
            if (cidadedestino == null)
            {
                return NotFound();
            }
            else
            {
                CidadeDestino = cidadedestino;
            }
            return Page();
        }
    }
}

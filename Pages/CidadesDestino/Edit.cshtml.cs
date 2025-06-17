using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.CidadesDestino
{
    public class EditModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public EditModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino =  await _context.CidadesDestino.FirstOrDefaultAsync(m => m.Id == id);
            if (cidadedestino == null)
            {
                return NotFound();
            }
            CidadeDestino = cidadedestino;
           ViewData["PaisDestinoId"] = new SelectList(_context.PaisesDestino, "Id", "Nome");
            return Page();
        }

      
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CidadeDestino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeDestinoExists(CidadeDestino.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CidadeDestinoExists(int id)
        {
            return _context.CidadesDestino.Any(e => e.Id == id);
        }
    }
}

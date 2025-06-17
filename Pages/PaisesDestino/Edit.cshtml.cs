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

namespace AppTurismo.Pages.PaisesDestino
{
    public class EditModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public EditModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaisDestino PaisDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisdestino =  await _context.PaisesDestino.FirstOrDefaultAsync(m => m.Id == id);
            if (paisdestino == null)
            {
                return NotFound();
            }
            PaisDestino = paisdestino;
            return Page();
        }

 
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PaisDestino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisDestinoExists(PaisDestino.Id))
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

        private bool PaisDestinoExists(int id)
        {
            return _context.PaisesDestino.Any(e => e.Id == id);
        }
    }
}

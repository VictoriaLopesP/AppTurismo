using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.CidadesDestino
{
    public class CreateModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public CreateModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PaisDestinoId"] = new SelectList(_context.PaisesDestino, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CidadesDestino.Add(CidadeDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

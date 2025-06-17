using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.PacotesTuristicos
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
            return Page();
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PacotesTuristicos.Add(PacoteTuristico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

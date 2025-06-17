﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public DeleteModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos.FirstOrDefaultAsync(m => m.Id == id);

            if (pacoteturistico == null)
            {
                return NotFound();
            }
            else
            {
                PacoteTuristico = pacoteturistico;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteturistico = await _context.PacotesTuristicos.FindAsync(id);
            if (pacoteturistico != null)
            {
                PacoteTuristico = pacoteturistico;
                _context.PacotesTuristicos.Remove(PacoteTuristico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppTurismo.Data;
using AppTurismo.Models;

namespace AppTurismo.Pages.Clientes
{
    [Authorize]  // autenticaçao
    public class IndexModel : PageModel
    {
        private readonly AppTurismo.Data.TurismoContext _context;

        public IndexModel(AppTurismo.Data.TurismoContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Clientes
                .Where(c => c.DeletedAt == null)
                .ToListAsync();
        }
    }
}

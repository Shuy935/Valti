using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenControl.Data;
using GardenControl.Models;

namespace GardenControl.Pages.GCUnidades
{
    public class IndexModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public IndexModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        public IList<Unidad> Unidad { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Unidades != null)
            {
                Unidad = await _context.Unidades
                .Include(u => u.Curso).ToListAsync();
            }
        }
    }
}

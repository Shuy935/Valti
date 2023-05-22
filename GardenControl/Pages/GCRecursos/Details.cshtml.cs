using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GardenControl.Data;
using GardenControl.Models;
using GardenControl2.Models;

namespace GardenControl.Pages.GCRecursos
{
    public class DetailsModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public DetailsModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

      public Recurso Recurso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recursos == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos.FirstOrDefaultAsync(m => m.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }
            else 
            {
                Recurso = recurso;
            }
            return Page();
        }
    }
}

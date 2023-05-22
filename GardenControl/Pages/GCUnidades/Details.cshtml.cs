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
    public class DetailsModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public DetailsModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

      public Unidad Unidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades.FirstOrDefaultAsync(m => m.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }
            else 
            {
                Unidad = unidad;
            }
            return Page();
        }
    }
}

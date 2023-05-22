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
    public class DeleteModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public DeleteModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Unidades == null)
            {
                return NotFound();
            }
            var unidad = await _context.Unidades.FindAsync(id);

            if (unidad != null)
            {
                Unidad = unidad;
                _context.Unidades.Remove(Unidad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

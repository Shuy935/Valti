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
    public class DeleteModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public DeleteModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Recursos == null)
            {
                return NotFound();
            }
            var recurso = await _context.Recursos.FindAsync(id);

            if (recurso != null)
            {
                Recurso = recurso;
                _context.Recursos.Remove(Recurso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

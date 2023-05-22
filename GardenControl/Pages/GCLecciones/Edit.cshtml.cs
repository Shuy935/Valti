using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GardenControl.Data;
using GardenControl.Models;
using GardenControl2.Models;

namespace GardenControl.Pages.GCLecciones
{
    public class EditModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public EditModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Leccion Leccion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Lecciones == null)
            {
                return NotFound();
            }

            var leccion =  await _context.Lecciones.FirstOrDefaultAsync(m => m.Id == id);
            if (leccion == null)
            {
                return NotFound();
            }
            Leccion = leccion;
           ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "Nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Leccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeccionExists(Leccion.Id))
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

        private bool LeccionExists(int id)
        {
          return _context.Lecciones.Any(e => e.Id == id);
        }
    }
}

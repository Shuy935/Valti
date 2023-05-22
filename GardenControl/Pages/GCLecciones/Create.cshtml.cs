using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GardenControl.Data;
using GardenControl.Models;
using GardenControl2.Models;

namespace GardenControl.Pages.GCLecciones
{
    public class CreateModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public CreateModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UnidadId"] = new SelectList(_context.Unidades, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Leccion Leccion { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lecciones.Add(Leccion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

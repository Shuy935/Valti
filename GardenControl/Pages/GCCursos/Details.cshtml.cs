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

namespace GardenControl.Pages.GCCursos
{
    public class DetailsModel : PageModel
    {
        private readonly GardenControl.Data.GardenControlContext _context;

        public DetailsModel(GardenControl.Data.GardenControlContext context)
        {
            _context = context;
        }

      public Curso Curso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }
            else 
            {
                Curso = curso;
            }
            return Page();
        }
    }
}

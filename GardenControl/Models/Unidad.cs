using GardenControl.Models;
using GardenControl2.Models;
using System.ComponentModel.DataAnnotations;

namespace GardenControl.Models
{
	public class Unidad
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "El nombre es obligatorio")]
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "El orden es obligatorio")]
		public int Orden { get; set; }
		[Required(ErrorMessage = "La fecha es obligatoria")]
		public DateOnly FechaCreacion { get; set; }
		public bool Activo { get; set; }
		[Required(ErrorMessage = "El curso es obligatorio")]
		public int CursoId { get; set; }
		public Curso Curso { get; set; }
		public ICollection<Leccion> Lecciones { get; set; }
	}
}

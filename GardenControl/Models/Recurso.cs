using System.ComponentModel.DataAnnotations;

namespace GardenControl2.Models
{
	public class Recurso
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "El nombre es obligatorio")]
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "La fecha es obligatoria")]
		public DateOnly FechaCreacion { get; set; }
		[Required(ErrorMessage = "El orden es obligatorio")]
		public int Orden { get; set; }
		public bool Activo { get; set; }
		[Required(ErrorMessage = "La leccion es obligatoria")]
		public int LeccionId { get; set; }
		public Leccion Leccion { get; set; }
	}
}

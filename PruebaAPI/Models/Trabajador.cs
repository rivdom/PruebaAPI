using System.ComponentModel.DataAnnotations;

namespace PruebaAPI.Models
{
    public class Trabajador
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Puesto { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PruebaAPI.Models.DTO
{
    public class TrabajadorDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es un campo obligatorio")]
        [MaxLength(50, ErrorMessage = "El número máximo de caracteres es de 50")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Nombre es un campo obligatorio")]
        [MaxLength(20, ErrorMessage = "El puesto no puede tener mas de 20 caracteres")]
        public string Puesto { get; set; }
    }
}

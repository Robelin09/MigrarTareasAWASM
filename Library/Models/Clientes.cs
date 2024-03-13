using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [StringLength(70, ErrorMessage = "No se puede exceder el limite de 70 caracteres")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string? Nombres { get; set; }

        [StringLength(10, ErrorMessage = "No se puede exceder el limite de 10 caracteres numericos")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string? Telefono { get; set; }

        [StringLength(10, ErrorMessage = "No se puede exceder el limite de 10 caracteres numericos")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string? Celular { get; set; }

        [StringLength(11, ErrorMessage = "No se puede exceder el limite de 11 caracteres numericos")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string? RNC { get; set; }

        [EmailAddress(ErrorMessage = "El Email no es valido")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string? Email { get; set; }

        [StringLength(100, ErrorMessage = "No se puede exceder el limite de 100 caracteres")]
        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public string? Direccion { get; set; }
    }
}

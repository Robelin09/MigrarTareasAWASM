using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Sistemas
    {
        [Key]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "El Nombre del sistema es obligatorio.")]
        public string? NombredeSistema { get; set; }
    }
}

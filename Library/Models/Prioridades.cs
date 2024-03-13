using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "Este campo Obligatorio")]
        public string? Descripcion { get; set; }
        [Range(1, 31, ErrorMessage = "Valores Validos entre 1 y 31")]
        public int DiasCompromiso { get; set; }
    }
}

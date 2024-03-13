using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    internal class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El ID del sistema es obligatorio.")]
        [ForeignKey("SistemaId")]
        public int SistemaId { get; set; }

        [Required(ErrorMessage = "El ID de prioridad es obligatorio.")]
        [ForeignKey("PrioridadId")]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string? SolicitadoPor { get; set; }

        [Required(ErrorMessage = "El asunto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El asunto no puede exceder los 100 caracteres.")]
        public string? Asunto { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Descripcion { get; set; }
    }
}

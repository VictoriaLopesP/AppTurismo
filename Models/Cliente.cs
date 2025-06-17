using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppTurismo.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }
        public DateTime? DeletedAt { get; set; } // exclusao logica

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}

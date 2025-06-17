using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppTurismo.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do pacote é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome do pacote deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O número máximo de participantes deve ser maior que zero")]
        public int MaxParticipantes { get; set; }

        public List<CidadeDestino> Destinos { get; set; } = new();

        public List<Reserva> Reservas { get; set; } = new();
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace AppTurismo.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; }

        public DateTime DataReserva { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ValorPago { get; set; }
    }
}

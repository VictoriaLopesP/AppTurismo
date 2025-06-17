using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppTurismo.Models
{
    public class PaisDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do país é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome do país deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }

        public List<CidadeDestino> Cidades { get; set; } = new();
    }
}

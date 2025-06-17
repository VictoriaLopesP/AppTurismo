using System.ComponentModel.DataAnnotations;

namespace AppTurismo.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome da cidade deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }

        public int PaisDestinoId { get; set; }
        public PaisDestino PaisDestino { get; set; }
    }
}

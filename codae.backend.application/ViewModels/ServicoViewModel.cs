using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace codae.backend.application.ViewModels
{
    public class ServicoViewModel
    {
        [Key]
        public int ServicoId { get; set; }

        [Required(ErrorMessage = "Por favor informe o Nome do Serviço")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        public List<ItemServicoViewModel> ItensServico { get; } = new List<ItemServicoViewModel>();
    }
}
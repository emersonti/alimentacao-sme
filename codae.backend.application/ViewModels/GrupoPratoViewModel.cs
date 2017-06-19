using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace codae.backend.application.ViewModels
{
    public class GrupoPratoViewModel
    {
        [Key]
        public int PratoId { get; set; }

        [Required(ErrorMessage = "Por favor informe o nome do Grupo de Pratos")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        public List<PratoViewModel> Pratos { get; } = new List<PratoViewModel>();
    }
}
using System.ComponentModel.DataAnnotations;

namespace codae.backend.application.ViewModels
{
    public class ItemServicoViewModel
    {        
        public int PratoId { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
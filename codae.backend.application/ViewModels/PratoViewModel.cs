using System.ComponentModel.DataAnnotations;

namespace codae.backend.application.ViewModels
{
    public class PratoViewModel
    {
        [Key]
        public int PratoId { get; set; }

        [Required(ErrorMessage = "Por favor informe o Nom do Prato")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
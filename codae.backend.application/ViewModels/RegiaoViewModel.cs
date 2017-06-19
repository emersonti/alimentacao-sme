using codae.backend.core.Models;
using System.ComponentModel.DataAnnotations;

namespace codae.backend.application.ViewModels
{
    public class RegiaoViewModel
    {
        [Key]
        public int RegiaoId { get; set; }

        [Required(ErrorMessage = "Por favor informe o Nome da Região")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por vaor informe um Agrupamento")]
        [Display(Name = "Agrupamento")]
        public AgrupamentoEnum AgrupamentoId { get; set; }

        [Required(ErrorMessage = "Por favor informe o nome do Dirigente")]
        [MinLength(5)]
            [MaxLength(100)]
        public string Dirigente { get; set; }

        [Required(ErrorMessage = "Por favor informe o e-mail da Região")]
        [DataType(DataType.EmailAddress)]
        [MinLength(7)]
        [MaxLength(100)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor informe o Telefone da Região")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(20)]
        public string Telefone { get; set; }
    }
}
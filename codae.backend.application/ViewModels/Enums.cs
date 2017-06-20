using System.ComponentModel.DataAnnotations;

namespace codae.backend.application.ViewModels
{
    public enum Agrupamentos
    {
        [Display(Name ="Agrupamento 1")]
        Agrupamento1 = 1,
            [Display(Name = "Agrupamento 2")]        
        Agrupamento2 = 2,
        [Display(Name = "Agrupamento 3")]
        Agrupamento3 = 3,
        [Display(Name = "Agrupamento 4")]
        Agrupamento4 = 4
    }
}

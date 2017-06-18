
namespace codae.backend.core.Models
{
    /// <summary>
    /// Domínio de Agrupamentos de DRE
    /// </summary>
    public enum AgrupamentoEnum
    {
        Agrupamento1 = 1,
        Agrupamento2 = 2,
        Agrupamento3 = 3,
        Agrupamento4 = 4
    }

    /// <summary>
    /// Representa um Agrupamento de DRE
    /// </summary>
    public class Agrupamento
    {
        /// <summary>
        /// Identificador do Agrupamento
        /// </summary>
        public AgrupamentoEnum AgrupamentoId { get; private set; }

        /// <summary>
        /// Nome do Agrupamento
        /// </summary>
        public string Nome { get; private set; }

        protected Agrupamento() { }

        public static Agrupamento Create(AgrupamentoEnum id, string nome) =>
            new Agrupamento()
            {
                AgrupamentoId = id,
                Nome = nome
            };
    }
}
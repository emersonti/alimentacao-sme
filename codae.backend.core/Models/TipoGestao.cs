namespace codae.backend.core.Models
{
    /// <summary>
    /// Domínio para os Tipos de Gestão
    /// </summary>
    public enum TipoGestaoEnum
    {
        Direta = 1,
        Mista = 2,
        Terceirzada = 3
    }

    /// <summary>
    /// Representa um Tipo de Gestão
    /// </summary>
    public class TipoGestao
    {
        /// <summary>
        /// Identificador do Tipo de Gestão
        /// </summary>
        public TipoGestaoEnum TipoGestaoId { get; private set; }

        /// <summary>
        /// Nome do Tipo de Gestão
        /// </summary>
        public string Nome { get; private set; }
    }
}

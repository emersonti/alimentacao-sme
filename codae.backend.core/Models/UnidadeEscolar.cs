namespace codae.backend.core.Models
{
    public class UnidadeEscolar
    {
        /// <summary>
        /// Identificador da Unidade Ecolar
        /// </summary>
        public int UnidadeEscolarId { get; private set; }

        /// <summary>
        /// Referenia a um Tipo de Gestão
        /// </summary>
        public TipoGestaoEnum TipoGestaoId { get; private set; }
        /// <summary>
        /// Tipo de Gestão da Unidade Escolar
        /// </summary>
        public TipoGestao TipoGestao { get; private set; }

        /// <summary>
        /// Referenia ao Tipo de Unidade Escolar
        /// </summary>
        public TipoUnidadeEscolarEnum TipoUnidadeEscolarId { get; private set; }

        /// <summary>
        /// Tipo de Unidade Escolar
        /// </summary>
        public virtual TipoUnidadeEscolar TipoUnidadeEscolar { get; private set; }

        /// <summary>
        /// Referencia a Região que a Unidade Escolar pertence
        /// </summary>
        public int RegiaoId { get; private set; }

        /// <summary>
        /// Regiao a qual a Unidade Escolar pertence
        /// </summary>
        public virtual Regiao Regiao { get; private set; }

        /// <summary>
        /// Nome da Unidade Escolar
        /// </summary>
        public string Nome { get; private set; }

        protected UnidadeEscolar() { }

        public static UnidadeEscolar Create(int regiaoId,
            TipoGestaoEnum tipoGestaoId, TipoUnidadeEscolarEnum tipoUnidadeEscolarId,
            string nome) =>
            new UnidadeEscolar()
            {
                RegiaoId = regiaoId,
                TipoGestaoId = tipoGestaoId,
                TipoUnidadeEscolarId = tipoUnidadeEscolarId,
                Nome = nome
            };
    }
}
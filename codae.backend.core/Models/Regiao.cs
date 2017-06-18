namespace codae.backend.core.Models
{
    /// <summary>
    /// Representa uma Delegacia Regional de Ensino (DRE)
    /// </summary>
    public class Regiao
    {
        public int RegiaoId { get; private set; }

        /// <summary>
        /// Referencia para um Agrupamento
        /// </summary>
        public AgrupamentoEnum AgrupamentoId { get; private set; }

        /// <summary>
        /// Indica a qual Agrupamento uma DRE pertence
        /// </summary>
        public virtual Agrupamento Agrupamento { get; private set; }


        /// <summary>
        /// Nome da DRE
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Nome do atual dirigente da DRE
        /// </summary>
        public string Dirigente { get; private set; }

        /// <summary>
        /// /E-mail para contato com a DRE
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// /Telefone para contato com a DRE
        /// </summary>
        public string Telefone { get; private set; }

        protected Regiao() { }

        public static Regiao Create(AgrupamentoEnum agrupamentoId, string nome,
            string dirigente, string email, string telefone) =>
            new Regiao()
            {
                AgrupamentoId = agrupamentoId,
                Nome = nome,
                Dirigente = dirigente,
                Email = email,
                Telefone = telefone
            };
    }
}
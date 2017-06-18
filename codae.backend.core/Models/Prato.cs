namespace codae.backend.core.Models
{
    /// <summary>
    /// Representa um Prato ou Grupo de Pratos do cardápio
    /// </summary>
    public class Prato
    {
        /// <summary>
        /// Identificador do Prato
        /// </summary>
        public int PratoId { get; private set; }

        /// <summary>
        /// Nome do Prato ou Grupo de Pratos
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Referenia para o Grupo de Pratos que este Prato pertence. Será nulo caso este seja um grupo
        /// </summary>
        public int? GrupoPratoId { get; private set; }

        /// <summary>
        /// Grupo ao qual este prato pertence. Nulo caso seja um Grupo de Pratos
        /// </summary>
        public virtual Prato GrupoPrato { get; private set; }

        protected Prato() { }

        public static Prato Create(string nome) => Create(nome, null);

        public static Prato Create(string nome, int? grupoPratoId) =>
            new Prato()
            {
                Nome = nome,
                GrupoPratoId = grupoPratoId
            };
    }
}

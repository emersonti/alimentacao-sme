namespace codae.backend.core.Models
{
    /// <summary>
    /// Item que compõe o que será servico em um Serviço
    /// </summary>
    public class ItemServico
    {

        /// <summary>
        /// Referencia ao Grupo de Pratos que este item representa dentro do serviço
        /// </summary>
        public int PratoId { get; private set; }

        /// <summary>
        /// Referencia para o Servço o qual o item pertence
        /// </summary>
        public int ServicoId { get; private set; }

        /// <summary>
        /// Serviço o qual este item pertence
        /// </summary>
        public Servico Servico { get; private set; }

        /// <summary>
        /// Grupo de Pratos que podem ser servidos
        /// </summary>
        public Prato Grupo { get; private set; }

        /// <summary>
        /// Nome como este item será apresentado
        /// </summary>
        public string Nome { get; private set; }

        protected ItemServico() { }

        public static ItemServico Create(int servicoId, int grupoPratoId, string nome) =>
            new ItemServico()
            {
                ServicoId = servicoId,
                PratoId = grupoPratoId,
                Nome = nome
            };
    }
}
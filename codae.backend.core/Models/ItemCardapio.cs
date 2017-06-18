using System;

namespace codae.backend.core.Models
{
    public class ItemCardapio
    {
        /// <summary>
        /// Referencia para o ´Cardápio o qual este item pertence
        /// </summary>
        public int CardapioId { get; set; }

        /// <summary>
        /// Referencia ao Serviço onde este prato será servido
        /// </summary>
        public int ServicoId { get; private set; }

        /// <summary>
        /// Serviço onde este prato será servido
        /// </summary>
        public virtual Servico Servico { get; private set; }

        /// <summary>
        /// Data em que o item será servido
        /// </summary>
        public DateTime Data { get; private set; }

        /// <summary>
        /// Referenci ao Prato ou Grupo de Pratos que será servido
        /// </summary>
        public int PratoId { get; private set; }

        /// <summary>
        /// Prato ou Grupo de Pratos que será servido
        /// </summary>
        public virtual Prato Prato { get; private set; }

        protected ItemCardapio() { }

        public static ItemCardapio Create(int cardapioId, int servicoId, int pratoId, DateTime data) =>
        new ItemCardapio()
        {
            CardapioId = cardapioId,
            ServicoId = servicoId,
            PratoId = pratoId,
            Data = data
        };
    }
}
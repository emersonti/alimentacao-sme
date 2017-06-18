using System;
using System.Collections.Generic;
using System.Linq;

namespace codae.backend.core.Models
{
    public class Cardapio
    {
        /// <summary>
        /// Identificador do Cardápio
        /// </summary>
        public int CardapioId { get; private set; }

        /// <summary>
        /// Referencia para o Agrupamento para o qual o Cardápio foi confeccionado
        /// </summary>
        public AgrupamentoEnum AgrupamentoId { get; private set; }

        public void AdicionarItem(int servicoid, int pratoId, DateTime data)
        {
            if (!_itensCardapio.Any(i => i.ServicoId ==servicoid
              && i.PratoId == pratoId && i.Data == data))
            {
                _itensCardapio.Add(ItemCardapio.Create(this.CardapioId, servicoid, pratoId, data));
            }
        }

        /// <summary>
        /// Agrupamento para o qual o Cardápio foi confeccionado
        /// </summary>
        public virtual Agrupamento Agrupamento { get; private set; }

        /// <summary>
        /// Referencia para o Tipo de Gestão para o qual o Cardápio foi confeccionado
        /// </summary>
        public TipoGestaoEnum TipoGestaoId { get; private set; }

        /// <summary>
        /// Tipo de Gestão para o qual o Cardápio foi confeccionado
        /// </summary>
        public virtual TipoGestao Tipogestao { get; private set; }

        /// <summary>
        /// Data do início da vigéncia do Cardápio
        /// </summary>
        public DateTime DataInicioVigencia { get; private set; }

        /// <summary>
        /// Data de término da vigencia do Cardápio
        /// </summary>
        public DateTime DataTerminoVigencia { get; private set; }

        /// <summary>
        /// Itens que compõe o ´Cardápio
        /// </summary>
        private readonly List<ItemCardapio> _itensCardapio = new List<ItemCardapio>();
        public IEnumerable<ItemCardapio> ItensCardapio => _itensCardapio.ToList();


        protected Cardapio() { }

        public static Cardapio Create(AgrupamentoEnum agrupamentoId,
            TipoGestaoEnum tipoGestaoId, DateTime dataInicioVigencia,
            DateTime dataTerminoVigencia) =>
            new Cardapio()
            {
                AgrupamentoId = agrupamentoId,
                TipoGestaoId = tipoGestaoId,
                DataInicioVigencia = dataInicioVigencia,
                DataTerminoVigencia = dataTerminoVigencia
            };
    }
}

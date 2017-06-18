using System;
using System.Collections.Generic;
using System.Linq;

namespace codae.backend.core.Models
{
    /// <summary>
    /// Define uma refeição que será servida aos alunos
    /// </summary>
    public class Servico
    {
        /// <summary>
        /// 
        /// </summary>
        public int ServicoId { get; private set; }

        /// <summary>
        /// Define o nome do Serviço
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Grupos que compoe  este serviço
        /// </summary>
        private readonly List<ItemServico> _composicao = new List<ItemServico>();
        public IEnumerable<ItemServico> Composicao => _composicao.ToList();

        public void AdicionarComponente(Prato grupoPrato, string nome = null)
        {
            if (string.IsNullOrWhiteSpace(nome))
                nome = grupoPrato.Nome;

            if (_composicao.Any(i => string.Compare(i.Nome, nome, StringComparison.OrdinalIgnoreCase) == 0))
                return;

            _composicao.Add(ItemServico.Create(this, grupoPrato, nome));
        }


        protected Servico() { }

        public static Servico Create(string nome) =>
            new Servico()
            {
                Nome = nome          
            };
    }
}
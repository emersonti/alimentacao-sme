using System;

namespace codae.backend.core.Models
{
    /// <summary>
    /// Domínio para os tipos de Unidade Escolar
    /// </summary>
    public enum TipoUnidadeEscolarEnum
    {
        EMEI = 1,
        EMEF = 2,
        EMEFB = 3,
        EMFM = 4,
        CEU = 5
    }   

    /// <summary>
    /// Representa um Tipo de Unidade Escolar
    /// </summary>
    public class TipoUnidadeEscolar
    {
        /// <summary>
        /// Identificador do Tipo de Unidade Escolar
        /// </summary>
        public TipoUnidadeEscolarEnum TipoUnidadeEscolarId { get; private set; }

        /// <summary>
        /// Nome do Tipo de Unidade Escolar
        /// </summary>
        public string Nome { get; private set; }

        public static TipoUnidadeEscolar Create(TipoUnidadeEscolarEnum tipoUnidadeEscolarId, string nome) =>
            new TipoUnidadeEscolar()
            {
                TipoUnidadeEscolarId = tipoUnidadeEscolarId,
                Nome = nome
            };
    }
}

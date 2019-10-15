using SuperDigital.Dominio.Base.Entidades;
using System;

namespace SuperDigital.Servico.Api.Modelos.ModeloVisao
{
    /// <summary>
    /// Classe de Modelo Visao da entidade <see cref="Lancamento"/>
    /// </summary>
    public class ModeloVisaoLancamento : IModeloVisao<Lancamento>
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// LancamentoId
        /// </summary>
        public string LancamentoId { get; set; }
        /// <summary>
        /// Tipo de Lancamento
        /// </summary>
        public string TipoLancamento { get; set; }
        /// <summary>
        /// ContaCorrenteOrigem
        /// </summary>
        public ModeloVisaoContaCorrente ContaCorrenteOrigem { get; set; }
        /// <summary>
        /// ContaCorrenteDestino
        /// </summary>
        public ModeloVisaoContaCorrente ContaCorrenteDestino { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Valor { get; set; }
        /// <summary>
        /// Data da Operacao
        /// </summary>
        public DateTime DataInclusaoRegistro { get; set; }
        #endregion
        #endregion
    }
}

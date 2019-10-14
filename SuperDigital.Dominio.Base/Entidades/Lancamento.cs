using SuperDigital.Dominio.Base.Enum;

namespace SuperDigital.Dominio.Base.Entidades
{
    /// <summary>
    /// Entidade Lancamento
    /// </summary>
    public class Lancamento : EntidadeBase
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// LancamentoId
        /// </summary>
        public string LancamentoId { get; set; }
        /// <summary>
        /// TipoLancamento
        /// </summary>
        public TipoLancamento TipoLancamento { get; set; }
        /// <summary>
        /// ContaCorrenteOrigemId
        /// </summary>
        public string ContaCorrenteOrigemId { get; set; }
        /// <summary>
        /// ContaCorrenteOrigem
        /// </summary>
        public ContaCorrente ContaCorrenteOrigem { get; set; }
        /// <summary>
        /// ContaCorrenteDestinoIds
        /// </summary>
        public string ContaCorrenteDestinoId { get; set; }
        /// <summary>
        /// ContaCorrenteDestino
        /// </summary>
        public ContaCorrente ContaCorrenteDestino { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Valor { get; set; }
        #endregion
        #endregion
    }
}

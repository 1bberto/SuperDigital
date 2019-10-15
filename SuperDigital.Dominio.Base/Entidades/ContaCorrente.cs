using System.Collections.Generic;
using System.Linq;

namespace SuperDigital.Dominio.Base.Entidades
{
    /// <summary>
    /// Entidade ContaCorrente
    /// </summary>
    public class ContaCorrente : EntidadeBase
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// ContaCorrenteId
        /// </summary>
        public string ContaCorrenteId { get; set; }
        /// <summary>
        /// Codigo
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Lancamentos
        /// </summary>
        public List<Lancamento> Lancamentos { get; set; }
        /// <summary>
        /// Saldo da conta corrente
        /// </summary>
        public decimal Saldo => Lancamentos != null && Lancamentos.Any() ?
            Lancamentos.Sum(x => x.TipoLancamento == Enum.TipoLancamento.Debito ? -1 * x.Valor : x.Valor) : 0;
        #endregion
        #endregion
    }
}

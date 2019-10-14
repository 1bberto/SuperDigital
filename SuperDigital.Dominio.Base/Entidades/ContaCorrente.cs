using System.Collections.Generic;

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
        #endregion
        #endregion
    }
}

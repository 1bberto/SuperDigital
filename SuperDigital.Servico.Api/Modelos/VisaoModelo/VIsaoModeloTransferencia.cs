namespace SuperDigital.Servico.Api.Modelos.VisaoModelo
{
    /// <summary>
    /// Classe de Visao Modelo para transferencia entre contas correntes
    /// </summary>
    public class VIsaoModeloTransferencia
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// ContaCorrenteOrigem
        /// </summary>
        public string ContaCorrenteOrigem { get; set; }
        /// <summary>
        /// ContaCorrenteDestino
        /// </summary>
        public string ContaCorrenteDestino { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Valor { get; set; }
        #endregion
        #endregion
    }
}

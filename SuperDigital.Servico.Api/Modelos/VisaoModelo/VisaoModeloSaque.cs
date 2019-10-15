﻿namespace SuperDigital.Servico.Api.Modelos.VisaoModelo
{
    /// <summary>
    /// Classe de Visao Modelo para saque em conta corrente
    /// </summary>
    public class VisaoModeloSaque
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// ContaCorrente
        /// </summary>
        public string ContaCorrente { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Valor { get; set; }
        #endregion
        #endregion
    }
}

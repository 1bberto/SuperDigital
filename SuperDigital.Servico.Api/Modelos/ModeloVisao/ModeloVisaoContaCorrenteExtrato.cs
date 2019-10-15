using SuperDigital.Dominio.Base.Entidades;
using System.Collections.Generic;

namespace SuperDigital.Servico.Api.Modelos.ModeloVisao
{
    /// <summary>
    /// Classe de Modelo Visao da entidade <see cref="ContaCorrente"/>
    /// </summary>
    public class ModeloVisaoContaCorrenteExtrato : IModeloVisao<ContaCorrente>
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
        public List<ModeloVisaoLancamento> Lancamentos { get; set; }
        /// <summary>
        /// Saldo
        /// </summary>
        public decimal Saldo { get; set; }
        #endregion
        #endregion
    }
}

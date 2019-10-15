using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Servico.Api.Modelos.ModeloVisao
{
    /// <summary>
    /// Classe de Modelo Visao da entidade <see cref="ContaCorrente"/>
    /// </summary>
    public class ModeloVisaoContaCorrente : IModeloVisao<ContaCorrente>
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
        #endregion
        #endregion
    }
}

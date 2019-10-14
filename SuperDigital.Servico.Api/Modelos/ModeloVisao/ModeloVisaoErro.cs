namespace SuperDigital.Servico.Api.Modelos.ModeloVisao
{
    /// <summary>
    /// Classe de Modelo Visao de Erro
    /// </summary>
    public class ModeloVisaoErro
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// Core
        /// </summary>
        public bool Core { get; set; }
        /// <summary>
        /// Controller
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Action
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// Mensagem
        /// </summary>
        public string Mensagem { get; set; }
        #endregion
        #endregion
    }
}
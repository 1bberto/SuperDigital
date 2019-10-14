using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Servico.Api.Modelos.ModeloVisao
{
    /// <summary>
    /// Classe de Modelo Visao da entidade <see cref="Usuario"/>
    /// </summary>
    public class ModeloVisaoUsuario : IModeloVisao<Usuario>
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// UsuarioId
        /// </summary>
        public string UsuarioId { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }
        #endregion
        #endregion
    }
}
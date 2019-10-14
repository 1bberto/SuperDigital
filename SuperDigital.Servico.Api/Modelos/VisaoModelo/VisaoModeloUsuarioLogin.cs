using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Servico.Api.Modelos.VisaoModelo
{
    /// <summary>
    /// Classe de Visao Modelo da entidade <see cref="Usuario"/>
    /// </summary>
    public class VisaoModeloUsuarioLogin : IVisaoModelo<Usuario>
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; set; }
        #endregion
        #endregion
    }
}

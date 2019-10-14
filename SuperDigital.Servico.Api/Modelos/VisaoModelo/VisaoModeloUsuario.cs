using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Servico.Api.Modelos.VisaoModelo
{
    /// <summary>
    /// Classe de Visao Modelo da entidade <see cref="Usuario"/>
    /// </summary>
    public class VisaoModeloUsuario : IVisaoModelo<Usuario>
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
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }
        #endregion
        #endregion
    }
}

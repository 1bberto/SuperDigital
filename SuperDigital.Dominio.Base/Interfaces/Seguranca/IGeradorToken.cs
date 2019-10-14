using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Dominio.Base.Interfaces.Seguranca
{
    /// <summary>
    /// Interface para a geracao de tokens
    /// </summary>
    public interface IGeradorToken
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Gera um token para redefinir uma senha
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        string GerarToken(Usuario usuario);
        #endregion
        #endregion
    }
}

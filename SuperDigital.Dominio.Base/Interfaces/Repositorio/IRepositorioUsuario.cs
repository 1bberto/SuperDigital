using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interface.Repositorio.Generico;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interfaces.Repositorio
{
    /// <summary>
    /// Repositorio da entidade <see cref="Usuario"/>
    /// </summary>
    public interface IRepositorioUsuario : IRepositorioBase<Usuario, string>, ISalvar<Usuario>
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Realiza o login do usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<Usuario> RealizarLoginUsuario(Usuario usuario);
        #endregion
        #endregion
    }
}

using SuperDigital.Dominio.Base.Entidades;
using System.Threading.Tasks;

namespace SuperDigital.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface de Servico Aplicaco da Entidade <see cref="Usuario"/>
    /// </summary>
    public interface IServicoAplicacaoUsuario : IServicoAplicacaoBase<Usuario>
    {
        #region |Membros|
        #region |Atributos|
        /// <summary>
        /// Criar um novo usuario na base de dados
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        Task<Usuario> AdicionarUsuarioAssincrono(Usuario usuario);
        /// <summary>
        /// Busca usuario pelo Id
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        Task<Usuario> BuscarUsuarioAssincrono(string usuarioId);
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

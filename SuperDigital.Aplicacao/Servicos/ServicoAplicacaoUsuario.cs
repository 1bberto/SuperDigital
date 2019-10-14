using SuperDigital.Aplicacao.Interfaces;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Servico;
using System.Threading.Tasks;

namespace SuperDigital.Aplicacao.Servicos
{
    /// <inheritdoc />  
    public class ServicoAplicacaoUsuario : ServicoAplicacaoBase<Usuario>, IServicoAplicacaoUsuario
    {
        #region |Membros|
        #region |Propriedades|
        private readonly IServicoUsuario _servico;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de ServicoAplicacaoUsuario
        /// </summary>
        /// <param name="servico"></param>
        public ServicoAplicacaoUsuario(IServicoUsuario servico)
        {
            _servico = servico;
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />  
        public async Task<Usuario> AdicionarUsuarioAssincrono(Usuario usuario)
        {
            return await _servico.AdicionarUsuarioAssincrono(usuario);
        }
        /// <inheritdoc />  
        public async Task<Usuario> BuscarUsuarioAssincrono(string usuarioId)
        {
            return await _servico.BuscarUsuarioAssincrono(usuarioId);
        }
        /// <inheritdoc />  
        public async Task<Usuario> RealizarLoginUsuario(Usuario usuario)
        {
            return await _servico.RealizarLoginUsuario(usuario);
        }
        #endregion
        #endregion
    }
}

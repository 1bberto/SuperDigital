using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Excecoes;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Base.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Servicos
{
    /// <inheritdoc />  
    public class ServicoUsuario : ServicoBase<Usuario>, IServicoUsuario
    {
        #region |Membros|
        #region |Atributos|
        private readonly IRepositorioUsuario _repositorio;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Contrutor de ServicoUsuario
        /// </summary>
        /// <param name="repositorio"></param>
        public ServicoUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />  
        public async Task<Usuario> AdicionarUsuarioAssincrono(Usuario usuario)
        {
            ValidarUsuario(usuario);

            var usuariosCadastrados = await _repositorio.ObterTodosAssincrono();

            VerificarLoginUsuario(usuario, usuariosCadastrados);

            await _repositorio.SalvarAssincrono(usuario);

            return usuario;
        }
        /// <inheritdoc />  
        public async Task<Usuario> BuscarUsuarioAssincrono(string usuarioId)
        {
            ValidarFiltroBuscaUsuario(usuarioId);

            var usuario = await _repositorio.ObterPorIdAssincrono(usuarioId);

            ValidarBuscaUsuario(usuario, usuarioId);

            return usuario;
        }
        /// <summary>
        /// Valida a busca de um usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="usuarioId">codigo do usuario</param>
        public bool ValidarBuscaUsuario(Usuario usuario, string usuarioId)
        {
            if (usuario == null)
                throw new ExcecaoDominioObjetoNaoEncontrado($"{usuarioId} nao encontrado");

            return true;
        }
        /// <summary>
        /// Valida o filtro de busca de um usuario
        /// </summary>
        /// <param name="usuarioId"></param>
        public bool ValidarFiltroBuscaUsuario(string usuarioId)
        {
            if (string.IsNullOrEmpty(usuarioId))
                throw new ExcecaoDominio($"{nameof(usuarioId)} nao informado");

            if (!Guid.TryParse(usuarioId, out _))
                throw new ExcecaoDominio($"{nameof(usuarioId)} invalido");

            return true;
        }
        /// <summary>
        /// Valida usuario
        /// </summary>
        /// <param name="usuario"></param>
        public bool ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ExcecaoDominio($"{nameof(usuario)} nulo");

            if (string.IsNullOrEmpty(usuario.Login))
                throw new ExcecaoDominio($"{nameof(usuario.Login)} em branco");

            if (string.IsNullOrEmpty(usuario.Nome))
                throw new ExcecaoDominio($"{nameof(usuario.Nome)} em branco");

            if (string.IsNullOrEmpty(usuario.Senha))
                throw new ExcecaoDominio($"{nameof(usuario.Senha)} em branco");

            if (usuario.Login.Length < 5)
                throw new ExcecaoDominio($"{nameof(usuario.Login)} invalido");

            if (usuario.Senha.Length < 5)
                throw new ExcecaoDominio($"{nameof(usuario.Senha)} invalida");

            return true;
        }
        /// <summary>
        /// Valida se o login inserido pelo usuario e valido
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="usuarios"></param>
        public bool VerificarLoginUsuario(Usuario usuario, IList<Usuario> usuarios)
        {
            if (usuario == null)
                throw new ExcecaoDominio($"{nameof(usuario)} nulo");

            if (usuarios == null)
                return true;

            if (usuarios.Any(x => x.Login == usuario.Login))
                throw new ExcecaoDominio("Login ja cadastrado");

            return true;
        }
        /// <inheritdoc />  
        public async Task<Usuario> RealizarLoginUsuario(Usuario usuario)
        {
            ValidarLoginUsuario(usuario);

            var usuarioLogin = await _repositorio.RealizarLoginUsuario(usuario);

            ValidarLoginUsuarioRealizado(usuarioLogin);

            return usuarioLogin;
        }
        /// <summary>
        /// Valida se o login do usuario foi realizado com sucesso
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ValidarLoginUsuarioRealizado(Usuario usuario)
        {
            if (usuario == null)
                throw new ExcecaoDominioUsuarioNaoEncontrado();

            return true;
        }
        /// <summary>
        /// Valida os dados do usuario para realizacao do login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ValidarLoginUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ExcecaoDominio($"{nameof(usuario)} nulo");

            if (string.IsNullOrEmpty(usuario.Login))
                throw new ExcecaoDominio($"{nameof(usuario.Login)} em branco");

            if (string.IsNullOrEmpty(usuario.Senha))
                throw new ExcecaoDominio($"{nameof(usuario.Senha)} em branco");

            return true;
        }
        #endregion
        #endregion
    }
}

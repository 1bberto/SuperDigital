using Dapper;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Compartilhado.Interface;
using System.Threading.Tasks;

namespace SuperDigital.Infraestrutura.Dados.Persistencia.Repositorio
{
    /// <inheritdoc />
    public class RepositorioUsuario : RepositorioBase<Usuario, string>, IRepositorioUsuario
    {
        #region |Membros|
        #region |Atributos|
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de RepositorioUsuario
        /// </summary>
        /// <param name="unidadeTrabalho"></param>
        public RepositorioUsuario(IUnidadeTrabalho unidadeTrabalho) : base(unidadeTrabalho)
        {
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />
        public async Task SalvarAssincrono(Usuario entidade)
        {
            var parametroLogin = nameof(entidade.Login);
            var parametroSenha = nameof(entidade.Senha);
            var parametroNome = nameof(entidade.Nome);

            var parametros = new DynamicParameters();
            parametros.Add($"@{parametroLogin}", entidade.Login);
            parametros.Add($"@{parametroSenha}", entidade.Senha);
            parametros.Add($"@{parametroNome}", entidade.Nome);

            var usuarioId = await UnidadeTrabalho.ObterConexao()
                .QueryFirstOrDefaultAsync<string>($"EXEC {NomeProcedureInclusao} " +
                $"@{parametroLogin}," +
                $"@{parametroSenha}," +
                $"@{parametroNome}"
                , parametros, UnidadeTrabalho.ObterTransacao());

            entidade.UsuarioId = usuarioId;
        }
        /// <inheritdoc />
        public async Task<Usuario> RealizarLoginUsuario(Usuario usuario)
        {
            var parametroLogin = nameof(usuario.Login);
            var parametroSenha = nameof(usuario.Senha);

            var parametros = new DynamicParameters();
            parametros.Add($"@{parametroLogin}", usuario.Login);
            parametros.Add($"@{parametroSenha}", usuario.Senha);

            return await UnidadeTrabalho.ObterConexao()
                .QueryFirstOrDefaultAsync<Usuario>($"EXEC USP_UsuarioLogin " +
                $"@{parametroLogin}," +
                $"@{parametroSenha}"
                , parametros, UnidadeTrabalho.ObterTransacao());
        }
        #endregion
        #endregion
    }
}

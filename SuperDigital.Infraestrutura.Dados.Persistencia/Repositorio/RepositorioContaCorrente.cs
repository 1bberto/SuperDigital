using Dapper;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Compartilhado.Interface;
using System.Threading.Tasks;

namespace SuperDigital.Infraestrutura.Dados.Persistencia.Repositorio
{
    /// <inheritdoc />
    public class RepositorioContaCorrente : RepositorioBase<ContaCorrente, string>, IRepositorioContaCorrente
    {
        #region |Membros|
        #region |Atributos|
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de RepositorioUsuario
        /// </summary>
        /// <param name="unidadeTrabalho"></param>
        public RepositorioContaCorrente(IUnidadeTrabalho unidadeTrabalho) : base(unidadeTrabalho)
        {
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />
        public async Task SalvarAssincrono(ContaCorrente entidade)
        {
            var parametroCodigo = nameof(entidade.Codigo);

            var parametros = new DynamicParameters();
            parametros.Add($"@{parametroCodigo}", entidade.Codigo);

            var contaCorrenteId = await UnidadeTrabalho.ObterConexao()
                .QueryFirstOrDefaultAsync<string>($"EXEC {NomeProcedureInclusao} " +
                $"@{parametroCodigo}"
                , parametros, UnidadeTrabalho.ObterTransacao());

            entidade.ContaCorrenteId = contaCorrenteId;
        }
        /// <inheritdoc />
        public async Task<ContaCorrente> BuscarContaCorrenteAssincrono(string codigo)
        {
            var parametroCodigo = nameof(ContaCorrente.Codigo);

            var parametros = new DynamicParameters();
            parametros.Add($"@{parametroCodigo}", codigo);

            return await UnidadeTrabalho.ObterConexao()
                .QueryFirstOrDefaultAsync<ContaCorrente>($"EXEC {NomeProcedureSelecao} " +
                $"NULL, @{parametroCodigo}"
                , parametros, UnidadeTrabalho.ObterTransacao());
        }
        #endregion
        #endregion
    }
}

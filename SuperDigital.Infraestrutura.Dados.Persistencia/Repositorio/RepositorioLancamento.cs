using Dapper;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Compartilhado.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Infraestrutura.Dados.Persistencia.Repositorio
{
    /// <inheritdoc />
    public class RepositorioLancamento : RepositorioBase<Lancamento, string>, IRepositorioLancamento
    {
        #region |Membros|
        #region |Atributos|
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de RepositorioLancamento
        /// </summary>
        /// <param name="unidadeTrabalho"></param>
        public RepositorioLancamento(IUnidadeTrabalho unidadeTrabalho) : base(unidadeTrabalho)
        {
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />
        public async Task SalvarAssincrono(Lancamento entidade)
        {
            var parametroTipoLancamentoId = nameof(Lancamento.TipoLancamento);
            var parametroContaCorrenteOrigemId = nameof(Lancamento.ContaCorrenteOrigemId);
            var parametroContaCorrenteDestinoId = nameof(Lancamento.ContaCorrenteDestinoId);
            var parametroValor = nameof(Lancamento.Valor);

            var parametros = new DynamicParameters();

            parametros.Add($"@{parametroTipoLancamentoId}", entidade.TipoLancamento);
            parametros.Add($"@{parametroContaCorrenteOrigemId}", entidade.ContaCorrenteOrigemId);
            parametros.Add($"@{parametroContaCorrenteDestinoId}", entidade.ContaCorrenteDestinoId);
            parametros.Add($"@{parametroValor}", entidade.Valor);

            var lancamentoId = await UnidadeTrabalho.ObterConexao()
                .QueryFirstAsync<string>($"EXEC {NomeProcedureInclusao} " +
                $"@{parametroTipoLancamentoId}, " +
                $"@{parametroContaCorrenteOrigemId}, " +
                $"@{parametroContaCorrenteDestinoId}, " +
                $"@{parametroValor}"
                , parametros, UnidadeTrabalho.ObterTransacao());

            entidade.LancamentoId = lancamentoId;
        }
        /// <inheritdoc />
        public async Task<List<Lancamento>> BuscarLancamentosContaCorrenteAssincrono(ContaCorrente contaCorrente)
        {
            var parametroContaCorrenteId = nameof(contaCorrente.ContaCorrenteId);

            var parametros = new DynamicParameters();
            parametros.Add($"@{parametroContaCorrenteId}", contaCorrente.ContaCorrenteId);

            var dados = await UnidadeTrabalho.ObterConexao()
                .QueryAsync<Lancamento>($"EXEC USP_LancamentoExtrato " +
                $"@{parametroContaCorrenteId}"
                , parametros, UnidadeTrabalho.ObterTransacao());

            return dados.AsList();
        }
        #endregion
        #endregion
    }
}

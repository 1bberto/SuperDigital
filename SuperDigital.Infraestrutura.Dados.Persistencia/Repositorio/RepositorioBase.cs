using Dapper;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Compartilhado.Interface;
using SuperDigital.Infraestrutura.Dados.Persistencia.Configuracao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Infraestrutura.Dados.Persistencia.Repositorio
{
    /// <summary>
    /// Classe base de repositorio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class RepositorioBase<T, TId> :
        IRepositorioBase<T, TId>
        where T : EntidadeBase
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// Unidade de Trabalho
        /// </summary>
        protected readonly IUnidadeTrabalhoBase UnidadeTrabalho;
        /// <summary>
        /// Nome da tabela da entidade
        /// </summary>
        protected readonly string NomeTabela;
        /// <summary>
        /// Nome da procedure de inclusao
        /// </summary>
        protected readonly string NomeProcedureInclusao;
        /// <summary>
        /// Nome da procedure de selecao
        /// </summary>
        protected readonly string NomeProcedureSelecao;
        /// <summary>
        /// Nome da procedure de atualizacao
        /// </summary>
        protected readonly string NomeProcedureAtualizacao;
        /// <summary>
        /// Nome da procedure de exclusao
        /// </summary>
        protected readonly string NomeProcedureExclusao;
        #endregion
        #region |Contrutor|
        /// <summary>
        /// RepositorioBase
        /// </summary>
        static RepositorioBase()
        {
            ConfiguradorMapeamento.RegistrarModelos();
        }
        /// <summary>
        /// Contrutor de RepositorioBase
        /// </summary>
        /// <param name="unidadeTrabalho"></param>
        protected RepositorioBase(IUnidadeTrabalhoBase unidadeTrabalho)
        {
            UnidadeTrabalho = unidadeTrabalho;
            NomeTabela = ClasseParaTabela(typeof(T).Name);
            NomeProcedureInclusao = $"USP_{typeof(T).Name}_INS";
            NomeProcedureSelecao = $"USP_{typeof(T).Name}_SEL";
            NomeProcedureAtualizacao = $"USP_{typeof(T).Name}_UPD";
            NomeProcedureExclusao = $"USP_{typeof(T).Name}_DEL";
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />
        public IUnidadeTrabalhoBase ObterUnidadeTrabalho()
        {
            return UnidadeTrabalho;
        }
        /// <inheritdoc />
        protected string ClasseParaTabela(string classe)
        {
            return $"tbl{classe}";
        }
        /// <inheritdoc />
        public static string ObterNomeColunaChave(string classe)
        {
            return $"{classe}Id";
        }
        /// <inheritdoc />  
        public virtual async Task<T> ObterPorIdAssincrono(TId entidadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add($"@{ObterNomeColunaChave(typeof(T).Name)}", entidadeId);

            var dados = await UnidadeTrabalho.ObterConexao().QueryFirstOrDefaultAsync<T>(
                $"EXEC {NomeProcedureSelecao} @{ObterNomeColunaChave(typeof(T).Name)}", parametros, UnidadeTrabalho.ObterTransacao()
            );

            return dados;
        }
        /// <inheritdoc />  
        public virtual async Task<IList<T>> ObterTodosAssincrono()
        {
            var dados = await UnidadeTrabalho.ObterConexao().QueryAsync<T>(
                $"EXEC {NomeProcedureSelecao}", null, UnidadeTrabalho.ObterTransacao());

            return dados.AsList();
        }
        /// <inheritdoc />  
        public virtual async Task ApagarAssincrono(TId entidadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add($"@{ObterNomeColunaChave(typeof(T).Name)}", entidadeId);

            await UnidadeTrabalho.ObterConexao()
                .ExecuteAsync($"EXEC {NomeProcedureExclusao} @{ObterNomeColunaChave(typeof(T).Name)}", parametros, UnidadeTrabalho.ObterTransacao());
        }
        #endregion
        #endregion
    }
}

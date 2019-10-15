using SuperDigital.Dominio.Base.Entidades;
using System.Threading.Tasks;

namespace SuperDigital.Aplicacao.Interfaces
{
    /// <summary>
    /// Interface de Servico Aplicaco da Entidade <see cref="ContaCorrente"/>
    /// </summary>
    public interface IServicoAplicacaoContaCorrente : IServicoAplicacaoBase<ContaCorrente>
    {
        #region |Membros|
        #region |Atributos|
        /// <summary>
        /// Cria uma nova conta corrente
        /// </summary>
        /// <returns>conta corrente <see cref="ContaCorrente"/></returns>
        Task<ContaCorrente> AdicionarContaCorrenteAssincrono();
        /// <summary>
        /// Busca conta corrente pelo codigo
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        /// <returns>conta corrente <see cref="ContaCorrente"/></returns>
        Task<ContaCorrente> BuscarContaCorrenteAssincrono(string codigo);
        /// <summary>
        /// Busca extrato conta corrente
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        /// <returns>lista de <see cref="Lancamento"/></returns>
        Task<ContaCorrente> BuscarExtratoContaCorrenteAssincrono(string codigo);
        /// <summary>
        /// Realiza um deposito de um montante em uma conta corrente
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        /// <param name="valor">valor a ser depositado</param>
        Task EfetuarDepositoCaixaContaCorrenteAssincrono(string codigo, decimal valor);
        /// <summary>
        /// Realiza um saque de um montante em uma conta corrente
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        /// <param name="valor">valor a ser sacado</param>
        Task EfetuarSaqueCaixaContaCorrenteAssincrono(string codigo, decimal valor);
        /// <summary>
        /// Realiza tranferencia de um montante de uma conta para outra
        /// </summary>
        /// <param name="contaCorrenteOrigem">codigo da conta corrente de origem</param>
        /// <param name="contaCorrenteDestino">codigo da conta corrente de destino</param>
        /// <param name="valor">valor a ser transferido</param>
        Task EfetuarTransferenciaAssincrono(string contaCorrenteOrigem, string contaCorrenteDestino, decimal valor);
        #endregion
        #endregion
    }
}

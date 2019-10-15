using SuperDigital.Dominio.Base.Entidades;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interfaces.Servico
{
    /// <summary>
    /// Servico da entidade <see cref="ContaCorrente"/>
    /// </summary>
    public interface IServicoContaCorrente : IServicoBase<ContaCorrente>
    {
        #region |Membros|
        #region |Atributos|
        /// <summary>
        /// Criar uma nova conta corrente
        /// </summary>
        /// <returns></returns>
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

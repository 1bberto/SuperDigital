using SuperDigital.Aplicacao.Interfaces;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Servico;
using System.Threading.Tasks;

namespace SuperDigital.Aplicacao.Servicos
{
    /// <inheritdoc />  
    public class ServicoAplicacaoContaCorrente : ServicoAplicacaoBase<ContaCorrente>, IServicoAplicacaoContaCorrente
    {
        #region |Membros|
        #region |Propriedades|
        private readonly IServicoContaCorrente _servico;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de ServicoAplicacaoContaCorrente
        /// </summary>
        /// <param name="servico"></param>
        public ServicoAplicacaoContaCorrente(IServicoContaCorrente servico)
        {
            _servico = servico;
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />  
        public async Task<ContaCorrente> AdicionarContaCorrenteAssincrono()
        {
            return await _servico.AdicionarContaCorrenteAssincrono();
        }
        /// <inheritdoc />  
        public async Task<ContaCorrente> BuscarContaCorrenteAssincrono(string codigo)
        {
            return await _servico.BuscarContaCorrenteAssincrono(codigo);
        }
        /// <inheritdoc />  
        public async Task<ContaCorrente> BuscarExtratoContaCorrenteAssincrono(string codigo)
        {
            return await _servico.BuscarExtratoContaCorrenteAssincrono(codigo);
        }
        /// <inheritdoc />  
        public async Task EfetuarDepositoCaixaContaCorrenteAssincrono(string codigo, decimal valor)
        {
            await _servico.EfetuarDepositoCaixaContaCorrenteAssincrono(codigo, valor);
        }
        /// <inheritdoc />  
        public async Task EfetuarSaqueCaixaContaCorrenteAssincrono(string codigo, decimal valor)
        {
            await _servico.EfetuarSaqueCaixaContaCorrenteAssincrono(codigo, valor);
        }
        /// <inheritdoc />  
        public async Task EfetuarTransferenciaAssincrono(string contaCorrenteOrigem, string contaCorrenteDestino, decimal valor)
        {
            await _servico.EfetuarTransferenciaAssincrono(contaCorrenteOrigem, contaCorrenteDestino, valor);
        }
        #endregion
        #endregion
    }
}

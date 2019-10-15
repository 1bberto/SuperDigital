using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.Aplicacao.Interfaces;
using SuperDigital.Servico.Api.Modelos.ModeloVisao;
using SuperDigital.Servico.Api.Modelos.VisaoModelo;
using System.Net;
using System.Threading.Tasks;

namespace SuperDigital.Servico.Api.Controllers
{
    /// <summary>
    /// Controller responsavel por receber as requisicoes relacionadas
    /// a conta corrente
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("conta-corrente")]
    public class ContaCorrenteController : BaseController
    {
        #region |Membros|
        #region |Atributos|
        private readonly IMapper _mapper;
        private readonly IServicoAplicacaoContaCorrente _servicoAplicacaoContaCorrente;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de ContaCorrenteController
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="servicoAplicacaoContaCorrente"></param>
        public ContaCorrenteController(
            IMapper mapper,
            IServicoAplicacaoContaCorrente servicoAplicacaoContaCorrente)
        {
            _mapper = mapper;
            _servicoAplicacaoContaCorrente = servicoAplicacaoContaCorrente;
        }
        #endregion
        #region |Metodos|
        /// <summary>
        /// Cria uma nova conta corrente
        /// </summary>
        /// <response code="201">Conta Corrente</response>
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Nenhum item encontrado</response> 
        /// <response code="409">Se alguma regra de negocio for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpPost]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoContaCorrente>), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AdicionarContaCorrente()
        {
            var contaCorrenteDominio = await _servicoAplicacaoContaCorrente.AdicionarContaCorrenteAssincrono();

            var retorno = new ModeloVisaoRetorno<ModeloVisaoContaCorrente>
            {
                ObjetoDeRetorno = _mapper.Map<ModeloVisaoContaCorrente>(contaCorrenteDominio)
            };

            return CreatedAtAction(nameof(ObterContaCorrente), new { codigo = contaCorrenteDominio.Codigo }, retorno);
        }
        /// <summary>
        /// Busca conta corrente pelo codigo
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        /// <response code="200">Conta Corrente</response>
        /// <response code="400">Erro na requisicao</response> 
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Usuario nao encontrado</response> 
        /// <response code="409">Se alguma regra/validacao for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpGet("{codigo}")]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoContaCorrente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterContaCorrente(string codigo)
        {
            if (codigo is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var contaCorrenteDominio = await _servicoAplicacaoContaCorrente.BuscarContaCorrenteAssincrono(codigo);

            var retorno = new ModeloVisaoRetorno<ModeloVisaoContaCorrente>
            {
                ObjetoDeRetorno = _mapper.Map<ModeloVisaoContaCorrente>(contaCorrenteDominio)
            };

            return Ok(retorno);
        }
        /// <summary>
        /// Busca o extrato de uma conta corrente
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        /// <response code="200">Extrato da Corrente</response>
        /// <response code="400">Erro na requisicao</response> 
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Usuario nao encontrado</response> 
        /// <response code="409">Se alguma regra/validacao for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpGet("{codigo}/extrato")]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoContaCorrenteExtrato>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterExtratoContaCorrente(string codigo)
        {
            if (codigo is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var extratoDominio = await _servicoAplicacaoContaCorrente.BuscarExtratoContaCorrenteAssincrono(codigo);

            var retorno = new ModeloVisaoRetorno<ModeloVisaoContaCorrenteExtrato>
            {
                ObjetoDeRetorno = _mapper.Map<ModeloVisaoContaCorrenteExtrato>(extratoDominio)
            };

            return Ok(retorno);
        }
        /// <summary>
        /// Efetua o depositorio em uma conta corrente, a partir de um caixa, ou 
        /// seja sem identificacao de conta corrente de origem
        /// </summary>
        /// <param name="deposito">dados do deposito</param>
        /// <response code="201">Deposito efetuado com sucesso</response>
        /// <response code="400">Erro na requisicao</response> 
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Usuario nao encontrado</response> 
        /// <response code="409">Se alguma regra/validacao for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpPost("deposito")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> EfetuarDepositoContaCorrente(
            VisaoModeloDeposito deposito)
        {
            if (deposito is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            await _servicoAplicacaoContaCorrente.EfetuarDepositoCaixaContaCorrenteAssincrono(deposito.ContaCorrente, deposito.Valor);

            return Accepted();
        }
        /// <summary>
        /// Efetua o saque em uma conta corrente, a partir de um caixa, ou 
        /// seja sem identificacao de conta corrente de destino
        /// </summary>
        /// <param name="saque">dados do saque</param>
        /// <response code="201">Saque efetuado com sucesso</response>
        /// <response code="400">Erro na requisicao</response> 
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Usuario nao encontrado</response> 
        /// <response code="409">Se alguma regra/validacao for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpPost("saque")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> EfetuarSaqueContaCorrente(
            VisaoModeloSaque saque)
        {
            if (saque is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            await _servicoAplicacaoContaCorrente.EfetuarSaqueCaixaContaCorrenteAssincrono(saque.ContaCorrente, saque.Valor);

            return Accepted();
        }
        /// <summary>
        /// Efetua transferencia de valor entre conta correntes
        /// </summary>
        /// <param name="transferencia">dados da transferencia</param>
        /// <response code="201">Transferencia efetuada com sucesso</response>
        /// <response code="400">Erro na requisicao</response> 
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Usuario nao encontrado</response> 
        /// <response code="409">Se alguma regra/validacao for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpPost("transferencia")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> EfetuarTransferencia(
            VIsaoModeloTransferencia transferencia)
        {
            if (transferencia is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            await _servicoAplicacaoContaCorrente.EfetuarTransferenciaAssincrono(
                    transferencia.ContaCorrenteOrigem,
                    transferencia.ContaCorrenteDestino,
                    transferencia.Valor);

            return Accepted();
        }
        #endregion
        #endregion
    }
}

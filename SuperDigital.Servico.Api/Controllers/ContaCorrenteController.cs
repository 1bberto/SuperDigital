using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.Servico.Api.Modelos.ModeloVisao;
using System.Collections.Generic;
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
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de ContaCorrenteController
        /// </summary>
        /// <param name="mapper"></param>
        public ContaCorrenteController(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion
        #region |Metodos|
        /// <summary>
        /// Retorna a lista de tipo de comissao
        /// </summary>
        /// <param name="contaCorrente">Codigo da Conta Corrente</param>
        /// <response code="200">Lista de tipo de comissao</response>
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Nenhum item encontrado</response> 
        /// <response code="409">Se alguma regra de negocio for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpGet]
        [Route("{contaCorrente}/extrato")]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<List<string>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ListarExtrato(string contaCorrente)
        {
            return Ok(contaCorrente);
        }
        #endregion
        #endregion
    }
}

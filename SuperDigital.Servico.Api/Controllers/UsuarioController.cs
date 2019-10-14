using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.Aplicacao.Interfaces;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Seguranca;
using SuperDigital.Servico.Api.Modelos.ModeloVisao;
using SuperDigital.Servico.Api.Modelos.VisaoModelo;
using System.Net;
using System.Threading.Tasks;

namespace SuperDigital.Servico.Api.Controllers
{
    /// <summary>
    /// Controller responsavel por receber as requisicoes relacionadas
    /// a entidade usuario
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : BaseController
    {
        #region |Membros|
        #region |Atributos|
        private readonly IMapper _mapper;
        private readonly IServicoAplicacaoUsuario _servicoAplicacaoUsuario;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de UsuarioController
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="servicoAplicacaoUsuario"></param>
        public UsuarioController(
            IMapper mapper,
            IServicoAplicacaoUsuario servicoAplicacaoUsuario)
        {
            _mapper = mapper;
            _servicoAplicacaoUsuario = servicoAplicacaoUsuario;
        }
        #endregion
        #region |Metodos|
        /// <summary>
        /// Realiza o cadastro o cadastro de um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Novo Usuario</param>
        /// <response code="201">Novo usuario criado</response>
        /// <response code="401">Acesso negado</response> 
        /// <response code="409">Se alguma regra de negocio for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpPost]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoUsuario>), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> AdicionarUsuario(
            [FromBody] VisaoModeloUsuario novoUsuario)
        {
            if (novoUsuario is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = new ModeloVisaoRetorno<ModeloVisaoUsuario>();

            var usuario = _mapper.Map<Usuario>(novoUsuario);

            var usuarioDominio = await _servicoAplicacaoUsuario.AdicionarUsuarioAssincrono(usuario);

            retorno.ObjetoDeRetorno = _mapper.Map<ModeloVisaoUsuario>(usuarioDominio);

            return CreatedAtAction(nameof(ObterUsuario), new { usuarioId = usuarioDominio.UsuarioId }, retorno);
        }
        /// <summary>
        /// Busca usuario pelo Id
        /// </summary>
        /// <param name="usuarioId">codigo de identificacao do usuario</param>
        /// <response code="200">Usuario</response>
        /// <response code="400">Erro na requisicao</response> 
        /// <response code="401">Acesso negado</response> 
        /// <response code="404">Usuario nao encontrado</response> 
        /// <response code="409">Se alguma regra/validacao for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [HttpGet("{usuarioId}")]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoUsuario>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> ObterUsuario(string usuarioId)
        {
            if (usuarioId is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = new ModeloVisaoRetorno<ModeloVisaoUsuario>();

            var usuarioDominio = await _servicoAplicacaoUsuario.BuscarUsuarioAssincrono(usuarioId);

            retorno.ObjetoDeRetorno = _mapper.Map<ModeloVisaoUsuario>(usuarioDominio);

            return Ok(retorno);
        }
        /// <summary>
        /// Realiza login do usuario
        /// </summary>
        /// <param name="loginUsuario">codigo de identificacao do usuario</param>
        /// <param name="geradorToken">codigo de identificacao do usuario</param>
        /// <response code="200">Usuario</response>
        /// <response code="400">Erro na requisicao</response> 
        /// <response code="401">Acesso negado</response> 
        /// <response code="409">Se alguma regra/validacao for violada</response> 
        /// <response code="500">Erro interno desconhecido</response>
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoToken>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.Conflict)]
        [ProducesResponseType(typeof(ModeloVisaoRetorno<ModeloVisaoErro>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RealizarLogin(
            [FromBody] VisaoModeloUsuarioLogin loginUsuario,
            [FromServices]IGeradorToken geradorToken)
        {
            if (loginUsuario is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var objRetorno = new ModeloVisaoRetorno<ModeloVisaoToken>();

            var usuario = _mapper.Map<Usuario>(loginUsuario);

            var usuarioAutenticado = await _servicoAplicacaoUsuario.RealizarLoginUsuario(usuario);

            objRetorno.ObjetoDeRetorno = new ModeloVisaoToken()
            {
                Token = geradorToken.GerarToken(usuarioAutenticado),
                Nome = usuarioAutenticado.Nome,
                UsuarioId = usuarioAutenticado.UsuarioId
            };

            return Ok(objRetorno);
        }
        #endregion
        #endregion
    }
}

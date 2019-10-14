using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SuperDigital.Dominio.Base.Excecoes;
using SuperDigital.Servico.Api.Modelos.ModeloVisao;
using SuperDigital.Servico.Api.ObjetosRetorno;

namespace SuperDigital.Servico.Api.Filtros
{
    /// <summary>
    /// Filtro responsavel por interceptar os erros ocorridos na aplicacao e trata-los
    /// </summary>
    public class FiltroErro : ExceptionFilterAttribute
    {
        #region |Membros|
        #region |Atributos|
        private readonly ILogger<FiltroErro> _logger;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de FiltroErro
        /// </summary>
        /// <param name="logger"></param>
        public FiltroErro(ILogger<FiltroErro> logger)
        {
            _logger = logger;
        }
        #endregion
        #region |Metodos|
        /// <summary>
        /// Acionada quando ocorrer um erro
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var coreError = context.Exception is ExcecaoDominio;
            var mvcController = context.ActionDescriptor.RouteValues["controller"];
            var mvcAction = context.ActionDescriptor.RouteValues["action"];
            var errorMessage = $"{context.Exception.Message}{context.Exception.InnerException?.Message}";

            var resultado = new ModeloVisaoRetorno<ModeloVisaoErro>
            {
                Mensagem = "Erro",
                Sucesso = false,
#if DEBUG
                ObjetoDeRetorno = new ModeloVisaoErro()
                {
                    Core = coreError,
                    Controller = mvcController,
                    Action = mvcAction,
                    Mensagem = errorMessage
                },
#else
                ObjetoDeRetorno = new ModeloVisaoErro()
                {
                    Core = false,
                    Controller = null,
                    Action = null,
                    Mensagem = "Erro"
                },
#endif
            };

            if (coreError)
                TratarExcecaoDominio((ExcecaoDominio)context.Exception, context, resultado);
            else
            {
                context.Result = new ErroInternoServidorObjectResult(resultado);
                _logger.LogError(context.Exception, "Erro interno");
            }
        }
        private static void TratarExcecaoDominio(ExcecaoDominio excecao, ExceptionContext ctx, ModeloVisaoRetorno<ModeloVisaoErro> retorno)
        {
            if (excecao is ExcecaoDominioObjetoNaoEncontrado)
                ctx.Result = new NaoEncontradoObjectResult(retorno);
            else if (excecao is ExcecaoDominioUsuarioNaoEncontrado)
                ctx.Result = new NaoAutorizadoObjectResult(retorno);
            else
                ctx.Result = new ConflitoObjectResult(retorno);
        }
        #endregion
        #endregion
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperDigital.Servico.Api.ObjetosRetorno
{
    /// <summary>
    /// Objeto de retorno quando o usuario nao for autorizado a realizar
    /// determinada tarefa
    /// </summary>
    public class NaoAutorizadoObjectResult : ObjectResult
    {
        #region |Membros|
        #region |Construtor|
        /// <summary>
        /// Construtor de NaoAutorizadoObjectResult
        /// </summary>
        /// <param name="value"></param>
        public NaoAutorizadoObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
        /// <summary>
        /// Construtor de NaoAutorizadoObjectResult
        /// </summary>
        public NaoAutorizadoObjectResult() : this(null)
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
        #endregion 
        #endregion
    }
}
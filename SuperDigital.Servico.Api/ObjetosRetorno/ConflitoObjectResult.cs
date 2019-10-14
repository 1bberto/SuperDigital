using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperDigital.Servico.Api.ObjetosRetorno
{
    /// <summary>
    /// Objeto de retorno quando um erro de negocio ocorre durante
    /// a solicitacao do usuario
    /// </summary>
    public class ConflitoObjectResult : ObjectResult
    {
        #region |Membros|
        #region |Construtor|
        /// <summary>
        /// Construtor de ConflitoObjectResult
        /// </summary>
        /// <param name="value"></param>
        public ConflitoObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status409Conflict;
        }
        /// <summary>
        /// Construtor de ConflitoObjectResult
        /// </summary>
        public ConflitoObjectResult() : this(null)
        {
            StatusCode = StatusCodes.Status409Conflict;
        }
        #endregion 
        #endregion
    }
}
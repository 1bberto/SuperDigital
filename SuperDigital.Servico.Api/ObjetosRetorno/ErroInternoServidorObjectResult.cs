using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperDigital.Servico.Api.ObjetosRetorno
{
    /// <summary>
    /// Objeto de retorno quando um erro occore dentro da aplicacao
    /// </summary>
    public class ErroInternoServidorObjectResult : ObjectResult
    {
        #region |Membros|
        #region |Construtor|
        /// <summary>
        /// Construtor de ErroInternoServidorObjectResult
        /// </summary>
        /// <param name="value"></param>
        public ErroInternoServidorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
        /// <summary>
        /// Construtor de ErroInternoServidorObjectResult
        /// </summary>
        public ErroInternoServidorObjectResult() : this(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
        #endregion 
        #endregion
    }
}
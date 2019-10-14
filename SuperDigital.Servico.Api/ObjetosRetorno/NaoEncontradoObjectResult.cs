using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperDigital.Servico.Api.ObjetosRetorno
{
    /// <summary>
    /// Objeto de retorno quando o que o usuario estiver solicitando nao for
    /// encontrado pelo sistema
    /// </summary>
    public class NaoEncontradoObjectResult : ObjectResult
    {
        #region |Membros|
        #region |Construtor|
        /// <summary>
        /// Construtor de NaoEncontradoObjectResult
        /// </summary>
        /// <param name="value"></param>
        public NaoEncontradoObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status404NotFound;
        }
        /// <summary>
        /// Construtor de NaoEncontradoObjectResult
        /// </summary>
        public NaoEncontradoObjectResult() : base(null)
        {
            StatusCode = StatusCodes.Status404NotFound;
        }
        #endregion 
        #endregion
    }
}
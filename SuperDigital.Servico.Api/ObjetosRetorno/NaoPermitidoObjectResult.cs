using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperDigital.Servico.Api.ObjetosRetorno
{
    /// <summary>
    /// Objeto de retorno quando usuario tenta acessar algo que o mesmo nao
    /// possui permissao
    /// </summary>
    public class NaoPermitidoObjectResult : ObjectResult
    {
        #region |Membros|
        #region |Construtor|
        /// <summary>
        /// Construtor de NaoPermitidoObjectResult
        /// </summary>
        /// <param name="value"></param>
        public NaoPermitidoObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
        /// <summary>
        /// Construtor de NaoPermitidoObjectResult
        /// </summary>
        public NaoPermitidoObjectResult() : this(null)
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
        #endregion 
        #endregion
    }
}
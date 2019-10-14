using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.Dominio.Base.Entidades;
using System.IdentityModel.Tokens.Jwt;

namespace SuperDigital.Servico.Api.Controllers
{
    /// <summary>
    /// Base que tem o objetivo de auxiliar na obtencao dos dados do usuario logado no sistema
    /// </summary>
    [EnableCors]
    public class BaseController : ControllerBase
    {
        #region |Membros|
        #region |Atributos|
        /// <summary>
        /// Codigo do usuario Logado
        /// </summary>
        protected string UsuarioId => User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
        /// <summary>
        /// Login do usuario logado
        /// </summary>
        protected string Login => User.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value;
        /// <summary>
        /// Nome do usuario Logado
        /// </summary>
        protected string Nome => User.Identity.Name;
        /// <summary>
        /// Entidade usuário logado <see cref="Dominio.Base.Entidades.Usuario"/>
        /// </summary>
        protected Usuario Usuario =>
            new Usuario
            {
                UsuarioId = UsuarioId,
                Login = Login,
                Nome = Nome
            };
        #endregion
        #endregion
    }
}

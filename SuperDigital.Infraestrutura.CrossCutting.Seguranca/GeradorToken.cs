using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Seguranca;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace SuperDigital.Infraestrutura.CrossCutting.Seguranca
{
    /// <summary>
    /// Classe para gerar tokens 
    /// </summary>
    public class GeradorToken : IGeradorToken
    {
        #region |Membros|
        #region |Atributos|
        private readonly ConfiguracaoToken _configuracaoToken;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor
        /// </summary>
        public GeradorToken(IOptions<ConfiguracaoToken> configuracaoToken)
        {
            _configuracaoToken = configuracaoToken.Value;
        }
        #endregion
        #region |Propriedades|
        #endregion
        #region |Metodos|
        /// <inheritdoc />
        public string GerarToken(Usuario usuario)
        {
            var identidade = new ClaimsIdentity(
            new GenericIdentity(usuario.Login, "Login"),
            new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, usuario.UsuarioId),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login),
                new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nome)
            });

            var dataCriacao = DateTime.Now;

            var dataExpiracao = dataCriacao + TimeSpan.FromDays(1);

            var handler = new JwtSecurityTokenHandler();

            var dadosToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _configuracaoToken.Issuer,
                Audience = _configuracaoToken.Audience,
                Subject = identidade,
                NotBefore = dataCriacao,
                Expires = dataExpiracao,

                SigningCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(
                                                Encoding.UTF8.GetBytes(_configuracaoToken.SigningKey)),
                                                SecurityAlgorithms.HmacSha256
                                            ),
            });

            var token = handler.WriteToken(dadosToken);

            return token;
        }
        #endregion
        #endregion
    }
}

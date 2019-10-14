using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuperDigital.Infraestrutura.CrossCutting.Seguranca;
using System;
using System.Text;

namespace SuperDigital.Servico.Api.Configuracoes
{
    /// <summary>
    /// ConfiguracaoAutenticacao
    /// </summary>
    public static class ConfiguracaoAutenticacao
    {
        #region |Membros|
        #region |Atributos|
        private static ConfiguracaoToken _configuracaoToken;
        #endregion
        #region |Metodos|
        /// <summary>
        /// Registrar os servicos referentes a autenticacao da aplicacao
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Registrar(IServiceCollection services, IConfiguration configuration)
        {
            _configuracaoToken = new ConfiguracaoToken();

            new ConfigureFromConfigurationOptions<ConfiguracaoToken>(
                    configuration.GetSection(nameof(ConfiguracaoToken)))
                .Configure(_configuracaoToken);

            services.AddSingleton(_configuracaoToken);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(bearrerOptions =>
                {
                    var parametrosValidacao = bearrerOptions.TokenValidationParameters;
                    parametrosValidacao.ValidateIssuerSigningKey = true;
                    parametrosValidacao.ValidateLifetime = true;
                    parametrosValidacao.ValidateActor = true;
                    parametrosValidacao.ValidateAudience = true;
                    parametrosValidacao.ValidAudience = _configuracaoToken.Audience;
                    parametrosValidacao.ValidIssuer = _configuracaoToken.Issuer;
                    parametrosValidacao.ClockSkew = TimeSpan.Zero;

                    parametrosValidacao.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracaoToken.SigningKey));
                });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });
            services.AddMemoryCache();
        }
        #endregion
        #endregion
    }
}
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SuperDigital.Servico.Api.Configuracoes
{
    /// <summary>
    /// ConfiguracaoSwagger
    /// </summary>
    public static class ConfiguracaoSwagger
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Realiza a configuracao do Swagger
        /// </summary>
        /// <param name="app"></param>
        public static void Registrar(IServiceCollection app)
        {
            app.AddSwaggerGen(options =>
            {
                AdicionarDocumentacao(options);

                options.OrderActionsBy((apiDesc) =>
                    $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");

                options.CustomSchemaIds(o => o.FullName);

                options.IncludeXmlComments(CaminhoComentarioXml, true);

                options.DescribeAllEnumsAsStrings();

                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Exemplo: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                options.AddSecurityRequirement(security);

                options.OperationFilter<GeradorDeIdsCustomizadosSwagger>();
            });
        }
        private static void AdicionarDocumentacao(SwaggerGenOptions options)
        {
            options.SwaggerDoc($"v1.0", new Info()
            {
                Title = $"SuperDigital",
                Version = "1.0",
                Description = "Microservico de Transacoes Bancarias",
                Contact = new Contact()
                {
                    Name = "Humberto Rodrigues",
                    Email = "humberto_henrique1@live.com",
                    Url = "https://www.linkedin.com/in/humbberto/"
                }
            });
        }
        static string CaminhoComentarioXml
        {
            get
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                return xmlPath;
            }
        }
        #endregion
        #endregion
    }
}
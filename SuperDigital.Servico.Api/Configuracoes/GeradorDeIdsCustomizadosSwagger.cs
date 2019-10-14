using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;

namespace SuperDigital.Servico.Api.Configuracoes
{
    /// <summary>
    /// Classe para gerar ids unicos para o swagger
    /// </summary>
    public class GeradorDeIdsCustomizadosSwagger : IOperationFilter
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Gera ids com base no verbo, caminho e metodo
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var novoNome = $"{context.ApiDescription.HttpMethod}.{Regex.Replace(context.ApiDescription.RelativePath, "\\W", "_")}".ToLower();
            novoNome = Regex.Replace(novoNome, "_{2,}", "_");
            novoNome = Regex.Replace(novoNome, "(_)(\\w)", delegate (Match m)
               {
                   return m.Groups[2].ToString().ToUpper();
               });

            operation.OperationId = Regex.Replace(novoNome, "_", "");
        }
        #endregion
        #endregion
    }
}
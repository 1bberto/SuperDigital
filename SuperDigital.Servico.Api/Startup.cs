using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SuperDigital.Infraestrutura.CrossCutting.IoC;
using SuperDigital.Servico.Api.Configuracoes;
using SuperDigital.Servico.Api.Filtros;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;

namespace SuperDigital
{
    /// <summary>
    /// Classde de Startup do projeto
    /// </summary>
    public class Startup
    {
        #region |Membros|
        #region |Atributos|
        private IConfiguration Configuration { get; }
        private const string Cultura = "pt-BR";
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion        
        #region |Metodos|
        /// <summary>
        /// Configurar Servicos
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddTransient<FiltroPerformance>();

            ConfiguracaoAutenticacao.Registrar(services, Configuration);

            ConfiguracaoMapeamento.Registrar(services);

            services.AdicionarApi(Configuration);

            var corsBuilder = new CorsPolicyBuilder()
                .WithExposedHeaders("content-disposition")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(corsBuilder.Build());
            });

            services.AddMvc(options =>
            {
                options.Filters.AddService<FiltroPerformance>();
                options.Filters.Add<FiltroErro>();
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.EscapeNonAscii;
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

#if (DEBUG == true)
            ConfiguracaoSwagger.Registrar(services);
#endif

        }
        /// <summary>
        /// Configura os servicos que vao rodar dentro do pipeline de request
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddConsole();
            }

            var culturas = new[]
            {
                new CultureInfo(Cultura),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(Cultura),
                SupportedCultures = culturas,
                SupportedUICultures = culturas
            });

#if (DEBUG == true)
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", $"v1.0");

                c.DocumentTitle = "SuperDigital";
                c.RoutePrefix = string.Empty;
                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
            });
#endif
            app.UseAuthentication();

            app.UseCors();

            app.UseMvc();
        }
        #endregion
        #endregion
    }
}

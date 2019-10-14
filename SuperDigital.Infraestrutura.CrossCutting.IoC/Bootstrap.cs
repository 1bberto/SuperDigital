using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperDigital.Aplicacao.Servicos;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Base.Interfaces.Seguranca;
using SuperDigital.Dominio.Base.Servicos;
using SuperDigital.Dominio.Compartilhado.Interface;
using SuperDigital.Infraestrutura.CrossCutting.Seguranca;
using SuperDigital.Infraestrutura.Dados.Persistencia;
using SuperDigital.Infraestrutura.Dados.Persistencia.Repositorio;
using System;
using System.Linq;

namespace SuperDigital.Infraestrutura.CrossCutting.IoC
{
    /// <summary>
    /// Classe para injecao de dependecias
    /// </summary>
    public static class Bootstrap
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Metodo para configurar as dependencias para a API
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuracao"></param>
        public static void AdicionarApi(this IServiceCollection services, IConfiguration configuracao)
        {
            services.AddScoped<IUnidadeTrabalho>(x => new UnidadeTrabalho(
                configuracao.GetSection("Configuracoes").GetSection("BancoDeDados").GetSection("Conexao").Value));

            //AppService
            RegistrarInterfaces(services, typeof(ServicoAplicacaoBase<Usuario>), "Aplicacao", "ServicoAplicacao");
            //Services
            RegistrarInterfaces(services, typeof(ServicoBase<Usuario>), "Servico", "Servico");
            //Repositorios
            RegistrarInterfaces(services, typeof(RepositorioBase<Usuario, string>), "Repositorio", "Repositorio");
            services.AddScoped(typeof(IRepositorioBase<,>), typeof(RepositorioBase<,>));

            services.Configure<ConfiguracaoToken>(configuracao.GetSection("ConfiguracaoToken"));
            services.AddScoped<IGeradorToken, GeradorToken>();
        }
        private static void RegistrarInterfaces(IServiceCollection servicos, Type tipo, string existeNoNamespace, string prefixo)
        {
            var types = tipo
                .Assembly
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                               type.Namespace.Contains(existeNoNamespace) &&
                               type.Name.StartsWith(prefixo) &&
                               !type.IsGenericType &&
                               type.IsClass &&
                               type.GetInterfaces().Any());

            foreach (var type in types)
            {
                var interfaceType = type
                    .GetInterfaces()?
                    .FirstOrDefault(t => t.Name == $"I{type.Name}");

                if (interfaceType == null)
                    continue;

                if (servicos.ToList().Any(x => x.ServiceType == interfaceType)) continue;

                servicos.AddScoped(interfaceType, type);
            }
        }
        #endregion
        #endregion
    }
}

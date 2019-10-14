using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SuperDigital.Servico.Api.Modelos.ModeloVisao;
using SuperDigital.Servico.Api.Modelos.VisaoModelo;
using SuperDigital.Utilitarios;
using System;
using System.Linq;
using System.Reflection;

namespace SuperDigital.Servico.Api.Configuracoes
{
    /// <summary>
    /// ConfiguracaoMapeamento
    /// </summary>
    public static class ConfiguracaoMapeamento
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Registrar os servicos referentes a mapeamento da aplicacao
        /// </summary>
        /// <param name="services"></param>
        public static void Registrar(IServiceCollection services)
        {
            var configuracaoMapeamento = new MapperConfiguration(x =>
            {
                RegistrarPerfisMapeamentos(x);
                CriarMapeamentosAutomaticos(x);
            });

            var mapeamento = configuracaoMapeamento.CreateMapper();

            services.AddSingleton(mapeamento);
        }

        private static void CriarMapeamentosAutomaticos(IMapperConfigurationExpression mc)
        {
            //mapeamento das viewModels tipadas
            typeof(IModeloVisao<>).Assembly.GetTypes()?.ToList().Where(vm =>
                    vm.PossuiImplementado(typeof(IModeloVisao<>)) && !vm.IsAbstract && !vm.IsInterface
                )
                .Where(vm =>
                    !JaMapeadoNoProfile(mc, vm.GetInterface(typeof(IModeloVisao<>).Name).GetGenericArguments()[0], vm)
                    )
                .ToList()
                .ForEach(vm =>
                {
                    mc.CreateMap(vm.GetInterface(typeof(IModeloVisao<>).Name).GetGenericArguments()[0], vm);
                });
            //mapeamento das viewModels tipadas
            typeof(IVisaoModelo<>).Assembly.GetTypes()?.ToList().Where(vm =>
                    vm.PossuiImplementado(typeof(IVisaoModelo<>)) && !vm.IsAbstract && !vm.IsInterface
                ).Where(vm =>
                    !JaMapeadoNoProfile(mc, vm, vm.GetInterface(typeof(IVisaoModelo<>).Name).GetGenericArguments()[0])
                    )
                .ToList()
                .ForEach(vm =>
                {
                    mc.CreateMap(vm, vm.GetInterface(typeof(IVisaoModelo<>).Name).GetGenericArguments()[0]);
                });
        }
        /// <summary>
        /// Registrar perfis de mapeamento automaticamente
        /// </summary>
        /// <param name="mc"></param>
        private static void RegistrarPerfisMapeamentos(IMapperConfigurationExpression mc)
        {
            mc.AddProfiles(Assembly.GetExecutingAssembly());
        }
        /// <summary>
        /// Metodo para varificar se o mapeamento ja foi feito em algum profile
        /// </summary>
        /// <param name="mc"></param>
        /// <param name="origem"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        private static bool JaMapeadoNoProfile(IMapperConfigurationExpression mc, Type origem, Type destino)
        {
            return ((AutoMapper.Configuration.MapperConfigurationExpression)mc)
                .Profiles
                .SelectMany(x => x.TypeMapConfigs)
                .Any(x => x.SourceType == origem && x.DestinationType == destino);
        }

        #endregion
        #endregion
    }
}
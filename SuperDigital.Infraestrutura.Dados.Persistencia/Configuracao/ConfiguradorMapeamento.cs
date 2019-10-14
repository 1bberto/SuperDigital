using Dapper;
using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Utilitarios;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace SuperDigital.Infraestrutura.Dados.Persistencia.Configuracao
{
    /// <summary>
    /// Configurador da Persistencia, responsavel por realizar o mapeamento
    /// das propriedades das entidades
    /// </summary>
    public class ConfiguradorMapeamento
    {
        #region |Membros|
        #region |Atributos|
        private static bool _configurado;
        #endregion
        #region |Metodos|
        /// <summary>
        /// Registra os mapeamentos
        /// </summary>
        public static void RegistrarModelos()
        {
            if (_configurado) return;
            var tipoPadrao = typeof(EntidadeBase);
            var entitidades = tipoPadrao
                .Assembly
                .GetTypes()
                .Where(type => type.Namespace != null &&
                               (type.GetCustomAttribute<TableAttribute>() != null ||
                               type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Any(x => Attribute.IsDefined(x, typeof(ColumnAttribute)))
                                ) &&
                               !type.IsGenericType && type.IsClass).ToList();
            entitidades.ForEach(type =>
            {
                var typeName = type.ToString();
                dynamic typeMap =
                    Activator.CreateInstance(typeof(MapaColunaTipoAtributo<>).MakeGenericType(type));
                SqlMapper.SetTypeMap(type, typeMap);
            });
            _configurado = true;

            typeof(ConfiguradorMapeamento).Assembly.GetTypes().Where(x =>
                x.PossuiImplementado(typeof(SqlMapper.TypeHandler<>)) && !x.IsAbstract
            ).ToList().ForEach(x =>
            {
                var handler = Activator.CreateInstance(x);
                SqlMapper.AddTypeHandler(x.BaseType.GenericTypeArguments[0], (SqlMapper.ITypeHandler)handler);
            });
        }
        #endregion
        #endregion
    }
}

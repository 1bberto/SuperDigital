using Dapper;
using System;
using System.Linq;
using System.Reflection;

namespace SuperDigital.Infraestrutura.Dados.Persistencia.Configuracao
{
    /// <summary>
    /// Mapeamento das colunas das tabelas com as propriedades
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MapaColunaTipoAtributo<T> : MapeadorTipo
    {
        #region |Membros|
        #region |Atributos|
        private static readonly string _columnAttributeName = "ColumnAttribute";
        #endregion
        /// <summary>
        /// Construtor MapaColunaTipoAtributo
        /// </summary>
        #region |Construtor|
        public MapaColunaTipoAtributo() : base(new SqlMapper.ITypeMap[]
            {
                new CustomPropertyTypeMap(typeof (T), SelecionarPropriedade),
                new DefaultTypeMap(typeof (T))
            })
        { }
        #endregion
        #region |Metodos|
        private static PropertyInfo SelecionarPropriedade(Type tipo, string nomeColuna)
        {
            var propertyInfo = tipo.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(
                prop =>
                    prop.GetCustomAttributes(false)
                        .Any(attr => attr.GetType().Name == _columnAttributeName
                                     &&
                                     attr.GetType().GetProperties(BindingFlags.Public |
                                                                  BindingFlags.NonPublic |
                                                                  BindingFlags.Instance)
                                         .Any(
                                             f =>
                                                 f.Name == "Name" &&
                                                 f.GetValue(attr).ToString().ToLower() == nomeColuna.ToLower()))
                    &&
                    (prop.DeclaringType == tipo
                        ? prop.GetSetMethod(true)
                        : prop.DeclaringType.GetProperty(prop.Name,
                            BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.Instance).GetSetMethod(true)) != null
            );

            return propertyInfo;
        }
        #endregion
        #endregion
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SuperDigital.Infraestrutura.Dados.Persistencia.Configuracao
{
    /// <summary>
    /// Classe de Auxilio no mapeamento das entidades com as tabelas do banco de dados
    /// </summary>
    public class MapeadorTipo : SqlMapper.ITypeMap
    {
        #region |Membros|
        #region |Atributos|
        private readonly IEnumerable<SqlMapper.ITypeMap> _mappers;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de FallbackTypeMapper
        /// </summary>
        /// <param name="mappers"></param>
        public MapeadorTipo(IEnumerable<SqlMapper.ITypeMap> mappers)
        {
            _mappers = mappers;
        }
        #endregion
        #region |Metodos|
        /// <summary>
        /// Retorna as informacoes do Construtor
        /// </summary>
        /// <param name="names"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var resultado = mapper.FindConstructor(names, types);
                    if (resultado != null)
                        return resultado;
                }
                catch (NotImplementedException)
                {
                }
            }
            return null;
        }
        /// <summary>
        /// Retorna as informacoes do construtor
        /// </summary>
        /// <returns></returns>
        public ConstructorInfo FindExplicitConstructor()
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var resultado = mapper.FindExplicitConstructor();
                    if (resultado != null)
                        return resultado;
                }
                catch (NotImplementedException)
                {
                }
            }
            return null;
        }
        /// <summary>
        /// Obtem os parametros do construtor
        /// </summary>
        /// <param name="constructor"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var resultado = mapper.GetConstructorParameter(constructor, columnName);
                    if (resultado != null)
                        return resultado;
                }
                catch (NotImplementedException)
                {
                }
            }
            return null;
        }
        /// <summary>
        /// Retorna membro
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var resultado = mapper.GetMember(columnName);
                    if (resultado != null)
                        return resultado;
                }
                catch (NotImplementedException)
                {
                }
            }
            return null;
        }
        #endregion
        #endregion
    }
}

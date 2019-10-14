using System;
using System.Linq;

namespace SuperDigital.Utilitarios
{
    /// <summary>
    /// ExtensoesAtribuiveis
    /// </summary>
    public static class ExtensoesAtribuiveis
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Verifica se o tipo <paramref name="tipo"/> possui o tipo
        /// <paramref name="tipoGenerico"/> implementado
        /// </summary>
        public static bool PossuiImplementado(this Type tipo, Type tipoAtribuido)
        {
            if (tipo == null || tipoAtribuido == null)
                return false;

            return tipo == tipoAtribuido
                   || tipo.PossuiDefinicao(tipoAtribuido)
                   || tipo.PossuiInterface(tipoAtribuido)
                   || tipo.BaseType.PossuiImplementado(tipoAtribuido);
        }

        private static bool PossuiInterface(this Type tipo, Type interfaceImplementada)
        {
            return tipo
                .GetInterfaces()
                .Where(it => it.IsGenericType)
                .Any(it => it.GetGenericTypeDefinition() == interfaceImplementada);
        }

        private static bool PossuiDefinicao(this Type tipo, Type definicao)
        {
            return definicao.IsGenericTypeDefinition
                   && tipo.IsGenericType
                   && tipo.GetGenericTypeDefinition() == definicao;
        }
        #endregion
        #endregion
    }
}

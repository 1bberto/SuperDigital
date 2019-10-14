using SuperDigital.Dominio.Base.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interface.Repositorio.Generico
{
    /// <summary>
    /// Interface generica de Obter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IObter<T, in TId>
        where T : EntidadeBase
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Obtem uma Entidade pelo Id
        /// </summary>
        /// <param name="entidadeId"></param>
        /// <returns></returns>
        Task<T> ObterPorIdAssincrono(TId entidadeId);
        /// <summary>
        /// Obtem todas entidades
        /// </summary>        
        /// <returns></returns>
        Task<IList<T>> ObterTodosAssincrono();
        #endregion
        #endregion
    }
}
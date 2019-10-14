using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interface.Repositorio.Generico
{
    /// <summary>
    /// Interface generica de Apagar
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IApagar<in TId>
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Apaga uma Entidade
        /// </summary>
        /// <param name="entidadeId"></param>
        /// <returns></returns>
        Task ApagarAssincrono(TId entidadeId);
        #endregion 
        #endregion
    }
}
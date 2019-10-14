using SuperDigital.Dominio.Base.Entidades;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interface.Repositorio.Generico
{
    /// <summary>
    /// Interface generica de Atualizar
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAtualizar<in T> where T : EntidadeBase
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Atualiza uma Entidade
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        Task AtualizarAssincrono(T entidade);
        #endregion 
        #endregion
    }
}
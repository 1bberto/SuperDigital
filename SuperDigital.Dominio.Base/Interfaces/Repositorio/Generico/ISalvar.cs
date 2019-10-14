using SuperDigital.Dominio.Base.Entidades;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interface.Repositorio.Generico
{
    /// <summary>
    /// Interface generica de Salvar
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISalvar<in T> where T : EntidadeBase
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Salva uma Entidade
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        Task SalvarAssincrono(T entidade);
        #endregion 
        #endregion
    }
}

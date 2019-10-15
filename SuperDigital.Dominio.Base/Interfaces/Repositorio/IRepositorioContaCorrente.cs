using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interface.Repositorio.Generico;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interfaces.Repositorio
{
    /// <summary>
    /// Repositorio da entidade <see cref="ContaCorrente"/>
    /// </summary>
    public interface IRepositorioContaCorrente : IRepositorioBase<ContaCorrente, string>, ISalvar<ContaCorrente>
    {
        #region |Membros|
        #region |Atributos|
        /// <summary>
        /// Busca conta corrente pelo codigo
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        /// <returns>conta corrente <see cref="ContaCorrente"/></returns>
        Task<ContaCorrente> BuscarContaCorrenteAssincrono(string codigo);
        #endregion
        #endregion
    }
}

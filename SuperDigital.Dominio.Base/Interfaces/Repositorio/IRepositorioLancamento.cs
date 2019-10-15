using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interface.Repositorio.Generico;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interfaces.Repositorio
{
    /// <summary>
    /// Repositorio da entidade <see cref="Lancamento"/>
    /// </summary>
    public interface IRepositorioLancamento : IRepositorioBase<Lancamento, string>, ISalvar<Lancamento>
    {
        #region |Membros|
        #region |Atributos|
        /// <summary>
        /// Busca todos os lancamentos de uma conta corrente
        /// </summary>
        /// <param name="contaCorrente">conta corrente</param>
        /// <returns>lancamentos <see cref="Lancamento"/></returns>
        Task<List<Lancamento>> BuscarLancamentosContaCorrenteAssincrono(ContaCorrente contaCorrente);
        #endregion
        #endregion
    }
}

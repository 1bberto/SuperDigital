using SuperDigital.Dominio.Base.Entidades;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Interfaces.Servico
{
    /// <summary>
    /// Servico da entidade <see cref="ContaCorrente"/>
    /// </summary>
    public interface IServicoContaCorrente : IServicoBase<ContaCorrente>
    {
        #region |Membros|
        #region |Atributos|
        /// <summary>
        /// Criar uma nova conta corrente
        /// </summary>
        /// <param name="contaCorrente"></param>
        /// <returns></returns>
        Task<ContaCorrente> AdicionarContaCorrenteAssincrono(ContaCorrente contaCorrente);
        /// <summary>
        /// Busca usuario pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Task<Usuario> BuscarContaCorrenteAssincrono(string codigo);
        #endregion
        #endregion
    }
}

using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interface.Repositorio.Generico;

namespace SuperDigital.Dominio.Base.Interfaces.Repositorio
{
    /// <summary>
    /// Interface de Repositorio Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IRepositorioBase<T, TId>
        : IObterUnidadeTrabalho,
        IObter<T, TId>,
        IApagar<TId> where T : EntidadeBase
    {
        #region |Membros|
        #region |Metodos|
        #endregion 
        #endregion
    }
}

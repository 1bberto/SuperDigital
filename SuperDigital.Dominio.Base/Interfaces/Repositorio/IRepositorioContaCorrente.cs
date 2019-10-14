using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Interface.Repositorio.Generico;

namespace SuperDigital.Dominio.Base.Interfaces.Repositorio
{
    /// <summary>
    /// Repositorio da entidade <see cref="ContaCorrente"/>
    /// </summary>
    public interface IRepositorioContaCorrente : IRepositorioBase<ContaCorrente, string>, ISalvar<ContaCorrente>
    {
    }
}

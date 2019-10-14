using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Dominio.Base.Interfaces.Servico
{
    /// <summary>
    /// Interface de Servico Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IServicoBase<T> where T : EntidadeBase
    {
    }
}

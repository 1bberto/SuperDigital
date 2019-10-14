using SuperDigital.Aplicacao.Interfaces;
using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Aplicacao.Servicos
{
    /// <summary>
    /// Classe base de Aplicacao
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServicoAplicacaoBase<T> : IServicoAplicacaoBase<T> where T : EntidadeBase
    {
    }
}

using SuperDigital.Dominio.Compartilhado.Interface;

namespace SuperDigital.Dominio.Base.Interface.Repositorio.Generico
{
    /// <summary>
    /// Interface Para Obter Unidade de Trabalho
    /// </summary>
    public interface IObterUnidadeTrabalho
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// Obtem a unidade de trabalho
        /// </summary>
        /// <returns></returns>
        IUnidadeTrabalhoBase ObterUnidadeTrabalho();
        #endregion 
        #endregion
    }
}
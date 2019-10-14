using SuperDigital.Dominio.Base.Entidades;

namespace SuperDigital.Dominio.Base.Servicos
{
    /// <summary>
    /// Classe base de Servico
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServicoBase<T> where T : EntidadeBase, new()
    {
        #region |Membros|
        #region |Atributos|
        #endregion
        #region |Construtor|
        /// <summary>
        /// Construtor de ServicoBase
        /// </summary>        
        protected ServicoBase()
        {
        }
        #endregion
        #endregion
    }
}

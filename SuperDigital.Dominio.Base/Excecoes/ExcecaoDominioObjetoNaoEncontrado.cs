namespace SuperDigital.Dominio.Base.Excecoes
{
    /// <summary>
    /// Tipo de Excessao ExcecaoDominioObjetoNaoEncontrado
    /// </summary>
    public class ExcecaoDominioObjetoNaoEncontrado : ExcecaoDominio
    {
        #region |Membros|
        #region |Construtor|
        /// <summary>
        /// Construtor de ExcecaoDominioObjetoNaoEncontrado
        /// </summary>
        /// <param name="message"></param>
        public ExcecaoDominioObjetoNaoEncontrado(string message) : base(message)
        { }
        #endregion 
        #endregion
    }
}
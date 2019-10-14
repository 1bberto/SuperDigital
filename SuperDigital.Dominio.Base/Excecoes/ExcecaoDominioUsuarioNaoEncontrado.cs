namespace SuperDigital.Dominio.Base.Excecoes
{
    /// <summary>
    /// Tipo de Excessao ExcecaoDominioUsuarioNaoEncontrado
    /// </summary>
    public class ExcecaoDominioUsuarioNaoEncontrado : ExcecaoDominio
    {
        #region |Membros|
        #region |Construtor|
        /// <summary>
        /// Construtor de ExcecaoDominioUsuarioNaoEncontrado
        /// </summary>
        public ExcecaoDominioUsuarioNaoEncontrado() : base("Usuário ou senha incorretos")
        { }
        #endregion 
        #endregion
    }
}

namespace SuperDigital.Dominio.Base.Entidades
{
    /// <summary>
    /// Entidade Usuario
    /// </summary>
    public class Usuario : EntidadeBase
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// UsuarioId
        /// </summary>
        public string UsuarioId { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }
        #endregion
        #endregion
    }
}

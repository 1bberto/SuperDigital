namespace SuperDigital.Infraestrutura.CrossCutting.Seguranca
{
    /// <summary>
    /// ConfiguracaoToken
    /// </summary>
    public class ConfiguracaoToken
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// Audience
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// ExpireIn
        /// </summary>
        public int ExpireIn { get; set; }
        /// <summary>
        /// SigningKey
        /// </summary>
        public string SigningKey { get; set; }
        #endregion
        #endregion
    }
}

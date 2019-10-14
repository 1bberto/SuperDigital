namespace SuperDigital.Servico.Api.Modelos.ModeloVisao
{
    /// <summary>
    /// Base de ModeloVisaoRetorno
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModeloVisaoRetorno<T> where T : class, new()
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// Sucesso
        /// </summary>
        public bool Sucesso { get; set; } = true;
        /// <summary>
        /// Mensagem
        /// </summary>
        public string Mensagem { get; set; } = null;
        /// <summary>
        /// TempoDeProcessamento
        /// </summary>
        public long TempoDeProcessamento { get; set; } = 0;
        /// <summary>
        /// ObjetoDeRetorno
        /// </summary>
        public T ObjetoDeRetorno { get; set; } = new T();
        #endregion
        #endregion
    }
}
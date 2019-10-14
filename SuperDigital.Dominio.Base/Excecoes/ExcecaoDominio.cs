using System;

namespace SuperDigital.Dominio.Base.Excecoes
{
    /// <summary>
    /// Classe de Excecao do Dominio
    /// </summary>
    public class ExcecaoDominio : Exception
    {
        #region |Membros|
        #region |Construtor| 
        /// <summary>
        /// Construtor de ExcecaoDominio
        /// </summary>
        /// <param name="message"></param>
        public ExcecaoDominio(string message) : base(message)
        {
        }
        #endregion 
        #endregion
    }
}
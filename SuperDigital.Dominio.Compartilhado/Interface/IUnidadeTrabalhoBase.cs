using System;
using System.Data;

namespace SuperDigital.Dominio.Compartilhado.Interface
{
    /// <summary>
    /// Interface de Unidade de Trabalho Base
    /// </summary>
    public interface IUnidadeTrabalhoBase : IDisposable
    {
        #region |Membros|
        #region |Metodos|
        /// <summary>
        /// IniciarTransacao
        /// </summary>
        void IniciarTransacao();
        /// <summary>
        /// ConfirmarTransacao
        /// </summary>
        void ConfirmarTransacao();
        /// <summary>
        /// ReverterTransacao
        /// </summary>
        void ReverterTransacao();
        /// <summary>
        /// ObterConexao
        /// </summary>
        /// <returns></returns>
        IDbConnection ObterConexao();
        /// <summary>
        /// ObterTransacao
        /// </summary>
        /// <returns></returns>
        IDbTransaction ObterTransacao();
        #endregion 
        #endregion
    }
}

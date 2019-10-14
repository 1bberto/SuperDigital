using System;

namespace SuperDigital.Dominio.Base.Entidades
{
    /// <summary>
    /// Entidade Base
    /// </summary>
    public abstract class EntidadeBase
    {
        #region |Membros|
        #region |Propriedades|
        /// <summary>
        /// Data de Inclusao do Registro
        /// </summary>
        public virtual DateTime DataInclusaoRegistro { get; set; }
        #endregion
        #endregion
    }
}

using SuperDigital.Dominio.Compartilhado.Interface;

namespace SuperDigital.Infraestrutura.Dados.Persistencia
{
    /// <summary>
    /// UnidadeTrabalhoCorban
    /// </summary>
    public class UnidadeTrabalho : UnidadeTrabalhoBase, IUnidadeTrabalho
    {
        #region |Membros|
        #region |Construtor|
        /// <inheritdoc />
        public UnidadeTrabalho(string conexaoBanco) : base(conexaoBanco)
        {
        }
        #endregion
        #endregion
    }
}

using SuperDigital.Dominio.Compartilhado.Interface;
using SuperDigital.Infraestrutura.Dados.Persistencia.Configuracao;
using System.Data;
using System.Data.SqlClient;

namespace SuperDigital.Infraestrutura.Dados.Persistencia
{
    /// <inheritdoc />
    public abstract class UnidadeTrabalhoBase : IUnidadeTrabalhoBase
    {
        #region |Membros|
        #region |Atributos|
        private readonly string _conexaoBanco;
        private IDbConnection _conexao;
        private IDbTransaction _transacao;
        #endregion
        #region |Construtor|
        /// <inheritdoc />
        protected UnidadeTrabalhoBase(string conexaoBanco)
        {
            _conexaoBanco = conexaoBanco;
            ConfiguradorMapeamento.RegistrarModelos();
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />
        public void IniciarTransacao()
        {
            if (_conexao == null) CriarConexao();
            _transacao = _conexao.BeginTransaction();
        }
        /// <inheritdoc />
        public void ConfirmarTransacao()
        {
            _transacao?.Commit();
            _transacao = null;
        }
        /// <inheritdoc />
        public void ReverterTransacao()
        {
            _transacao?.Rollback();
            _transacao = null;
        }
        /// <inheritdoc />
        public IDbConnection ObterConexao()
        {
            if (_conexao == null) CriarConexao();
            return _conexao;
        }
        /// <inheritdoc />
        public IDbTransaction ObterTransacao()
        {
            return _transacao;
        }
        /// <inheritdoc />
        private void CriarConexao()
        {
            _conexao = new SqlConnection(_conexaoBanco);
            _conexao.Open();
        }
        /// <inheritdoc />
        public void Dispose()
        {
            _transacao?.Dispose();
            _conexao?.Dispose();
        }
        #endregion
        #endregion
    }
}

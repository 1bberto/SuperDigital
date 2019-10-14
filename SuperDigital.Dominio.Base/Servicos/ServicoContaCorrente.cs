using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Excecoes;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Base.Interfaces.Servico;
using System;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Servicos
{
    /// <inheritdoc />  
    public class ServicoContaCorrente : ServicoBase<ContaCorrente>, IServicoContaCorrente
    {
        #region |Membros|
        #region |Atributos|
        private readonly IRepositorioContaCorrente _repositorio;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Contrutor de ServicoContaCorrente
        /// </summary>
        /// <param name="repositorio"></param>
        public ServicoContaCorrente(IRepositorioContaCorrente repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />  
        public async Task<ContaCorrente> AdicionarContaCorrenteAssincrono(ContaCorrente contaCorrente)
        {
            GerarCodigoContaCorrente(contaCorrente);

            ValidarCadastroContaCorrente(contaCorrente);

            await _repositorio.SalvarAssincrono(contaCorrente);

            VerificarContaCorrenteCadastrada(contaCorrente);

            return contaCorrente;
        }
        /// <summary>
        /// Verifica se a conta corrente foi cadastrada com sucesso
        /// </summary>
        /// <param name="contaCorrente"></param>
        public bool VerificarContaCorrenteCadastrada(ContaCorrente contaCorrente)
        {
            if (contaCorrente == null)
                throw new ExcecaoDominio($"{nameof(contaCorrente)} nulo");

            if (string.IsNullOrEmpty(contaCorrente.ContaCorrenteId))
                throw new ExcecaoDominio($"{nameof(contaCorrente.ContaCorrenteId)} em branco");

            if (string.IsNullOrEmpty(contaCorrente.Codigo))
                throw new ExcecaoDominio($"{nameof(contaCorrente.Codigo)} em branco");

            return true;
        }
        /// <summary>
        /// Gera codigo da conta Corrente
        /// </summary>
        /// <param name="contaCorrente"></param>
        /// <returns></returns>
        public bool GerarCodigoContaCorrente(ContaCorrente contaCorrente)
        {
            if (contaCorrente == null)
                throw new ExcecaoDominio($"{nameof(contaCorrente)} nulo");

            contaCorrente.Codigo = Guid.NewGuid().ToString().Split('-')[0];

            return true;
        }
        /// <summary>
        /// Valida o conta corrente para efetuar cadastro
        /// </summary>
        /// <param name="contaCorrente"></param>
        /// <returns></returns>
        public bool ValidarCadastroContaCorrente(ContaCorrente contaCorrente)
        {
            if (contaCorrente == null)
                throw new ExcecaoDominio($"{nameof(contaCorrente)} nulo");

            if (string.IsNullOrEmpty(contaCorrente.Codigo))
                throw new ExcecaoDominio($"{nameof(contaCorrente.Codigo)} em branco");

            return true;
        }
        /// <inheritdoc />  
        public Task<Usuario> BuscarContaCorrenteAssincrono(string codigo)
        {
            throw new System.NotImplementedException();
        }
        #endregion
        #endregion
    }
}

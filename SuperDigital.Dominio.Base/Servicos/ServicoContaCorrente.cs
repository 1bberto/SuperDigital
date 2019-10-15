using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Excecoes;
using SuperDigital.Dominio.Base.Interfaces.Repositorio;
using SuperDigital.Dominio.Base.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Base.Servicos
{
    /// <inheritdoc />  
    public class ServicoContaCorrente : ServicoBase<ContaCorrente>, IServicoContaCorrente
    {
        #region |Membros|
        #region |Atributos|
        private readonly IRepositorioContaCorrente _repositorio;
        private readonly IRepositorioLancamento _repositorioLancamento;
        #endregion
        #region |Construtor|
        /// <summary>
        /// Contrutor de ServicoContaCorrente
        /// </summary>
        /// <param name="repositorio"></param>
        /// <param name="repositorioLancamento"></param>
        public ServicoContaCorrente(
            IRepositorioContaCorrente repositorio,
            IRepositorioLancamento repositorioLancamento)
        {
            _repositorio = repositorio;
            _repositorioLancamento = repositorioLancamento;
        }
        #endregion
        #region |Metodos|
        /// <inheritdoc />  
        public async Task<ContaCorrente> AdicionarContaCorrenteAssincrono()
        {
            var contaCorrente = new ContaCorrente();

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

            var aleatorio = new Random();

            contaCorrente.Codigo = aleatorio.Next(0, 99999).ToString().PadLeft(5);

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
        public async Task<ContaCorrente> BuscarContaCorrenteAssincrono(string codigo)
        {
            ValidarBuscaContaCorrente(codigo);

            var contaCorrente = await _repositorio.BuscarContaCorrenteAssincrono(codigo);

            ValidarBuscaEfetuadaContaCorrente(contaCorrente, codigo);

            return contaCorrente;
        }
        /// <summary>
        /// Valida se a busca do usuario
        /// </summary>
        /// <param name="contaCorrente"></param>
        /// <param name="codigo"></param>
        /// <returns></returns>
        private bool ValidarBuscaEfetuadaContaCorrente(ContaCorrente contaCorrente, string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ExcecaoDominio($"{nameof(codigo)} em branco");

            if (contaCorrente == null)
                throw new ExcecaoDominioObjetoNaoEncontrado($"Conta corrente - {codigo} nao encontrada");

            return true;
        }
        /// <summary>
        /// Valida filtro para busca de conta correntes
        /// </summary>
        /// <param name="codigo">codigo da conta corrente</param>
        public bool ValidarBuscaContaCorrente(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ExcecaoDominio($"{nameof(codigo)} em branco");

            return true;
        }
        /// <inheritdoc />  
        public async Task<ContaCorrente> BuscarExtratoContaCorrenteAssincrono(string codigo)
        {
            var contaCorrente = await BuscarContaCorrenteAssincrono(codigo);

            var contasCorrentes = await _repositorio.ObterTodosAssincrono();

            contaCorrente.Lancamentos = await _repositorioLancamento.BuscarLancamentosContaCorrenteAssincrono(contaCorrente);

            ValidarLancamentos(contaCorrente.Lancamentos);

            foreach (var lancamento in contaCorrente.Lancamentos)
            {
                lancamento.ContaCorrenteOrigem = contasCorrentes.FirstOrDefault(x => x.ContaCorrenteId == lancamento.ContaCorrenteOrigemId);
                lancamento.ContaCorrenteDestino = contasCorrentes.FirstOrDefault(x => x.ContaCorrenteId == lancamento.ContaCorrenteDestinoId);
            }

            return contaCorrente;
        }
        /// <summary>
        /// Valida os lancamentos de uma conta corrente
        /// </summary>
        /// <param name="lancamentos">lancamentos</param>
        /// <returns></returns>
        public bool ValidarLancamentos(List<Lancamento> lancamentos)
        {
            if (lancamentos == null || !lancamentos.Any())
                throw new ExcecaoDominioObjetoNaoEncontrado("Conta corrente nao possui nenhum lancamenento");

            return true;
        }
        /// <inheritdoc />  
        public async Task EfetuarDepositoCaixaContaCorrenteAssincrono(string codigo, decimal valor)
        {
            ValidarDeposito(codigo, valor);

            var contaCorrente = await BuscarContaCorrenteAssincrono(codigo);

            var envio = new Lancamento()
            {
                TipoLancamento = Enum.TipoLancamento.Credito,
                Valor = valor,
                ContaCorrenteDestinoId = contaCorrente.ContaCorrenteId
            };

            ValidarLancamentoDeposito(envio);

            var retirada = new Lancamento()
            {
                TipoLancamento = Enum.TipoLancamento.Debito,
                Valor = valor,
                ContaCorrenteOrigemId = contaCorrente.ContaCorrenteId
            };

            ValidarLancamentoSaque(retirada);

            await _repositorioLancamento.SalvarAssincrono(envio);

            await _repositorioLancamento.SalvarAssincrono(retirada);
        }
        /// <summary>
        /// Valida lancamento para deposito
        /// </summary>
        /// <param name="novoLancamento"></param>
        public bool ValidarLancamentoDeposito(Lancamento novoLancamento)
        {
            if (novoLancamento == null)
                throw new ExcecaoDominio($"{nameof(novoLancamento)} nulo");

            if (novoLancamento.TipoLancamento != Enum.TipoLancamento.Credito)
                throw new ExcecaoDominio($"{nameof(novoLancamento.TipoLancamento)} deve ser {Enum.TipoLancamento.Credito}");

            if (novoLancamento.Valor <= 0)
                throw new ExcecaoDominio($"{nameof(novoLancamento.Valor)} deve ser maior que zero");

            return true;
        }
        /// <summary>
        /// Valida lancamento para deposito
        /// </summary>
        /// <param name="novoLancamento"></param>
        public bool ValidarLancamentoSaque(Lancamento novoLancamento)
        {
            if (novoLancamento == null)
                throw new ExcecaoDominio($"{nameof(novoLancamento)} nulo");

            if (novoLancamento.TipoLancamento != Enum.TipoLancamento.Debito)
                throw new ExcecaoDominio($"{nameof(novoLancamento.TipoLancamento)} deve ser {Enum.TipoLancamento.Credito}");

            if (novoLancamento.Valor <= 0)
                throw new ExcecaoDominio($"{nameof(novoLancamento.Valor)} deve ser maior que zero");

            return true;
        }
        /// <summary>
        /// Valida depositorio em conta corrente
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool ValidarDeposito(string codigo, decimal valor)
        {
            ValidarBuscaContaCorrente(codigo);

            if (valor <= 0)
                throw new ExcecaoDominio($"{nameof(valor)} deve ser maior que zero");

            return true;
        }
        /// <inheritdoc />  
        public async Task EfetuarSaqueCaixaContaCorrenteAssincrono(string codigo, decimal valor)
        {
            ValidarSaque(codigo, valor);

            var contaCorrente = await BuscarContaCorrenteAssincrono(codigo);

            contaCorrente.Lancamentos = await _repositorioLancamento.BuscarLancamentosContaCorrenteAssincrono(contaCorrente);

            ValidarValorSaque(contaCorrente, valor);

            var retirada = new Lancamento()
            {
                TipoLancamento = Enum.TipoLancamento.Debito,
                Valor = valor,
                ContaCorrenteDestinoId = contaCorrente.ContaCorrenteId,
            };

            ValidarLancamentoSaque(retirada);

            var envio = new Lancamento()
            {
                TipoLancamento = Enum.TipoLancamento.Credito,
                Valor = valor,
                ContaCorrenteOrigemId = contaCorrente.ContaCorrenteId,
            };

            ValidarLancamentoDeposito(envio);

            await _repositorioLancamento.SalvarAssincrono(retirada);

            await _repositorioLancamento.SalvarAssincrono(envio);
        }
        /// <summary>
        /// Valida se o valor de saque é permitido para conta corrente
        /// </summary>
        /// <param name="contaCorrenteOrigem">conta corrente</param>
        /// <param name="valor">valor a ser sacado</param>
        /// <returns></returns>
        public bool ValidarValorSaque(ContaCorrente contaCorrenteOrigem, decimal valor)
        {
            if (contaCorrenteOrigem.Saldo >= valor)
                return true;

            throw new ExcecaoDominio($"Conta {contaCorrenteOrigem.Codigo} nao possui saldo suficiente para montante solicitado para saque");
        }
        /// <summary>
        /// Valida saque em conta corrente
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool ValidarSaque(string codigo, decimal valor)
        {
            ValidarBuscaContaCorrente(codigo);

            if (valor <= 0)
                throw new ExcecaoDominio($"{nameof(valor)} deve ser maior que zero");

            return true;
        }
        /// <inheritdoc />  
        public async Task EfetuarTransferenciaAssincrono(string contaCorrenteOrigem, string contaCorrenteDestino, decimal valor)
        {
            ValidarTransferencia(contaCorrenteOrigem, contaCorrenteDestino, valor);

            var contaOrigem = await BuscarContaCorrenteAssincrono(contaCorrenteOrigem);

            contaOrigem.Lancamentos = await _repositorioLancamento.BuscarLancamentosContaCorrenteAssincrono(contaOrigem);

            var contaDestino = await BuscarContaCorrenteAssincrono(contaCorrenteDestino);

            ValidarValorTransferencia(contaOrigem, valor);

            var envio = new Lancamento()
            {
                TipoLancamento = Enum.TipoLancamento.Credito,
                Valor = valor,
                ContaCorrenteOrigemId = contaOrigem.ContaCorrenteId,
                ContaCorrenteDestinoId = contaDestino.ContaCorrenteId,
            };

            ValidarLancamentoDeposito(envio);

            var retirada = new Lancamento()
            {
                TipoLancamento = Enum.TipoLancamento.Debito,
                Valor = valor,
                ContaCorrenteOrigemId = contaDestino.ContaCorrenteId,
                ContaCorrenteDestinoId = contaOrigem.ContaCorrenteId,
            };

            ValidarLancamentoSaque(retirada);

            await _repositorioLancamento.SalvarAssincrono(envio);

            await _repositorioLancamento.SalvarAssincrono(retirada);
        }
        /// <summary>
        /// Valida os dados para realizadao de transferencia
        /// </summary>
        /// <param name="contaCorrenteOrigem"></param>
        /// <param name="contaCorrenteDestino"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public bool ValidarTransferencia(string contaCorrenteOrigem, string contaCorrenteDestino, decimal valor)
        {
            ValidarBuscaContaCorrente(contaCorrenteOrigem);

            ValidarBuscaContaCorrente(contaCorrenteDestino);

            if (valor <= 0)
                throw new ExcecaoDominio($"{nameof(valor)} deve ser maior que zero");

            return true;
        }
        /// <summary>
        /// Valida se o valor de transferencia é permitido para conta corrente
        /// </summary>
        /// <param name="contaCorrenteOrigem">conta corrente</param>
        /// <param name="valor">valor a ser sacado</param>
        /// <returns></returns>
        public bool ValidarValorTransferencia(ContaCorrente contaCorrenteOrigem, decimal valor)
        {
            if (contaCorrenteOrigem.Saldo >= valor)
                return true;

            throw new ExcecaoDominio($"Conta {contaCorrenteOrigem.Codigo} nao possui saldo suficiente para montante solicitado para saque");
        }
        #endregion
        #endregion
    }
}

using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Excecoes;
using SuperDigital.Dominio.Base.Servicos;
using System.Collections.Generic;
using Xunit;

namespace SuperDigital.Dominio.Base.Tests.Servicos
{
    /// <summary>
    /// Classe de teste de <see cref="ServicoContaCorrente"/>
    /// </summary>
    public class ServicoContaCorrenteTest
    {
        #region |Membros|
        #region |Metodos|
        [Fact]
        public void GerarCodigoContaCorrente_CodigoGeradoSucesso()
        {
            var contaCorrente = new ContaCorrente();

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.True(contaCorrenteServico.GerarCodigoContaCorrente(contaCorrente));
        }

        [Fact]
        public void GerarCodigoContaCorrente_CodigoGeradoComErro()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.GerarCodigoContaCorrente(null));
        }

        [Fact]
        public void ValidarCadastroContaCorrente_CadastroValido()
        {
            var contaCorrente = new ContaCorrente();

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            contaCorrenteServico.GerarCodigoContaCorrente(contaCorrente);

            Assert.True(contaCorrenteServico.ValidarCadastroContaCorrente(contaCorrente));
        }

        [Fact]
        public void ValidarCadastroContaCorrente_CadastroInvalido_ContaCorrenteNula()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarCadastroContaCorrente(null));
        }

        [Fact]
        public void ValidarCadastroContaCorrente_CadastroInvalido()
        {
            var contaCorrente = new ContaCorrente();

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarCadastroContaCorrente(contaCorrente));
        }

        [Theory]
        [InlineData("1", "12345")]
        [InlineData("2", "123487")]
        public void VerificarContaCorrenteCadastrada_CadastroRealizadoSucesso(string contaCorrenteId, string codigo)
        {
            var contaCorrente = new ContaCorrente()
            {
                ContaCorrenteId = contaCorrenteId,
                Codigo = codigo
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.True(contaCorrenteServico.VerificarContaCorrenteCadastrada(contaCorrente));
        }

        [Fact]
        public void VerificarContaCorrenteCadastrada_CadastroRealizadoErro_ContaCorrenteNula()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.VerificarContaCorrenteCadastrada(null));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("2", "")]
        [InlineData("", "1234")]
        public void VerificarContaCorrenteCadastrada_CadastroRealizadoErro(string contaCorrenteId, string codigo)
        {
            var contaCorrente = new ContaCorrente()
            {
                ContaCorrenteId = contaCorrenteId,
                Codigo = codigo
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.VerificarContaCorrenteCadastrada(null));
        }

        [Fact]
        public void ValidarBuscaContaCorrente_FiltroValido()
        {
            var codigo = "123";

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.True(contaCorrenteServico.ValidarBuscaContaCorrente(codigo));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ValidarBuscaContaCorrente_FiltroInvalido(string codigo)
        {
            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarBuscaContaCorrente(codigo));
        }

        [Fact]
        public void ValidarLancamentos_Valido()
        {
            var lancamentos = new List<Lancamento>()
            {
                new Lancamento()
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.True(contaCorrenteServico.ValidarLancamentos(lancamentos));
        }

        [Fact]
        public void ValidarLancamentos_Invalido()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominioObjetoNaoEncontrado>(() => contaCorrenteServico.ValidarLancamentos(null));
        }

        [Fact]
        public void ValidarLancamentoDeposito_Valido()
        {
            var lancamentoDeposito = new Lancamento()
            {
                ContaCorrenteDestinoId = "123",
                TipoLancamento = Enum.TipoLancamento.Credito,
                Valor = 1
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.True(contaCorrenteServico.ValidarLancamentoDeposito(lancamentoDeposito));
        }

        [Fact]
        public void ValidarLancamentoDeposito_Invalido_Nulo()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarLancamentoDeposito(null));
        }

        [Theory]
        [InlineData("", Enum.TipoLancamento.Credito, 10)]
        [InlineData("123", Enum.TipoLancamento.Debito, 10)]
        [InlineData("123", Enum.TipoLancamento.Credito, 0)]
        [InlineData("123", Enum.TipoLancamento.Credito, -10)]
        public void ValidarLancamentoDeposito_Invalido(string contaCorrente, Enum.TipoLancamento tipoLancamento, decimal valor)
        {
            var lancamentoDeposito = new Lancamento()
            {
                ContaCorrenteDestinoId = contaCorrente,
                TipoLancamento = tipoLancamento,
                Valor = valor
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarLancamentoDeposito(null));
        }

        [Fact]
        public void ValidarLancamentoSaque_Invalido_Nulo()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarLancamentoSaque(null));
        }

        [Theory]
        [InlineData("", Enum.TipoLancamento.Debito, 10)]
        [InlineData("123", Enum.TipoLancamento.Credito, 10)]
        [InlineData("123", Enum.TipoLancamento.Debito, 0)]
        [InlineData("123", Enum.TipoLancamento.Debito, -10)]
        public void ValidarLancamentoSaque_Invalido(string contaCorrente, Enum.TipoLancamento tipoLancamento, decimal valor)
        {
            var lancamentoSaque = new Lancamento()
            {
                ContaCorrenteOrigemId = contaCorrente,
                TipoLancamento = tipoLancamento,
                Valor = valor
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarLancamentoSaque(null));
        }

        [Fact]
        public void ValidarLancamentoSaque_ComSaldoSuficiente()
        {
            decimal valorSaque = 10;

            var contaCorrenteOrigem = new ContaCorrente
            {
                Lancamentos = new List<Lancamento>()
                {
                    new Lancamento(){ Valor = 10}
                }
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.True(contaCorrenteServico.ValidarValorSaque(contaCorrenteOrigem, valorSaque));
        }

        [Fact]
        public void ValidarLancamentoSaque_ComSaldoInsuficiente()
        {
            decimal valorSaque = 10;

            var contaCorrenteOrigem = new ContaCorrente
            {
                Lancamentos = new List<Lancamento>()
                {
                    new Lancamento(){ Valor = 5}
                }
            };

            var contaCorrenteServico = new ServicoContaCorrente(null, null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarValorSaque(contaCorrenteOrigem, valorSaque));
        }
        #endregion
        #endregion
    }
}

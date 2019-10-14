using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Excecoes;
using SuperDigital.Dominio.Base.Servicos;
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

            var contaCorrenteServico = new ServicoContaCorrente(null);

            Assert.True(contaCorrenteServico.GerarCodigoContaCorrente(contaCorrente));
        }

        [Fact]
        public void GerarCodigoContaCorrente_CodigoGeradoComErro()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.GerarCodigoContaCorrente(null));
        }

        [Fact]
        public void ValidarCadastroContaCorrente_CadastroValido()
        {
            var contaCorrente = new ContaCorrente();

            var contaCorrenteServico = new ServicoContaCorrente(null);

            contaCorrenteServico.GerarCodigoContaCorrente(contaCorrente);

            Assert.True(contaCorrenteServico.ValidarCadastroContaCorrente(contaCorrente));
        }

        [Fact]
        public void ValidarCadastroContaCorrente_CadastroInvalido_ContaCorrenteNula()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.ValidarCadastroContaCorrente(null));
        }

        [Fact]
        public void ValidarCadastroContaCorrente_CadastroInvalido()
        {
            var contaCorrente = new ContaCorrente();

            var contaCorrenteServico = new ServicoContaCorrente(null);

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

            var contaCorrenteServico = new ServicoContaCorrente(null);

            Assert.True(contaCorrenteServico.VerificarContaCorrenteCadastrada(contaCorrente));
        }

        [Fact]
        public void VerificarContaCorrenteCadastrada_CadastroRealizadoErro_ContaCorrenteNula()
        {
            var contaCorrenteServico = new ServicoContaCorrente(null);

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

            var contaCorrenteServico = new ServicoContaCorrente(null);

            Assert.Throws<ExcecaoDominio>(() => contaCorrenteServico.VerificarContaCorrenteCadastrada(null));
        }

        #endregion
        #endregion
    }
}

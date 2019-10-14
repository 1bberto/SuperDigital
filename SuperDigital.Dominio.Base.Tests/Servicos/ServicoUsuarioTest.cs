using SuperDigital.Dominio.Base.Entidades;
using SuperDigital.Dominio.Base.Excecoes;
using SuperDigital.Dominio.Base.Servicos;
using System;
using System.Collections.Generic;
using Xunit;

namespace SuperDigital.Dominio.Base.Tests.Servicos
{
    /// <summary>
    /// Classe de teste de <see cref="ServicoUsuario"/>
    /// </summary>
    public class ServicoUsuarioTest
    {
        #region |Membros|
        #region |Metodos|
        [Fact]
        public void ValidarFiltroBuscaUsuario_UsuarioValido()
        {
            var usuarioId = Guid.NewGuid().ToString();

            var usuarioServico = new ServicoUsuario(null);

            Assert.True(usuarioServico.ValidarFiltroBuscaUsuario(usuarioId));
        }

        [Theory]
        [InlineData("")]
        [InlineData("123")]
        public void ValidarFiltroBuscaUsuario_UsuarioInvalido(string usuarioId)
        {
            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominio>(() => usuarioServico.ValidarFiltroBuscaUsuario(usuarioId));
        }

        [Fact]
        public void ValidarUsuario_UsuarioValido()
        {
            var usuarioValido = true;

            var usuario = new Usuario()
            {
                Login = "Humberto",
                Nome = "Humberto Rodrigues",
                Senha = "123456"
            };

            var usuarioServico = new ServicoUsuario(null);

            Assert.Equal(usuarioServico.ValidarUsuario(usuario), usuarioValido);
        }

        [Fact]
        public void ValidarUsuario_UsuarioInvalido()
        {
            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominio>(() => usuarioServico.ValidarUsuario(null));
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("Humberto", "", "")]
        [InlineData("Humberto", "Humberto Rodrigues", "")]
        [InlineData("Humb", "Humberto Rodrigues", "123456")]
        [InlineData("Humberto", "Humberto Rodrigues", "123")]
        public void ValidarUsuario_UsuarioCamposInvalido(string login, string nome, string senha)
        {
            var usuario = new Usuario()
            {
                Login = login,
                Nome = nome,
                Senha = senha
            };

            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominio>(() => usuarioServico.ValidarUsuario(usuario));
        }

        [Fact]
        public void VerificarLoginUsuario_LoginValido_LoginPreenchido_ListaNula()
        {
            var usuario = new Usuario()
            {
                Login = "Humberto",
                Nome = "Humberto Rodrigues",
                Senha = "123456"
            };

            var usuarioServico = new ServicoUsuario(null);

            Assert.True(usuarioServico.VerificarLoginUsuario(usuario, null));
        }

        [Fact]
        public void VerificarLoginUsuario_LoginValido_LoginPreenchido_ListaPreenchida()
        {
            var usuario = new Usuario()
            {
                Login = "Humberto",
                Nome = "Humberto Rodrigues",
                Senha = "123456"
            };

            var lista = new List<Usuario>()
            {
                new Usuario(){ }
            };

            var usuarioServico = new ServicoUsuario(null);

            Assert.True(usuarioServico.VerificarLoginUsuario(usuario, lista));
        }

        [Fact]
        public void VerificarLoginUsuario_LoginInvalido_LoginNulo()
        {
            var lista = new List<Usuario>()
            {
                new Usuario(){ }
            };

            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominio>(() => usuarioServico.VerificarLoginUsuario(null, lista));
        }
        [Fact]
        public void VerificarLoginUsuario_LoginInvalido_LoginPreenchido_ListaPreenchida()
        {
            var usuario = new Usuario()
            {
                Login = "Humberto"
            };

            var lista = new List<Usuario>()
            {
                new Usuario(){ Login = "Humberto"}
            };

            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominio>(() => usuarioServico.VerificarLoginUsuario(usuario, lista));
        }

        [Fact]
        public void ValidarBuscaUsuario_UsuarioEncontrado()
        {
            var usuario = new Usuario();

            var usuarioServico = new ServicoUsuario(null);

            Assert.True(usuarioServico.ValidarBuscaUsuario(usuario, string.Empty));
        }

        [Fact]
        public void ValidarBuscaUsuario_UsuarioNaoEncontrado()
        {
            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominioObjetoNaoEncontrado>(() => usuarioServico.ValidarBuscaUsuario(null, string.Empty));
        }

        [Fact]
        public void ValidarLoginUsuario_LoginInvalido()
        {
            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominio>(() => usuarioServico.ValidarLoginUsuario(null));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("Joao", "")]
        [InlineData("", "123465")]
        public void ValidarLoginUsuario_LoginCamposInvalidos(string login, string senha)
        {
            var usuario = new Usuario()
            {
                Login = login,
                Senha = senha
            };

            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominio>(() => usuarioServico.ValidarLoginUsuario(usuario));
        }

        [Fact]
        public void ValidarLoginUsuarioRealizado_LoginRealizadoSucesso()
        {
            var usuario = new Usuario();

            var usuarioServico = new ServicoUsuario(null);

            Assert.True(usuarioServico.ValidarLoginUsuarioRealizado(usuario));
        }

        [Fact]
        public void ValidarLoginUsuarioRealizado_LoginRealizadoComFalha()
        {
            var usuarioServico = new ServicoUsuario(null);

            Assert.Throws<ExcecaoDominioUsuarioNaoEncontrado>(() => usuarioServico.ValidarLoginUsuarioRealizado(default));
        }
        #endregion
        #endregion
    }
}

USE [dbSuperDigital];
GO
--=============================================
-- Nome: USP_Usuario_INS
-- Data: 13/10/2019
-- Função: Inserir Registro na tabela tblUsuario
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_Usuario_INS]
	@Login VARCHAR(100),
	@Senha VARCHAR(50),
	@Nome VARCHAR(200)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblUsuario(Login, Senha, Nome)
	OUTPUT CAST(inserted.UsuarioId AS VARCHAR(36))
	VALUES(@Login, HASHBYTES('SHA2_512', @Senha), @Nome)
END
GO
--=============================================
-- Nome: USP_Usuario_SEL
-- Data: 13/10/2019
-- Função: Seleciona Registro na tabela tblUsuario
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_Usuario_SEL]
	@UsuarioId UNIQUEIDENTIFIER = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT 
		CAST(UsuarioId AS VARCHAR(36)) AS UsuarioId,
		Login,
		Nome,
		DataInclusaoRegistro
	FROM tblUsuario
	WHERE 
		@UsuarioId IS NULL OR UsuarioId = @UsuarioId
END
GO
--=============================================
-- Nome: USP_UsuarioLogin
-- Data: 13/10/2019
-- Função: Login do usuario
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_UsuarioLogin]
	@Login VARCHAR(100),
	@Senha VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
		CAST(UsuarioId AS VARCHAR(36)) AS UsuarioId,
		Login,
		Nome,
		DataInclusaoRegistro
	FROM tblUsuario
	WHERE 
		Login = @Login
	AND Senha = HASHBYTES('SHA2_512',@Senha)
END
GO
--=============================================
-- Nome: USP_ContaCorrente_INS
-- Data: 13/10/2019
-- Função: Inserir Registro na tabela tblContaCorrente
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_ContaCorrente_INS]
	@Codigo VARCHAR(10)	
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblContaCorrente(Codigo)
	OUTPUT CAST(inserted.ContaCorrenteId AS VARCHAR(36))
	VALUES(@Codigo)
END
GO
--=============================================
-- Nome: USP_ContaCorrente_SEL
-- Data: 13/10/2019
-- Função: Inserir Registro na tabela tblContaCorrente
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_ContaCorrente_SEL]
	@ContaCorrenteId UNIQUEIDENTIFIER = NULL,
	@Codigo VARCHAR(10) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT 
		CAST(ContaCorrenteId AS VARCHAR(36)) AS ContaCorrenteId,		
		Codigo,
		DataInclusaoRegistro
	FROM tblContaCorrente
	WHERE 
		(@ContaCorrenteId IS NULL OR ContaCorrenteId = @ContaCorrenteId)
	AND (@Codigo IS NULL OR Codigo = @Codigo)
END

GO
--=============================================
-- Nome: USP_Lancamento_INS
-- Data: 13/10/2019
-- Função: Inserir Registro na tabela tblLancamento
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_Lancamento_INS]
	@TipoLancamentoId INT,
	@ContaCorrenteOrigemId UNIQUEIDENTIFIER = NULL,
	@ContaCorrenteDestinoId UNIQUEIDENTIFIER,
	@Valor DECIMAL(18,2)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblLancamento(TipoLancamentoId, ContaCorrenteOrigemId, ContaCorrenteDestinoId, Valor)
	OUTPUT CAST(inserted.LancamentoId AS VARCHAR(36))
	VALUES(@TipoLancamentoId, @ContaCorrenteOrigemId, @ContaCorrenteDestinoId, @Valor);
END
GO
--=============================================
-- Nome: USP_Lancamento_INS
-- Data: 13/10/2019
-- Função: Inserir Registro na tabela tblLancamento
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_Lancamento_SEL]
	@LancamentoId UNIQUEIDENTIFIER = NULL,
	@TipoLancamentoId INT = NULL,
	@ContaCorrenteOrigemId UNIQUEIDENTIFIER = NULL,
	@ContaCorrenteDestinoId UNIQUEIDENTIFIER = NULL
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT 
		CAST(LancamentoId AS VARCHAR(36)) AS LancamentoId,		
		TipoLancamentoId,
		ContaCorrenteOrigemId,
		ContaCorrenteDestinoId,
		Valor,
		DataInclusaoRegistro
	FROM tblLancamento
	WHERE 
		(@LancamentoId IS NULL OR LancamentoId = @LancamentoId)
	AND (@TipoLancamentoId IS NULL OR TipoLancamentoId = @TipoLancamentoId)
	AND (@ContaCorrenteOrigemId IS NULL OR ContaCorrenteOrigemId = @ContaCorrenteOrigemId)
	AND (@ContaCorrenteDestinoId IS NULL OR ContaCorrenteDestinoId = @ContaCorrenteDestinoId)
END

GO
--=============================================
-- Nome: USP_LancamentoExtrato
-- Data: 13/10/2019
-- Função: Retorna o extrato de uma conta corrente
-- Autor: Humberto Rodrigues
--=============================================
CREATE OR ALTER PROCEDURE [dbo].[USP_LancamentoExtrato]	
	@ContaCorrenteId UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT 
		CAST(LancamentoId AS VARCHAR(36)) AS LancamentoId,		
		TipoLancamentoId,
		ContaCorrenteOrigemId,
		ContaCorrenteDestinoId,
		Valor,
		DataInclusaoRegistro
	FROM tblLancamento
	WHERE 
		ContaCorrenteOrigemId = @ContaCorrenteId OR ContaCorrenteDestinoId = @ContaCorrenteId
END
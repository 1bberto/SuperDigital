USE dbSuperDigital;
GO

CREATE TABLE tblUsuario
(
	UsuarioId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	Login VARCHAR(100) NOT NULL,
	Senha BINARY(64) NOT NULL,
	Nome VARCHAR(200) NOT NULL,
	DataInclusaoRegistro DATETIME NOT NULL DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_tblUsuario_UsuarioId] PRIMARY KEY(UsuarioId),
	CONSTRAINT [UNQ_tblUsuario_Login] UNIQUE (Login)
)

GO

CREATE TABLE tblContaCorrente
(
	ContaCorrenteId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
	Codigo VARCHAR(10) NOT NULL,
	DataInclusaoRegistro DATETIME NOT NULL DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_tblContaCorrente_ContaCorrenteId] PRIMARY KEY(ContaCorrenteId),
	CONSTRAINT [UNQ_tblContaCorrente_Codigo] UNIQUE(Codigo)
)

GO

CREATE TABlE tblTipoLancamento
(
	TipoLancamentoId INT IDENTITY(1,1) NOT NULL, 
	Nome VARCHAR(10) NOT NULL,
	DataInclusaoRegistro DATETIME NOT NULL DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_tblTipoLancamento_TipoLancamentoId] PRIMARY KEY(TipoLancamentoId)
)

GO

CREATE TABLE tblLancamento
(
	LancamentoId UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
	TipoLancamentoId INT NOT NULL,
	ContaCorrenteOrigemId UNIQUEIDENTIFIER,
	ContaCorrenteDestinoId UNIQUEIDENTIFIER,
	Valor DECIMAL(18,2) NOT NULL,
	DataInclusaoRegistro datetime NOT NULL DEFAULT GETUTCDATE(),
	CONSTRAINT [PK_tblLancamento_LancamentoId] PRIMARY KEY(LancamentoId),
	CONSTRAINT [FK_tblLancamento_tblTipoLancamento_TipoLancamentoId] FOREIGN KEY(TipoLancamentoId) REFERENCES tblTipoLancamento(TipoLancamentoId),
	CONSTRAINT [FK_tblLancamento_tblContaCorrente_ContaCorrenteOrigemId] FOREIGN KEY(ContaCorrenteOrigemId) REFERENCES tblContaCorrente(ContaCorrenteId),
	CONSTRAINT [FK_tblLancamento_tblContaCorrente_ContaCorrenteDestinoId] FOREIGN KEY(ContaCorrenteDestinoId) REFERENCES tblContaCorrente(ContaCorrenteId),
)
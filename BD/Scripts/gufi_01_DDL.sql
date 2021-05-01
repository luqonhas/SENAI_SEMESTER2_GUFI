CREATE DATABASE Gufi;
GO

USE Gufi;
GO

CREATE TABLE tiposUsuarios
(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(200) UNIQUE NOT NULL -- esse UNIQUE vai fazer ser ÚNICO, por exemplo, não pode ter dois "Administrador"
);
GO

CREATE TABLE Usuarios
(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario),
	nomeUsuario VARCHAR(100) NOT NULL,
	email VARCHAR(255) UNIQUE NOT NULL,
	senha VARCHAR(255) NOT NULL
);
GO

CREATE TABLE instituicoes
(
	idInstituicao INT PRIMARY KEY IDENTITY,
	cnpj CHAR(14) UNIQUE NOT NULL,
	nomeFantasia VARCHAR(255) UNIQUE NOT NULL,
	endereco VARCHAR(255) UNIQUE NOT NULL
);
GO

CREATE TABLE tiposEventos
(
	idTipoEvento INT PRIMARY KEY IDENTITY,
	tituloTipoEvento VARCHAR(255) UNIQUE NOT NULL
);
GO

CREATE TABLE eventos
(
	idEvento INT PRIMARY KEY IDENTITY,
	idTipoEvento INT FOREIGN KEY REFERENCES tiposEventos(idTipoEvento),
	idInstituicao INT FOREIGN KEY REFERENCES instituicoes(idInstituicao),
	nomeEvento VARCHAR(255),
	acessoLivre BIT DEFAULT(1), -- o BIT vai ser tipo o BOLEANO || o DEFAULT vai padronizar um valor, então mesmo que não seja colocado o valor '0' ou '1', nesse caso, seria como padrão o '1'
	dataEvento DATE NOT NULL,
	descricao VARCHAR(255)
);
GO

CREATE TABLE presencas
(
	idPresenca INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario),
	idEvento INT FOREIGN KEY REFERENCES eventos(idEvento),
	situacao VARCHAR(200) NOT NULL
);
GO
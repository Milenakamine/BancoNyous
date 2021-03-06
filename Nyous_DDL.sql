CREATE DATABASE NyousTarde;

USE NyousTarde;

CREATE TABLE Acesso(
	IdAcesso INT PRIMARY KEY IDENTITY NOT NULL,
	Tipo VARCHAR (50)
	);


CREATE TABLE Categoria (
	IdCategoria INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR (50)
);

--Preciso arrumar no logico o id local 

CREATE TABLE Localizacao(
	IdLocalizacao INT PRIMARY KEY IDENTITY NOT NULL,
	Logradouro VARCHAR(100)NOT NULL,
	Numero VARCHAR (50),
	Complemento VARCHAR(50),
	Bairro VARCHAR(50) NOT NULL,
	Cidade VARCHAR(50) NOT NULL,
	UF CHAR(2),
	CEP VARCHAR (10),
);


CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR (100) NOT NULL,
	Email VARCHAR (50) NOT NULL,
	Senha VARCHAR (100) NOT NULL,
	DataNascimento DATETIME,

--FK
	IdAcesso INT FOREIGN KEY REFERENCES Acesso (IdAcesso)
);

CREATE TABLE Evento (
	IdEvento INT PRIMARY KEY IDENTITY NOT NULL,
	DataEvento DATETIME NOT NULL, 
	AcessoRestrito BINARY DEFAULT 0 NOT NULL,
	Capacidade INT NOT NULL,
	Descricao VARCHAR (250),

--FK
	IdLocalizacao  INT FOREIGN KEY REFERENCES Localizacao (IdLocalizacao),
	IdCategoria INT FOREIGN KEY REFERENCES Categoria (IdCategoria)
);

CREATE TABLE Presenca (
	IdPresenca  INT PRIMARY KEY IDENTITY NOT NULL,
	Confirmado BIT NOT NULL,

--FK
	IdEvento INT FOREIGN KEY REFERENCES Evento (IdEvento),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);

CREATE TABLE Convite (
	IdConvite INT PRIMARY KEY IDENTITY NOT NULL,
	Confirmado BIT NOT NULL,

--FK
	IdEvento INT FOREIGN KEY REFERENCES Evento (IdEvento),
	IdUsuarioEmissor INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdUsuarioConvidado INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);






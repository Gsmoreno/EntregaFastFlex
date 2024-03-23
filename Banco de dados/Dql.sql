Create database Whaterver

use Whaterver
use FastFlex

create database FastFlex
use model
drop database FastFlex

select * 
Create table TipoUsuario(
	TipoUsuarioId INT IDENTITY PRIMARY KEY NOT NULL,
	Nome VARCHAR(100)
) 


Create table Usuario(
	UserId INT IDENTITY PRIMARY KEY NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Senha VARCHAR(255) NOT NULL,
	Ativado Bit not null,
	TipoUsuarioId int FOREIGN KEY (TipoUsuarioId) REFERENCES TipoUsuario(TipoUsuarioId),
) 


CREATE TABLE Destinatario (
	DestinatarioId INT IDENTITY primary key NOT NULL ,
	Nome VARCHAR(250) not null,
	Sobrenome VARCHAR(250),
	NumeroDocumento VARCHAR(14) not null,
	Cep VARCHAR(15)not null,
	Endereco VARCHAR(250) not null,
	Numero INT not null,
	Bairro VARCHAR(250) not null,
	Cidade VARCHAR(150) not null,
	Uf VARCHAR(2) not null
)

Create table Entregador(
	EntregadorId INT IDENTITY primary key NOT NULL ,
	Nome VARCHAR(250) not null,
	Sobrenome VARCHAR(250),
	NumeroDocumento VARCHAR(14) not null,
	MEI VARCHAR(11) not null,
	Endereco VARCHAR(250) not null,
	Numero INT not null,
	Bairro VARCHAR(250) not null,
	Cidade VARCHAR(150) not null,
	Uf VARCHAR(2) not null,
	Cep VARCHAR(15)not null, 
	UserId int FOREIGN KEY (UserId) REFERENCES Usuario(UserId)
)

Create Table Cliente(
	ClienteId INT IDENTITY primary key NOT NULL ,
	NomeFantasia varchar(255),
	RazaoSocial varchar(255) not null,
	Contato varchar(255),
	Telefone int not null,
	Email varchar(255) not null,
	Logradouro varchar(255) not null,
	Bairro varchar(255) not null,
	Cep varchar(15) not null,
	Cidade varchar(255) not null,
	Uf VARCHAR(2) not null,
	Cpnj varchar(255) not null,
	Numero int not null,
	Ativado bit not null,
	Descricao varchar(500),
	UserId int FOREIGN KEY (UserId) REFERENCES Usuario(UserId)
)

Create Table Entrega(
	EntregaId INT IDENTITY primary key NOT NULL,
	CepDestino varchar(15) not null,
	CepOrigem varchar(15) not null,
	Rua varchar(255) not null,
	Numero int not null,
	Bairro varchar(255) not null,
	PrecoEntrega decimal(4,2) not null,
	QtdPacotes int not null,
	ValorEntrega decimal not null,
	HoraSaida Datetime  not null,
	HoraEntrega Datetime  not null,
	[Status] varchar(55) not null,
	EntregadorId int FOREIGN KEY (EntregadorId) REFERENCES Entregador(EntregadorId),
	ClienteId int FOREIGN KEY (ClienteId) REFERENCES Cliente(ClienteId),
	DestinatarioId int FOREIGN KEY (DestinatarioId) REFERENCES Destinatario(DestinatarioId)
)	

Create Table Pacote(
	PacoteId INT IDENTITY PRIMARY KEY NOT NULL,
	Altura DECIMAL(5,1),
	Largura DECIMAL(5,1),
	Comprimento DECIMAL(5,1),
	Peso DECIMAL(5,2),
	ValorDeclarado DECIMAL(19,4),
	EntregaId int FOREIGN KEY (EntregaId) REFERENCES Entrega(EntregaId)
)



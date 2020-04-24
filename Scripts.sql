create database LojaVirtual
go

use LojaVirtual
go

CREATE TABLE Loja(
	idLoja bigint IDENTITY(1,1) NOT NULL,
	nomeFantasia varchar(200) NOT NULL,
	descricao varchar(650) NULL,
	tags varchar(350) NULL,
	dominio varchar(100) NULL,
	email varchar(250) NULL,
	telefone varchar(11) NULL,
	ativa bit NOT NULL,
 CONSTRAINT PK_Loja PRIMARY KEY CLUSTERED 
(
	idLoja ASC
))
GO

insert into Loja values ('Loja 1', 'Descricao da Loja 1', 'tags da loja 1', '1dominio.com', 'email1@teste.com', '11944445551', 1)
insert into Loja values ('Loja 2', 'Descricao da Loja 2', 'tags da loja 2', '2dominio.com', 'email2@teste.com', '11944445552', 1)
insert into Loja values ('Loja 3', 'Descricao da Loja 3', 'tags da loja 3', '3dominio.com', 'email3@teste.com', '11944445553', 1)
insert into Loja values ('Loja 4', 'Descricao da Loja 4', 'tags da loja 4', '4dominio.com', 'email4@teste.com', '11944445554', 1)
insert into Loja values ('Loja 5', 'Descricao da Loja 5', 'tags da loja 5', '5dominio.com', 'email5@teste.com', '11944445555', 1)
insert into Loja values ('Loja 6', 'Descricao da Loja 6', 'tags da loja 6', '6dominio.com', 'email6@teste.com', '11944445556', 1)
insert into Loja values ('Loja 7', 'Descricao da Loja 7', 'tags da loja 7', '7dominio.com', 'email7@teste.com', '11944445557', 1)
insert into Loja values ('Loja 8', 'Descricao da Loja 8', 'tags da loja 8', '8dominio.com', 'email8@teste.com', '11944445558', 1)
insert into Loja values ('Loja 9', 'Descricao da Loja 9', 'tags da loja 9', '9dominio.com', 'email9@teste.com', '11944445559', 1)

select * from Loja
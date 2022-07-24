-- Cria o banco de dados
CREATE DATABASE [avaliacao_d3];
GO

-- Define qual banco de dados será utilizado
USE [avaliacao_d3];
GO

-- Cria a tabela Products
CREATE TABLE Users( --Não usar User pois é reservado
	[user_id]		    VARCHAR(255) NOT NULL UNIQUE,
	[user_name]			VARCHAR(255) NOT NULL,
	[user_email]		VARCHAR(255) NOT NULL,
	[user_password]		VARCHAR(255) NOT NULL
);
GO

-- Lista os dados da tabela
SELECT * FROM Users;
GO

-- Insere um registro na tabela
INSERT INTO Users ([user_id], [user_name], [user_email], [user_password])
VALUES ('df4759ac-cade-4bfe-b292-746cfef77249', 'admin', 'admin@email.com', 'admin123');
GO

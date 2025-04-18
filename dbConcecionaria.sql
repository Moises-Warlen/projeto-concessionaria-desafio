USE [master]
GO
/****** Object:  Database [Concessionaria]    Script Date: 02/04/2025 09:18:44 ******/
CREATE DATABASE [Concessionaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Concessionaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Concessionaria.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Concessionaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Concessionaria_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Concessionaria] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Concessionaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Concessionaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Concessionaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Concessionaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Concessionaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Concessionaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Concessionaria] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Concessionaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Concessionaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Concessionaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Concessionaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Concessionaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Concessionaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Concessionaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Concessionaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Concessionaria] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Concessionaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Concessionaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Concessionaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Concessionaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Concessionaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Concessionaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Concessionaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Concessionaria] SET RECOVERY FULL 
GO
ALTER DATABASE [Concessionaria] SET  MULTI_USER 
GO
ALTER DATABASE [Concessionaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Concessionaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Concessionaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Concessionaria] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Concessionaria] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Concessionaria] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Concessionaria', N'ON'
GO
ALTER DATABASE [Concessionaria] SET QUERY_STORE = ON
GO
ALTER DATABASE [Concessionaria] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Concessionaria]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[CPF] [varchar](15) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[Ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [CPF] UNIQUE NONCLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[IdEmail] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[IdCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Endereco]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[IdEndereco] [int] IDENTITY(1,1) NOT NULL,
	[CEP] [varchar](15) NOT NULL,
	[Rua] [varchar](100) NOT NULL,
	[Numero] [int] NULL,
	[Bairro] [varchar](100) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[Tipo] [varchar](15) NOT NULL,
	[IdCliente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstoqueCarro]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstoqueCarro](
	[IdEstoqueCarro] [int] IDENTITY(1,1) NOT NULL,
	[IdModelo] [int] NOT NULL,
	[Ano] [int] NOT NULL,
	[MotorTurbo] [bit] NOT NULL,
	[Detalhes] [varchar](500) NOT NULL,
	[Cor] [varchar](100) NOT NULL,
	[Valor] [decimal](10, 2) NULL,
	[Quantidade] [int] NULL,
	[Disponivel] [bit] NOT NULL,
	[Placa] [varchar](11) NOT NULL,
	[Ativo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEstoqueCarro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[IdModelo] [int] IDENTITY(1,1) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Modelo] [varchar](100) NOT NULL,
	[IdMotorizacao] [int] NOT NULL,
	[IdTipoCarroceria] [int] NOT NULL,
	[AnoMinimo] [int] NOT NULL,
	[AnoMaximo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdModelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Motorizacao]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motorizacao](
	[IdMotorizacao] [int] IDENTITY(1,1) NOT NULL,
	[Potencia] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMotorizacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefone]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefone](
	[IdTelefone] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [varchar](15) NOT NULL,
	[Tipo] [varchar](15) NULL,
	[IdCliente] [int] NOT NULL,
	[DDD] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTelefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCarroceria]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCarroceria](
	[IdTipoCarroceria] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoCarroceria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venda]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venda](
	[IdVenda] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdEstoqueCarro] [int] NOT NULL,
	[ValorNegociado] [decimal](10, 0) NULL,
	[ValorEntrada] [decimal](10, 2) NULL,
	[Parcelas] [int] NULL,
	[ValorParcela] [decimal](10, 2) NULL,
	[DataVenda] [date] NOT NULL,
	[Disponivel] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[EstoqueCarro] ADD  DEFAULT ((0)) FOR [Quantidade]
GO
ALTER TABLE [dbo].[EstoqueCarro] ADD  DEFAULT ((1)) FOR [Disponivel]
GO
ALTER TABLE [dbo].[EstoqueCarro] ADD  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Venda] ADD  DEFAULT ((0)) FOR [Disponivel]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[EstoqueCarro]  WITH CHECK ADD FOREIGN KEY([IdModelo])
REFERENCES [dbo].[Modelo] ([IdModelo])
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([IdMarca])
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD FOREIGN KEY([IdMotorizacao])
REFERENCES [dbo].[Motorizacao] ([IdMotorizacao])
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD FOREIGN KEY([IdTipoCarroceria])
REFERENCES [dbo].[TipoCarroceria] ([IdTipoCarroceria])
GO
ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venda]  WITH CHECK ADD FOREIGN KEY([IdEstoqueCarro])
REFERENCES [dbo].[EstoqueCarro] ([IdEstoqueCarro])
GO
/****** Object:  StoredProcedure [dbo].[AdicionarCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[AdicionarCliente]
    @Nome VARCHAR(100),
	@CPF VARCHAR(15),
    @DataNascimento DATE,
    @Ativo BIT
    
AS
/*
Documentação
Arquivo Fonte.....: AdicionarCliente.sql
Objetivo..........: Inserir um novo cliente na tabela cliente
Autor.............: [Moises]
Data..............: [04/07/2024]
Ex................: EXEC [dbo].[AdicionarCliente] 
                        @Nome = 'Novo Usuário',
                        @CPF = '123321654',
                        @DataNascimento = '1990-01-01',
                        @Ativo = 1,
                      
*/

BEGIN
    INSERT INTO Cliente(Nome,CPF, DataNascimento, Ativo)
    VALUES (@Nome,@CPF,@DataNascimento,1)

	RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AdicionarEmail]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AdicionarEmail]
    @IdCliente INT,           -- ID do cliente
    @Email VARCHAR(100)       -- E-mail do cliente
AS

/*
Documentação
Arquivo Fonte.....: AdicionarEmail.sql 
Autor.............: [Moises]
Data..............: [08/11/2024]
Ex................: EXEC [dbo].[AdicionarEmail]
                        @IdCliente = 1,
                        @Email = 'fulano@gmail.com',
                    
*/
BEGIN
    INSERT INTO Email(IdCliente,Email)
    VALUES (@IdCliente, @Email)
END
GO
/****** Object:  StoredProcedure [dbo].[AdicionarEnderecoCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create     PROCEDURE [dbo].[AdicionarEnderecoCliente]
    @CEP VARCHAR(15),
	@Rua VARCHAR(100),
	@Numero INT,
	@Bairro VARCHAR(100),
    @Cidade VARCHAR(100),
    @Tipo VARCHAR(15),
    @IdCliente INT
AS
/*
Documentação
Arquivo Fonte.....: AdicionarEnderecoUsuario.sql
Objetivo..........: Inserir um novo endereço de usuário na tabela EnderecosUsuarios
Autor.............: [Moises]
Data..............: [08/11/2024]
Ex................: EXEC [dbo].[AdicionarEnderecoCliente]
                        @CEP = '12345678',
                        @Cidade = 'São Paulo',
                        @Bairro = 'Centro',
                        @Rua = 'Rua Principal',
                        @Numero = 100,
                        @Tipo = 'Residencial',
                        @IdUsuario = 1,
                    
*/

BEGIN
    INSERT INTO Endereco (CEP, Cidade, Bairro, Rua, Numero, Tipo, IdCliente)
    VALUES (@CEP, @Cidade, @Bairro, @Rua, @Numero, @Tipo, @IdCliente)
END
GO
/****** Object:  StoredProcedure [dbo].[AdicionarEstoque]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AdicionarEstoque]
    @IdModelo INT,                -- ID do modelo associado ao estoque
    @Ano INT,                     -- Ano do veículo
    @MotorTurbo BIT,              -- Indica se o motor é turbo
    @Detalhes VARCHAR(255),       -- Detalhes do veículo
    @Cor VARCHAR(50),             -- Cor do veículo
    @Valor DECIMAL(18, 2),        -- Valor do veículo
    @Disponivel BIT = 1,          -- Indica se está disponível (padrão 1)
    @Placa VARCHAR(10)            -- Placa do veículo
AS
/*
Documentação
Arquivo Fonte.....: AdicionarEstoque.sql
Objetivo..........: Inserir um novo registro no estoque
Autor.............: [Moises]
Data..............: [02/11/2024]
Exemplo...........: EXEC [dbo].[AdicionarEstoque] 
                       @IdModelo = 29,
                       @Ano = 2008,
                       @MotorTurbo,
                       @Detalhes = 'Carro em excelente estado',
                       @Cor = 'Prata',
                       @Valor = 20.000,
                       @Disponivel = 1,
                       @Placa = 'BMW-6688'
*/

BEGIN
    -- Inserir um novo registro no estoque, com Disponivel fixado como 1
    INSERT INTO EstoqueCarro (IdModelo, Ano, MotorTurbo, Detalhes, Cor, Valor, Disponivel, Placa)
    VALUES (@IdModelo, @Ano, @MotorTurbo, @Detalhes, @Cor, @Valor, 1, @Placa)

    -- Retornar o ID do novo registro inserido
    RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AdicionarMarca]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AdicionarMarca]
    @Marca VARCHAR(100)
AS
/*
Documentação
Arquivo Fonte.....: AdicionarMarca.sql
Objetivo..........: Inserir uma nova marca na tabela Marcas
Autor.............: [Moises]
Data..............: [21/10/2021]
Exemplo...........: EXEC [dbo].[AdicionarMarca] 
                       @Marca= 'Marca Exemplo'
*/

BEGIN
    -- Inserir uma nova marca na tabela Marcas
    INSERT INTO Marca (Marca)
    VALUES (@Marca)

    -- Retornar o ID da nova marca inserida
    RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AdicionarModelo]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE     PROCEDURE [dbo].[AdicionarModelo]
    @IdMarca INT,                 -- ID da marca associada ao modelo
    @Modelo VARCHAR(100),         -- Nome do modelo
    @IdMotorizacao INT,           -- ID da motorização
    @IdTipoCarroceria INT,        -- ID do tipo de carroceria
    @AnoMinimo INT,               -- Ano mínimo de fabricação
    @AnoMaximo INT                -- Ano máximo de fabricação
AS
/*
Documentação
Arquivo Fonte.....: AdicionarModelo.sql
Objetivo..........: Inserir um novo modelo na tabela Modelos
Autor.............: [Moises]
Data..............: [24/10/2024]
Exemplo...........: EXEC [dbo].[AdicionarModelo] 
                       @IdMarca = 1,
                       @Modelo = 'Modelo Exemplo',
                       @IdMotorizacao = 2,
                       @IdTipoCarroceria = 3,
                       @AnoMinimo = 2015,
                       @AnoMaximo = 2024
*/

BEGIN
    -- Inserir um novo modelo na tabela Modelos
    INSERT INTO Modelo (IdMarca, Modelo, IdMotorizacao, IdTipoCarroceria, AnoMinimo, AnoMaximo)
    VALUES (@IdMarca, @Modelo, @IdMotorizacao, @IdTipoCarroceria, @AnoMinimo, @AnoMaximo)

    -- Retornar o ID do novo modelo inserido
    RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AdicionarTelefone]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AdicionarTelefone]
    @IdCliente INT,           -- Id do cliente (obrigatório)
    @Numero VARCHAR(15),      -- Número do telefone (obrigatório)
    @DDD VARCHAR(5),          -- DDD do telefone (obrigatório)
    @Tipo VARCHAR(20)         -- Tipo do telefone (ex: Celular, Comercial, etc.) (obrigatório)
AS

/* Arquivo Fonte.....: AdicionarTelefone.sql ******/
-- Objetivo..........: Inserir um novo número de telefone para um cliente
-- Autor.............: [Moises]
-- Data..............: [07/11/2024]
-- Exemplo...........: EXEC [dbo].[AdicionarTelefone] 
--                       @IdCliente = 1,
--                       @Numero = '9876543210',
--                       @DDD = '071',
--                       @Tipo = 'Celular'

BEGIN
    INSERT INTO Telefone(IdCliente, Numero, DDD, Tipo)
    VALUES (@IdCliente, @Numero ,@DDD, @Tipo)
END
GO
/****** Object:  StoredProcedure [dbo].[AdicionarVenda]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AdicionarVenda]
    @IdCliente INT,
    @IdEstoque INT,
    @ValorNegociado DECIMAL(18, 2),
    @ValorEntrada DECIMAL(18, 2) = NULL, -- Permitir valor NULL
    @Parcelas INT,
    @ValorParcela DECIMAL(18, 2),
    @Disponivel INT = NULL -- Permitir valor NULL
AS
/*
Documentação
Arquivo Fonte.....: AdicionarVenda.sql
Objetivo..........: Inserir uma nova venda na tabela Venda e atualizar o EstoqueCarro para Disponivel = 0
Autor.............: [Seu Nome]
Data..............: [22/11/2024]
Ex................: EXEC [dbo].[AdicionarVenda] 
                        @IdCliente = 1,
                        @IdEstoque = 101,
                        @ValorNegociado = 35000.00,
                        @ValorEntrada = 5000.00,
                        @Parcelas = 24,
                        @ValorParcela = 1458.33
*/

BEGIN
    -- Inserir a nova venda na tabela Venda
    INSERT INTO [dbo].[Venda]
               ([IdCliente]
               ,[IdEstoqueCarro]
               ,[ValorNegociado]
               ,[ValorEntrada]
               ,[Parcelas]
               ,[ValorParcela]
               ,[DataVenda]
               ,[Disponivel])
               
    VALUES
               (@IdCliente
               ,@IdEstoque
               ,@ValorNegociado
               ,@ValorEntrada
               ,@Parcelas
               ,@ValorParcela
               ,GETDATE()
               ,@Disponivel) -- Disponivel será permitido valor NULL
              

    -- Atualizar a tabela EstoqueCarro para marcar o carro como não disponível
    UPDATE [dbo].[EstoqueCarro]
    SET [Disponivel] = 0
    WHERE [IdEstoqueCarro] = @IdEstoque

    -- Retorna o ID da venda inserida (para referência)
    RETURN SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AtualizarCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AtualizarCliente]
    @IdCliente INT,
    @Nome VARCHAR(100),
    @CPF VARCHAR(15),
    @DataNascimento DATE
AS
/*
Documentação
Arquivo Fonte.....: AtualizarCliente.sql
Objetivo..........: Atualizar informações de um cliente na tabela Cliente
Autor.............: [Moises]
Data..............: [04/07/2024]
Ex................: EXEC [dbo].[AtualizarCliente] 
                         @IdCliente = 1,
                         @Nome = 'Novo Nome',
                         @CPF = '12332112334',
                         @DataNascimento = '1990-01-01'
*/

BEGIN
    UPDATE Cliente
    SET Nome = @Nome,
        CPF = @CPF,
        DataNascimento = @DataNascimento,
        Ativo = 1
    WHERE IdCliente = @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[AtualizarEstoque]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AtualizarEstoque]
    @IdEstoque INT,               -- ID do estoque que será atualizado
    @Cor VARCHAR(50),             -- Cor do veículo
    @Placa VARCHAR(20),           -- Placa do veículo
    @MotorTurbo BIT,              -- Indicador se o carro é turbo ou não (1 = Sim, 0 = Não)
    @Detalhes VARCHAR(255),       -- Detalhes do veículo
    @Valor DECIMAL(18, 2)         -- Valor do veículo
AS
/*
Documentação
Arquivo Fonte.....: AtualizarEstoque.sql
Objetivo..........: Atualizar informações de um veículo no estoque, incluindo o valor do veículo
Autor.............: [Seu Nome]
Data..............: [Data de Criação]
Exemplo...........: EXEC [dbo].[AtualizarEstoque] 
                       @IdEstoque = 1,
                       @Cor = 'Preto',
                       @Placa = 'ABC-1234',
                       @MotorTurbo = 1,
                       @Detalhes = 'Carro novo com motor turbo',
                       @Valor = 45000.00
*/

BEGIN
    -- Verificar se o estoque existe antes de atualizar
    IF EXISTS (SELECT 1 FROM EstoqueCarro WHERE IdEstoqueCarro = @IdEstoque)
    BEGIN
        -- Atualizar as informações do veículo no estoque
        UPDATE EstoqueCarro
        SET Cor = @Cor,
            Placa = @Placa,
            MotorTurbo = @MotorTurbo,
            Detalhes = @Detalhes,
            Valor = @Valor
        WHERE IdEstoqueCarro = @IdEstoque
        
        -- Retornar sucesso
        RETURN 0
    END
    ELSE
    BEGIN
        -- Retornar erro se o estoque não existir
        RETURN -1
    END
END
GO
/****** Object:  StoredProcedure [dbo].[AtualizarMarca]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AtualizarMarca]
    @IdMarca INT,
    @Marca VARCHAR(100)
AS
/*
Documentação
Arquivo Fonte.....: AtualizarMarca.sql
Objetivo..........: Atualizar uma marca existente na tabela Marca
Autor.............: [Moises]
Data..............: [21/10/2024]
Exemplo...........: EXEC [dbo].[AtualizarMarca]
                        @IdMarca = 1,
                        @Marca = 'Novo Nome da Marca'
*/

BEGIN
    -- Atualizar a marca existente na tabela Marca
    UPDATE Marca
    SET Marca = @Marca
    WHERE IdMarca = @IdMarca

    -- Verificar se a atualização foi bem-sucedida
    IF @@ROWCOUNT = 0
        RETURN -1  -- Indica que nenhuma linha foi atualizada (ID não encontrado)
    
    -- Retornar o ID da marca atualizada
    RETURN @IdMarca
END
GO
/****** Object:  StoredProcedure [dbo].[AtualizarModelo]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AtualizarModelo]
    @IdModelo INT,               -- ID do modelo que será atualizado
    @IdMarca INT,                -- ID da marca associada ao modelo
    @Modelo VARCHAR(100),        -- Nome do modelo
    @IdMotorizacao INT,          -- ID da motorização
    @IdTipoCarroceria INT,       -- ID do tipo de carroceria
    @AnoMinimo INT,              -- Ano mínimo de fabricação
    @AnoMaximo INT               -- Ano máximo de fabricação
AS
/*
Documentação
Arquivo Fonte.....: AtualizarModelo.sql
Objetivo..........: Atualizar um modelo existente na tabela Modelos
Autor.............: [Moises]
Data..............: [24/10/2024]
Exemplo...........: EXEC [dbo].[AtualizarModelo] 
                       @IdModelo = 1,
                       @IdMarca = 1,
                       @Modelo = 'Modelo Atualizado',
                       @IdMotorizacao = 2,
                       @IdTipoCarroceria = 3,
                       @AnoMinimo = 2015,
                       @AnoMaximo = 2024
*/

BEGIN
    -- Verificar se o modelo existe antes de atualizar
    IF EXISTS (SELECT 1 FROM Modelo WHERE IdModelo = @IdModelo)
    BEGIN
        -- Atualizar o modelo existente na tabela Modelo
        UPDATE Modelo
        SET IdMarca = @IdMarca,
            Modelo = @Modelo,
            IdMotorizacao = @IdMotorizacao,
            IdTipoCarroceria = @IdTipoCarroceria,
            AnoMinimo = @AnoMinimo,
            AnoMaximo = @AnoMaximo
        WHERE IdModelo = @IdModelo
        
        -- Retornar sucesso
        RETURN 0
    END
    ELSE
    BEGIN
        -- Retornar erro se o modelo não existir
        RETURN -1
    END
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarClientePorCPF]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BuscarClientePorCPF]
    @CPF VARCHAR(14) = NULL  -- Parâmetro opcional
AS
/*
Documentação:
Arquivo Fonte.....: BuscarClientePorCPF.sql
Objetivo..........: Buscar clientes ativos por CPF.
Data..............: 18/12/2024

Exemplos de Uso:
EXEC [dbo].[BuscarClientePorCPF] @CPF = '123.456.789-00' -- Para listar um cliente específico
EXEC [dbo].[BuscarClientePorCPF] -- Para listar todos os clientes ativos
*/

BEGIN
    SET NOCOUNT ON;

    -- Se @CPF é NULL, retorna todos os clientes ativos
    -- Caso contrário, retorna apenas o cliente ativo específico
    SELECT IdCliente, CPF, Nome, DataNascimento
    FROM Cliente
    WHERE (@CPF IS NULL OR CPF = @CPF)
    --  AND Ativo = 1; -- Apenas clientes ativos
END
GO
/****** Object:  StoredProcedure [dbo].[DeletarEmailCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE   PROCEDURE [dbo].[DeletarEmailCliente]
    @IdCliente INT
AS
BEGIN

    DELETE FROM Email
        WHERE IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[DeletarEnderecoCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create      PROCEDURE [dbo].[DeletarEnderecoCliente]
    @IdCliente INT
AS
BEGIN

    DELETE FROM Endereco
        WHERE IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[DeletarMarca]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[DeletarMarca]
    @IdMarca INT
AS
/*
Documentação
Arquivo Fonte.....: DeletarMarca.sql
Objetivo..........: Excluir uma marca existente na tabela Marca
Autor.............: [Moises]
Data..............: [21/10/2024]
Exemplo...........: EXEC [dbo].[DeletarMarca] 
                        @IdMarca = 1
*/

BEGIN
    -- Verificar se a marca existe
    IF NOT EXISTS (SELECT 1 FROM Marca WHERE IdMarca = @IdMarca)
    BEGIN
        RETURN -1  -- Indica que a marca não foi encontrada
    END

    -- Excluir a marca da tabela Marca
    DELETE FROM Marca
    WHERE IdMarca = @IdMarca

    -- Verificar se a exclusão foi bem-sucedida
    IF @@ROWCOUNT = 0
        RETURN -2  -- Indica que a exclusão falhou por outro motivo
    
    -- Retornar o ID da marca excluída
    RETURN @IdMarca
END
GO
/****** Object:  StoredProcedure [dbo].[DeletarModelo]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[DeletarModelo]
    @IdModelo INT                 -- ID do modelo a ser deletado
AS
/*
Documentação
Arquivo Fonte.....: DeletarModelo.sql
Objetivo..........: Excluir um modelo existente da tabela Modelos
Autor.............: [Moises]
Data..............: [24/10/2024]
Exemplo...........: EXEC [dbo].[DeletarModelo] 
                       @IdModelo = 1
*/

BEGIN
    -- Verificar se o modelo existe antes de deletar
    IF EXISTS (SELECT 1 FROM Modelo WHERE IdModelo = @IdModelo)
    BEGIN
        -- Excluir o modelo da tabela Modelo
        DELETE FROM Modelo
        WHERE IdModelo = @IdModelo
        
        -- Retornar sucesso
        RETURN 0
    END
    ELSE
    BEGIN
        -- Retornar erro se o modelo não existir
        RETURN -1
    END
END






GO
/****** Object:  StoredProcedure [dbo].[DeletarTelefoneCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[DeletarTelefoneCliente]
    @IdCliente INT
AS
BEGIN

    DELETE FROM Telefone
        WHERE IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[DesativarCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create     PROCEDURE [dbo].[DesativarCliente]
    @IdCliente INT
   
AS
/*
Documentação
Arquivo Fonte.....: DesativarCliente.sql
Objetivo..........: desativar um cliente existente na tabela cliente
Autor.............: [Moises]
Data..............: [21/10/2024]
Exemplo...........: EXEC [dbo].[DesativarCliente]@IdCliente = 1,
                        
                       
*/

BEGIN
    -- desativar cliente existente na tabela cliente
    UPDATE Cliente
    SET Ativo = 0
    WHERE IdCliente = @IdCliente

    -- Verificar se a atualização foi bem-sucedida
    IF @@ROWCOUNT = 0
        RETURN -1  -- Indica que nenhuma linha foi atualizada (ID não encontrado)
    
    -- Retornar o ID do cliente atualizada
    RETURN @IdCliente
END
GO
/****** Object:  StoredProcedure [dbo].[DetalheCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DetalheCliente]
   @IdCliente INT
AS
BEGIN
    SELECT *
    FROM cliente
    WHERE IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[DetalheVendaCliente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DetalheVendaCliente]
    @IdVenda INT -- Adiciona um parâmetro para o ID da venda
AS
BEGIN
    SET NOCOUNT ON;

    -- Retorna dados de venda relacionados ao cliente, incluindo o modelo, motorização, valor de venda, entrada, parcelas, valor das parcelas, nome do cliente, CPF, data de nascimento e data da venda
    SELECT 
        M.IdModelo,
        M.Modelo AS NomeModelo,
        Marca.Marca AS NomeMarca,
        Motorizacao.Potencia AS NomeMotorizacao,
        TipoCarroceria.Tipo AS NomeCarroceria,
        E.Ano,
        E.MotorTurbo,
        E.Cor,
        E.Valor AS ValorCarro,
        V.ValorNegociado,
        V.ValorEntrada,
        V.Parcelas,
        V.ValorParcela,
        C.Nome AS NomeCliente, -- Nome do cliente
        C.CPF, -- CPF do cliente
        C.DataNascimento, -- Data de nascimento do cliente
        V.DataVenda -- Data da venda
    FROM 
        Venda V
    INNER JOIN 
        EstoqueCarro E ON V.IdEstoqueCarro = E.IdEstoqueCarro
    INNER JOIN 
        Modelo M ON E.IdModelo = M.IdModelo
    INNER JOIN 
        Marca ON M.IdMarca = Marca.IdMarca
    INNER JOIN 
        Motorizacao ON M.IdMotorizacao = Motorizacao.IdMotorizacao
    INNER JOIN 
        TipoCarroceria ON M.IdTipoCarroceria = TipoCarroceria.IdTipoCarroceria
    INNER JOIN
        Cliente C ON V.IdCliente = C.IdCliente -- Junta com a tabela Cliente para obter o nome
    WHERE 
        V.Disponivel IS NULL -- Certificando que a venda está com 'Disponivel' como NULL
        AND V.IdVenda = @IdVenda -- Filtro pelo ID da venda recebido como parâmetro
    ORDER BY 
        V.DataVenda DESC; -- Ordena pela data da venda, mais recente primeiro
END
GO
/****** Object:  StoredProcedure [dbo].[ListarCarroceriaPorId]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarCarroceriaPorId]
    @IdTipoCarroceria INT
AS
/*
Documentação:
Arquivo Fonte.....: ListarCarroceriaPorId.sql
Objetivo..........: Retornar uma carroceria específica da tabela TipoCarroceria pelo Id.
Autor.............: Moises
Data..............: 30/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarCarroceriaPorId] @IdTipoCarroceria = 1 -- Para listar a carroceria com Id 1
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna a carroceria com o Id especificado
    SELECT IdTipoCarroceria, Tipo
    FROM TipoCarroceria
    WHERE IdTipoCarroceria = @IdTipoCarroceria;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarEstoquePorId]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   PROCEDURE [dbo].[ListarEstoquePorId]
    @IdEstoqueCarro INT  -- Parâmetro de entrada para o ID do veículo
AS
/*
Documentação:
Arquivo Fonte.....: ListarEstoquePorId.sql
Objetivo..........: Listar um veículo específico no estoque com base no ID fornecido.
Autor.............: Moises
Data..............: 05/11/2024

Exemplo de Uso:
EXEC [dbo].[ListarEstoquePorId] @IdEstoqueCarro = 1 -- Para listar o veículo com ID 1
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna o veículo específico do estoque com base no ID fornecido
    SELECT
        E.IdEstoqueCarro AS IdEstoque,
        M.Modelo AS NomeModelo,
        Marca.Marca AS NomeMarca,
        Motorizacao.Potencia AS NomePotencia,
        TipoCarroceria.Tipo AS NomeCarroceria,
        E.Ano,                -- Adiciona o ano
        E.Placa,             -- Adiciona a placa
        E.Cor,               -- Adiciona a cor
        E.Detalhes,          -- Adiciona os detalhes
        CASE 
            WHEN E.MotorTurbo = 1 THEN 1  -- Assumindo que 1 indica que é turbo
            ELSE 0
        END AS MotorTurbo,    -- Adiciona se é turbo
        E.Valor AS Valor,
        E.Disponivel
    FROM EstoqueCarro E
    INNER JOIN Modelo M ON E.IdModelo = M.IdModelo
    INNER JOIN Marca ON M.IdMarca = Marca.IdMarca
    INNER JOIN Motorizacao ON M.IdMotorizacao = Motorizacao.IdMotorizacao
    INNER JOIN TipoCarroceria ON M.IdTipoCarroceria = TipoCarroceria.IdTipoCarroceria
    WHERE E.IdEstoqueCarro = @IdEstoqueCarro;  -- Filtra pelo ID fornecido
END
GO
/****** Object:  StoredProcedure [dbo].[ListarMarcaPorId]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarMarcaPorId]
    @IdMarca INT
AS
/*
Documentação:
Arquivo Fonte.....: ListarMarcaPorId.sql
Objetivo..........: Listar a marca disponível na tabela Marcas pelo ID.
Autor.............: Moises
Data..............: 21/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarMarcaPorId] @IdMarca = 1 -- Para listar a marca com ID 1
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna a marca da tabela Marca pelo ID
    SELECT IdMarca, Marca
    FROM Marca
    WHERE IdMarca = @IdMarca;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarModeloPorId]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarModeloPorId]
    @IdModelo INT
AS
/*
Documentação:
Arquivo Fonte.....: ListarModeloPorId.sql
Objetivo..........: Listar os detalhes do modelo disponível na tabela Modelo pelo ID.
Autor.............: Moises
Data..............: 23/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarModeloPorId] @IdModelo = 1 -- Para listar o modelo com ID 1
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna todos os detalhes do modelo com as respectivas marcas, motorização e carroceria pelo ID
    SELECT 
        M.IdModelo,
        M.Modelo AS NomeModelo,
        M.IdMarca,  -- Adicionando IdMarca
        Marca.Marca AS NomeMarca,
        M.IdTipoCarroceria,  -- Adicionando IdTipoCarroceria
        C.Tipo AS NomeCarroceria,  -- Corrigido: Adicionada palavra-chave 'AS' após 'C.Tipo'
        M.IdMotorizacao,  -- Adicionando IdMotorizacao
        Motorizacao.Potencia AS NomeMotorizacao,
        M.AnoMinimo,
        M.AnoMaximo
    FROM Modelo M
    INNER JOIN Marca ON M.IdMarca = Marca.IdMarca
    INNER JOIN Motorizacao ON M.IdMotorizacao = Motorizacao.IdMotorizacao
    INNER JOIN TipoCarroceria C ON M.IdTipoCarroceria = C.IdTipoCarroceria
    WHERE M.IdModelo = @IdModelo;  -- Filtra pelo ID do modelo
END
GO
/****** Object:  StoredProcedure [dbo].[ListarModelos]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListarModelos]
    @NomeModelo VARCHAR(255) = NULL -- Parâmetro opcional para filtrar pelo nome do modelo
AS
/*
Documentação:
Arquivo Fonte.....: ListarModelos.sql
Objetivo..........: Listar todos os modelos disponíveis ou filtrar por nome.
Autor.............: Moises
Data..............: 03/11/2024

Exemplo de Uso:
EXEC [dbo].[ListarModelos] -- Para listar todos os modelos
EXEC [dbo].[ListarModelos] @NomeModelo = 'Nome do Modelo' -- Para buscar um modelo específico
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna todos os modelos ou filtra pelo nome do modelo, se fornecido
    SELECT 
        M.IdModelo,
        M.Modelo AS NomeModelo,
        TipoCarroceria.Tipo AS NomeCarroceria,
        Motorizacao.Potencia AS NomeMotorizacao
    FROM Modelo M
    INNER JOIN Marca ON M.IdMarca = Marca.IdMarca
    INNER JOIN Motorizacao ON M.IdMotorizacao = Motorizacao.IdMotorizacao
    INNER JOIN TipoCarroceria ON M.IdTipoCarroceria = TipoCarroceria.IdTipoCarroceria
    WHERE (@NomeModelo IS NULL OR M.Modelo = @NomeModelo); -- Filtra se o nome do modelo for fornecido
END
GO
/****** Object:  StoredProcedure [dbo].[ListarPotenciaPorId]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create     PROCEDURE [dbo].[ListarPotenciaPorId]
    @IdMotorizacao INT -- Parâmetro de entrada para o ID da motorização
AS
/*
Documentação:
Arquivo Fonte.....: ListarPotenciaPorId.sql
Objetivo..........: Listar a potência disponível na tabela Motorizacao com base no IdMotorizacao.
Autor.............: Moises
Data..............: 30/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarPotenciaPorId] @IdMotorizacao = 1 -- Para listar a potência com ID 1
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna a potência da tabela Motorizacao com base no IdMotorizacao fornecido
    SELECT IdMotorizacao, Potencia
    FROM Motorizacao
    WHERE IdMotorizacao = @IdMotorizacao;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodasCarrocerias]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarTodasCarrocerias]
AS
/*
Documentação:
Arquivo Fonte.....: ListarTodasCarrocerias.sql
Objetivo..........: Listar todas as carrocerias disponíveis na tabela Carroceria.
Autor.............: Moises
Data..............: 25/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarTodasCarrocerias] -- Para listar todas as carrocerias
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna todas as carrocerias da tabela Carroceria
    SELECT IdTipoCarroceria, Tipo
    FROM TipoCarroceria;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodasMarcas]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListarTodasMarcas]
AS
/*
Documentação:
Arquivo Fonte.....: ListarTodasMarcas.sql
Objetivo..........: Listar todas as marcas disponíveis na tabela Marcas.
Autor.............: Moises
Data..............: 17/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarTodasMarcas] -- Para listar todas as marcas
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna todas as marcas da tabela Marcas
    SELECT IdMarca, Marca
    FROM Marca;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodasPotencia]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[ListarTodasPotencia]
AS
/*
Documentação:
Arquivo Fonte.....: ListarTodasPotencias.sql
Objetivo..........: Listar todas as potência disponíveis na tabela Motorizacao.
Autor.............: Moises
Data..............: 25/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarTodasPotencia] -- Para listar todas as potências
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna todas as potências da tabela Motorizacao
    SELECT IdMotorizacao, Potencia
    FROM Motorizacao;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodoEstoque]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarTodoEstoque]
AS 
/*
Documentação:
Arquivo Fonte.....: ListarTodoEstoque.sql
Objetivo..........: Listar os veículos disponíveis na tabela EstoqueCarro.
Autor.............: Moises
Data..............: 01/11/2024

Exemplo de Uso:
EXEC [dbo].[ListarTodoEstoque] -- Para listar os veículos disponíveis em estoque
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna todos os veículos disponíveis em estoque com suas respectivas marcas, motorização e carroceria
    SELECT 
        E.IdEstoqueCarro AS IdEstoque,
        M.Modelo AS NomeModelo,
        Marca.Marca AS NomeMarca,
        Motorizacao.Potencia AS NomePotencia,
        TipoCarroceria.Tipo AS NomeCarroceria,
        E.Ano,                -- Adiciona o ano
        E.Placa,             -- Adiciona a placa
        E.Cor,               -- Adiciona a cor
        E.Detalhes,          -- Adiciona os detalhes
        CASE 
            WHEN E.MotorTurbo = 1 THEN 1  -- Assumindo que 1 indica que é turbo
            ELSE 0
        END AS MotorTurbo,    -- Adiciona se é turbo
        E.Valor AS Valor,
        E.Disponivel
    FROM EstoqueCarro E
    INNER JOIN Modelo M ON E.IdModelo = M.IdModelo
    INNER JOIN Marca ON M.IdMarca = Marca.IdMarca
    INNER JOIN Motorizacao ON M.IdMotorizacao = Motorizacao.IdMotorizacao
    INNER JOIN TipoCarroceria ON M.IdTipoCarroceria = TipoCarroceria.IdTipoCarroceria
    WHERE E.Disponivel = 1;  -- Filtra para trazer apenas os carros disponíveis
END
GO
/****** Object:  StoredProcedure [dbo].[ListartodosCiente]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListartodosCiente]
    @IdCliente INT = NULL  -- Parâmetro opcional
AS
/*
Documentação:
Arquivo Fonte.....: ListartodosCiente.sql
Objetivo..........: Listar todos os clientes ativos, ou um específico, pelo id.
Data..............: 08/11/2024

Exemplos de Uso:
EXEC [dbo].[ListartodosCiente] @IdCliente = 1 -- Para listar telefone de um cliente específico
EXEC [dbo].[ListartodosCiente] -- Para listar todos os clientes ativos
*/

BEGIN
    SET NOCOUNT ON;

    -- Se @IdCliente é NULL, retorna todos os clientes ativos
    -- Caso contrário, retorna apenas o cliente ativo específico
    SELECT IdCliente, CPF, Nome, DataNascimento
    FROM Cliente
    WHERE (@IdCliente IS NULL OR IdCliente = @IdCliente)
      AND Ativo = 1; -- Adiciona a condição de que o cliente deve estar ativo (Ativo = 1)
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodosEmail]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[ListarTodosEmail]
    @IdCliente INT = NULL  -- Parâmetro opcional
AS
/*
Documentação:
Arquivo Fonte.....: ListarTodosEmail.sql
Objetivo..........: Listar todos os email ou os email de um cliente específico, se um Id for fornecido.
Autor.............: Moises
Data..............: 08/11/2024

Exemplos de Uso:
EXEC [dbo].[ListarTodosEmail] @IdCliente = 1 -- Para listar email de um cliente específico
EXEC [dbo].[ListarTodosEmail] -- Para listar todos os emails
*/

BEGIN
    SET NOCOUNT ON;

    -- Se @IdCliente é NULL, retorna todos os email
    -- Caso contrário, retorna apenas os email do cliente específico
    SELECT IdEmail, Email
    FROM Email
    WHERE @IdCliente IS NULL OR IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodosEndereco]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[ListarTodosEndereco]
    @IdCliente INT = NULL  -- Parâmetro opcional
AS
/*
Documentação:
Arquivo Fonte.....: ListarTodosendereco.sql
Objetivo..........: Listar todos os endereco ou os email de um endereco específico, se um Id for fornecido.
Autor.............: Moises
Data..............: 08/11/2024

Exemplos de Uso:
EXEC [dbo].[ListarTodosEmail] @IdCliente = 1 -- Para listar endereco de um clienderecoente específico
EXEC [dbo].[ListarTodosEmail] -- Para listar todos os endereco
*/

BEGIN
    SET NOCOUNT ON;

    -- Se @IdCliente é NULL, retorna todos os endereco
    -- Caso contrário, retorna apenas os endereco do cliente específico
    SELECT IdEndereco, CEP, Rua,Numero,Bairro,Cidade,Tipo
    FROM Endereco
    WHERE @IdCliente IS NULL OR IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodosModelos]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListarTodosModelos]
AS
/*
Documentação:
Arquivo Fonte.....: ListarTodosModelos.sql
Objetivo..........: Listar todos os modelos disponíveis na tabela Modelo.
Autor.............: Moises
Data..............: 23/10/2024

Exemplo de Uso:
EXEC [dbo].[ListarTodosModelos] -- Para listar todos os modelos
*/

BEGIN
    SET NOCOUNT ON;

    -- Retorna todos os modelos com as respectivas marcas, motorização e carroceria
    SELECT 
        M.IdModelo,
        M.Modelo AS NomeModelo,
        Marca.Marca AS NomeMarca,
        Motorizacao.Potencia AS NomeMotorizacao,
        TipoCarroceria.Tipo AS NomeCarroceria,
        M.AnoMinimo,
        M.AnoMaximo
    FROM Modelo M
    INNER JOIN Marca ON M.IdMarca = Marca.IdMarca
    INNER JOIN Motorizacao ON M.IdMotorizacao = Motorizacao.IdMotorizacao
    INNER JOIN TipoCarroceria ON M.IdTipoCarroceria = TipoCarroceria.IdTipoCarroceria;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTodosTelefone]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[ListarTodosTelefone]
    @IdCliente INT = NULL  -- Parâmetro opcional
AS
/*
Documentação:
Arquivo Fonte.....: ListarTodosTelefone.sql
Objetivo..........: Listar todos os telefone de um cliente específico, se um Id for fornecido.
Autor.............: Moises
Data..............: 08/11/2024

Exemplos de Uso:
EXEC [dbo].[ListarTodosTelefone] @IdCliente = 1 -- Para listar telefone de um cliente específico
EXEC [dbo].[ListarTodosTelefone] -- Para listar todos os telefone
*/

BEGIN
    SET NOCOUNT ON;

    -- Se @IdCliente é NULL, retorna todos os telefone
    -- Caso contrário, retorna apenas os telefone do cliente específico
    SELECT IdTelefone,Numero,Tipo,DDD
    FROM Telefone
    WHERE (@IdCliente IS NULL OR IdCliente = @IdCliente);
END
GO
/****** Object:  StoredProcedure [dbo].[ListarVendas]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarVendas]
AS
/*
Documentação
Arquivo Fonte.....: ListarVendas.sql
Objetivo..........: Listar todas as vendas com o modelo do carro, tipo de carroceria, motorização, 
                     data da venda e o nome do cliente associado a cada venda.
Autor.............: [Seu Nome]
Data..............: [22/11/2024]
Ex................: EXEC [dbo].[ListarVendas]
*/

BEGIN
    -- Seleciona as vendas com o modelo do carro, tipo de carroceria, motorização, data da venda
    -- o nome do cliente e os IDs da venda e do cliente
    SELECT 
        V.IdVenda AS IdVenda,                -- ID da venda
        C.IdCliente AS IdCliente,            -- ID do cliente
        C.Nome AS NomeCliente,               -- Nome do cliente (da tabela Cliente)
        M.Modelo AS Modelo,                  -- Nome do modelo do carro
        TC.Tipo AS TipoCarroceria,           -- Tipo de carroceria
        Mo.Potencia AS Motorizacao,          -- Potência da motorização
        V.DataVenda AS DataVenda             -- Data da venda
    FROM 
        [dbo].[Venda] V
    INNER JOIN 
        [dbo].[EstoqueCarro] EC ON V.IdEstoqueCarro = EC.IdEstoqueCarro
    INNER JOIN 
        [dbo].[Modelo] M ON EC.IdModelo = M.IdModelo
    INNER JOIN 
        [dbo].[TipoCarroceria] TC ON M.IdTipoCarroceria = TC.IdTipoCarroceria
    INNER JOIN 
        [dbo].[Motorizacao] Mo ON M.IdMotorizacao = Mo.IdMotorizacao
    INNER JOIN 
        [dbo].[Cliente] C ON V.IdCliente = C.IdCliente  -- Junção com a tabela Cliente
    WHERE 
        V.DataVenda IS NOT NULL  -- Exclui vendas onde a DataVenda é nula
        AND V.Disponivel IS NULL  -- Exclui vendas onde Disponivel não é nulo
    ORDER BY 
        V.DataVenda DESC; -- Ordena pelas vendas mais recentes
END
GO
/****** Object:  StoredProcedure [dbo].[VerificarMarcaAssociadaAModelos]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerificarMarcaAssociadaAModelos]
    @IdMarca INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifica se existe algum modelo associado à marca
    IF EXISTS (
        SELECT 1
        FROM Modelo
        WHERE IdMarca = @IdMarca
    )
    BEGIN
        -- Retorna 1 se a marca estiver associada a algum modelo
        RETURN 1;
    END
    ELSE
    BEGIN
        -- Retorna 0 se a marca não estiver associada a nenhum modelo
        RETURN 0;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[VerificarModeloEmEstoque]    Script Date: 02/04/2025 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create      PROCEDURE [dbo].[VerificarModeloEmEstoque]
    @IdModelo INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifica se existe algum registro de estoque para o modelo
    IF EXISTS (
        SELECT 1
        FROM EstoqueCarro
        WHERE IdModelo = @IdModelo
    )
    BEGIN
        -- Retorna 1 se o modelo estiver em estoque
        RETURN 1;
    END
    ELSE
    BEGIN
        -- Retorna 0 se o modelo não estiver em estoque
        RETURN 0;
    END
END
GO
USE [master]
GO
ALTER DATABASE [Concessionaria] SET  READ_WRITE 
GO

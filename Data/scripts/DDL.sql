drop table Reservas
drop table Cadastro
drop table Sala
drop table Bloco
drop table Usuario

CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeUsuario VARCHAR(255) NOT NULL,
    Privilegio INT NULL
);

--Usuario and Cadastro 1.1

CREATE TABLE Cadastro(
    Matricula INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
    Email VARCHAR(255) NOT NULL,
    Senha VARCHAR(255) NOT NULL,
    DataCadastro date
);

CREATE TABLE Sala(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdBloco INT NOT NULL FOREIGN KEY (IdBloco) REFERENCES Bloco(Id),
    Status INT NOT NULL,
    Descricao VARCHAR(255)
)

--Sala and Bloco N.1

CREATE TABLE Bloco(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(255)
)

--Reservas and Sala 1.N

CREATE TABLE Reservas(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdSala INT NOT NULL FOREIGN KEY (IdSala) REFERENCES Sala(Id),
    IdSolicitante INT NOT NULL FOREIGN KEY (IdSolicitante) REFERENCES Usuario(Id),
    IdAprovador INT NULL FOREIGN KEY (IdAprovador) REFERENCES Usuario(Id),
    Status INT NULL,
    PeriodoReserva VARCHAR(255) NULL
)





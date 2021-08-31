Create DataBase M_Rental;
Go

Use M_Rental;
Go

Create Table Empresa(
IdEmpresa Int Primary Key Identity(1,1),
Nome_Empresa Varchar(20) Not Null Unique
);
Go

Create Table Veiculo(
IdVeiculo Int Primary Key Identity(1,1),
IdEmpresa Int Foreign Key References Empresa(IdEmpresa),
Placa Char(7) Not Null Unique
);
Go

Create Table Modelo(
IdModelo Int Primary Key Identity(1,1),
IdVeiculo Int Foreign Key References Veiculo(IdVeiculo),
Modelo_Veiculo Varchar(40) Not Null 
);
Go

Create Table Marca(
IdMarca Int Primary Key Identity(1,1),
IdModelo Int Foreign Key References Modelo(IdModelo),
Marca_Veiculo Varchar(20) Not Null
);
Go

Create Table Cliente(
IdCliente Int Primary Key Identity(1,1),
Nome Varchar(30),
Sobrenome Varchar(75),
CPF Char(11)
);
Go

Create Table Aluga(
IdAluguel Int Primary Key Identity(1,1),
IdVeiculo Int Foreign Key References Veiculo(IdVeiculo),
IdCliente Int Foreign Key References Cliente(IdCliente),
Descricao_Aluguel Varchar(200) Not Null,
Data_devolucao Varchar(15) Not Null,
Data_Emprestimo Varchar(15) Not Null
);
Go

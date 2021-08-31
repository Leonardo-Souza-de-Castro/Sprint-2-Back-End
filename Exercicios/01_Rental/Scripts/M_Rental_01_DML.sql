Use M_Rental;
Go

Insert Into Empresa(Nome_Empresa)
Values ('Rental');
Go

Insert Into Cliente(Nome, Sobrenome, CPF)
Values ('Leonardo','Souza', '11111111111'), ('Robertinho', 'Santos', '22222222222');
Go

Insert Into Veiculo(IdEmpresa, Placa)
Values(1, 'KGG3708'), (1, 'ALF8996'), (1,'NEK9305');
Go

Insert Into Modelo(IdVeiculo, Modelo_Veiculo)
Values(1,'Corsa Rebaixado'), (2, 'Uno com Escada'), (3, 'Onix');
Go

Insert Into Marca(IdModelo, Marca_Veiculo)
Values(1, 'Chevrolet'), (2,'Fiat'), (3,'Chevrolet');
Go

Insert Into Aluga(IdVeiculo, IdCliente, Descricao_Aluguel, Data_devolucao, Data_Emprestimo)
Values(1,1,'Pago a Vista', '12/05/2021', '16/04/2021'), (2,2,'Pago a Vista', '12/05/2021', '16/04/2021');
Go
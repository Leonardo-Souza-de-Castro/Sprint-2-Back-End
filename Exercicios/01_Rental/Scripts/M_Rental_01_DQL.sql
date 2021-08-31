Use M_Rental;
Go

Select * From Empresa
Select * From Cliente
Select * From Veiculo
Select * From Modelo
Select * From Marca
Select * From Aluga

Select Data_devolucao, Data_emprestimo, Descricao_Aluguel, Nome, Modelo_Veiculo
From Aluga
Inner Join Cliente
On Aluga.IdCliente = Cliente.IdCliente
Inner Join Modelo
On Aluga.IdVeiculo = Modelo.IdVeiculo;
Go

Select Nome,Data_Emprestimo, Data_devolucao, Modelo_Veiculo
From Aluga
Right Join Cliente
On Cliente.IdCliente = Aluga.IdCliente
Inner Join Modelo
On Aluga.IdVeiculo = Modelo.IdVeiculo;
Go
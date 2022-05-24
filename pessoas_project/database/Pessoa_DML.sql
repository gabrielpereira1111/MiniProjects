USE Pessoas



INSERT INTO Pessoa (Nome, CPF)
VALUES			  ('Gabriel','00000000000'),
				  ('João', '99999999999')
GO

INSERT INTO Email (Email, idPessoa)
VALUES			  ('gabriel@email.com', 1),
				  ('admin@email.com', 1),
				  ('joao@email.com', 2)
GO

INSERT INTO Telefone (numTelefone, idPessoa)
VALUES				 ('0012345678', 1),
					 ('0000000000', 1),
					 ('0099999999', 2)
GO
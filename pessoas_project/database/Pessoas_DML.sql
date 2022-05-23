USE Pessoas

INSERT INTO Pessoas (nome)
VALUES				('Gabriel'),
					('João')

INSERT INTO Telefones (Descricao, IdPessoa)
VALUES				  ('(11) 94479-8203', 1),
					  ('(11) 97494-5892', 2)

INSERT INTO Emails (Descricao, IdPessoa)
VALUES			   ('gabriel_pereira02@outlook.com.br', 1),
				   ('joao_augusto@outlook.com', 2)

INSERT INTO CNH (Descricao, IdPessoa)
VALUES			('123456789', 1),
				('987654321', 2)
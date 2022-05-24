SELECT * FROM Pessoa
SELECT * FROM Email
SELECT * FROM Telefone

SELECT Nome, Email, numTelefone FROM Pessoa 
INNER JOIN Email
ON Pessoa.idPessoa = Email.idPessoa
INNER JOIN Telefone
ON Pessoa.idPessoa = Telefone.idPessoa
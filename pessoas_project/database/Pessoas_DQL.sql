USE Pessoas

SELECT * FROM Pessoas
SELECT * FROM Emails
SELECT * FROM Telefones
SELECT * FROM CNH


SELECT P.Nome, E.Descricao as 'Email', T.Descricao as 'Telefone', C.Descricao as 'CNH' FROM Pessoas AS P
INNER JOIN Emails AS E
ON P.IdPessoa = E.IdPessoa
INNER JOIN Telefones AS T
ON P.IdPessoa = T.IdPessoa
INNER JOIN CNH AS C
ON P.IdPessoa = C.IdPessoa
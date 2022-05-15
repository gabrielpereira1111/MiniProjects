use BD_Teste;

select filmes.nome as 'Filme', generos.nome as 'Gênero'  from filmes
inner join generos
on filmes.idGenero = generos.idGenero
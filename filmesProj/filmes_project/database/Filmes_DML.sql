use BD_Teste;

insert into generos (idGenero ,nome)
			  values(1 ,'Ação'),
				    (2 ,'Aventura'),
				    (3 ,'Terror')

insert into filmes (idFilme, nome, idGenero)
values			   (1, 'Vingadores', 1),
				   (2, 'O Chamado', 3),
				   (3, 'Indiana Jones', 2)

update filmes
set nome = 'Indiana Jones e o Reino da Caveira de Cristal'
where idFilme = 3

delete from filmes where idFilme = 3
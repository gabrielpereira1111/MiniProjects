create database BD_Teste;
use BD_Teste;

create table generos (
	idGenero int not null,
	nome varchar(100) not null,
	primary key (idGenero),
)

create table filmes (
	idFilme int identity not null,
	nome varchar(100) not null,
	idGenero int not null,
	primary key (idFilme),
	foreign key (idGenero) references generos (idGenero)
)

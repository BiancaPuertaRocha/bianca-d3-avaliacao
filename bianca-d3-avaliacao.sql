create database [bianca_d3_avaliacao];
use [bianca_d3_avaliacao];

create table [user] (
	Id int not null,
	[Name] varchar(30) not null,
	[Password] varchar(MAX) not null,
	Email varchar(60) not null,
);

insert into [user] (Id, [Name], [Password], Email) values (1, 'admin', 'admin123', 'admin@email.com');

select * from [user];

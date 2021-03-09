USE MASTER
GO

CREATE DATABASE [schoolDB]
GO

USE [schoolDB]
GO

create table Student (
	id int not null primary key,
	name varchar(50) not null,
	created_date datetime not null
)
GO

insert into Student values (1, 'Edson', getdate());
insert into Student values (2, 'Cassia', getdate());
insert into Student values (3, 'Augusto', getdate());


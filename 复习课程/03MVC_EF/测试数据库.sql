if exists(select * from sys.databases where name='cc')
drop database cc
go
create database cc
go
use cc
go

--������
if exists(select * from sys.tables where name='Student')
drop table Student
go
create table Student
(
	Id int primary key identity(1001,1),
	Name varchar(10) not null,
	Sex varchar(2) not null check(Sex='��' or Sex='Ů')
)
go
insert Student values('����','��')
select * from Student
--delete Student where id=1001
update Student set Name='123',Sex='Ů' where Id=1006
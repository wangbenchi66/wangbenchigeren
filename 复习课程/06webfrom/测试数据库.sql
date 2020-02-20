if exists(select * from sys.databases where name='cc')
drop database cc
go
create database cc
go
use cc
go

--´´½¨±í
if exists(select * from sys.tables where name='Student')
drop table Student
go
create table Student
(
	Id int primary key identity(1001,1),
	Name varchar(10) not null,
	Sex varchar(2) not null check(Sex='ÄĞ' or Sex='Å®')
)
go
insert Student values('²âÊÔ','ÄĞ')
select * from Student
go
--delete Student where id=1001
--update Student set Name='123',Sex='Å®' where Id=1006
--²éÑ¯
create proc StudentSselect(@name varchar(10)='')
as
	select * from Student where Name like '%'+@name+'%'
go
exec StudentSselect
go
--Ìí¼Ó
create proc StudentInsert(@name varchar(10),@sex varchar(2))
as
	insert Student values(@name,@sex)
go
exec StudentInsert '²âÊÔ','ÄĞ'
go
--ĞŞ¸Ä
create proc StudentUpdate(@name varchar(10),@sex varchar(2),@id int)
as
	update Student set Name=@name,Sex=@sex where Id=@id
go
exec StudentUpdate '²âÊÔ','ÄĞ',1010
go
--É¾³ı
create proc StudentDelete(@id int)
as
	delete Student where Id=@id
go
exec StudentDelete 1010
go
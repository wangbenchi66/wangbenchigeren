if exists(select * from sys.databases where name='cc')
drop database cc
go
create database cc
go
use cc
go

--创建表
if exists(select * from sys.tables where name='Student')
drop table Student
go
create table Student
(
	Id int primary key identity(1001,1),
	Name varchar(10) not null,
	Sex varchar(2) not null check(Sex='男' or Sex='女')
)
go
insert Student values('测试','男')
select * from Student
--delete Student where id=1001
update Student set Name='123',Sex='女' where Id=1006
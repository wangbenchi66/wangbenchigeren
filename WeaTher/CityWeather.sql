use master
go

if exists(select * from sys.databases where name='Weather')
drop database Weather
go
create database Weather
go

use Weather
go

if exists(select * from sys.tables where name='City')
drop database City
go
create table City(
 CityID int primary key identity(1,1),
 CityName  nvarchar(20) not null,
 ParentCityName nvarchar(15) not null,
 CityCode varchar(20) not null,
 UpdateTime nvarchar(100) not null,
)

if exists(select * from sys.tables where name='CityWeather')
drop database CityWeather
go
create table CityWeather(
 ID int primary key identity(1,1),
 CityID int references City(CityID),
 shidu varchar(20) not null,
 pm25 varchar(20) not null,
 pm10 varchar(20) not null,
 quality nvarchar(2) not null,
 wendu varchar(20) not null,
 ganmao varchar(100) not null,

)
if exists(select * from sys.tables where name='forecast')
drop database forecast
go
create table  forecast(
 FID int identity(1,1) primary key,
 ID int references CityWeather(ID),
 date nvarchar(100) not null,
  high varchar(50) not null,
  low varchar(50) not null,
  ymd nvarchar(100) not null,
  week nvarchar(10) not null,
  sunrise nvarchar(100) not null,
  sunset nvarchar(100) not null,
  fx nvarchar(10) not null,
  fl nvarchar(10) not null,
  type nvarchar(5) not null,
  notice nvarchar(50)not null

)
select * from City
select * from forecast
 select type,COUNT(type) from forecast where ID=1 group by type
select * from CityWeather where ID=8

delete from City
delete from forecast
delete from CityWeather  


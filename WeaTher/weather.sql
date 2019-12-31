if exists(select * from sys.databases where name='weather')
drop database weather
go
create database weather
go

use weather
go


if exists(select * from sys.tables where name='cityInfo')
drop table cityInfo
go
create table cityInfo--������Ϣ
(
	cityInfoid int primary key identity(201,1),
	city nvarchar(20) not null,--����
	citykey nvarchar(30) not null,--������������
	parent nvarchar(20) not null,--����ʡ��
	updateTime datetime not null,--����ʱ��
	
)
if exists(select * from sys.tables where name='cityweather')
drop table cityweather
go
create table cityweather
(
	cityweatherid int primary key identity(101,1),
	shidu nvarchar(20) not null,--ʪ��
	pm25 int not null,--PM2.5
	pm10 int not null,--PM1.0
	quality nvarchar(50) not null,--��������
	wendu nvarchar(50) not null,--�¶�
	ganmao  nvarchar(200),--��ע
	cityInfoid int references cityInfo(cityInfoid)

)


if exists(select * from sys.tables where name='forecast')
drop table forecast
create table forecast --������Ϣ
(
	forecastid int identity(1,1),
	date nvarchar(20) not null,--���ڣ��գ�
	high nvarchar(30) not null,--����
	low nvarchar(30) not null,--����
	ymd datetime not null,--���ڣ������գ�
	week nvarchar(30) not null,--����
	sunrise nvarchar(30) not null,--�ճ�
	sunset nvarchar(30) not null,--����
	--aqi int not null,--api
	fx nvarchar(30) not null,--����
	fl  nvarchar(30) not null,--����
	type  nvarchar(10) not null,--�������ͣ��磩
	notice nvarchar(200),--��ע
	cityweatherid int references cityweather(cityweatherid)
)



select * from forecast
select * from cityweather
select * from cityInfo

--if exists(select * from sys.tables where name='WeatherInfo')
--drop table WeatherInfo
--create table WeatherInfo--������Ϣ�����Բ�Ҫ��
--(
--	WeatherInfo int primary key identity(301,1),
--	message nvarchar(50),
--	status int not null, --״̬
--	date varchar(50) not null,
--	time datetime not null,
--	cityInfoid int references cityInfo(cityInfoid), 
--	dataid int references cityweather(cityweatherid),
--)









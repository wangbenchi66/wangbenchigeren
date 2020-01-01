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
	CityID int primary key identity(1,1),
	city nvarchar(20) not null,--����
	citykey nvarchar(30) not null,--������������
	parent nvarchar(20) not null,--����ʡ��
	updateTime nvarchar(100) not null,--����ʱ��
	
)
if exists(select * from sys.tables where name='cityweather')
drop table cityweather
go
create table cityweather
(
	ID int primary key identity(1,1),
	shidu nvarchar(20) not null,--ʪ��
	pm25 float not null,--PM2.5
	pm10 float not null,--PM1.0
	quality nvarchar(50) not null,--��������
	wendu nvarchar(50) not null,--�¶�
	ganmao  nvarchar(200),--��ע
	CityID int references cityInfo(CityID)

)


if exists(select * from sys.tables where name='forecast')
drop table forecast
create table forecast --������Ϣ
(
	FID int primary key identity(1,1),
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
	ID int references cityweather(ID)
)



select * from forecast
select * from cityweather
select * from cityInfo

--delete forecast delete cityweather delete cityInfo
--��������
select  f.type name,COUNT(f.type) value from forecast f  group by f.type
--����
select  f.fx name,COUNT(f.fx) value from forecast f  group by f.fx

SELECT   forecast.type,COUNT(forecast.type) data
FROM      dbo.cityInfo INNER JOIN
                dbo.cityweather ON dbo.cityInfo.CityID = dbo.cityweather.CityID INNER JOIN
                dbo.forecast ON dbo.cityweather.ID = dbo.forecast.ID group by type

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









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
create table cityInfo--城市信息
(
	CityID int primary key identity(1,1),
	city nvarchar(20) not null,--城市
	citykey nvarchar(30) not null,--城市天气代码
	parent nvarchar(20) not null,--所属省份
	updateTime nvarchar(100) not null,--更新时间
	
)
if exists(select * from sys.tables where name='cityweather')
drop table cityweather
go
create table cityweather
(
	ID int primary key identity(1,1),
	shidu nvarchar(20) not null,--湿度
	pm25 float not null,--PM2.5
	pm10 float not null,--PM1.0
	quality nvarchar(50) not null,--空气质量
	wendu nvarchar(50) not null,--温度
	ganmao  nvarchar(200),--备注
	CityID int references cityInfo(CityID)

)


if exists(select * from sys.tables where name='forecast')
drop table forecast
create table forecast --具体信息
(
	FID int primary key identity(1,1),
	date nvarchar(20) not null,--日期（日）
	high nvarchar(30) not null,--高温
	low nvarchar(30) not null,--低温
	ymd datetime not null,--日期（年月日）
	week nvarchar(30) not null,--星期
	sunrise nvarchar(30) not null,--日出
	sunset nvarchar(30) not null,--日落
	--aqi int not null,--api
	fx nvarchar(30) not null,--风速
	fl  nvarchar(30) not null,--风力
	type  nvarchar(10) not null,--天气类型（晴）
	notice nvarchar(200),--备注
	ID int references cityweather(ID)
)



select * from forecast
select * from cityweather
select * from cityInfo

--delete forecast delete cityweather delete cityInfo
--天气类型
select  f.type name,COUNT(f.type) value from forecast f  group by f.type
--风向
select  f.fx name,COUNT(f.fx) value from forecast f  group by f.fx

SELECT   forecast.type,COUNT(forecast.type) data
FROM      dbo.cityInfo INNER JOIN
                dbo.cityweather ON dbo.cityInfo.CityID = dbo.cityweather.CityID INNER JOIN
                dbo.forecast ON dbo.cityweather.ID = dbo.forecast.ID group by type

--if exists(select * from sys.tables where name='WeatherInfo')
--drop table WeatherInfo
--create table WeatherInfo--总体信息（可以不要）
--(
--	WeatherInfo int primary key identity(301,1),
--	message nvarchar(50),
--	status int not null, --状态
--	date varchar(50) not null,
--	time datetime not null,
--	cityInfoid int references cityInfo(cityInfoid), 
--	dataid int references cityweather(cityweatherid),
--)









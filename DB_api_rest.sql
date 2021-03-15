CREATE DATABASE DB_API_REST
GO
USE DB_API_REST
GO
CREATE TABLE Product(
Id int not null primary key identity(1,1),
Name nvarchar(50) not null,
Description nvarchar(100) not null,
Price money not null
)
GO
INSERT INTO	Product(Name,Description,Price)
VALUES ('PlayStation 5', 'La ultima de las versiones', 1200),
	   ('SmartTv Samsung 65 pulgadas', 'Alta tele', 500),
	   ('Moto G7 power', 'Dura bastante la batería', 300),
	   ('Notebook HP 12 RAM I7 7th gen', 'Le falta gráfica no más', 850),
	   ('Ventilador Liliana', 'pal verano', 10)
GO
select *from Product
create database Brive_Prueba_

use Brive_Prueba_

create table productos(
Id int primary key identity (1,1) not null,
Nombre varchar (30) not null, 
Codigo_Barras int not null,
Cantidad int not null,
Precio_Uni float not null,
Sucursal varchar(30) not  null 
)

create proc SpObtener
as 
begin
select [Id], [Nombre], [Codigo_Barras], [Cantidad], [Precio_Uni], [Sucursal] from productos
end


exec SpObtener

create proc SpObtenerId(@id int)
as 
begin 
select [Id], [Nombre], [Codigo_Barras], [Cantidad], [Precio_Uni],[sucursal]  from productos where Id=@id
end

exec SpObtenerId 2


create proc SpAgregar (@nombre varchar(50), @cod_barras int, @canti int, @precio float, @suc varchar(50))
as
begin
insert into productos values (@nombre, @cod_barras, @canti , @precio, @suc)
end



-------------------------------------------------------------------

alter proc SpEditar ( @nombre varchar(50), @cod_barras int, @canti int, @precio float, @suc varchar(50),@id int)
as
begin
update productos set Nombre=@nombre, Codigo_Barras=@cod_barras, Cantidad=@canti, Precio_Uni=@precio, Sucursal=@suc where Id=@id
end

SpEditar 'Sabritas', 11103, 50, 100.00, 'Sucursal A', 1


create proc SpEliminar(@id int)
as
begin
delete productos where Id=@id
end

SpEliminar 1

alter proc SpBuscar (@valor varchar(50))
as
begin
select * from productos WHERE Nombre like '%'+@valor+'%' or Sucursal like '%'+@valor+'%' 
end
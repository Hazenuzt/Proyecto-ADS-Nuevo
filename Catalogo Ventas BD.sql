use master

create database Catalogo_Ventas
go
use Catalogo_Ventas
go

create table Usuarios(
	Id_Usuario int primary key identity,
	Nombre varchar (100) not null,
	Username varchar (75) not null,
	Contra varchar (100) not null, 
	tipoUsuario varchar (75) not null,

	constraint chk_tipoUsuario check (tipoUsuario in ('Cliente', 'Administrador'))
);
go

create table Marca(
	Id_Marca int primary key identity,
	Nombre varchar (75) not null,
);
go

create table Proveedores(
	Id_Proveedor int primary key identity,
	Nombre varchar (100) not null,
	Telefono varchar (25) not null,
	Direccion varchar (max) not null
);
go

create table Vehiculo(
	Id_Vehiculo int primary key identity,
	Id_Marca int,
	Id_Proveedor int,
	Modelo varchar (50) not null,
	Año int not null,

	foreign key (Id_Marca) references Marca(Id_Marca)
	on delete cascade
	on update cascade,
	foreign key (Id_Proveedor) references Proveedores(Id_Proveedor)
	on delete cascade
	on update cascade
);
go

create table Detalle_Vehiculo(
	Id_Detalle int primary key identity,
	Id_Vehiculo int,
	Motor varchar(25) not null,
	Cilindra varchar (25) not null,
	Tipo_combustible varchar (50) not null,
	Transmision varchar (50) not null,
	Kilometraje decimal (10,2),
	Color varchar (75) not null,
	Descripcion varchar (max),

	foreign key (Id_Vehiculo) references Vehiculo(Id_Vehiculo)
	on delete cascade
	on update cascade,
	constraint chk_Tipo_Combustible check (Tipo_Combustible in ('gasolina', 'diesel', 'electrico')),
	constraint chk_Transmision check (Transmision in ('CVT', 'ATF', 'Manual'))
);
go

create table Imagenes_Vehiculo(
	Id_Imagen int primary key identity,
	Id_Vehiculo int,
	Ruta_Imagen varchar (max) not null,

	foreign key (Id_Vehiculo) references Vehiculo (Id_Vehiculo)
);
go

--
insert into Usuarios values
('Admin', 'adminads', 'admin1234', 'Administrador'),
('User', 'usuarioads', 'usuario1234', 'Cliente')
go


create view VistaCliente
as
	select Id_Detalle, DV.Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion, Ruta_Imagen
	from [Detalle_Vehiculo] DV inner join [Imagenes_Vehiculo] IV
	on DV.Id_Vehiculo = IV.Id_Vehiculo
go

select * from Usuarios
SELECT tipoUsuario FROM Usuarios WHERE Username = 'adminads' AND Contra = 'admin1234'


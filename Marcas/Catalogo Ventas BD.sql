use master
GO
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
	Id_Proveedor int primary key,
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
	on delete cascade
	on update cascade,
);
go

create view VistaCliente
as
	select DV.Id_Detalle, DV.Id_Vehiculo, DV.Motor, DV.Cilindra, DV.Tipo_combustible, 
	DV.Transmision, DV.Kilometraje, DV.Color, DV.Descripcion, IV.Ruta_Imagen,
	V.Modelo, V.Año, M.Nombre as NombreMarca, M.Id_Marca,
	P.Nombre as NombreProveedor, P.Id_Proveedor
	from [Detalle_Vehiculo] DV 
	inner join [Vehiculo] V on DV.Id_Vehiculo = V.Id_Vehiculo
	inner join [Marca] M on V.Id_Marca = M.Id_Marca
	inner join [Proveedores] P on V.Id_Proveedor = P.Id_Proveedor
	inner join [Imagenes_Vehiculo] IV on DV.Id_Vehiculo = IV.Id_Vehiculo
go


insert into Usuarios values
('Admin', 'adminads', 'admin1234', 'Administrador'),
('User', 'usuarioads', 'usuario1234', 'Cliente')
go
--
INSERT INTO Marca(Nombre)
VALUES
('Toyota'),
('Nissan'),
('Mitsubishi'),
('Subaru'),
('Mazda');

INSERT INTO Proveedores values 
(101, 'Proveedor Toyota', '2269-8547', 'San José'),
(102, 'Proveedor Nissan', '2895-2237', 'Los Angeles'),
(103, 'Proveedor Mitsubishi', '2036-5699', 'Maracaibo'),
(104, 'Proveedor Subaru', '2111-8548', 'Nagasaki'),
(105, 'Proveedor Mazda', '2365-2145', 'Denver')

INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(1, 101, 'Corolla', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(1, 101, 'RAV4', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(1, 101, 'Camry', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(1, 101, 'Tacoma', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(2, 102, 'Qashqai', 2022);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(2, 102, 'Kicks', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(2, 102, 'Sentra', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(2, 102, 'Frontier', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(3, 103, 'Outlander', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(3, 103, 'ASX', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(3, 103, 'L200', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(3, 103, 'Mirage', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(4, 104, 'Forester', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(4, 104, 'XV Crosstrek', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(4, 104, 'Impreza', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(4, 104, 'Outback', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(5, 105, 'CX-5', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(5, 105, 'Mazda3', 2024);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(5, 105, 'CX-30', 2023);
INSERT INTO Vehiculo (Id_Marca, Id_Proveedor, Modelo, Año) VALUES
(5, 105, 'MX-5 Miata', 2024);


INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Corolla' AND Año = 2023), '1.8L 4-cylinder', '1798cc', 'gasolina', 'CVT', 1500.25, 'Blanco Perla', 'Vehículo compacto eficiente y confiable, ideal para la ciudad y carretera.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'RAV4' AND Año = 2024), '2.5L 4-cylinder', '2487cc', 'gasolina', 'ATF', 750.00, 'Plata Metálico', 'SUV versátil y popular, perfecta para aventuras urbanas y viajes familiares.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Camry' AND Año = 2023), '2.5L 4-cylinder', '2487cc', 'gasolina', 'ATF', 12000.50, 'Negro Medianoche', 'Sedán elegante y espacioso, conocido por su fiabilidad y confort.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Tacoma' AND Año = 2024), '3.5L V6', '3456cc', 'gasolina', 'ATF', 200.00, 'Gris Cemento', 'Camioneta robusta y potente, ideal para trabajo y aventura.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Qashqai' AND Año = 2022), '1.3L Turbo', '1332cc', 'gasolina', 'ATF', 25000.75, 'Gris Oscuro', 'SUV compacto con excelente rendimiento y tecnología avanzada.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Kicks' AND Año = 2023), '1.6L 4-cylinder', '1598cc', 'gasolina', 'CVT', 9000.00, 'Naranja Eléctrico', 'Crossover subcompacto con estilo juvenil y eficiente consumo de combustible.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Sentra' AND Año = 2024), '2.0L 4-cylinder', '1997cc', 'gasolina', 'CVT', 1500.00, 'Blanco Puro', 'Sedán compacto con diseño moderno y gran equipamiento de seguridad.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Frontier' AND Año = 2023), '2.5L 4-cylinder', '2488cc', 'diesel', 'Manual', 30000.00, 'Negro Perla', 'Pick-up robusta y confiable, ideal para el trabajo pesado y aventura.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Outlander' AND Año = 2024), '2.5L MIVEC', '2488cc', 'gasolina', 'CVT', 500.00, 'Rojo Diamante', 'Espaciosa SUV ideal para la familia, con tracción en las cuatro ruedas.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'ASX' AND Año = 2023), '2.0L 4-cylinder', '1998cc', 'gasolina', 'CVT', 18000.25, 'Gris Titanio', 'Crossover compacto y ágil, perfecto para la ciudad con un diseño moderno.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'L200' AND Año = 2024), '2.4L MIVEC Diesel', '2442cc', 'diesel', 'Manual', 5000.00, 'Blanco Polar', 'Pick-up robusta y versátil, ideal para el trabajo pesado y la aventura.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Mirage' AND Año = 2023), '1.2L 3-cylinder', '1193cc', 'gasolina', 'CVT', 10000.00, 'Azul Eléctrico', 'Compacto urbano ultra eficiente en consumo de combustible.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Forester' AND Año = 2023), '2.5L Boxer', '2498cc', 'gasolina', 'CVT', 10000.50, 'Azul Marino', 'SUV versátil con tracción simétrica y gran capacidad todoterreno.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'XV Crosstrek' AND Año = 2024), '2.0L Boxer', '1995cc', 'gasolina', 'CVT', 3000.00, 'Caqui Desierto', 'Crossover compacto con tracción integral y estilo aventurero.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Impreza' AND Año = 2023), '2.0L Boxer', '1995cc', 'gasolina', 'CVT', 7500.00, 'Blanco Cristal', 'Sedán compacto y confiable con tracción integral estándar.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Outback' AND Año = 2024), '2.5L Boxer', '2498cc', 'gasolina', 'CVT', 1000.00, 'Verde Otoño', 'Wagon crossover robusto y espacioso, ideal para la aventura y la familia.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'CX-5' AND Año = 2023), '2.5L Skyactiv-G', '2488cc', 'gasolina', 'ATF', 8000.10, 'Gris Polymetal', 'SUV elegante con un diseño distintivo y una experiencia de conducción dinámica.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Mazda3' AND Año = 2024), '2.5L Skyactiv-G', '2488cc', 'gasolina', 'ATF', 2000.00, 'Rojo Alma', 'Sedán compacto con diseño sofisticado y manejo deportivo.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'CX-30' AND Año = 2023), '2.5L Skyactiv-G', '2488cc', 'gasolina', 'ATF', 6000.75, 'Azul Marino', 'Crossover compacto que combina la agilidad de un auto con la versatilidad de un SUV.');
INSERT INTO Detalle_Vehiculo (Id_Vehiculo, Motor, Cilindra, Tipo_combustible, Transmision, Kilometraje, Color, Descripcion) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'MX-5 Miata' AND Año = 2024), '2.0L Skyactiv-G', '1998cc', 'gasolina', 'Manual', 500.00, 'Gris Metálico', 'Deportivo convertible ligero y divertido de conducir.');



INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Corolla' AND Año = 2023), 'Marcas/Toyota/corolla_frente.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'RAV4' AND Año = 2024), 'Marcas/Toyota/rav4_delantera.jpeg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Camry' AND Año = 2023), 'Marcas/Toyota/camry_lateral.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Tacoma' AND Año = 2024), 'Marcas/Toyota/tacoma_frontal.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Qashqai' AND Año = 2022), 'Marcas/Nissan/qashqai_frente.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Kicks' AND Año = 2023), 'Marcas/Nissan/kicks_lateral.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Sentra' AND Año = 2024), 'Marcas/Nissan/sentra_frontal.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Frontier' AND Año = 2023), 'Marcas/Nissan/frontier_lateral.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Outlander' AND Año = 2024), 'Marcas/Mitsubishi/outlander_frontal.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'ASX' AND Año = 2023), 'Marcas/Mitsubishi/asx_lateral.jpeg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'L200' AND Año = 2024), 'Marcas/Mitsubishi/l200_frontal.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Mirage' AND Año = 2023), 'Marcas/Mitsubishi/mirage_lateral.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Forester' AND Año = 2023), 'Marcas/Subaru/forester_delantera.jpeg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'XV Crosstrek' AND Año = 2024), 'Marcas/Subaru/xv_crosstrek_lateral.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Impreza' AND Año = 2023), 'Marcas/Subaru/impreza_frontal.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Outback' AND Año = 2024), 'Marcas/Subaru/outback_trasera.jpeg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'CX-5' AND Año = 2023), 'Marcas/Mazda/cx5_frontal.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'Mazda3' AND Año = 2024), 'Marcas/Mazda/mazda3_lateral.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'CX-30' AND Año = 2023), 'Marcas/Mazda/cx30_frontal.jpg');
INSERT INTO Imagenes_Vehiculo (Id_Vehiculo, Ruta_Imagen) VALUES
((SELECT Id_Vehiculo FROM Vehiculo WHERE Modelo = 'MX-5 Miata' AND Año = 2024), 'Marcas/Mazda/mx5_miata_lateral.jpg');

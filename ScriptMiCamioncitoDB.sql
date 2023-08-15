 CREATE DATABASE MiCamioncitoDB;
--DROP DATABASE MiCamioncitoDB;
USE MiCamioncitoDB;

CREATE TABLE vehiculos(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	capacidad int,
	consumoConbustible int,
	distanciaPendiente int,
	disponibilidad VARCHAR(10),
	tipoCarga VARCHAR(255)
	
);

CREATE TABLE empleados(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	codigoEmpleado VARCHAR(50) UNIQUE NOT NULL,
	cui int,
	nombre VARCHAR(100),
	apellido VARCHAR(100),
	disponibilidad VARCHAR(50),
	tipoEmpleado VARCHAR(100) NOT NULL
);

CREATE TABLE clientes(
	id int  IDENTITY(1,1) NOT NULL PRIMARY KEY,
	codigoCliente VARCHAR(255) UNIQUE NOT NULL,
	nombre VARCHAR(255) NOT NULL,
	direccion VARCHAR(255) NOT NULL,
	telefono VARCHAR(255),
	documentacion VARCHAR(50),
	porcentajeCargo int
);


CREATE TABLE transacciones(
	id int  IDENTITY(1,1) PRIMARY KEY NOT NULL,
	tipoTransaccion VARCHAR ,
	idCliente int FOREIGN KEY REFERENCES clientes(id),
	fechaInicio DATETIME NOT NULL,
	fechaFin DATETIME,
	direccionRecepcion VARCHAR(255) NOT NULL,
	direccionEntrega VARCHAR(255) NOT NULL,
	idVehiculo INT FOREIGN KEY REFERENCES vehiculos(id),
	departamento VARCHAR(255),
	municipio VARCHAR(255),
	viaticos int
);

CREATE TABLE asignacionEmpleadosTransaccion(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	idEmpleado int FOREIGN KEY REFERENCES empleados(id),
	idTransaccion int FOREIGN KEY REFERENCES transacciones(id)
);

CREATE TABLE gastosAdicionalesTransaccion(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	descripcionGasto VARCHAR(255),
	costoGasto int,
	idTransaccion int FOREIGN KEY REFERENCES transacciones(id)

);
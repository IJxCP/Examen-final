
CREATE DATABASE ConstructoresAvance;
GO


USE ConstructoresAvance;
GO


CREATE TABLE Empleados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NumeroCarnet VARCHAR(50) UNIQUE NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Categoria NVARCHAR(20) CHECK (Categoria IN ('Administrador', 'Operario', 'Peón')) NOT NULL,
    Salario DECIMAL(10,2) CHECK (Salario BETWEEN 250000 AND 500000) DEFAULT 250000,
    Direccion NVARCHAR(255) DEFAULT 'San José',
    Telefono NVARCHAR(15),
    Correo NVARCHAR(100) UNIQUE NOT NULL
);
GO


CREATE TABLE Proyectos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Codigo VARCHAR(50) UNIQUE NOT NULL,
    Nombre NVARCHAR(100) UNIQUE NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL
);
GO


CREATE TABLE Asignaciones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmpleadoId INT NOT NULL FOREIGN KEY REFERENCES Empleados(Id),
    ProyectoId INT NOT NULL FOREIGN KEY REFERENCES Proyectos(Id),
    FechaAsignacion DATE NOT NULL,
    CONSTRAINT UC_EmpleadoProyecto UNIQUE (EmpleadoId, ProyectoId)
);
GO


CREATE PROCEDURE InsertarEmpleado
    @NumeroCarnet VARCHAR(50),
    @Nombre NVARCHAR(100),
    @FechaNacimiento DATE,
    @Categoria NVARCHAR(20),
    @Salario DECIMAL(10,2) = 250000,
    @Direccion NVARCHAR(255) = 'San José',
    @Telefono NVARCHAR(15),
    @Correo NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Empleados WHERE Correo = @Correo OR NumeroCarnet = @NumeroCarnet)
    BEGIN
        THROW 50000, 'El correo o número de carnet ya existe.', 1;
    END

    INSERT INTO Empleados (NumeroCarnet, Nombre, FechaNacimiento, Categoria, Salario, Direccion, Telefono, Correo)
    VALUES (@NumeroCarnet, @Nombre, @FechaNacimiento, @Categoria, @Salario, @Direccion, @Telefono, @Correo);
END;
GO


CREATE PROCEDURE ListarEmpleados
    @Categoria NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Categoria IS NULL
        SELECT * FROM Empleados;
    ELSE
        SELECT * FROM Empleados WHERE Categoria = @Categoria;
END;
GO


CREATE PROCEDURE InsertarProyecto
    @Codigo VARCHAR(50),
    @Nombre NVARCHAR(100),
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Proyectos WHERE Codigo = @Codigo OR Nombre = @Nombre)
    BEGIN
        THROW 50000, 'El código o nombre del proyecto ya existe.', 1;
    END

    INSERT INTO Proyectos (Codigo, Nombre, FechaInicio, FechaFin)
    VALUES (@Codigo, @Nombre, @FechaInicio, @FechaFin);
END;
GO


CREATE PROCEDURE ListarProyectos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT * FROM Proyectos;
END;
GO


CREATE PROCEDURE AsignarEmpleadoAProyecto
    @EmpleadoId INT,
    @ProyectoId INT,
    @FechaAsignacion DATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Asignaciones WHERE EmpleadoId = @EmpleadoId AND ProyectoId = @ProyectoId)
    BEGIN
        THROW 50000, 'El empleado ya está asignado a este proyecto.', 1;
    END

    INSERT INTO Asignaciones (EmpleadoId, ProyectoId, FechaAsignacion)
    VALUES (@EmpleadoId, @ProyectoId, @FechaAsignacion);
END;
GO


CREATE PROCEDURE ListarEmpleadosPorProyecto
    @ProyectoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT E.Id, E.NumeroCarnet, E.Nombre, E.Categoria, A.FechaAsignacion
    FROM Asignaciones A
    INNER JOIN Empleados E ON A.EmpleadoId = E.Id
    WHERE A.ProyectoId = @ProyectoId;
END;
GO


CREATE PROCEDURE ListarProyectosPorEmpleado
    @EmpleadoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT P.Id, P.Codigo, P.Nombre, P.FechaInicio, P.FechaFin, A.FechaAsignacion
    FROM Asignaciones A
    INNER JOIN Proyectos P ON A.ProyectoId = P.Id
    WHERE A.EmpleadoId = @EmpleadoId;
END;
GO

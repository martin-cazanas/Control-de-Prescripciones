-- USE MASTER
USE CTRL_PRES
GO

CREATE PROCEDURE CONSULTAR_DIVISIONES 
AS BEGIN
    SELECT Nombre FROM Analistas
    WHERE Jefe = 1 AND Estatus = 1
    ORDER BY Nombre
END
GO

CREATE PROCEDURE INSERTAR_SIDEC
    @pieza VARCHAR(50),
    @promovente VARCHAR(MAX),
    @denunciado VARCHAR(MAX),
    @expediente VARCHAR(30),
    @folio VARCHAR(20),
    @clave VARCHAR(50),
    @analista NUMERIC,
    @division NUMERIC,
    @concluido BIT,
    @estatus NUMERIC,
    @narracion VARCHAR(MAX),
    @clasificacion NUMERIC,
    @tipo NUMERIC,
    @conclusion VARCHAR(7),
    @recepcion SMALLDATETIME,
    @ultimo SMALLDATETIME
AS BEGIN
    INSERT INTO SIDEC
    VALUES(@pieza, @promovente, @denunciado, @expediente, @folio, @clave, @analista, @division, @concluido,
        @estatus, @narracion, @clasificacion, @tipo, @conclusion, @recepcion, GETDATE(), @ultimo)
END
GO

CREATE PROCEDURE INSERTAR_ANALISTA
    @nombre VARCHAR(100),
    @usuario VARCHAR(25),
    @jefe BIT, 
    @division NUMERIC
AS BEGIN
    IF(@jefe = 1) BEGIN
        INSERT INTO Analistas(Nombre, Usuario, Jefe)
        VALUES(@nombre, @usuario, @jefe)
        SET @division = (SELECT TOP 1 ID FROM Analistas ORDER BY ID DESC)
        UPDATE Analistas
        SET Division = @division
        WHERE ID = @division
    END
    ELSE
        INSERT INTO Analistas
        VALUES(@nombre, @usuario, @jefe, @division,1)
END
GO

CREATE PROCEDURE GET_DIVISION_ID
    @nombre VARCHAR(100)
AS BEGIN
    SELECT ID FROM Analistas
    WHERE Nombre = @nombre
END
GO

CREATE PROCEDURE CONSULTAR_ANALISTAS
    @division NUMERIC
AS BEGIN
    SELECT * FROM Analistas
    WHERE Division = @division AND Estatus = 1
    ORDER BY Jefe DESC, Nombre
END
GO

CREATE PROCEDURE INSERTAR_ESTATUS
    @descripcion VARCHAR(100),
    @tipo BIT
AS BEGIN
    IF NOT EXISTS (SELECT * FROM Estatus WHERE DESCRIPCION = @descripcion AND Tipo = @tipo)
    INSERT INTO Estatus
    VALUES(@descripcion, @tipo)
END
GO

CREATE PROCEDURE CONSULTAR_ESTATUS
    @tipo BIT
 AS BEGIN
    SELECT ID, Descripcion FROM Estatus 
    WHERE Tipo = @tipo
    ORDER BY Descripcion
END
GO

CREATE PROCEDURE INSERTAR_CLASIFICACION
    @descripcion VARCHAR(100)
AS BEGIN
    IF NOT EXISTS (SELECT * FROM Clasificaciones WHERE Descripcion = @descripcion)
        INSERT INTO Clasificaciones
        VALUES(@descripcion)
END
GO

CREATE PROCEDURE CONSULTAR_CLASIFICACIONES AS BEGIN
    SELECT * FROM Clasificaciones ORDER BY Descripcion
END
GO

CREATE PROCEDURE INSERTAR_TIPO
    @descripcion VARCHAR(100)
AS BEGIN
    IF NOT EXISTS (SELECT * FROM Tipos WHERE Descripcion = @descripcion)
        INSERT INTO Tipos
        VALUES(@descripcion)
END
GO

CREATE PROCEDURE CONSULTAR_TIPO AS BEGIN
    SELECT * FROM Tipos ORDER BY Descripcion
END
GO

CREATE PROCEDURE ACTUALIZAR_CLASIFICACION
    @id NUMERIC,
    @descripcion VARCHAR(100)
AS BEGIN
    UPDATE Clasificaciones
    SET Descripcion = @descripcion
    WHERE ID = @id
END
GO

CREATE PROCEDURE ACTUALIZAR_ESTATUS
    @id NUMERIC,
    @descripcion VARCHAR(100)
AS BEGIN
    UPDATE Estatus
    SET Descripcion = @descripcion
    WHERE ID = @id
END
GO

CREATE PROCEDURE ACTUALIZAR_TIPO
    @id NUMERIC,
    @descripcion VARCHAR(100)
AS BEGIN
    UPDATE Tipos
    SET Descripcion = @descripcion
    WHERE ID = @id
END
GO

CREATE PROCEDURE GET_TIPO_ID
    @descripcion VARCHAR(100)
AS BEGIN
    SELECT ID FROM Tipos WHERE Descripcion = @descripcion
END
GO

CREATE PROCEDURE GET_CLASIFICACION_ID
    @descripcion VARCHAR(100)
AS BEGIN
    SELECT ID FROM Clasificaciones WHERE Descripcion = @descripcion
END
GO

CREATE PROCEDURE GET_ESTATUS_ID
    @descripcion VARCHAR(100)
AS BEGIN
    SELECT ID FROM Estatus WHERE Descripcion = @descripcion
END
GO

CREATE PROCEDURE EXISTE_ANALISTA
     @nombre VARCHAR(100),
     @division NUMERIC
AS BEGIN
    SELECT * FROM Analistas
    WHERE Nombre = @nombre AND Division = @division
END
GO

CREATE PROCEDURE MODIFICAR_SIDEC
    @id NUMERIC,
    @pieza VARCHAR(50),
    @promovente VARCHAR(MAX),
    @denunciado VARCHAR(MAX),
    @expediente VARCHAR(30),
    @folio VARCHAR(20),
    @clave VARCHAR(50),
    @analista NUMERIC,
    @division NUMERIC,
    @concluido BIT,
    @estatus NUMERIC,
    @narracion VARCHAR(MAX),
    @clasificacion NUMERIC,
    @tipo NUMERIC,
    @conclusion VARCHAR(7),
    @recepcion SMALLDATETIME,
    @ultimo SMALLDATETIME
AS BEGIN
    UPDATE SIDEC
    SET   Pieza = @pieza,
                Promovente = @promovente,
                Denunciado = @denunciado,
                Expediente = @expediente,
                Folio_Ciu = @folio,
                Clave = @clave,
                Analista = @analista,
                Division = @division,
                Concluido = @concluido,
                Estatus = @estatus,
                Narracion = @narracion,
                Clasificacion = @clasificacion,
                Tipo = @tipo,
                Conclusion = @conclusion,
                Recepcion = @recepcion,
                Ultimo = @ultimo
    WHERE ID = @id
END
GO

CREATE PROCEDURE CONSULTAR_ORIGENES AS
BEGIN
    SELECT * FROM Origenes
END
GO

CREATE PROCEDURE INSERTAR_ORIGEN
    @descripcion VARCHAR(100)
AS BEGIN
    IF NOT EXISTS (SELECT * FROM Origenes WHERE Descripcion = @descripcion)
        INSERT INTO Origenes
        VALUES(@descripcion)
END
GO

CREATE PROCEDURE ACTUALIZAR_ORIGEN
    @id NUMERIC,
    @descripcion VARCHAR(100)
AS BEGIN
    UPDATE Origenes
    SET Descripcion = @descripcion
    WHERE ID = @id
END
GO

CREATE PROCEDURE GET_ORIGEN_ID
    @descripcion VARCHAR(100)
AS BEGIN
    SELECT ID FROM Origenes WHERE Descripcion = @descripcion
END
GO

CREATE PROCEDURE INSERTAR_SANC
    @pieza NUMERIC,
    @denunciante VARCHAR(100),
    @denunciado VARCHAR(100),
    @origen NUMERIC, 
    @dep_org VARCHAR(50),
    @exp_org VARCHAR(30),
    @expediente VARCHAR(16),
    @analista NUMERIC,
    @division NUMERIC,
    @estatus NUMERIC,
    @narracion VARCHAR(MAX),
    @conclusion VARCHAR(7),
    @recepcion SMALLDATETIME,
    @pa VARCHAR(100)
AS BEGIN
    INSERT INTO SANC
    VALUES(@pieza, @denunciante, @denunciado, @origen, @dep_org, @exp_org, @expediente, @analista,
        @division,@estatus, @narracion, @conclusion, GETDATE(), @recepcion, @pa)
END
GO

CREATE PROCEDURE EDITAR_SANC
    @id NUMERIC,
    @pieza NUMERIC,
    @denunciante VARCHAR(100),
    @denunciado VARCHAR(100),
    @origen NUMERIC, 
    @dep_org VARCHAR(50),
    @exp_org VARCHAR(30),
    @expediente VARCHAR(16),
    @analista NUMERIC,
    @division NUMERIC,
    @estatus NUMERIC,
    @narracion VARCHAR(MAX),
    @conclusion VARCHAR(7),
    @recepcion SMALLDATETIME,
    @pa VARCHAR(100)
AS BEGIN
    UPDATE SANC
    SET 
        Pieza = @pieza,
        Denunciante = @denunciante,
        Denunciado = @denunciado,
        Origen = @origen,
        Dependencia_Origen = @dep_org,
        Expediente_Origen = @exp_org,
        Expediente = Expediente,
        Analista = @analista,
        Division = @division,
        Estatus = @estatus,
        Narracion = @narracion,
        Conclusion = @conclusion,
        Recepcion = @recepcion,
        PA = @pa
    WHERE ID = @id
END
GO

CREATE PROCEDURE ELIMINAR_SANC
    @id NUMERIC
AS BEGIN
    DELETE FROM SANC
    WHERE ID = @id
END
GO

CREATE PROCEDURE EXPEDIENTES_ACTIVOS
    @analista NUMERIC
AS BEGIN
    SELECT ID, Promovente, Denunciado, Expediente, Analista, Estatus, Conclusion
    FROM SIDEC
    WHERE Analista = @analista AND Conclusion IS NULL
    UNION ALL
    SELECT ID,  Denunciante, Denunciado, Expediente, Analista, Estatus, Conclusion
    FROM SANC
    WHERE Analista = @analista AND Conclusion IS NULL
END
GO

CREATE PROCEDURE EDITAR_ANALISTA
    @id NUMERIC,
    @nombre VARCHAR(100), 
    @usuario VARCHAR(25),
    @jefe BIT, 
    @division NUMERIC, 
    @estatus BIT
AS BEGIN
    UPDATE Analistas
    SET 
        Nombre = @nombre,
        Usuario = @usuario,
        Jefe = @jefe,
        Division = @division,
        Estatus = @estatus
    WHERE ID = @id
END
GO

CREATE PROCEDURE CONSULTAR_ANALISTAS_TURNOS
    @division NUMERIC = 0,
    @ano VARCHAR(4)
 AS BEGIN
    -- SELECT * FROM Analistas
    -- WHERE 
    --     Division = CASE WHEN ISNULL(@division, 0) <> 0 THEN @division ELSE Division END AND
    --     Estatus = 1
    -- ORDER BY Division, Jefe DESC

    SELECT DISTINCT Analista 
    FROM  Turnos 
    WHERE 
        Ano = @ano AND 
        Division = CASE WHEN ISNULL(@division, 0) = 0 THEN Division ELSE @division END
END
GO

CREATE PROCEDURE GETALL_DIVISIONES AS BEGIN
    DECLARE @division NUMERIC
    DECLARE CUR_DIVISION CURSOR FOR
        SELECT DISTINCT Division
        FROM Analistas
        WHERE Division > 0
    OPEN CUR_DIVISION
    FETCH NEXT FROM CUR_DIVISION INTO @division
    WHILE @@FETCH_STATUS = 0 BEGIN
        SELECT * FROM Analistas
        WHERE Division = @division AND
              Jefe <> 1
        FETCH NEXT FROM CUR_DIVISION INTO @division
    END
    CLOSE CUR_DIVISION
    DEALLOCATE CUR_DIVISION
END
GO

CREATE PROCEDURE AGREGAR_A_ORDEN
    @ano VARCHAR(4),
    @analista NUMERIC, 
    @division NUMERIC,
    @turno BIT
AS BEGIN
    INSERT INTO Orden
    VALUES(@ano, @analista, @division, @turno,1)
END
GO

CREATE PROCEDURE BORRAR_ORDEN
    @ano VARCHAR(4)
AS BEGIN
    DELETE FROM Orden
    WHERE Ano = @ano
END
GO

CREATE PROCEDURE PROXIMO_TURNO
    @id_actual NUMERIC,
    @id_proximo NUMERIC
AS BEGIN
    UPDATE Orden
    SET Turno = 0
    WHERE ID = @id_actual
    UPDATE Orden
    SET Turno = 1
    WHERE ID = @id_proximo
END
GO

CREATE PROCEDURE INSERTAR_TURNO
    @ano VARCHAR(4),
    @analista NUMERIC, 
    @division NUMERIC,
    @descripcion BIT
AS BEGIN
    INSERT INTO Turnos
    VALUES(@ano, @analista, @division, @descripcion)
END
GO

CREATE  PROCEDURE CONSULTAR_TURNOS
    @analista VARCHAR(100),
    @ano VARCHAR(4)
AS BEGIN
    SELECT T.* FROM Turnos T
    INNER JOIN Analistas A ON T.Analista = A.ID 
    WHERE 
        A.Nombre = @analista AND
        Ano = @ano
END
GO

CREATE PROCEDURE GET_ANOS_TURNOS AS BEGIN
    SELECT DISTINCT Ano FROM TURNOS
END
GO

CREATE PROCEDURE GET_ANALISTAS_TURNOS
    @ano VARCHAR(4)
AS BEGIN
    SELECT A.Nombre
    FROM Turnos T
    INNER JOIN Analistas A ON T.Analista = A.ID
    WHERE Ano = @ano
END
GO

CREATE PROCEDURE ACTUALIZAR_ESTATUS_ORDEN
    @id NUMERIC,
    @estatus NUMERIC
AS BEGIN
    IF EXISTS (SELECT * FROM Orden WHERE ID = @id)
        UPDATE Orden
        SET Estatus = @estatus
        WHERE ID = @id
END
GO

CREATE PROCEDURE GET_ID_ORDEN
    @nombre NUMERIC,
    @ano VARCHAR(4)
AS BEGIN
    SELECT *
    FROM Orden
    WHERE 
        Analista = @nombre AND
        Ano = @ano
END
GO

CREATE PROCEDURE GET_DIVISIONES_TURNOS
    @ano VARCHAR(4)
AS BEGIN
    SELECT DISTINCT  A.Nombre
    FROM Turnos T
    INNER JOIN Analistas A ON T.Division = A.ID
END
GO

CREATE PROCEDURE CONSULTAR_NOMBRE
    @id NUMERIC
AS BEGIN
    SELECT Nombre
    FROM Analistas
    WHERE ID = @id
END
GO

CREATE PROCEDURE CONSULTAR_DIVISION
    @nombre VARCHAR(100)
AS BEGIN
    SELECT D.Nombre
    FROM Analistas A
    INNER JOIN Analistas D ON A.Division = D.ID
    WHERE A.Nombre = @nombre
END
GO

USE CTRL_PRES
GO

CREATE VIEW PREVIA_SIDEC([NO.], [FOLIO, PROCEDENCIA O PIEZA], [FECHA DE RECEPCION], CIUDADANO, 
    DENUNCIADO, [NO. CTRL. INTERNO], [FOLIO CIUDADANO], CLAVE, ANALISTA, DIVISION, ESTATUS, [PRESUNTAS IRREGULARIDADES],
    CLASIFICACION, TIPO, [MES DE CONCLUSION], [FECHA DE ULTIMO MOVIMIENTO], [FECHA DE REGISTRO]) AS
    SELECT I.ID, I.Pieza, I.Recepcion, I.Promovente, I.Denunciado, I.Expediente, I.Folio_Ciu, I.Clave, A.Nombre,
        D.Nombre, E.Descripcion, I.Narracion, C.Descripcion, T.Descripcion, I.Conclusion, I.Ultimo, I.Registro
    FROM SIDEC I
    INNER JOIN Analistas A ON I.Analista = A.ID
    INNER JOIN Analistas D ON I.Division = D.ID
    INNER JOIN Estatus E ON I.Estatus = E.ID
    INNER JOIN Clasificaciones C ON I.Clasificacion = C.ID
    INNER JOIN Tipos T ON I.Tipo = T.ID
GO

CREATE VIEW PREVIA_SANC([NO.], [NÚMERO DE PIEZA], [FECHA DE REGISTRO], [FECHA DE RECEPCIÓN], DENUNCIANTE,
    DENUNCIADO, ORIGEN, [DEPENDENCIA DE ORIGEN], [EXPEDIENTE DE ORIGEN], [NO. DE EXPEDIENTE (INV)],
    ANALISTA, DIVISION, ESTATUS, NARRACION, [FECHA DE CONCLUSION], [PROCEDIMIENTO ADMINISTRATIVO (PA)]) AS
    SELECT S.ID, S.Pieza, S.Registro, S.Recepcion, S.Denunciante, S.Denunciado, O.Descripcion,
        S.Dependencia_Origen, S.Expediente_Origen, S.Expediente, A.Nombre, D.Nombre, E.Descripcion,
        S.Narracion, S.Conclusion, S.PA
    FROM SANC S
    INNER JOIN Origenes O ON S.Origen = O.ID
    INNER JOIN Analistas A ON S.Analista = A.ID
    INNER JOIN Analistas D ON S.Division = A.ID
    INNER JOIN Estatus E ON S.Estatus = E.ID
GO

CREATE VIEW PREVIA_ANALISTAS(ID, NOMBRE, USUARIO, DIVISIÓN, ESTATUS) AS
    SELECT A.ID, A.Nombre, A.Usuario,
        CASE WHEN A.Jefe = 1 THEN 'JEFE DE DIVISIÓN' ELSE D.Nombre END,
        CASE WHEN A.Estatus = 0 THEN 'INACTIVO' ELSE 'ACTIVO' END
    FROM Analistas A
    INNER JOIN Analistas D ON A.Division = D.ID
GO

CREATE VIEW PREVIA_ORDEN(ID, AÑO, ANALISTA, DIVISIÓN, [PRÓXIMO TURNO], ESTATUS) AS
    SELECT O.ID, O.Ano, A.Nombre, D.Nombre,
        CASE WHEN Turno = 1 THEN 'Sí' ELSE 'No' END,
        CASE
            WHEN O.Estatus = 0 THEN 'INACTIVO'
            WHEN O.Estatus = 1 THEN 'ACTIVO'
            WHEN O.Estatus = 2 THEN 'CONGELADO'
        END
    FROM Orden O
    INNER JOIN Analistas A ON O.Analista = A.ID
    INNER JOIN Analistas D ON O.Division = D.ID
GO
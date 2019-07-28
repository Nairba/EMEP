
use EMEP

SELECT * FROM Tipo_Usuario
SELECT * FROM Usuario
SELECT * FROM Especialidad
SELECT * FROM Categoria
SELECT * FROM Horario
SELECT * FROM Consultorio
SELECT * FROM Cirugia



--ESPECIALIDADES--
INSERT INTO Especialidad(descripcion) Values('Especialidad en Alergología')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Dermatología')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Cardiología')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Cirugía Cardiovascular Torácica')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Cirugía General')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Medicina Familiar y Comunitaria')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Medicina Física y Rehabilitación')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Medicina Interna')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Psiquiatría')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Psicología Clínica')
INSERT INTO Especialidad(descripcion) Values('Especialidad en Oftalmología')

--CONSULTORIO--
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Uno','1')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Dos','2')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Tres','3')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Cuatro','4')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Cinco','5')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Seis','6')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Siente','7')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Ocho','8')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Nueve','9')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Diez','10')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Once','11')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Doce','12')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Trese','13')
INSERT INTO Consultorio(descripcion,numero) VALUES('Consultorio Catorse','14')

--CONSULTA--
SELECT con.id, con.precio, u.nombre AS nombreMedico, 
u.p_Apellido AS apellido_1Medico, 
u.s_Apellido AS apellido_2Medico, 
co.descripcion AS Consultorio, es.descripcion AS Especialidad
FROM Consulta con
INNER JOIN Usuario u ON u.correoID = con.ID_MEDICO
INNER JOIN Consultorio co ON co.id = con.ID_CONSULTORIO
INNER JOIN Especialidad es ON es.id= con.ID_ESPECIALIDAD

INSERT INTO Consulta(ID_MEDICO,ID_CONSULTORIO,precio,ID_ESPECIALIDAD)
VALUES('man@gmail.com',1,20000,1)

UPDATE Consulta SET ID_MEDICO='man@gmail.com', ID_CONSULTORIO=2,precio=30000,ID_ESPECIALIDAD=1
WHERE id=1



--CIRUGIA--
SELECT 
FROM Cirugia ci
INNER JOIN 

Delete Consultorio
DBCC CHECKIDENT(Consultorio,RESEED,0)

--ELIMINAR--
Delete Consulta


--REINICIAR IDENTITY--
DBCC CHECKIDENT(Consulta,RESEED,0)
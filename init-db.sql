CREATE DATABASE ObraDB;
USE ObraDB;

CREATE TABLE Obra (
    IdPlay INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(100) NOT NULL,
    Photo NVARCHAR(100) NOT NULL,
    Price NVARCHAR(100) NOT NULL
);

CREATE TABLE Reserva (
    IdReservation INT IDENTITY(1,1) PRIMARY KEY,
    User_Email NVARCHAR (100) NOT NULL,
    ReservationPrice NVARCHAR (100) NOT NULL,
    ReservationDate NVARCHAR(500) NOT NULL
);

INSERT INTO Obra (Name, Description, Photo, Price)
    VALUES ('barro','1234567890', 'John Doe', 1000.00),
           ('barroko','1234567890', 'pepe', 2000.00),
           ('barroka','1234567890', 'pepe', 2000.00);

 
 INSERT INTO Reserva (User_Email, ReservationPrice, ReservationDate)
     VALUES ('cepo@gmail.com', '200', '2021-01-01 10:00:00'),
             ('hola1@gmail.com', '300', '2021-01-02 11:00:00'),
          ('hola2@gmail.com', '400', '2021-01-03 09:30:00'),
          ('hola3@gmail.com', '500', '2021-01-04 14:00:00');
          
          
SELECT * FROM Obra
DROP TABLE Reserva
          
          
          
          
          
          
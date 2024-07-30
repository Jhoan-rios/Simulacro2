-- Active: 1717035105715@@byaqa1w2ryruf5a2e2tw-mysql.services.clever-cloud.com@3306
CREATE TABLE Patients(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Names VARCHAR(125),
    LastName VARCHAR(125),
    DateBirth DATE,
    Email VARCHAR(125) UNIQUE,
    Phone VARCHAR(75),
    Address VARCHAR(125),
    State ENUM('Activo','Inactivo') DEFAULT 'Activo'
);

CREATE TABLE Specialties(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(125),
    Description TEXT,
    State ENUM('Activo', 'Inactivo') DEFAULT 'Activo'
);

DROP TABLE `Specialties`

CREATE TABLE Doctors(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(125),
    Email VARCHAR(125) UNIQUE,
    Phone VARCHAR(75),
    State ENUM('Activo','Inactivo') DEFAULT 'Activo',
    SpecialtiesId INT(11),
    Foreign Key (SpecialtiesId) REFERENCES Specialties(Id)
);

DROP TABLE `Doctors`

CREATE TABLE Quotes (
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    DateQuote DATE,
    State ENUM('Activo','Inactivo') DEFAULT 'Activo',
    DoctorId INT(11),
    Foreign Key (DoctorId) REFERENCES Doctors(Id),
    PatientId INT(11),
    Foreign Key (PatientId) REFERENCES Patients(Id)
);

DROP TABLE `Quotes`

CREATE TABLE Treatments(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Description TEXT,
    State ENUM('Activo','Inactivo') DEFAULT 'Activo',
    QuoteId INT(11),
    Foreign Key (QuoteId) REFERENCES Quotes(Id)
);

DROP TABLE `Treatments`


INSERT INTO Patients (Names, LastName, DateBirth, Email, Phone, Address, State)
VALUES 
('Juan', 'Pérez', '1980-01-15', 'juan.perez@example.com', '123456789', 'Calle Falsa 123', 'Activo'),
('María', 'Gómez', '1992-06-20', 'maria.gomez@example.com', '987654321', 'Avenida Siempreviva 456', 'Activo'),
('Carlos', 'Ramírez', '1985-03-12', 'carlos.ramirez@example.com', '555123456', 'Calle Luna 789', 'Inactivo'),
('Ana', 'Martínez', '1990-11-02', 'ana.martinez@example.com', '321654987', 'Avenida del Sol 101', 'Activo'),
('Luis', 'Fernández', '1975-08-25', 'luis.fernandez@example.com', '654987321', 'Calle Estrella 202', 'Inactivo');

INSERT INTO Specialties (Name, Description, State)
VALUES 
('Cardiología', 'Especialidad médica que se ocupa de las enfermedades del corazón y del sistema circulatorio.', 'Activo'),
('Pediatría', 'Especialidad médica que se ocupa de la salud de los niños desde el nacimiento hasta la adolescencia.', 'Activo'),
('Dermatología', 'Especialidad médica que se ocupa de las enfermedades de la piel.', 'Inactivo'),
('Neurología', 'Especialidad médica que se ocupa de las enfermedades del sistema nervioso.', 'Activo'),
('Ginecología', 'Especialidad médica que se ocupa del sistema reproductor femenino.', 'Activo');

INSERT INTO Doctors (FullName, Email, Phone, State, SpecialtiesId)
VALUES 
('Dr. Pedro López', 'pedro.lopez@example.com', '111222333', 'Activo', 1),
('Dra. Laura Díaz', 'laura.diaz@example.com', '444555666', 'Activo', 2),
('Dr. José Torres', 'jose.torres@example.com', '777888999', 'Inactivo', 3),
('Dra. Elena Ruiz', 'elena.ruiz@example.com', '000111222', 'Activo', 4),
('Dr. Miguel Vega', 'miguel.vega@example.com', '333444555', 'Activo', 5);

INSERT INTO Quotes (DateQuote, State, DoctorId, PatientId)
VALUES 
('2024-06-01', 'Activo', 1, 1),
('2024-06-02', 'Activo', 2, 2),
('2024-06-03', 'Inactivo', 3, 3),
('2024-06-04', 'Activo', 4, 4),
('2024-06-05', 'Activo', 5, 5);

INSERT INTO Treatments (Description, State, QuoteId)
VALUES 
('Tratamiento para la hipertensión', 'Activo', 1),
('Tratamiento para la bronquitis', 'Activo', 2),
('Tratamiento para la dermatitis', 'Inactivo', 3),
('Tratamiento para la migraña', 'Activo', 4),
('Tratamiento para la anemia', 'Activo', 5);



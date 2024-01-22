CREATE DATABASE EdTech;
USE EdTech;

CREATE TABLE S_USER
(
	T_UserID		INT PRIMARY KEY IDENTITY(1,1),
	T_UserName		VARCHAR(50) NOT NULL,
	T_Password		VARCHAR(100) NOT NULL,
	T_Phrase		VARCHAR(50) NOT NULL
);
INSERT INTO S_USER(T_UserName, T_Password, T_Phrase) VALUES ('Fahad','1234','leo');
INSERT INTO S_USER(T_UserName, T_Password, T_Phrase) VALUES ('Safwan','1234','reset1234');

SELECT * FROM S_USER;
DROP TABLE S_USER;

ALTER TABLE S_USER ADD T_Status	INT CHECK (T_Status IN (1,0));



CREATE TABLE Student(

StudentID		INT PRIMARY KEY,
Std_Session		INT,
Std_Name		VARCHAR(60),
Std_Age			INT,
Std_Gender		VARCHAR(30) CHECK (Std_Gender IN ('Male','Female')),
Std_DOB			DATETIME,
Std_Disability	VARCHAR(20),
Std_BForm		BIGINT,			
Std_FName		VARCHAR(60),
Std_FPhone		BIGINT,
Std_FCNIC		BIGINT,
Std_MName		VARCHAR(60),
Std_MPhone		BIGINT,
Std_MCNIC		BIGINT,
Std_Address		VARCHAR(100),
Std_Class		INT,
Std_Section		VARCHAR(30),
Std_EnrollementDate	DATETIME,
Std_Photo image
CONSTRAINT FK_Class FOREIGN KEY(Std_Class) REFERENCES S_Class(C_Grade)
);
-- Assuming your table is named 'YourTable'
ALTER TABLE Student
ADD CONSTRAINT FK_Class FOREIGN KEY (Std_Class) REFERENCES S_Class(C_Grade);

INSERT INTO Student (
    StudentID, Std_Session, Std_Name, Std_Gender, Std_DOB,
    Std_Disability, Std_BForm, Std_FName, Std_FPhone, Std_FCNIC,
    Std_MName, Std_MPhone, Std_MCNIC, Std_Address, Std_Class,
    Std_Section, Std_EnrollementDate, Std_Photo
) VALUES (
    1, -- StudentID
    2024, -- Std_Session
    'John Doe', -- Std_Name
    'Male', -- Std_Gender
    '2000-01-15', -- Std_DOB (Assuming 'YYYY-MM-DD' format)
    'No Disability', -- Std_Disability
    1234567890, -- Std_BForm
    'Father Doe', -- Std_FName
    9876543210, -- Std_FPhone
    123456789012, -- Std_FCNIC
    'Mother Doe', -- Std_MName
    8765432109, -- Std_MPhone
    987654321098, -- Std_MCNIC
    '123 Main St, City', -- Std_Address
    10, -- Std_Class
    'A', -- Std_Section
    '2024-01-07', -- Std_EnrollementDate (Assuming 'YYYY-MM-DD' format)
    0x -- Placeholder for Std_Photo
);



SELECT* FROM Student;

DROP TABLE Student;


	CREATE TABLE Teacher(
		TeacherID INT PRIMARY KEY,
		T_Name VARCHAR(50),
		T_Gender VARCHAR(40) CHECK (T_Gender IN ('Male','Female')),
		T_DOB DATE,
		T_Age INT,
		T_Disability VARCHAR(40),
		T_Role VARCHAR(50),
		T_Salary INT,
		T_JoiningDate DATE,
		T_Photo image,
		T_Qualification VARCHAR(60),
		T_InchargeShip int,
		T_CNIC BIGINT,
		T_PhoneNumber BIGINT,
		T_DepartureDate DATE,
		T_Address VARCHAR(50) 
	);

--inserting example data
INSERT INTO Teacher (
    TeacherID, T_Name, T_Gender, T_DOB, T_Age, T_Disability, T_Role, T_Salary,
    T_JoiningDate, T_Photo, T_Qualification, T_InchargeShip, T_CNIC, T_PhoneNumber,
    T_DepartureDate, T_Address
) VALUES 
(
   1, 'John', 'Male', '1980-05-15', 40, NULL, 'Lecturer', 50000,
    '2010-07-01', NULL, 'Ph.D. in Computer Science', 'Department Head', 1234567890123, 1234567890,
    NULL, '123 Main Street, City'
)
;



SELECT* FROM Teacher;
DELETE Teacher WHERE TeacherID = 3;
DROP TABLE Teacher;


CREATE TABLE S_Class(
ClassID		INT PRIMARY KEY,
C_Grade   	INT UNIQUE,
C_NumStd	INT,
C_NumChairs	INT,
C_NumTables	INT,
C_RoomNo	INT,
C_TotalCapacity	INT,
C_Section	VARCHAR(50)
);
ALTER TABLE S_Class DROP COLUMN C_Name;
ALTER TABLE S_Class  ADD C_Grade INT;

UPDATE S_Class SET C_Name = 1 WHERE ClassID = 1;
UPDATE S_Class SET C_Name = 2 WHERE ClassID = 2;
SELECT* FROM S_Class;
DELETE S_Class WHERE ClassID = 1;
DROP TABLE S_Class;


CREATE TABLE Timetable (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TDay INT,
    StartTime TIME,
    EndTime TIME,
	CGrade INT,
    Subject VARCHAR(255),

	CONSTRAINT FK_Grade FOREIGN KEY(CGrade) REFERENCES S_Class(C_Grade)
);
SELECT* FROM Timetable;
DELETE Timetable WHERE Id = 1;
DROP TABLE Timetable;	
-- Inserting a timetable entry for Monday
INSERT INTO Timetable (TDay, StartTime, EndTime,CGrade, Subject) VALUES (1, '08:00:00', '09:30:00',1, 'Math');

-- Inserting a timetable entry for Tuesday
INSERT INTO Timetable (TDay, StartTime, EndTime, CGrade,Subject) VALUES (1, '10:00:00', '11:30:00', 1,'English');

-- Inserting a timetable entry for Wednesday
INSERT INTO Timetable (TDay, StartTime, EndTime, CGrade,Subject) VALUES (2, '13:00:00', '14:30:00', 1,'Science');

-- Inserting a timetable entry for Thursday
INSERT INTO Timetable (TDay, StartTime, EndTime, CGrade,Subject) VALUES (2, '15:00:00', '16:30:00', 2,'History');

-- Inserting a timetable entry for Friday
INSERT INTO Timetable (TDay, StartTime, EndTime, CGrade,Subject) VALUES (2, '09:00:00', '10:30:00', 2, 'Physical Education');


INSERT INTO Teacher (
    TeacherID,
    T_Name,
    T_Gender,
    T_DOB,
    T_Age,
    T_Disability,
    T_Role,
    T_Salary,
    T_JoiningDate,
    T_Photo,
    T_Qualification,
    T_InchargeShip,
    T_CNIC,
    T_PhoneNumber,
    T_DepartureDate,
    T_Address
)
VALUES (
    1,                    -- TeacherID
    'John Doe',           -- T_Name
    'Male',               -- T_Gender
    '1990-01-01',         -- T_DOB (Assuming YYYY-MM-DD format)
    30,                   -- T_Age
    'No',                 -- T_Disability
    'Lecturer',           -- T_Role
    50000,                -- T_Salary
    '2022-01-01',         -- T_JoiningDate (Assuming YYYY-MM-DD format)
    NULL,                 -- T_Photo (Assuming no photo initially)
    'Ph.D. in Computer Science',  -- T_Qualification
    0,                    -- T_InchargeShip (Assuming no initial incharge ship)
    1234567890,           -- T_CNIC
    9876543210,           -- T_PhoneNumber
    NULL,                 -- T_DepartureDate (Assuming not applicable initially)
    '123 Main Street'     -- T_Address
);

CREATE TABLE Staff(

StaffID			INT PRIMARY KEY,
S_Name			VARCHAR(50),
S_Qualification	VARCHAR(50),
S_Status		VARCHAR(10) CHECK (S_Status IN ('Married', 'Single', 'Divorced')),
S_Gender		VARCHAR(10) CHECK (S_Gender In ('Male','Female')),
S_DOB			DATE,
S_Disability	VARCHAR(50),
S_Age			INT,
S_Role			VARCHAR(50),
S_Salary		INT,
S_JoiningDate	DATE,
S_Photo			image,
S_CNIC			BIGINT,
S_Address		VARCHAR(50),
S_PhoneNumber	BIGINT,
S_DepartureDate	DATE

);
SELECT* FROM Staff;
DELETE Staff WHERE StaffID = 1;
DROP TABLE Staff;
UPDATE Staff SET S_DepartureDate = null WHERE StaffID = 123;
INSERT INTO Staff (StaffID, S_Name, S_Qualification, S_Status, S_Gender, S_DOB, S_Disability, S_Age, S_Role, S_Salary, S_JoiningDate, S_Photo, S_CNIC, S_Address, S_PhoneNumber, S_DepartureDate)
VALUES
  (1, 'John Doe', 'BS','Single', 'Male', '1990-05-15', NULL, 32, 'Teacher', 50000, '2022-01-10', NULL, 123456789012, '123 Main St', 9876543210, NULL),
  (2, 'Jane Doe', 'BS','Single','Female', '1985-08-22', 'None', 37, 'Administrator', 60000, '2021-11-05', NULL, 987654321098, '456 Oak St', 9876543211, '2023-02-28');
-- Add more rows as needed



CREATE TABLE Salary (
    SalaryID INT IDENTITY(1,1) PRIMARY KEY,
    TeacherID INT,
    StaffID INT,
	S_Month NVARCHAR(MAX),
	issueDate DATE,
    TotalSalary DECIMAL(18, 2),
    BasicSalary DECIMAL(18, 2),
    MedicalAllowance DECIMAL(18, 2),
    HouseRent DECIMAL(18, 2),
    Others DECIMAL(18, 2),
	deductions DECIMAL
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID) ON UPDATE CASCADE ON DELETE SET NULL,


);


-- Insert data into Teacher table
INSERT INTO Teacher (TeacherID, T_Name, T_Gender, T_DOB, T_Age, T_Disability, T_Role, T_Salary, T_JoiningDate, T_Photo, T_Qualification, T_InchargeShip, T_CNIC, T_PhoneNumber, T_DepartureDate, T_Address)
VALUES
(1, 'John Doe', 'Male', '1990-05-15', 32, NULL, 'Math Teacher', 50000, '2010-08-01', NULL, 'M.Sc. in Mathematics', null, 123456789012, 9876543210, NULL, '123 Main St'),
(2, 'Jane Smith', 'Female', '1985-12-10', 37, 'None', 'English Teacher', 55000, '2012-03-15', NULL, 'B.A. in English Literature', null, 234567890123, 9876543211, NULL, '456 Oak St');

-- Insert data into Salary table
INSERT INTO Salary (TeacherID, StaffID, S_Month, issueDate, TotalSalary, BasicSalary, MedicalAllowance, HouseRent, Others, deductions)
VALUES
(1, NULL, 'January 2023', '2023-01-15', 50000, 40000, 3000, 5000, 2000, 1000),
(2, NULL, 'January 2023', '2023-01-15', 55000, 45000, 3500, 5000, 2500, 1200);

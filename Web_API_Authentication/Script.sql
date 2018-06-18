Create Table Users 
(
ID INT primary key,
Name VARCHAR(100),
Password VARCHAR(100)
)

select * from users 

Create Table MedMaster 
(
MedID INT PRIMARY KEY IDENTITY,
MedName VARCHAR(100),
Purpose VARCHAR(MAX)
)

INSERT INTO MedMaster(MedName,Purpose) VALUES ('TELMA','HIGH BLOOD PRESSURE')
INSERT INTO MedMaster(MedName,Purpose) VALUES ('STORVAS','CHOLESTRAL')
INSERT INTO MedMaster(MedName,Purpose) VALUES ('LIPIVAS','CHOLESTRAL')
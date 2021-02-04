
--INSERT INTO PasswordReset(User_Name, User_Email, Password, Reset_code_timestamp, Reset_code, Reset_code_sent)
--VALUES ('person TWO', 'email2@email.com', 'secretPass', '01/06/2020', '98YP64', 'TRUE')
--USE CTRL_Testing
--SELECT * FROM PasswordReset

--DELETE FROM PasswordReset WHERE [ID] = '3' 

--USE CTRL_TESTING

CREATE TABLE PersistCode(
[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
[Email] NVARCHAR(100),
[Expiration] DATETIME,
[ResetCode] NVARCHAR(6))


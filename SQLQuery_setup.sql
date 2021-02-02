--CREATE TABLE PasswordReset(
--[ID] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
--[User_Name] NVARCHAR(100),
--[User_Email] NVARCHAR(100),
--[Password] NVARCHAR(25),
--[Reset_code_sent] BIT,
--[Reset_code_timestamp] DATETIME,
--[Reset_code] NVARCHAR(25))

INSERT INTO PasswordReset(User_Name, User_Email, Reset_code_sent)
VALUES ('kittyCat', 'kitty@email.com', 0)

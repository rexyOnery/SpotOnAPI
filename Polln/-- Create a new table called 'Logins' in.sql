-- Create a new table called 'Logins' in schema 'SchemaName'
-- Drop the table if it already exists
IF OBJECT_ID('Logins', 'U') IS NOT NULL
DROP TABLE Logins
GO
-- Create the table in the specified schema
CREATE TABLE Logins
(
    LoginsId INT NOT NULL PRIMARY KEY, -- primary key column
    EmailAddress [NVARCHAR](50) NOT NULL,
    Password [NVARCHAR](50) NOT NULL
    -- specify more columns here
);
GO

SELECT * FROM Logins
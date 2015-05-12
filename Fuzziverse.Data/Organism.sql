CREATE TABLE dbo.Organism
(
	Id BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    CurrentStateId BIGINT NOT NULL, 
    Strength DECIMAL(2, 2) NOT NULL,
    Defense DECIMAL(2, 2) NOT NULL
)

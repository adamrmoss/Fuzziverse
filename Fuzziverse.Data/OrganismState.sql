﻿CREATE TABLE dbo.OrganismState
(
	Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
    OrganismId BIGINT NOT NULL,
    X INT NOT NULL,
    Y INT NOT NULL, 
    Health DECIMAL(2, 2) NOT NULL,
    Damage DECIMAL(2, 2) NOT NULL,
    Intensity DECIMAL(2, 2) NOT NULL,
    Aggressiveness DECIMAL(2, 2) NOT NULL,
    MoveEast DECIMAL(2, 2) NOT NULL,
    MoveWest DECIMAL(2, 2) NOT NULL,
    MoveNorth DECIMAL(2, 2) NOT NULL,
    MoveSouth DECIMAL(2, 2) NOT NULL,
    Variable1 DECIMAL(2, 2) NOT NULL,
    Variable2 DECIMAL(2, 2) NOT NULL,
    Variable3 DECIMAL(2, 2) NOT NULL,
    Variable4 DECIMAL(2, 2) NOT NULL,
)

﻿CREATE TABLE dbo.Neuron
(
	Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
    BrainId BIGINT NOT NULL,
    HealthFactor DECIMAL(2, 2) NOT NULL,
    DamageFactor DECIMAL(2, 2) NOT NULL,
    IntensityFactor DECIMAL(2, 2) NOT NULL,
    AggressivenessFactor DECIMAL(2, 2) NOT NULL,
    MoveEastFactor DECIMAL(2, 2) NOT NULL,
    MoveWestFactor DECIMAL(2, 2) NOT NULL,
    MoveNorthFactor DECIMAL(2, 2) NOT NULL,
    MoveSouthFactor DECIMAL(2, 2) NOT NULL,
    Variable1Factor DECIMAL(2, 2) NOT NULL,
    Variable2Factor DECIMAL(2, 2) NOT NULL,
    Variable3Factor DECIMAL(2, 2) NOT NULL,
    Variable4Factor DECIMAL(2, 2) NOT NULL,
)
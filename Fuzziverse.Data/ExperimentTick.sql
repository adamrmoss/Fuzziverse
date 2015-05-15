CREATE TABLE dbo.ExperimentTick (
	Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
	ExperimentId BIGINT NOT NULL,
  SimulationTime DATETIME NOT NULL,

  CONSTRAINT UIX_ExperimentTick UNIQUE NONCLUSTERED (
	  ExperimentId ASC,
    SimulationTime ASC
  )
)

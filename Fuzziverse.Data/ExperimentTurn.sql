CREATE TABLE dbo.ExperimentTurn (
  Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
  ExperimentId BIGINT NOT NULL,
  SimulationTime BIGINT NOT NULL,
  [Day] INT NOT NULL,
  SunX INT NOT NULL,
  SunY INT NOT NULL,
  SunRadius INT NOT NULL,

  CONSTRAINT UN_ExperimentTurn_ExperimentId_SimulationTime UNIQUE NONCLUSTERED (
    ExperimentId ASC,
    SimulationTime ASC
  ),
  CONSTRAINT FK_ExperimentTurn_Experiment FOREIGN KEY(ExperimentId) REFERENCES dbo.Experiment (Id)
)

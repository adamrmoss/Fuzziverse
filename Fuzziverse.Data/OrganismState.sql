CREATE TABLE dbo.OrganismState (
  Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
  OrganismId BIGINT NOT NULL,
  ExperimentTurnId BIGINT NOT NULL,
  X INT NOT NULL,
  Y INT NOT NULL, 
  Health DECIMAL(3, 2) NOT NULL,

  CONSTRAINT FK_OrganismState_Organism FOREIGN KEY(OrganismId) REFERENCES dbo.Organism (Id),
  CONSTRAINT FK_OrganismState_ExperimentTurn FOREIGN KEY(ExperimentTurnId) REFERENCES dbo.ExperimentTurn (Id)
)

CREATE TABLE dbo.Brain (
  Id BIGINT NOT NULL PRIMARY KEY IDENTITY,
  MetabolismNeuronId BIGINT NOT NULL,
  AggressivenessNeuronId BIGINT NOT NULL,
  MoveEastNeuronId BIGINT NOT NULL,
  MoveWestNeuronId BIGINT NOT NULL,
  MoveNorthNeuronId BIGINT NOT NULL,
  MoveSouthNeuronId BIGINT NOT NULL,
  Variable1NeuronId BIGINT NOT NULL,
  Variable2NeuronId BIGINT NOT NULL,
  Variable3NeuronId BIGINT NOT NULL,
  Variable4NeuronId BIGINT NOT NULL,
)

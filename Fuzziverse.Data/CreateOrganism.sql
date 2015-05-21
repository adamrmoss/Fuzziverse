CREATE PROCEDURE dbo.CreateOrganism
  @Red DECIMAL(3, 2) NOT NULL,
  @Green DECIMAL(3, 2) NOT NULL,
  @Blue DECIMAL(3, 2) NOT NULL
AS
BEGIN
  DECLARE @OrganismId BIGINT NOT NULL

  INSERT INTO dbo.Organism (Red, Green, Blue)
  VALUES (@Red, @Green, @Blue)

  SET @OrganismId = SCOPE_IDENTITY()
  SELECT @OrganismId AS OrganismId

  RETURN
END

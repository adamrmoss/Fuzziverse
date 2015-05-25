CREATE PROCEDURE dbo.CreateOrganism
  @Red DECIMAL(3, 2),
  @Green DECIMAL(3, 2),
  @Blue DECIMAL(3, 2)
AS
BEGIN
  DECLARE @OrganismId BIGINT

  INSERT INTO dbo.Organism (Red, Green, Blue)
  VALUES (@Red, @Green, @Blue)

  SET @OrganismId = SCOPE_IDENTITY()
  SELECT @OrganismId AS OrganismId

  RETURN
END

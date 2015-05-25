CREATE PROCEDURE dbo.CreateExperiment AS
BEGIN
  DECLARE @ExperimentId BIGINT
  DECLARE @Created DATETIME
  SET @Created = GETUTCDATE()

  INSERT INTO dbo.Experiment (Created)
  VALUES (@Created)

  SET @ExperimentId = SCOPE_IDENTITY()
  SELECT @ExperimentId AS ExperimentId, @Created AS Created

  RETURN
END

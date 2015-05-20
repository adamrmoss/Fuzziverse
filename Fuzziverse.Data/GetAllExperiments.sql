CREATE PROCEDURE dbo.GetAllExperiments
AS
BEGIN
  SELECT Id, Created
  FROM dbo.Experiment
  ORDER BY Created DESC
  RETURN
END

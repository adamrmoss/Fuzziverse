CREATE PROCEDURE dbo.GetExperimentPhases
  @ExperimentId BIGINT
AS
BEGIN
  SELECT et.[Day], et.PhaseOfDay, et.Phase
  FROM dbo.ExperimentTurn AS et
  WHERE et.ExperimentId = @ExperimentId
  GROUP BY et.[Day], et.PhaseOfDay, et.Phase
  ORDER BY [Day] DESC, PhaseOfDay DESC
  RETURN
END

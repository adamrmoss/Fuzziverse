using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Fuzziverse.Core.AlienSpaceTime;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;
using GuardClaws;

namespace Fuzziverse.PhaseVisualization
{
  public class PhaseVisualizationController
  {
    public const int CellSize = 16;

    private readonly DatabaseConnector databaseConnector;
    private readonly IViewPhaseVisualizations phaseVisualizationView;

    public long? ExperimentId { get; set; }
    public int? PhaseId { get; set; }

    private Image[] frames;

    public PhaseVisualizationController(DatabaseConnector databaseConnector, IViewPhaseVisualizations phaseVisualizationView)
    {
      Claws.NotNull(() => databaseConnector);
      Claws.NotNull(() => phaseVisualizationView);

      this.databaseConnector = databaseConnector;
      this.phaseVisualizationView = phaseVisualizationView;
    }

    public void Initialize()
    {
      this.phaseVisualizationView.AddTurnTrackBarValueChangedHandler(this.OnTurnTrackBarValueChanged);

      this.ShowPhaseIfAny();
    }

    public void ShowPhaseIfAny()
    {
      if (this.ExperimentId != null && this.PhaseId != null) {
        var sqlConnection = this.databaseConnector.OpenSqlConnection();
        var experimentTurns = sqlConnection.GetExperimentPhaseTurns(this.ExperimentId.Value, this.PhaseId.Value);
        this.frames = experimentTurns.Select(RenderTurn).ToArray();
        this.phaseVisualizationView.EnablePictureBox();
        this.phaseVisualizationView.EnableTurnTrackBar();
      } else {
        this.phaseVisualizationView.DisablePictureBox();
        this.phaseVisualizationView.DisableTurnTrackBar();
      }
    }

    private static Image RenderTurn(ExperimentTurn turn)
    {
      var bitmap = new Bitmap(AlienSpaceVector.WorldWidth * CellSize, AlienSpaceVector.WorldHeight * CellSize);

      for (var x = 0; x < AlienSpaceVector.WorldWidth; x++) {
        for (var y = 0; y < AlienSpaceVector.WorldHeight; y++) {
          var distanceFromSun = AlienSpaceVector.GetCoordinateDelta(new AlienSpaceVector(x, y), turn.SunPosition).Abs();
          var color = distanceFromSun < Experiment.SunRadius ? Color.Yellow : Color.Transparent;
          var brush = new SolidBrush(color);

          var graphics = Graphics.FromImage(bitmap);
          graphics.FillRectangle(brush, x * CellSize, y * CellSize, CellSize, CellSize);
        }
      }
      return bitmap;
    }

    private void OnTurnTrackBarValueChanged(object sender, EventArgs eventArgs)
    {
      var turnTrackBarValue = this.phaseVisualizationView.GetTurnTrackBarValue();
      var currentFrame = this.frames[turnTrackBarValue];
      this.phaseVisualizationView.SetVisualizationImage(currentFrame);
    }
  }
}

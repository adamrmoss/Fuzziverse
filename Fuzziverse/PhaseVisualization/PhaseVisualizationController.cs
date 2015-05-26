using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Fuzziverse.Core.AlienSpaceTime;
using Fuzziverse.Core.Experiments;
using Fuzziverse.Core.Organisms;
using Fuzziverse.Databases;
using Fuzziverse.Experiments;
using Fuzziverse.Simulations;
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

    private ExperimentTurn[] experimentTurns;
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
        this.experimentTurns = sqlConnection.GetExperimentPhaseTurns(this.ExperimentId.Value, this.PhaseId.Value).ToArray();
        this.frames = this.experimentTurns.Select(this.RenderTurn).ToArray();
        this.phaseVisualizationView.EnablePictureBox();
        this.phaseVisualizationView.EnableTurnTrackBar();
      } else {
        this.phaseVisualizationView.DisablePictureBox();
        this.phaseVisualizationView.DisableTurnTrackBar();
      }
    }

    private Image RenderTurn(ExperimentTurn turn)
    {
      var sqlConnection = this.databaseConnector.OpenSqlConnection();
      var turnOrganismStates = sqlConnection.GetTurnOrganismStates(turn.Id).ToDictionary(state => state.Position);

      var bitmap = new Bitmap(AlienSpaceVector.WorldWidth * CellSize, AlienSpaceVector.WorldHeight * CellSize);
      var graphics = Graphics.FromImage(bitmap);
      var sunBrush = new SolidBrush(Color.Yellow);

      for (var x = 0; x < AlienSpaceVector.WorldWidth; x++) {
        for (var y = 0; y < AlienSpaceVector.WorldHeight; y++) {
          var position = new AlienSpaceVector(x, y);

          var distanceFromSun = AlienSpaceVector.GetCoordinateDelta(position, turn.SunPosition).Abs();
          if (distanceFromSun < Experiment.SunRadius)
            graphics.FillRectangle(sunBrush, x * CellSize, y * CellSize, CellSize, CellSize);

          if (turnOrganismStates.ContainsKey(position)) {
            var state = turnOrganismStates[position];
            var organismBrush = new SolidBrush(Color.FromArgb(ScaleColorComponent(state.Red), ScaleColorComponent(state.Green), ScaleColorComponent(state.Blue)));
            graphics.FillEllipse(organismBrush, x * CellSize, y * CellSize, CellSize, CellSize);
          }
        }
      }
      return bitmap;
    }

    private static int ScaleColorComponent(decimal component)
    {
      return (int) (component * 0xff);
    }

    private void OnTurnTrackBarValueChanged(object sender, EventArgs eventArgs)
    {
      var turnTrackBarValue = this.phaseVisualizationView.GetTurnTrackBarValue();
      var currentFrame = this.frames[turnTrackBarValue];
      this.phaseVisualizationView.SetVisualizationImage(currentFrame);
    }
  }
}

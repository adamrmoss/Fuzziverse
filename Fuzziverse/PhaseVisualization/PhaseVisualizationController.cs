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
      if (this.ExperimentId != null && this.PhaseId != null) {
        var sqlConnection = this.databaseConnector.OpenSqlConnection();
        var experimentTurns = sqlConnection.GetExperimentPhaseTurns(this.ExperimentId.Value, this.PhaseId.Value);
        this.frames = experimentTurns.Select(this.RenderTurn).ToArray();
      } else {
        this.phaseVisualizationView.DisablePictureBox();
      }
    }

    private Image RenderTurn(ExperimentTurn turn)
    {
      var bitmap = new Bitmap(AlienSpaceVector.WorldWidth * CellSize, AlienSpaceVector.WorldHeight * CellSize);
      return bitmap;
    }
  }
}

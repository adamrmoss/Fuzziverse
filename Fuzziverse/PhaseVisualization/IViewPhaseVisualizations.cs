using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuzziverse.PhaseVisualization
{
  public interface IViewPhaseVisualizations
  {
    void DisablePictureBox();
    void EnablePictureBox();
    void SetVisualizationImage(Image image);

    void DisableTurnTrackBar();
    void EnableTurnTrackBar();
    void AddTurnTrackBarValueChangedHandler(EventHandler handler);
    int GetTurnTrackBarValue();
  }
}

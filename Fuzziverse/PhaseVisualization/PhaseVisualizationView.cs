using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuzziverse.PhaseVisualization
{
  public partial class PhaseVisualizationView : UserControl, IViewPhaseVisualizations
  {
    public PhaseVisualizationView()
    {
      InitializeComponent();
    }

    public void DisablePictureBox()
    {
      this.visualizationPictureBox.Enabled = false;
    }

    public void EnablePictureBox()
    {
      this.visualizationPictureBox.Enabled = true;
    }

    public void SetVisualizationImage(Image image)
    {
      this.visualizationPictureBox.Image = image;
    }

    public void DisableTurnTrackBar()
    {
      this.turnTrackBar.Enabled = false;
    }

    public void EnableTurnTrackBar()
    {
      this.turnTrackBar.Enabled = true;
    }

    public void AddTurnTrackBarValueChangedHandler(EventHandler handler)
    {
      this.turnTrackBar.ValueChanged += handler;
    }

    public int GetTurnTrackBarValue()
    {
      return this.turnTrackBar.Value;
    }
  }
}

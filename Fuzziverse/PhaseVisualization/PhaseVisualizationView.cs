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

    public void SetVisualizationImage(Image image)
    {
      this.visualizationPictureBox.Image = image;
    }
  }
}

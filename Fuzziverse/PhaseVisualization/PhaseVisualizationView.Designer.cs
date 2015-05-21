namespace Fuzziverse.PhaseVisualization
{
  partial class PhaseVisualizationView
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.visualizationPictureBox = new System.Windows.Forms.PictureBox();
      this.turnTrackBar = new System.Windows.Forms.TrackBar();
      ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.turnTrackBar)).BeginInit();
      this.SuspendLayout();
      // 
      // visualizationPictureBox
      // 
      this.visualizationPictureBox.BackColor = System.Drawing.Color.DarkGray;
      this.visualizationPictureBox.Location = new System.Drawing.Point(8, 8);
      this.visualizationPictureBox.Name = "visualizationPictureBox";
      this.visualizationPictureBox.Size = new System.Drawing.Size(1024, 576);
      this.visualizationPictureBox.TabIndex = 1;
      this.visualizationPictureBox.TabStop = false;
      // 
      // turnTrackBar
      // 
      this.turnTrackBar.LargeChange = 8;
      this.turnTrackBar.Location = new System.Drawing.Point(8, 592);
      this.turnTrackBar.Maximum = 127;
      this.turnTrackBar.Name = "turnTrackBar";
      this.turnTrackBar.Size = new System.Drawing.Size(1024, 45);
      this.turnTrackBar.TabIndex = 2;
      this.turnTrackBar.TickFrequency = 8;
      this.turnTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
      // 
      // PhaseVisualizationView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.turnTrackBar);
      this.Controls.Add(this.visualizationPictureBox);
      this.Name = "PhaseVisualizationView";
      this.Size = new System.Drawing.Size(1042, 642);
      ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.turnTrackBar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox visualizationPictureBox;
    private System.Windows.Forms.TrackBar turnTrackBar;
  }
}

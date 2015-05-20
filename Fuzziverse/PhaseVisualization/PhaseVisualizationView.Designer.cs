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
      ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).BeginInit();
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
      // PhaseVisualizationView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.visualizationPictureBox);
      this.Name = "PhaseVisualizationView";
      this.Size = new System.Drawing.Size(1040, 593);
      ((System.ComponentModel.ISupportInitialize)(this.visualizationPictureBox)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox visualizationPictureBox;
  }
}

namespace Fuzziverse
{
  partial class ProgramView
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramView));
      this.tabControl = new System.Windows.Forms.TabControl();
      this.serverTabPage = new System.Windows.Forms.TabPage();
      this.phaseVisualizationTabPage = new System.Windows.Forms.TabPage();
      this.experimentView = new Fuzziverse.Experiments.ExperimentView();
      this.databaseView = new Fuzziverse.Databases.DatabaseView();
      this.phaseVisualizationView = new Fuzziverse.PhaseVisualization.PhaseVisualizationView();
      this.tabControl.SuspendLayout();
      this.serverTabPage.SuspendLayout();
      this.phaseVisualizationTabPage.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.serverTabPage);
      this.tabControl.Controls.Add(this.phaseVisualizationTabPage);
      this.tabControl.Location = new System.Drawing.Point(12, 12);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(1068, 636);
      this.tabControl.TabIndex = 0;
      // 
      // serverTabPage
      // 
      this.serverTabPage.Controls.Add(this.experimentView);
      this.serverTabPage.Controls.Add(this.databaseView);
      this.serverTabPage.Location = new System.Drawing.Point(4, 22);
      this.serverTabPage.Name = "serverTabPage";
      this.serverTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.serverTabPage.Size = new System.Drawing.Size(1060, 610);
      this.serverTabPage.TabIndex = 0;
      this.serverTabPage.Text = "Server";
      this.serverTabPage.UseVisualStyleBackColor = true;
      // 
      // phaseVisualizationTabPage
      // 
      this.phaseVisualizationTabPage.Controls.Add(this.phaseVisualizationView);
      this.phaseVisualizationTabPage.Location = new System.Drawing.Point(4, 22);
      this.phaseVisualizationTabPage.Name = "phaseVisualizationTabPage";
      this.phaseVisualizationTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.phaseVisualizationTabPage.Size = new System.Drawing.Size(1060, 610);
      this.phaseVisualizationTabPage.TabIndex = 1;
      this.phaseVisualizationTabPage.Text = "Phase Visualization";
      this.phaseVisualizationTabPage.UseVisualStyleBackColor = true;
      // 
      // experimentView
      // 
      this.experimentView.Location = new System.Drawing.Point(8, 64);
      this.experimentView.Name = "experimentView";
      this.experimentView.Size = new System.Drawing.Size(1048, 536);
      this.experimentView.TabIndex = 1;
      // 
      // databaseView
      // 
      this.databaseView.Location = new System.Drawing.Point(8, 0);
      this.databaseView.Name = "databaseView";
      this.databaseView.Size = new System.Drawing.Size(1048, 68);
      this.databaseView.TabIndex = 0;
      // 
      // phaseVisualizationView
      // 
      this.phaseVisualizationView.Location = new System.Drawing.Point(8, 8);
      this.phaseVisualizationView.Name = "phaseVisualizationView";
      this.phaseVisualizationView.Size = new System.Drawing.Size(1040, 593);
      this.phaseVisualizationView.TabIndex = 0;
      // 
      // ProgramView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1094, 659);
      this.Controls.Add(this.tabControl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ProgramView";
      this.Text = "Fuzziverse";
      this.tabControl.ResumeLayout(false);
      this.serverTabPage.ResumeLayout(false);
      this.phaseVisualizationTabPage.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage serverTabPage;
    private System.Windows.Forms.TabPage phaseVisualizationTabPage;
    private Databases.DatabaseView databaseView;
    private Experiments.ExperimentView experimentView;
    private PhaseVisualization.PhaseVisualizationView phaseVisualizationView;
  }
}


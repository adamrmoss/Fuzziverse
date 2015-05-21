namespace Fuzziverse.Experiments
{
  partial class ExperimentView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExperimentView));
      this.experimentsGroupBox = new System.Windows.Forms.GroupBox();
      this.newExperimentButton = new System.Windows.Forms.Button();
      this.phasesTreeView = new System.Windows.Forms.TreeView();
      this.stopRadioButton = new System.Windows.Forms.RadioButton();
      this.playRadioButton = new System.Windows.Forms.RadioButton();
      this.experimentsTreeView = new System.Windows.Forms.TreeView();
      this.experimentsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // experimentsGroupBox
      // 
      this.experimentsGroupBox.Controls.Add(this.newExperimentButton);
      this.experimentsGroupBox.Controls.Add(this.phasesTreeView);
      this.experimentsGroupBox.Controls.Add(this.stopRadioButton);
      this.experimentsGroupBox.Controls.Add(this.playRadioButton);
      this.experimentsGroupBox.Controls.Add(this.experimentsTreeView);
      this.experimentsGroupBox.Location = new System.Drawing.Point(10, 9);
      this.experimentsGroupBox.Name = "experimentsGroupBox";
      this.experimentsGroupBox.Size = new System.Drawing.Size(1028, 567);
      this.experimentsGroupBox.TabIndex = 0;
      this.experimentsGroupBox.TabStop = false;
      this.experimentsGroupBox.Text = "Experiments";
      // 
      // newExperimentButton
      // 
      this.newExperimentButton.Location = new System.Drawing.Point(328, 528);
      this.newExperimentButton.Name = "newExperimentButton";
      this.newExperimentButton.Size = new System.Drawing.Size(96, 24);
      this.newExperimentButton.TabIndex = 2;
      this.newExperimentButton.Text = "New Experiment";
      this.newExperimentButton.UseVisualStyleBackColor = true;
      // 
      // phasesTreeView
      // 
      this.phasesTreeView.FullRowSelect = true;
      this.phasesTreeView.HideSelection = false;
      this.phasesTreeView.Location = new System.Drawing.Point(608, 24);
      this.phasesTreeView.Name = "phasesTreeView";
      this.phasesTreeView.ShowPlusMinus = false;
      this.phasesTreeView.Size = new System.Drawing.Size(408, 528);
      this.phasesTreeView.TabIndex = 5;
      // 
      // stopRadioButton
      // 
      this.stopRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
      this.stopRadioButton.AutoSize = true;
      this.stopRadioButton.Checked = true;
      this.stopRadioButton.Image = ((System.Drawing.Image)(resources.GetObject("stopRadioButton.Image")));
      this.stopRadioButton.Location = new System.Drawing.Point(520, 24);
      this.stopRadioButton.Name = "stopRadioButton";
      this.stopRadioButton.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
      this.stopRadioButton.Size = new System.Drawing.Size(70, 54);
      this.stopRadioButton.TabIndex = 4;
      this.stopRadioButton.TabStop = true;
      this.stopRadioButton.UseVisualStyleBackColor = true;
      // 
      // playRadioButton
      // 
      this.playRadioButton.Appearance = System.Windows.Forms.Appearance.Button;
      this.playRadioButton.AutoSize = true;
      this.playRadioButton.Image = ((System.Drawing.Image)(resources.GetObject("playRadioButton.Image")));
      this.playRadioButton.Location = new System.Drawing.Point(440, 24);
      this.playRadioButton.Name = "playRadioButton";
      this.playRadioButton.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
      this.playRadioButton.Size = new System.Drawing.Size(70, 54);
      this.playRadioButton.TabIndex = 3;
      this.playRadioButton.UseVisualStyleBackColor = true;
      // 
      // experimentsTreeView
      // 
      this.experimentsTreeView.FullRowSelect = true;
      this.experimentsTreeView.HideSelection = false;
      this.experimentsTreeView.Location = new System.Drawing.Point(16, 24);
      this.experimentsTreeView.Name = "experimentsTreeView";
      this.experimentsTreeView.Size = new System.Drawing.Size(408, 496);
      this.experimentsTreeView.TabIndex = 1;
      // 
      // ExperimentView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.experimentsGroupBox);
      this.Name = "ExperimentView";
      this.Size = new System.Drawing.Size(1048, 586);
      this.experimentsGroupBox.ResumeLayout(false);
      this.experimentsGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox experimentsGroupBox;
    private System.Windows.Forms.TreeView experimentsTreeView;
    private System.Windows.Forms.RadioButton stopRadioButton;
    private System.Windows.Forms.RadioButton playRadioButton;
    private System.Windows.Forms.Button newExperimentButton;
    private System.Windows.Forms.TreeView phasesTreeView;
  }
}

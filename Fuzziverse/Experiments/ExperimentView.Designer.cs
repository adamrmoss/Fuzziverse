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
      this.experimentsGroupBox = new System.Windows.Forms.GroupBox();
      this.experimentsTreeView = new System.Windows.Forms.TreeView();
      this.experimentsGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // experimentsGroupBox
      // 
      this.experimentsGroupBox.Controls.Add(this.experimentsTreeView);
      this.experimentsGroupBox.Location = new System.Drawing.Point(10, 9);
      this.experimentsGroupBox.Name = "experimentsGroupBox";
      this.experimentsGroupBox.Size = new System.Drawing.Size(1028, 527);
      this.experimentsGroupBox.TabIndex = 2;
      this.experimentsGroupBox.TabStop = false;
      this.experimentsGroupBox.Text = "Experiments";
      // 
      // experimentsTreeView
      // 
      this.experimentsTreeView.Location = new System.Drawing.Point(16, 24);
      this.experimentsTreeView.Name = "experimentsTreeView";
      this.experimentsTreeView.Size = new System.Drawing.Size(1000, 488);
      this.experimentsTreeView.TabIndex = 0;
      // 
      // ExperimentView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.experimentsGroupBox);
      this.Name = "ExperimentView";
      this.Size = new System.Drawing.Size(1048, 548);
      this.experimentsGroupBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox experimentsGroupBox;
    private System.Windows.Forms.TreeView experimentsTreeView;
  }
}

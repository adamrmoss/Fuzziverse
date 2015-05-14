namespace Fuzziverse
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.tabControl = new System.Windows.Forms.TabControl();
      this.serverTabPage = new System.Windows.Forms.TabPage();
      this.databaseGroupBox = new System.Windows.Forms.GroupBox();
      this.sqlInstanceTextBox = new System.Windows.Forms.TextBox();
      this.sqlInstanceLabel = new System.Windows.Forms.Label();
      this.simulationTabPage = new System.Windows.Forms.TabPage();
      this.tabControl.SuspendLayout();
      this.serverTabPage.SuspendLayout();
      this.databaseGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.serverTabPage);
      this.tabControl.Controls.Add(this.simulationTabPage);
      this.tabControl.Location = new System.Drawing.Point(12, 12);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(857, 751);
      this.tabControl.TabIndex = 0;
      // 
      // serverTabPage
      // 
      this.serverTabPage.Controls.Add(this.databaseGroupBox);
      this.serverTabPage.Location = new System.Drawing.Point(4, 22);
      this.serverTabPage.Name = "serverTabPage";
      this.serverTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.serverTabPage.Size = new System.Drawing.Size(849, 725);
      this.serverTabPage.TabIndex = 0;
      this.serverTabPage.Text = "Server";
      this.serverTabPage.UseVisualStyleBackColor = true;
      // 
      // databaseGroupBox
      // 
      this.databaseGroupBox.Controls.Add(this.sqlInstanceTextBox);
      this.databaseGroupBox.Controls.Add(this.sqlInstanceLabel);
      this.databaseGroupBox.Location = new System.Drawing.Point(20, 15);
      this.databaseGroupBox.Name = "databaseGroupBox";
      this.databaseGroupBox.Size = new System.Drawing.Size(811, 51);
      this.databaseGroupBox.TabIndex = 0;
      this.databaseGroupBox.TabStop = false;
      this.databaseGroupBox.Text = "Database Settings";
      // 
      // sqlInstanceTextBox
      // 
      this.sqlInstanceTextBox.Location = new System.Drawing.Point(96, 20);
      this.sqlInstanceTextBox.Name = "sqlInstanceTextBox";
      this.sqlInstanceTextBox.Size = new System.Drawing.Size(697, 20);
      this.sqlInstanceTextBox.TabIndex = 1;
      // 
      // sqlInstanceLabel
      // 
      this.sqlInstanceLabel.AutoSize = true;
      this.sqlInstanceLabel.Location = new System.Drawing.Point(16, 20);
      this.sqlInstanceLabel.Name = "sqlInstanceLabel";
      this.sqlInstanceLabel.Size = new System.Drawing.Size(75, 13);
      this.sqlInstanceLabel.TabIndex = 0;
      this.sqlInstanceLabel.Text = "SQL Instance:";
      // 
      // simulationTabPage
      // 
      this.simulationTabPage.Location = new System.Drawing.Point(4, 22);
      this.simulationTabPage.Name = "simulationTabPage";
      this.simulationTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.simulationTabPage.Size = new System.Drawing.Size(849, 725);
      this.simulationTabPage.TabIndex = 1;
      this.simulationTabPage.Text = "Simulation";
      this.simulationTabPage.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(883, 778);
      this.Controls.Add(this.tabControl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Fuzziverse";
      this.tabControl.ResumeLayout(false);
      this.serverTabPage.ResumeLayout(false);
      this.databaseGroupBox.ResumeLayout(false);
      this.databaseGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage serverTabPage;
    private System.Windows.Forms.TabPage simulationTabPage;
    private System.Windows.Forms.GroupBox databaseGroupBox;
    private System.Windows.Forms.TextBox sqlInstanceTextBox;
    private System.Windows.Forms.Label sqlInstanceLabel;
  }
}


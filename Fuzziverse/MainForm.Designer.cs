﻿namespace Fuzziverse
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
      this.visualizationTabPage = new System.Windows.Forms.TabPage();
      this.databaseGroupBox = new System.Windows.Forms.GroupBox();
      this.instanceNameLabel = new System.Windows.Forms.Label();
      this.instanceNameTextBox = new System.Windows.Forms.TextBox();
      this.tabControl.SuspendLayout();
      this.serverTabPage.SuspendLayout();
      this.databaseGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.serverTabPage);
      this.tabControl.Controls.Add(this.visualizationTabPage);
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
      // visualizationTabPage
      // 
      this.visualizationTabPage.Location = new System.Drawing.Point(4, 22);
      this.visualizationTabPage.Name = "visualizationTabPage";
      this.visualizationTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.visualizationTabPage.Size = new System.Drawing.Size(849, 725);
      this.visualizationTabPage.TabIndex = 1;
      this.visualizationTabPage.Text = "Visualization";
      this.visualizationTabPage.UseVisualStyleBackColor = true;
      // 
      // databaseGroupBox
      // 
      this.databaseGroupBox.Controls.Add(this.instanceNameTextBox);
      this.databaseGroupBox.Controls.Add(this.instanceNameLabel);
      this.databaseGroupBox.Location = new System.Drawing.Point(20, 15);
      this.databaseGroupBox.Name = "databaseGroupBox";
      this.databaseGroupBox.Size = new System.Drawing.Size(811, 51);
      this.databaseGroupBox.TabIndex = 0;
      this.databaseGroupBox.TabStop = false;
      this.databaseGroupBox.Text = "Database Settings";
      // 
      // instanceNameLabel
      // 
      this.instanceNameLabel.AutoSize = true;
      this.instanceNameLabel.Location = new System.Drawing.Point(7, 20);
      this.instanceNameLabel.Name = "instanceNameLabel";
      this.instanceNameLabel.Size = new System.Drawing.Size(82, 13);
      this.instanceNameLabel.TabIndex = 0;
      this.instanceNameLabel.Text = "Instance Name:";
      // 
      // instanceNameTextBox
      // 
      this.instanceNameTextBox.Location = new System.Drawing.Point(96, 20);
      this.instanceNameTextBox.Name = "instanceNameTextBox";
      this.instanceNameTextBox.Size = new System.Drawing.Size(697, 20);
      this.instanceNameTextBox.TabIndex = 1;
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
    private System.Windows.Forms.TabPage visualizationTabPage;
    private System.Windows.Forms.GroupBox databaseGroupBox;
    private System.Windows.Forms.TextBox instanceNameTextBox;
    private System.Windows.Forms.Label instanceNameLabel;
  }
}


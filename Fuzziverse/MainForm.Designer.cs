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
      this.saveSqlInstanceButton = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.autoconnectCheckBox = new System.Windows.Forms.CheckBox();
      this.connectSqlButton = new System.Windows.Forms.Button();
      this.tabControl.SuspendLayout();
      this.serverTabPage.SuspendLayout();
      this.databaseGroupBox.SuspendLayout();
      this.simulationTabPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.serverTabPage);
      this.tabControl.Controls.Add(this.simulationTabPage);
      this.tabControl.Location = new System.Drawing.Point(12, 12);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(1068, 636);
      this.tabControl.TabIndex = 0;
      // 
      // serverTabPage
      // 
      this.serverTabPage.Controls.Add(this.databaseGroupBox);
      this.serverTabPage.Location = new System.Drawing.Point(4, 22);
      this.serverTabPage.Name = "serverTabPage";
      this.serverTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.serverTabPage.Size = new System.Drawing.Size(1060, 610);
      this.serverTabPage.TabIndex = 0;
      this.serverTabPage.Text = "Server";
      this.serverTabPage.UseVisualStyleBackColor = true;
      // 
      // databaseGroupBox
      // 
      this.databaseGroupBox.Controls.Add(this.connectSqlButton);
      this.databaseGroupBox.Controls.Add(this.autoconnectCheckBox);
      this.databaseGroupBox.Controls.Add(this.saveSqlInstanceButton);
      this.databaseGroupBox.Controls.Add(this.sqlInstanceTextBox);
      this.databaseGroupBox.Controls.Add(this.sqlInstanceLabel);
      this.databaseGroupBox.Location = new System.Drawing.Point(20, 15);
      this.databaseGroupBox.Name = "databaseGroupBox";
      this.databaseGroupBox.Size = new System.Drawing.Size(1028, 51);
      this.databaseGroupBox.TabIndex = 0;
      this.databaseGroupBox.TabStop = false;
      this.databaseGroupBox.Text = "Database";
      // 
      // sqlInstanceTextBox
      // 
      this.sqlInstanceTextBox.Location = new System.Drawing.Point(96, 20);
      this.sqlInstanceTextBox.Name = "sqlInstanceTextBox";
      this.sqlInstanceTextBox.Size = new System.Drawing.Size(592, 20);
      this.sqlInstanceTextBox.TabIndex = 1;
      // 
      // sqlInstanceLabel
      // 
      this.sqlInstanceLabel.AutoSize = true;
      this.sqlInstanceLabel.Location = new System.Drawing.Point(16, 22);
      this.sqlInstanceLabel.Name = "sqlInstanceLabel";
      this.sqlInstanceLabel.Size = new System.Drawing.Size(75, 13);
      this.sqlInstanceLabel.TabIndex = 0;
      this.sqlInstanceLabel.Text = "SQL Instance:";
      this.sqlInstanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // simulationTabPage
      // 
      this.simulationTabPage.Controls.Add(this.pictureBox1);
      this.simulationTabPage.Location = new System.Drawing.Point(4, 22);
      this.simulationTabPage.Name = "simulationTabPage";
      this.simulationTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.simulationTabPage.Size = new System.Drawing.Size(1060, 610);
      this.simulationTabPage.TabIndex = 1;
      this.simulationTabPage.Text = "Simulation";
      this.simulationTabPage.UseVisualStyleBackColor = true;
      // 
      // saveSqlInstanceButton
      // 
      this.saveSqlInstanceButton.Location = new System.Drawing.Point(704, 18);
      this.saveSqlInstanceButton.Name = "saveSqlInstanceButton";
      this.saveSqlInstanceButton.Size = new System.Drawing.Size(75, 23);
      this.saveSqlInstanceButton.TabIndex = 2;
      this.saveSqlInstanceButton.Text = "Save";
      this.saveSqlInstanceButton.UseVisualStyleBackColor = true;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
      this.pictureBox1.Location = new System.Drawing.Point(16, 16);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(1024, 576);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // autoconnectCheckBox
      // 
      this.autoconnectCheckBox.AutoSize = true;
      this.autoconnectCheckBox.Location = new System.Drawing.Point(920, 22);
      this.autoconnectCheckBox.Name = "autoconnectCheckBox";
      this.autoconnectCheckBox.Size = new System.Drawing.Size(94, 17);
      this.autoconnectCheckBox.TabIndex = 4;
      this.autoconnectCheckBox.Text = "AutoConnect?";
      this.autoconnectCheckBox.UseVisualStyleBackColor = true;
      // 
      // connectSqlButton
      // 
      this.connectSqlButton.Location = new System.Drawing.Point(800, 18);
      this.connectSqlButton.Name = "connectSqlButton";
      this.connectSqlButton.Size = new System.Drawing.Size(96, 23);
      this.connectSqlButton.TabIndex = 3;
      this.connectSqlButton.Text = "Connect SQL";
      this.connectSqlButton.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1094, 659);
      this.Controls.Add(this.tabControl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Fuzziverse";
      this.tabControl.ResumeLayout(false);
      this.serverTabPage.ResumeLayout(false);
      this.databaseGroupBox.ResumeLayout(false);
      this.databaseGroupBox.PerformLayout();
      this.simulationTabPage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage serverTabPage;
    private System.Windows.Forms.TabPage simulationTabPage;
    private System.Windows.Forms.GroupBox databaseGroupBox;
    private System.Windows.Forms.TextBox sqlInstanceTextBox;
    private System.Windows.Forms.Label sqlInstanceLabel;
    private System.Windows.Forms.Button saveSqlInstanceButton;
    private System.Windows.Forms.Button connectSqlButton;
    private System.Windows.Forms.CheckBox autoconnectCheckBox;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}


namespace Fuzziverse.Databases
{
  partial class DatabaseView
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
      this.databaseGroupBox = new System.Windows.Forms.GroupBox();
      this.connectSqlButton = new System.Windows.Forms.Button();
      this.autoconnectCheckBox = new System.Windows.Forms.CheckBox();
      this.saveSqlInstanceButton = new System.Windows.Forms.Button();
      this.sqlInstanceTextBox = new System.Windows.Forms.TextBox();
      this.sqlInstanceLabel = new System.Windows.Forms.Label();
      this.databaseGroupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // databaseGroupBox
      // 
      this.databaseGroupBox.Controls.Add(this.connectSqlButton);
      this.databaseGroupBox.Controls.Add(this.autoconnectCheckBox);
      this.databaseGroupBox.Controls.Add(this.saveSqlInstanceButton);
      this.databaseGroupBox.Controls.Add(this.sqlInstanceTextBox);
      this.databaseGroupBox.Controls.Add(this.sqlInstanceLabel);
      this.databaseGroupBox.Location = new System.Drawing.Point(8, 8);
      this.databaseGroupBox.Name = "databaseGroupBox";
      this.databaseGroupBox.Size = new System.Drawing.Size(1028, 51);
      this.databaseGroupBox.TabIndex = 1;
      this.databaseGroupBox.TabStop = false;
      this.databaseGroupBox.Text = "Database";
      // 
      // connectSqlButton
      // 
      this.connectSqlButton.Location = new System.Drawing.Point(808, 18);
      this.connectSqlButton.Name = "connectSqlButton";
      this.connectSqlButton.Size = new System.Drawing.Size(96, 23);
      this.connectSqlButton.TabIndex = 3;
      this.connectSqlButton.Text = "Connect SQL";
      this.connectSqlButton.UseVisualStyleBackColor = true;
      // 
      // autoconnectCheckBox
      // 
      this.autoconnectCheckBox.AutoSize = true;
      this.autoconnectCheckBox.Location = new System.Drawing.Point(928, 22);
      this.autoconnectCheckBox.Name = "autoconnectCheckBox";
      this.autoconnectCheckBox.Size = new System.Drawing.Size(94, 17);
      this.autoconnectCheckBox.TabIndex = 4;
      this.autoconnectCheckBox.Text = "AutoConnect?";
      this.autoconnectCheckBox.UseVisualStyleBackColor = true;
      // 
      // saveSqlInstanceButton
      // 
      this.saveSqlInstanceButton.Location = new System.Drawing.Point(712, 18);
      this.saveSqlInstanceButton.Name = "saveSqlInstanceButton";
      this.saveSqlInstanceButton.Size = new System.Drawing.Size(75, 23);
      this.saveSqlInstanceButton.TabIndex = 2;
      this.saveSqlInstanceButton.Text = "Save";
      this.saveSqlInstanceButton.UseVisualStyleBackColor = true;
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
      // DatabaseView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.databaseGroupBox);
      this.Name = "DatabaseView";
      this.Size = new System.Drawing.Size(1048, 68);
      this.databaseGroupBox.ResumeLayout(false);
      this.databaseGroupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox databaseGroupBox;
    private System.Windows.Forms.Button connectSqlButton;
    private System.Windows.Forms.CheckBox autoconnectCheckBox;
    private System.Windows.Forms.Button saveSqlInstanceButton;
    private System.Windows.Forms.TextBox sqlInstanceTextBox;
    private System.Windows.Forms.Label sqlInstanceLabel;
  }
}

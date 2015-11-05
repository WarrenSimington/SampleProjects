namespace Eliminator.UserControls
{
  partial class ControlWinner
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
      if (disposing && (components != null))
      {
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
      this.components = new System.ComponentModel.Container();
      this.tWinner = new System.Windows.Forms.TextBox();
      this.cmsWinnerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsWinnerMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // tWinner
      // 
      this.tWinner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tWinner.BackColor = System.Drawing.Color.White;
      this.tWinner.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tWinner.ContextMenuStrip = this.cmsWinnerMenu;
      this.tWinner.Location = new System.Drawing.Point(5, 4);
      this.tWinner.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tWinner.Name = "tWinner";
      this.tWinner.ReadOnly = true;
      this.tWinner.Size = new System.Drawing.Size(250, 16);
      this.tWinner.TabIndex = 1;
      // 
      // cmsWinnerMenu
      // 
      this.cmsWinnerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUndo});
      this.cmsWinnerMenu.Name = "cmsWinnerMenu";
      this.cmsWinnerMenu.Size = new System.Drawing.Size(104, 26);
      this.cmsWinnerMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsWinnerMenu_Opening);
      // 
      // mnuUndo
      // 
      this.mnuUndo.Name = "mnuUndo";
      this.mnuUndo.Size = new System.Drawing.Size(103, 22);
      this.mnuUndo.Text = "Undo";
      this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
      // 
      // ControlWinner
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ContextMenuStrip = this.cmsWinnerMenu;
      this.Controls.Add(this.tWinner);
      this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ControlWinner";
      this.Size = new System.Drawing.Size(264, 29);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlWinner_Paint);
      this.cmsWinnerMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tWinner;
    private System.Windows.Forms.ContextMenuStrip cmsWinnerMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuUndo;
  }
}

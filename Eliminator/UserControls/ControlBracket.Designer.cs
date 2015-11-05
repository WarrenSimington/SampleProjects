namespace Eliminator.UserControls
{
  partial class ControlBracket
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
      this.tCompetitor1 = new System.Windows.Forms.TextBox();
      this.cmsBracketMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuAdvanceCompetitor1 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuAdvanceCompetitor2 = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
      this.tCompetitor2 = new System.Windows.Forms.TextBox();
      this.cmsBracketMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // tCompetitor1
      // 
      this.tCompetitor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tCompetitor1.BackColor = System.Drawing.Color.White;
      this.tCompetitor1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tCompetitor1.ContextMenuStrip = this.cmsBracketMenu;
      this.tCompetitor1.Location = new System.Drawing.Point(3, 4);
      this.tCompetitor1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tCompetitor1.Name = "tCompetitor1";
      this.tCompetitor1.ReadOnly = true;
      this.tCompetitor1.Size = new System.Drawing.Size(250, 16);
      this.tCompetitor1.TabIndex = 0;
      this.tCompetitor1.Click += new System.EventHandler(this.tCompetitor1_Click);
      this.tCompetitor1.TextChanged += new System.EventHandler(this.tCompetitor1_TextChanged);
      this.tCompetitor1.MouseEnter += new System.EventHandler(this.tCompetitor1_MouseEnter);
      this.tCompetitor1.MouseLeave += new System.EventHandler(this.tCompetitor1_MouseLeave);
      // 
      // cmsBracketMenu
      // 
      this.cmsBracketMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdvanceCompetitor1,
            this.mnuAdvanceCompetitor2,
            this.mnuSeparator1,
            this.mnuUndo});
      this.cmsBracketMenu.Name = "cmsBracketMenu";
      this.cmsBracketMenu.Size = new System.Drawing.Size(194, 76);
      this.cmsBracketMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmsBracketMenu_Opening);
      // 
      // mnuAdvanceCompetitor1
      // 
      this.mnuAdvanceCompetitor1.Name = "mnuAdvanceCompetitor1";
      this.mnuAdvanceCompetitor1.Size = new System.Drawing.Size(193, 22);
      this.mnuAdvanceCompetitor1.Text = "Advance Competitor 1";
      this.mnuAdvanceCompetitor1.Click += new System.EventHandler(this.mnuAdvanceCompetitor1_Click);
      // 
      // mnuAdvanceCompetitor2
      // 
      this.mnuAdvanceCompetitor2.Name = "mnuAdvanceCompetitor2";
      this.mnuAdvanceCompetitor2.Size = new System.Drawing.Size(193, 22);
      this.mnuAdvanceCompetitor2.Text = "Advance Competitor 2";
      this.mnuAdvanceCompetitor2.Click += new System.EventHandler(this.mnuAdvanceCompetitor2_Click);
      // 
      // mnuSeparator1
      // 
      this.mnuSeparator1.Name = "mnuSeparator1";
      this.mnuSeparator1.Size = new System.Drawing.Size(190, 6);
      // 
      // mnuUndo
      // 
      this.mnuUndo.Name = "mnuUndo";
      this.mnuUndo.Size = new System.Drawing.Size(193, 22);
      this.mnuUndo.Text = "Undo";
      this.mnuUndo.Click += new System.EventHandler(this.mnuUndo_Click);
      // 
      // tCompetitor2
      // 
      this.tCompetitor2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tCompetitor2.BackColor = System.Drawing.Color.White;
      this.tCompetitor2.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tCompetitor2.ContextMenuStrip = this.cmsBracketMenu;
      this.tCompetitor2.Location = new System.Drawing.Point(3, 54);
      this.tCompetitor2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tCompetitor2.Name = "tCompetitor2";
      this.tCompetitor2.ReadOnly = true;
      this.tCompetitor2.Size = new System.Drawing.Size(250, 16);
      this.tCompetitor2.TabIndex = 1;
      this.tCompetitor2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tCompetitor2_MouseClick);
      this.tCompetitor2.TextChanged += new System.EventHandler(this.tCompetitor2_TextChanged);
      this.tCompetitor2.MouseEnter += new System.EventHandler(this.tCompetitor2_MouseEnter);
      this.tCompetitor2.MouseLeave += new System.EventHandler(this.tCompetitor2_MouseLeave);
      // 
      // ControlBracket
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.ContextMenuStrip = this.cmsBracketMenu;
      this.Controls.Add(this.tCompetitor2);
      this.Controls.Add(this.tCompetitor1);
      this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ControlBracket";
      this.Size = new System.Drawing.Size(264, 78);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlBracket_Paint);
      this.cmsBracketMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tCompetitor1;
    private System.Windows.Forms.TextBox tCompetitor2;
    private System.Windows.Forms.ContextMenuStrip cmsBracketMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuAdvanceCompetitor1;
    private System.Windows.Forms.ToolStripMenuItem mnuAdvanceCompetitor2;
    private System.Windows.Forms.ToolStripSeparator mnuSeparator1;
    private System.Windows.Forms.ToolStripMenuItem mnuUndo;
  }
}

namespace Eliminator.Forms
{
  partial class FormMain
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.msMainMenu = new System.Windows.Forms.MenuStrip();
      this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.scLayout = new System.Windows.Forms.SplitContainer();
      this.gbSeedOption = new System.Windows.Forms.GroupBox();
      this.bMoveDown = new System.Windows.Forms.Button();
      this.bMoveUp = new System.Windows.Forms.Button();
      this.rbSeeded = new System.Windows.Forms.RadioButton();
      this.rbRandom = new System.Windows.Forms.RadioButton();
      this.bStart = new System.Windows.Forms.Button();
      this.dgCompetitors = new System.Windows.Forms.DataGridView();
      this.colSeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colCompetitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cmsCompetitorOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuAddCompetitorsFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
      this.ssItemCount = new System.Windows.Forms.StatusStrip();
      this.tsslCompetitorCount = new System.Windows.Forms.ToolStripStatusLabel();
      this.msMainMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scLayout)).BeginInit();
      this.scLayout.Panel1.SuspendLayout();
      this.scLayout.SuspendLayout();
      this.gbSeedOption.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgCompetitors)).BeginInit();
      this.cmsCompetitorOptions.SuspendLayout();
      this.ssItemCount.SuspendLayout();
      this.SuspendLayout();
      // 
      // msMainMenu
      // 
      this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
      this.msMainMenu.Location = new System.Drawing.Point(0, 0);
      this.msMainMenu.Name = "msMainMenu";
      this.msMainMenu.Size = new System.Drawing.Size(1071, 24);
      this.msMainMenu.TabIndex = 0;
      this.msMainMenu.Text = "menuStrip1";
      // 
      // mnuFile
      // 
      this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.mnuFileSeparator,
            this.mnuFileExit});
      this.mnuFile.Name = "mnuFile";
      this.mnuFile.Size = new System.Drawing.Size(37, 20);
      this.mnuFile.Text = "File";
      // 
      // mnuFileNew
      // 
      this.mnuFileNew.Name = "mnuFileNew";
      this.mnuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.mnuFileNew.Size = new System.Drawing.Size(155, 22);
      this.mnuFileNew.Text = "New";
      this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
      // 
      // mnuFileOpen
      // 
      this.mnuFileOpen.Name = "mnuFileOpen";
      this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.mnuFileOpen.Size = new System.Drawing.Size(155, 22);
      this.mnuFileOpen.Text = "Open...";
      this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
      // 
      // mnuFileSave
      // 
      this.mnuFileSave.Name = "mnuFileSave";
      this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.mnuFileSave.Size = new System.Drawing.Size(155, 22);
      this.mnuFileSave.Text = "Save";
      this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
      // 
      // mnuFileSaveAs
      // 
      this.mnuFileSaveAs.Name = "mnuFileSaveAs";
      this.mnuFileSaveAs.Size = new System.Drawing.Size(155, 22);
      this.mnuFileSaveAs.Text = "Save As...";
      this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
      // 
      // mnuFileSeparator
      // 
      this.mnuFileSeparator.Name = "mnuFileSeparator";
      this.mnuFileSeparator.Size = new System.Drawing.Size(152, 6);
      // 
      // mnuFileExit
      // 
      this.mnuFileExit.Name = "mnuFileExit";
      this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.mnuFileExit.Size = new System.Drawing.Size(155, 22);
      this.mnuFileExit.Text = "Exit";
      this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
      // 
      // mnuHelp
      // 
      this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
      this.mnuHelp.Name = "mnuHelp";
      this.mnuHelp.Size = new System.Drawing.Size(44, 20);
      this.mnuHelp.Text = "Help";
      // 
      // mnuAbout
      // 
      this.mnuAbout.Name = "mnuAbout";
      this.mnuAbout.Size = new System.Drawing.Size(116, 22);
      this.mnuAbout.Text = "About...";
      this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
      // 
      // scLayout
      // 
      this.scLayout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.scLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scLayout.Location = new System.Drawing.Point(0, 24);
      this.scLayout.Name = "scLayout";
      // 
      // scLayout.Panel1
      // 
      this.scLayout.Panel1.AutoScroll = true;
      this.scLayout.Panel1.Controls.Add(this.ssItemCount);
      this.scLayout.Panel1.Controls.Add(this.gbSeedOption);
      this.scLayout.Panel1.Controls.Add(this.bStart);
      this.scLayout.Panel1.Controls.Add(this.dgCompetitors);
      this.scLayout.Panel1MinSize = 200;
      // 
      // scLayout.Panel2
      // 
      this.scLayout.Panel2.AutoScroll = true;
      this.scLayout.Panel2.BackColor = System.Drawing.Color.White;
      this.scLayout.Size = new System.Drawing.Size(1071, 629);
      this.scLayout.SplitterDistance = 224;
      this.scLayout.TabIndex = 1;
      this.scLayout.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.scLayout_SplitterMoving);
      this.scLayout.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.scLayout_SplitterMoved);
      // 
      // gbSeedOption
      // 
      this.gbSeedOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gbSeedOption.Controls.Add(this.bMoveDown);
      this.gbSeedOption.Controls.Add(this.bMoveUp);
      this.gbSeedOption.Controls.Add(this.rbSeeded);
      this.gbSeedOption.Controls.Add(this.rbRandom);
      this.gbSeedOption.Location = new System.Drawing.Point(3, 502);
      this.gbSeedOption.Name = "gbSeedOption";
      this.gbSeedOption.Size = new System.Drawing.Size(214, 66);
      this.gbSeedOption.TabIndex = 2;
      this.gbSeedOption.TabStop = false;
      this.gbSeedOption.Text = "Seed Option";
      // 
      // bMoveDown
      // 
      this.bMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bMoveDown.Image = global::Eliminator.Properties.Resources.DownArrow;
      this.bMoveDown.Location = new System.Drawing.Point(184, 38);
      this.bMoveDown.Name = "bMoveDown";
      this.bMoveDown.Size = new System.Drawing.Size(24, 24);
      this.bMoveDown.TabIndex = 7;
      this.bMoveDown.UseVisualStyleBackColor = true;
      this.bMoveDown.Click += new System.EventHandler(this.bMoveDown_Click);
      // 
      // bMoveUp
      // 
      this.bMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.bMoveUp.Image = global::Eliminator.Properties.Resources.UpArrow;
      this.bMoveUp.Location = new System.Drawing.Point(184, 12);
      this.bMoveUp.Name = "bMoveUp";
      this.bMoveUp.Size = new System.Drawing.Size(24, 24);
      this.bMoveUp.TabIndex = 6;
      this.bMoveUp.UseVisualStyleBackColor = true;
      this.bMoveUp.Click += new System.EventHandler(this.bMoveUp_Click);
      // 
      // rbSeeded
      // 
      this.rbSeeded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.rbSeeded.AutoSize = true;
      this.rbSeeded.Location = new System.Drawing.Point(21, 42);
      this.rbSeeded.Name = "rbSeeded";
      this.rbSeeded.Size = new System.Drawing.Size(62, 17);
      this.rbSeeded.TabIndex = 5;
      this.rbSeeded.Text = "Seeded";
      this.rbSeeded.UseVisualStyleBackColor = true;
      this.rbSeeded.CheckedChanged += new System.EventHandler(this.rbSeeded_CheckedChanged);
      // 
      // rbRandom
      // 
      this.rbRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.rbRandom.AutoSize = true;
      this.rbRandom.Checked = true;
      this.rbRandom.Location = new System.Drawing.Point(21, 19);
      this.rbRandom.Name = "rbRandom";
      this.rbRandom.Size = new System.Drawing.Size(65, 17);
      this.rbRandom.TabIndex = 4;
      this.rbRandom.TabStop = true;
      this.rbRandom.Text = "Random";
      this.rbRandom.UseVisualStyleBackColor = true;
      this.rbRandom.CheckedChanged += new System.EventHandler(this.rbRandom_CheckedChanged);
      // 
      // bStart
      // 
      this.bStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.bStart.Location = new System.Drawing.Point(73, 574);
      this.bStart.Name = "bStart";
      this.bStart.Size = new System.Drawing.Size(75, 23);
      this.bStart.TabIndex = 1;
      this.bStart.Text = "Start";
      this.bStart.UseVisualStyleBackColor = true;
      this.bStart.Click += new System.EventHandler(this.bStart_Click);
      // 
      // dgCompetitors
      // 
      this.dgCompetitors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgCompetitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgCompetitors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeed,
            this.colCompetitor});
      this.dgCompetitors.ContextMenuStrip = this.cmsCompetitorOptions;
      this.dgCompetitors.Location = new System.Drawing.Point(-1, 0);
      this.dgCompetitors.MultiSelect = false;
      this.dgCompetitors.Name = "dgCompetitors";
      this.dgCompetitors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgCompetitors.Size = new System.Drawing.Size(221, 496);
      this.dgCompetitors.TabIndex = 0;
      this.dgCompetitors.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgCompetitors_RowsAdded);
      this.dgCompetitors.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgCompetitors_RowsRemoved);
      // 
      // colSeed
      // 
      this.colSeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.colSeed.HeaderText = "Seed";
      this.colSeed.Name = "colSeed";
      this.colSeed.ReadOnly = true;
      this.colSeed.Visible = false;
      this.colSeed.Width = 57;
      // 
      // colCompetitor
      // 
      this.colCompetitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.colCompetitor.HeaderText = "Competitor";
      this.colCompetitor.Name = "colCompetitor";
      // 
      // cmsCompetitorOptions
      // 
      this.cmsCompetitorOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddCompetitorsFromClipboard});
      this.cmsCompetitorOptions.Name = "cmsCompetitorOptions";
      this.cmsCompetitorOptions.Size = new System.Drawing.Size(287, 26);
      // 
      // mnuAddCompetitorsFromClipboard
      // 
      this.mnuAddCompetitorsFromClipboard.Name = "mnuAddCompetitorsFromClipboard";
      this.mnuAddCompetitorsFromClipboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.mnuAddCompetitorsFromClipboard.Size = new System.Drawing.Size(286, 22);
      this.mnuAddCompetitorsFromClipboard.Text = "Add competitors from clipboard";
      this.mnuAddCompetitorsFromClipboard.Click += new System.EventHandler(this.mnuAddCompetitorsFromClipboard_Click);
      // 
      // ssItemCount
      // 
      this.ssItemCount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCompetitorCount});
      this.ssItemCount.Location = new System.Drawing.Point(0, 603);
      this.ssItemCount.Name = "ssItemCount";
      this.ssItemCount.Size = new System.Drawing.Size(220, 22);
      this.ssItemCount.SizingGrip = false;
      this.ssItemCount.TabIndex = 3;
      this.ssItemCount.Text = "statusStrip1";
      // 
      // tsslCompetitorCount
      // 
      this.tsslCompetitorCount.Name = "tsslCompetitorCount";
      this.tsslCompetitorCount.Size = new System.Drawing.Size(90, 17);
      this.tsslCompetitorCount.Text = "0 Competitor(s)";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1071, 653);
      this.Controls.Add(this.scLayout);
      this.Controls.Add(this.msMainMenu);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.msMainMenu;
      this.Name = "FormMain";
      this.Text = "Eliminator";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.msMainMenu.ResumeLayout(false);
      this.msMainMenu.PerformLayout();
      this.scLayout.Panel1.ResumeLayout(false);
      this.scLayout.Panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scLayout)).EndInit();
      this.scLayout.ResumeLayout(false);
      this.gbSeedOption.ResumeLayout(false);
      this.gbSeedOption.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgCompetitors)).EndInit();
      this.cmsCompetitorOptions.ResumeLayout(false);
      this.ssItemCount.ResumeLayout(false);
      this.ssItemCount.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip msMainMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
    private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
    private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
    private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
    private System.Windows.Forms.ToolStripSeparator mnuFileSeparator;
    private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    private System.Windows.Forms.SplitContainer scLayout;
    private System.Windows.Forms.ToolStripMenuItem mnuHelp;
    private System.Windows.Forms.ToolStripMenuItem mnuAbout;
    private System.Windows.Forms.DataGridView dgCompetitors;
    private System.Windows.Forms.Button bStart;
    private System.Windows.Forms.GroupBox gbSeedOption;
    private System.Windows.Forms.RadioButton rbSeeded;
    private System.Windows.Forms.RadioButton rbRandom;
    private System.Windows.Forms.Button bMoveDown;
    private System.Windows.Forms.Button bMoveUp;
    private System.Windows.Forms.DataGridViewTextBoxColumn colSeed;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCompetitor;
    private System.Windows.Forms.ContextMenuStrip cmsCompetitorOptions;
    private System.Windows.Forms.ToolStripMenuItem mnuAddCompetitorsFromClipboard;
    private System.Windows.Forms.StatusStrip ssItemCount;
    private System.Windows.Forms.ToolStripStatusLabel tsslCompetitorCount;
  }
}


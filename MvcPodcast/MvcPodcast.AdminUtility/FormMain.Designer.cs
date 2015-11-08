namespace Blog.AdminUtility
{
  partial class frmMain
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
      this.msMainMenu = new System.Windows.Forms.MenuStrip();
      this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.scMain = new System.Windows.Forms.SplitContainer();
      this.pArticleType = new System.Windows.Forms.Panel();
      this.rbPodcastsOnly = new System.Windows.Forms.RadioButton();
      this.rbNewsOnly = new System.Windows.Forms.RadioButton();
      this.rbShowAll = new System.Windows.Forms.RadioButton();
      this.lbArticles = new System.Windows.Forms.ListBox();
      this.bRevert = new System.Windows.Forms.Button();
      this.bSave = new System.Windows.Forms.Button();
      this.gbPodcastInfo = new System.Windows.Forms.GroupBox();
      this.button2 = new System.Windows.Forms.Button();
      this.bBrowseAlbum1 = new System.Windows.Forms.Button();
      this.cboAlbum2 = new System.Windows.Forms.ComboBox();
      this.cboAlbum1 = new System.Windows.Forms.ComboBox();
      this.lAlbum2Caption = new System.Windows.Forms.Label();
      this.lAlbum1Caption = new System.Windows.Forms.Label();
      this.cbIsPodcast = new System.Windows.Forms.CheckBox();
      this.tArticleText = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.dtpArticleDate = new System.Windows.Forms.DateTimePicker();
      this.lArticleDateCaption = new System.Windows.Forms.Label();
      this.msMainMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
      this.scMain.Panel1.SuspendLayout();
      this.scMain.Panel2.SuspendLayout();
      this.scMain.SuspendLayout();
      this.pArticleType.SuspendLayout();
      this.gbPodcastInfo.SuspendLayout();
      this.SuspendLayout();
      // 
      // msMainMenu
      // 
      this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
      this.msMainMenu.Location = new System.Drawing.Point(0, 0);
      this.msMainMenu.Name = "msMainMenu";
      this.msMainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
      this.msMainMenu.Size = new System.Drawing.Size(1376, 24);
      this.msMainMenu.TabIndex = 0;
      this.msMainMenu.Text = "menuStrip1";
      // 
      // mnuFile
      // 
      this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
      this.mnuFile.Name = "mnuFile";
      this.mnuFile.Size = new System.Drawing.Size(37, 20);
      this.mnuFile.Text = "File";
      // 
      // mnuFileExit
      // 
      this.mnuFileExit.Name = "mnuFileExit";
      this.mnuFileExit.Size = new System.Drawing.Size(92, 22);
      this.mnuFileExit.Text = "Exit";
      this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
      // 
      // scMain
      // 
      this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scMain.Location = new System.Drawing.Point(0, 24);
      this.scMain.Margin = new System.Windows.Forms.Padding(4);
      this.scMain.Name = "scMain";
      // 
      // scMain.Panel1
      // 
      this.scMain.Panel1.Controls.Add(this.pArticleType);
      this.scMain.Panel1.Controls.Add(this.lbArticles);
      this.scMain.Panel1MinSize = 150;
      // 
      // scMain.Panel2
      // 
      this.scMain.Panel2.Controls.Add(this.bRevert);
      this.scMain.Panel2.Controls.Add(this.bSave);
      this.scMain.Panel2.Controls.Add(this.gbPodcastInfo);
      this.scMain.Panel2.Controls.Add(this.cbIsPodcast);
      this.scMain.Panel2.Controls.Add(this.tArticleText);
      this.scMain.Panel2.Controls.Add(this.label1);
      this.scMain.Panel2.Controls.Add(this.dtpArticleDate);
      this.scMain.Panel2.Controls.Add(this.lArticleDateCaption);
      this.scMain.Size = new System.Drawing.Size(1376, 735);
      this.scMain.SplitterDistance = 237;
      this.scMain.SplitterWidth = 5;
      this.scMain.TabIndex = 1;
      // 
      // pArticleType
      // 
      this.pArticleType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pArticleType.Controls.Add(this.rbPodcastsOnly);
      this.pArticleType.Controls.Add(this.rbNewsOnly);
      this.pArticleType.Controls.Add(this.rbShowAll);
      this.pArticleType.Dock = System.Windows.Forms.DockStyle.Top;
      this.pArticleType.Location = new System.Drawing.Point(0, 0);
      this.pArticleType.Margin = new System.Windows.Forms.Padding(4);
      this.pArticleType.Name = "pArticleType";
      this.pArticleType.Size = new System.Drawing.Size(237, 128);
      this.pArticleType.TabIndex = 1;
      // 
      // rbPodcastsOnly
      // 
      this.rbPodcastsOnly.AutoSize = true;
      this.rbPodcastsOnly.Location = new System.Drawing.Point(16, 81);
      this.rbPodcastsOnly.Margin = new System.Windows.Forms.Padding(4);
      this.rbPodcastsOnly.Name = "rbPodcastsOnly";
      this.rbPodcastsOnly.Size = new System.Drawing.Size(119, 23);
      this.rbPodcastsOnly.TabIndex = 2;
      this.rbPodcastsOnly.TabStop = true;
      this.rbPodcastsOnly.Text = "Podcasts Only";
      this.rbPodcastsOnly.UseVisualStyleBackColor = true;
      this.rbPodcastsOnly.CheckedChanged += new System.EventHandler(this.ArticleTypeChanged);
      // 
      // rbNewsOnly
      // 
      this.rbNewsOnly.AutoSize = true;
      this.rbNewsOnly.Location = new System.Drawing.Point(16, 50);
      this.rbNewsOnly.Margin = new System.Windows.Forms.Padding(4);
      this.rbNewsOnly.Name = "rbNewsOnly";
      this.rbNewsOnly.Size = new System.Drawing.Size(97, 23);
      this.rbNewsOnly.TabIndex = 1;
      this.rbNewsOnly.TabStop = true;
      this.rbNewsOnly.Text = "News Only";
      this.rbNewsOnly.UseVisualStyleBackColor = true;
      this.rbNewsOnly.CheckedChanged += new System.EventHandler(this.ArticleTypeChanged);
      // 
      // rbShowAll
      // 
      this.rbShowAll.AutoSize = true;
      this.rbShowAll.Checked = true;
      this.rbShowAll.Location = new System.Drawing.Point(16, 19);
      this.rbShowAll.Margin = new System.Windows.Forms.Padding(4);
      this.rbShowAll.Name = "rbShowAll";
      this.rbShowAll.Size = new System.Drawing.Size(82, 23);
      this.rbShowAll.TabIndex = 0;
      this.rbShowAll.TabStop = true;
      this.rbShowAll.Text = "Show All";
      this.rbShowAll.UseVisualStyleBackColor = true;
      this.rbShowAll.CheckedChanged += new System.EventHandler(this.ArticleTypeChanged);
      // 
      // lbArticles
      // 
      this.lbArticles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbArticles.FormattingEnabled = true;
      this.lbArticles.ItemHeight = 19;
      this.lbArticles.Location = new System.Drawing.Point(0, 128);
      this.lbArticles.Margin = new System.Windows.Forms.Padding(4);
      this.lbArticles.Name = "lbArticles";
      this.lbArticles.Size = new System.Drawing.Size(237, 593);
      this.lbArticles.TabIndex = 0;
      this.lbArticles.SelectedIndexChanged += new System.EventHandler(this.lbArticles_SelectedIndexChanged);
      // 
      // bRevert
      // 
      this.bRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bRevert.Location = new System.Drawing.Point(1029, 691);
      this.bRevert.Name = "bRevert";
      this.bRevert.Size = new System.Drawing.Size(92, 32);
      this.bRevert.TabIndex = 7;
      this.bRevert.Text = "Revert";
      this.bRevert.UseVisualStyleBackColor = true;
      // 
      // bSave
      // 
      this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.bSave.Location = new System.Drawing.Point(918, 691);
      this.bSave.Name = "bSave";
      this.bSave.Size = new System.Drawing.Size(92, 32);
      this.bSave.TabIndex = 6;
      this.bSave.Text = "Save";
      this.bSave.UseVisualStyleBackColor = true;
      // 
      // gbPodcastInfo
      // 
      this.gbPodcastInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gbPodcastInfo.Controls.Add(this.button2);
      this.gbPodcastInfo.Controls.Add(this.bBrowseAlbum1);
      this.gbPodcastInfo.Controls.Add(this.cboAlbum2);
      this.gbPodcastInfo.Controls.Add(this.cboAlbum1);
      this.gbPodcastInfo.Controls.Add(this.lAlbum2Caption);
      this.gbPodcastInfo.Controls.Add(this.lAlbum1Caption);
      this.gbPodcastInfo.Location = new System.Drawing.Point(7, 527);
      this.gbPodcastInfo.Name = "gbPodcastInfo";
      this.gbPodcastInfo.Size = new System.Drawing.Size(1114, 156);
      this.gbPodcastInfo.TabIndex = 5;
      this.gbPodcastInfo.TabStop = false;
      this.gbPodcastInfo.Text = "Podcast Info";
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(293, 109);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(29, 27);
      this.button2.TabIndex = 8;
      this.button2.Text = "...";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // bBrowseAlbum1
      // 
      this.bBrowseAlbum1.Location = new System.Drawing.Point(293, 57);
      this.bBrowseAlbum1.Name = "bBrowseAlbum1";
      this.bBrowseAlbum1.Size = new System.Drawing.Size(29, 27);
      this.bBrowseAlbum1.TabIndex = 7;
      this.bBrowseAlbum1.Text = "...";
      this.bBrowseAlbum1.UseVisualStyleBackColor = true;
      // 
      // cboAlbum2
      // 
      this.cboAlbum2.FormattingEnabled = true;
      this.cboAlbum2.Location = new System.Drawing.Point(29, 109);
      this.cboAlbum2.Name = "cboAlbum2";
      this.cboAlbum2.Size = new System.Drawing.Size(258, 27);
      this.cboAlbum2.TabIndex = 6;
      // 
      // cboAlbum1
      // 
      this.cboAlbum1.FormattingEnabled = true;
      this.cboAlbum1.Location = new System.Drawing.Point(29, 57);
      this.cboAlbum1.Name = "cboAlbum1";
      this.cboAlbum1.Size = new System.Drawing.Size(258, 27);
      this.cboAlbum1.TabIndex = 3;
      // 
      // lAlbum2Caption
      // 
      this.lAlbum2Caption.AutoSize = true;
      this.lAlbum2Caption.Location = new System.Drawing.Point(25, 87);
      this.lAlbum2Caption.Name = "lAlbum2Caption";
      this.lAlbum2Caption.Size = new System.Drawing.Size(66, 19);
      this.lAlbum2Caption.TabIndex = 2;
      this.lAlbum2Caption.Text = "Album 2:";
      // 
      // lAlbum1Caption
      // 
      this.lAlbum1Caption.AutoSize = true;
      this.lAlbum1Caption.Location = new System.Drawing.Point(25, 35);
      this.lAlbum1Caption.Name = "lAlbum1Caption";
      this.lAlbum1Caption.Size = new System.Drawing.Size(66, 19);
      this.lAlbum1Caption.TabIndex = 1;
      this.lAlbum1Caption.Text = "Album 1:";
      // 
      // cbIsPodcast
      // 
      this.cbIsPodcast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbIsPodcast.AutoSize = true;
      this.cbIsPodcast.Location = new System.Drawing.Point(7, 498);
      this.cbIsPodcast.Name = "cbIsPodcast";
      this.cbIsPodcast.Size = new System.Drawing.Size(94, 23);
      this.cbIsPodcast.TabIndex = 4;
      this.cbIsPodcast.Text = "Is Podcast";
      this.cbIsPodcast.UseVisualStyleBackColor = true;
      // 
      // tArticleText
      // 
      this.tArticleText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tArticleText.Location = new System.Drawing.Point(7, 83);
      this.tArticleText.Multiline = true;
      this.tArticleText.Name = "tArticleText";
      this.tArticleText.Size = new System.Drawing.Size(1114, 409);
      this.tArticleText.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 61);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(86, 19);
      this.label1.TabIndex = 2;
      this.label1.Text = "Article Text:";
      // 
      // dtpArticleDate
      // 
      this.dtpArticleDate.CustomFormat = "MM/dd/yyyy HH:mm tt";
      this.dtpArticleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpArticleDate.Location = new System.Drawing.Point(7, 31);
      this.dtpArticleDate.Name = "dtpArticleDate";
      this.dtpArticleDate.Size = new System.Drawing.Size(200, 27);
      this.dtpArticleDate.TabIndex = 1;
      // 
      // lArticleDateCaption
      // 
      this.lArticleDateCaption.AutoSize = true;
      this.lArticleDateCaption.Location = new System.Drawing.Point(3, 9);
      this.lArticleDateCaption.Name = "lArticleDateCaption";
      this.lArticleDateCaption.Size = new System.Drawing.Size(90, 19);
      this.lArticleDateCaption.TabIndex = 0;
      this.lArticleDateCaption.Text = "Article Date:";
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1376, 759);
      this.Controls.Add(this.scMain);
      this.Controls.Add(this.msMainMenu);
      this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MainMenuStrip = this.msMainMenu;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MinimumSize = new System.Drawing.Size(800, 540);
      this.Name = "frmMain";
      this.Text = "HeavyMotion Podcast Admin Utility";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.msMainMenu.ResumeLayout(false);
      this.msMainMenu.PerformLayout();
      this.scMain.Panel1.ResumeLayout(false);
      this.scMain.Panel2.ResumeLayout(false);
      this.scMain.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
      this.scMain.ResumeLayout(false);
      this.pArticleType.ResumeLayout(false);
      this.pArticleType.PerformLayout();
      this.gbPodcastInfo.ResumeLayout(false);
      this.gbPodcastInfo.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip msMainMenu;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    private System.Windows.Forms.SplitContainer scMain;
    private System.Windows.Forms.ListBox lbArticles;
    private System.Windows.Forms.Panel pArticleType;
    private System.Windows.Forms.RadioButton rbShowAll;
    private System.Windows.Forms.RadioButton rbNewsOnly;
    private System.Windows.Forms.RadioButton rbPodcastsOnly;
    private System.Windows.Forms.Label lArticleDateCaption;
    private System.Windows.Forms.DateTimePicker dtpArticleDate;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tArticleText;
    private System.Windows.Forms.CheckBox cbIsPodcast;
    private System.Windows.Forms.GroupBox gbPodcastInfo;
    private System.Windows.Forms.Label lAlbum2Caption;
    private System.Windows.Forms.Label lAlbum1Caption;
    private System.Windows.Forms.ComboBox cboAlbum2;
    private System.Windows.Forms.ComboBox cboAlbum1;
    private System.Windows.Forms.Button bRevert;
    private System.Windows.Forms.Button bSave;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button bBrowseAlbum1;
  }
}


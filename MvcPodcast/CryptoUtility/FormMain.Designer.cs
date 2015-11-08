namespace CryptoUtility
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
      this.msMain = new System.Windows.Forms.MenuStrip();
      this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
      this.lSourceStringCaption = new System.Windows.Forms.Label();
      this.tSourceString = new System.Windows.Forms.TextBox();
      this.tOutputString = new System.Windows.Forms.TextBox();
      this.lOutputStringCaption = new System.Windows.Forms.Label();
      this.bGo = new System.Windows.Forms.Button();
      this.gbCryptoFunction = new System.Windows.Forms.GroupBox();
      this.rbEncrypt = new System.Windows.Forms.RadioButton();
      this.rbDecrypt = new System.Windows.Forms.RadioButton();
      this.bCopyToClipboard = new System.Windows.Forms.Button();
      this.bClear = new System.Windows.Forms.Button();
      this.msMain.SuspendLayout();
      this.gbCryptoFunction.SuspendLayout();
      this.SuspendLayout();
      // 
      // msMain
      // 
      this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
      this.msMain.Location = new System.Drawing.Point(0, 0);
      this.msMain.Name = "msMain";
      this.msMain.Size = new System.Drawing.Size(476, 24);
      this.msMain.TabIndex = 0;
      this.msMain.Text = "menuStrip1";
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
      // lSourceStringCaption
      // 
      this.lSourceStringCaption.AutoSize = true;
      this.lSourceStringCaption.Location = new System.Drawing.Point(12, 41);
      this.lSourceStringCaption.Name = "lSourceStringCaption";
      this.lSourceStringCaption.Size = new System.Drawing.Size(71, 13);
      this.lSourceStringCaption.TabIndex = 1;
      this.lSourceStringCaption.Text = "Source String";
      // 
      // tSourceString
      // 
      this.tSourceString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tSourceString.Location = new System.Drawing.Point(12, 57);
      this.tSourceString.Name = "tSourceString";
      this.tSourceString.Size = new System.Drawing.Size(452, 20);
      this.tSourceString.TabIndex = 2;
      // 
      // tOutputString
      // 
      this.tOutputString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tOutputString.Location = new System.Drawing.Point(12, 110);
      this.tOutputString.Name = "tOutputString";
      this.tOutputString.ReadOnly = true;
      this.tOutputString.Size = new System.Drawing.Size(452, 20);
      this.tOutputString.TabIndex = 4;
      // 
      // lOutputStringCaption
      // 
      this.lOutputStringCaption.AutoSize = true;
      this.lOutputStringCaption.Location = new System.Drawing.Point(12, 94);
      this.lOutputStringCaption.Name = "lOutputStringCaption";
      this.lOutputStringCaption.Size = new System.Drawing.Size(69, 13);
      this.lOutputStringCaption.TabIndex = 3;
      this.lOutputStringCaption.Text = "Output String";
      // 
      // bGo
      // 
      this.bGo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.bGo.Location = new System.Drawing.Point(389, 209);
      this.bGo.Name = "bGo";
      this.bGo.Size = new System.Drawing.Size(75, 23);
      this.bGo.TabIndex = 5;
      this.bGo.Text = "Go";
      this.bGo.UseVisualStyleBackColor = true;
      this.bGo.Click += new System.EventHandler(this.bGo_Click);
      // 
      // gbCryptoFunction
      // 
      this.gbCryptoFunction.Controls.Add(this.rbDecrypt);
      this.gbCryptoFunction.Controls.Add(this.rbEncrypt);
      this.gbCryptoFunction.Location = new System.Drawing.Point(15, 136);
      this.gbCryptoFunction.Name = "gbCryptoFunction";
      this.gbCryptoFunction.Size = new System.Drawing.Size(449, 51);
      this.gbCryptoFunction.TabIndex = 6;
      this.gbCryptoFunction.TabStop = false;
      this.gbCryptoFunction.Text = "Crypto Function";
      // 
      // rbEncrypt
      // 
      this.rbEncrypt.AutoSize = true;
      this.rbEncrypt.Checked = true;
      this.rbEncrypt.Location = new System.Drawing.Point(88, 19);
      this.rbEncrypt.Name = "rbEncrypt";
      this.rbEncrypt.Size = new System.Drawing.Size(61, 17);
      this.rbEncrypt.TabIndex = 0;
      this.rbEncrypt.TabStop = true;
      this.rbEncrypt.Text = "Encrypt";
      this.rbEncrypt.UseVisualStyleBackColor = true;
      // 
      // rbDecrypt
      // 
      this.rbDecrypt.AutoSize = true;
      this.rbDecrypt.Location = new System.Drawing.Point(260, 19);
      this.rbDecrypt.Name = "rbDecrypt";
      this.rbDecrypt.Size = new System.Drawing.Size(62, 17);
      this.rbDecrypt.TabIndex = 1;
      this.rbDecrypt.Text = "Decrypt";
      this.rbDecrypt.UseVisualStyleBackColor = true;
      // 
      // bCopyToClipboard
      // 
      this.bCopyToClipboard.Location = new System.Drawing.Point(15, 209);
      this.bCopyToClipboard.Name = "bCopyToClipboard";
      this.bCopyToClipboard.Size = new System.Drawing.Size(110, 23);
      this.bCopyToClipboard.TabIndex = 7;
      this.bCopyToClipboard.Text = "Copy to Clipboard";
      this.bCopyToClipboard.UseVisualStyleBackColor = true;
      this.bCopyToClipboard.Click += new System.EventHandler(this.bCopyToClipboard_Click);
      // 
      // bClear
      // 
      this.bClear.Location = new System.Drawing.Point(131, 209);
      this.bClear.Name = "bClear";
      this.bClear.Size = new System.Drawing.Size(75, 23);
      this.bClear.TabIndex = 8;
      this.bClear.Text = "Clear";
      this.bClear.UseVisualStyleBackColor = true;
      this.bClear.Click += new System.EventHandler(this.bClear_Click);
      // 
      // frmMain
      // 
      this.AcceptButton = this.bGo;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(476, 244);
      this.Controls.Add(this.bClear);
      this.Controls.Add(this.bCopyToClipboard);
      this.Controls.Add(this.gbCryptoFunction);
      this.Controls.Add(this.bGo);
      this.Controls.Add(this.tOutputString);
      this.Controls.Add(this.lOutputStringCaption);
      this.Controls.Add(this.tSourceString);
      this.Controls.Add(this.lSourceStringCaption);
      this.Controls.Add(this.msMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.msMain;
      this.MaximizeBox = false;
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Crypto Utility";
      this.msMain.ResumeLayout(false);
      this.msMain.PerformLayout();
      this.gbCryptoFunction.ResumeLayout(false);
      this.gbCryptoFunction.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip msMain;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    private System.Windows.Forms.Label lSourceStringCaption;
    private System.Windows.Forms.TextBox tSourceString;
    private System.Windows.Forms.TextBox tOutputString;
    private System.Windows.Forms.Label lOutputStringCaption;
    private System.Windows.Forms.Button bGo;
    private System.Windows.Forms.GroupBox gbCryptoFunction;
    private System.Windows.Forms.RadioButton rbDecrypt;
    private System.Windows.Forms.RadioButton rbEncrypt;
    private System.Windows.Forms.Button bCopyToClipboard;
    private System.Windows.Forms.Button bClear;
  }
}


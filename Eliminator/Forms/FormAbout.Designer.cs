namespace Eliminator.Forms
{
  partial class FormAbout
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
      this.lAppTitle = new System.Windows.Forms.Label();
      this.lCopyright = new System.Windows.Forms.Label();
      this.pbAppLogo = new System.Windows.Forms.PictureBox();
      this.lVersion = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pbAppLogo)).BeginInit();
      this.SuspendLayout();
      // 
      // lAppTitle
      // 
      this.lAppTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lAppTitle.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lAppTitle.Location = new System.Drawing.Point(208, 12);
      this.lAppTitle.Name = "lAppTitle";
      this.lAppTitle.Size = new System.Drawing.Size(182, 23);
      this.lAppTitle.TabIndex = 0;
      this.lAppTitle.Text = "Eliminator";
      this.lAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lCopyright
      // 
      this.lCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lCopyright.Location = new System.Drawing.Point(208, 35);
      this.lCopyright.Name = "lCopyright";
      this.lCopyright.Size = new System.Drawing.Size(182, 13);
      this.lCopyright.TabIndex = 1;
      this.lCopyright.Text = "Copyright © 2014 Warren Simington";
      this.lCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pbAppLogo
      // 
      this.pbAppLogo.Image = global::Eliminator.Properties.Resources.Eliminator;
      this.pbAppLogo.Location = new System.Drawing.Point(12, 12);
      this.pbAppLogo.Name = "pbAppLogo";
      this.pbAppLogo.Size = new System.Drawing.Size(190, 203);
      this.pbAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pbAppLogo.TabIndex = 2;
      this.pbAppLogo.TabStop = false;
      // 
      // lVersion
      // 
      this.lVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lVersion.Location = new System.Drawing.Point(212, 198);
      this.lVersion.Name = "lVersion";
      this.lVersion.Size = new System.Drawing.Size(178, 17);
      this.lVersion.TabIndex = 3;
      this.lVersion.Text = "Version";
      this.lVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      // 
      // FormAbout
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(402, 229);
      this.Controls.Add(this.lVersion);
      this.Controls.Add(this.pbAppLogo);
      this.Controls.Add(this.lCopyright);
      this.Controls.Add(this.lAppTitle);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormAbout";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "About";
      this.Load += new System.EventHandler(this.FormAbout_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pbAppLogo)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lAppTitle;
    private System.Windows.Forms.Label lCopyright;
    private System.Windows.Forms.PictureBox pbAppLogo;
    private System.Windows.Forms.Label lVersion;
  }
}
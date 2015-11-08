using System;
using System.Windows.Forms;
using Wes.Crypto;

namespace CryptoUtility
{
  public partial class frmMain : Form
  {
    #region Constructors
    public frmMain()
    {
      InitializeComponent();
    } 
    #endregion

    #region Private Members
    private static byte[] _iv = new byte[]
    {
      0x50, 0xCE, 0x23, 0x89, 0x3A, 0x5D, 0xA6, 0xCF, 
      0xAB, 0x03, 0x1A, 0x6B, 0x12, 0x3E, 0xAE, 0x91
    };

    private static byte[] _key = new byte[]
    {
      0x8F, 0xE9, 0xB5, 0xF2, 0x37, 0x2D, 0x2C, 0x21, 
      0x10, 0x01, 0x06, 0x19, 0x26, 0x07, 0x08, 0x26, 
      0xE3, 0x08, 0x74, 0x2F, 0xA4, 0xAD, 0xC6, 0xA1, 
      0xED, 0x3D, 0x27, 0xFD, 0x05, 0x1F, 0xE8, 0xA3
    }; 
    #endregion

    #region Private Methods
    private void DisplayError(string message)
    {
      MessageBox.Show(this, message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void mnuFileExit_Click(object sender, EventArgs e)
    {
      try
      {
        Application.Exit();
      }
      catch (Exception ex)
      {
        DisplayError(ex.Message);
      }
    } 
    #endregion

    private void bGo_Click(object sender, EventArgs e)
    {
      try
      {
        //Make sure that we have a value
        if (string.IsNullOrWhiteSpace(tSourceString.Text))
          throw new ApplicationException("No source string provided.");

        Rijndael rijndael = new Rijndael(_key, _iv);

        string input = tSourceString.Text.Trim();
        
        string output;
        if (rbEncrypt.Checked)
        {
          output = rijndael.Encrypt(input);
        }
        else
        {
          output = rijndael.Decrypt(tSourceString.Text);
        }

        tOutputString.Text = output;
      }
      catch (Exception ex)
      {
        DisplayError(ex.Message);
      }
    }

    private void bCopyToClipboard_Click(object sender, EventArgs e)
    {
      try
      {
        Clipboard.SetText(tOutputString.Text);
      }
      catch (Exception ex)
      {
        DisplayError(ex.Message);
      }
    }

    private void bClear_Click(object sender, EventArgs e)
    {
      try
      {
        tSourceString.Clear();
        tOutputString.Clear();
      }
      catch (Exception ex)
      {
        DisplayError(ex.Message);
      }
    }
  }
}

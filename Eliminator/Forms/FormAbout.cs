using System;
using System.Reflection;
using System.Windows.Forms;
using Eliminator.Utility;

namespace Eliminator.Forms
{
  public partial class FormAbout : Form
  {
    #region Constructors
    public FormAbout()
    {
      InitializeComponent();
    } 
    #endregion

    #region Private Methods
    private void FormAbout_Load(object sender, EventArgs e)
    {
      try
      {
        //Get the app title from the assembly
        string appTitle = Assembly.GetExecutingAssembly().GetName().Name;

        //Set the form caption
        const string ABOUT_FORM_CAPTION_FORMAT = "About {0}";
        this.Text = string.Format(ABOUT_FORM_CAPTION_FORMAT, appTitle);

        //Set the app title label
        lAppTitle.Text = appTitle;

        //Set the version
        lVersion.Text = string.Format("v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    } 
    #endregion
  }
}

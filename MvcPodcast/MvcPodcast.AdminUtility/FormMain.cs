using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Blog.Common.BusinessObjects;
using Blog.Common.Implementation.Repository;
using Blog.Common.Interfaces;

namespace Blog.AdminUtility
{
  public partial class frmMain : Form
  {
    #region Constructors
    public frmMain()
    {
      InitializeComponent();

      _repository = new MsSqlRepository();
    } 
    #endregion

    #region Private Members
    private IBlogRepository _repository; 
    #endregion

    #region Private Methods
    private void ArticleTypeChanged(object sender, EventArgs e)
    {
      try
      {
        try
        {
          this.Cursor = Cursors.WaitCursor;
          LoadArticles();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
      catch (Exception ex)
      {
        DisplayError(ex.Message);
      }
    }

    private void DisplayError(string message)
    {
      MessageBox.Show(this, message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void LoadArticles()
    {
      //Load the data by the article type selected
      IEnumerable<NewsArticle> articles;

      if (rbPodcastsOnly.Checked)
      {
        //We are showing only podcasts, so get the appropriate data collection
        articles = _repository.GetPodcasts();
      }
      else
      {
        //We're either showing all articles or news only
        articles = _repository.GetArticles();

        //If we're showing news only, further whittle down our data collection
        if (rbNewsOnly.Checked)
        {
          articles = (from a in articles
                      where !(a is PodcastArticle)
                      select a).ToList();
        }
      }

      lbArticles.DisplayMember = "PostDateTime";
      lbArticles.ValueMember = "Id";
      lbArticles.DataSource = articles;
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      try
      {
        LoadArticles();
      }
      catch (Exception ex)
      {
        DisplayError(ex.Message);
      }
    }

    private void lbArticles_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        //TODO: Load the selected article
      }
      catch (Exception ex)
      {
        DisplayError(ex.Message);
      }
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
  }
}

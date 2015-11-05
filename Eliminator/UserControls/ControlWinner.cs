using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eliminator.Utility;
using Eliminator.BusinessObjects;

namespace Eliminator.UserControls
{
  public partial class ControlWinner : UserControl
  {
    #region Constructors
    public ControlWinner()
    {
      InitializeComponent();

      _winner = null;
    } 
    #endregion

    #region Private Members
    private Winner _winner; 
    #endregion

    #region Private Methods
    /// <summary>
    /// Draw the lines on the control.
    /// </summary>
    private void DrawLines()
    {
      //Prepare the Graphics and Pen objects
      Graphics g = this.CreateGraphics();
      Pen pen = Ui.CreateBracketPen();

      //Declare constants to help adjust bracket line positioning
      const int TEXTBOX_BOTTOM_LINE_OFFSET = 2;
      const int TEXTBOX_RIGHT_LINE_OFFSET = 8;

      //Draw the winner line
      //Get the starting position to draw the line under the Winner text box
      int winnerX = this.ClientRectangle.Left;
      int winnerY = tWinner.Bottom + TEXTBOX_BOTTOM_LINE_OFFSET;
      Point winnerLineStart = new Point(winnerX, winnerY);

      //Get the end position for the line under the Winner text box
      winnerX = this.Right - TEXTBOX_RIGHT_LINE_OFFSET;
      //Y stays the same, since we're drawing a horizontal line
      Point winnerLineEnd = new Point(winnerX, winnerY);

      //Draw the line
      g.DrawLine(pen, winnerLineStart, winnerLineEnd);
    }

    /// <summary>
    /// Refreshes the bracket control's UI.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Reload(object sender, EventArgs e)
    {
      //Set the competitor information (name and seed) in the control
      string competitorDesc = string.Empty;

      //Set Winner information
      if (_winner.Competitor != null)
      {
        //If it's a seeded tournament, show the seed
        if (_winner.SeedOption == SeedOption.Seeded)
          competitorDesc = string.Format(Constants.COMPETITOR_DISPLAY_FORMAT_SEEDED, _winner.Competitor.Seed, _winner.Competitor.Name);
        else
          competitorDesc = _winner.Competitor.Name;
      }

      tWinner.ForeColor = Ui.AdvanceCompetitorColor;
      tWinner.Text = competitorDesc;
    }
    
    private void ControlWinner_Paint(object sender, PaintEventArgs e)
    {
      try
      {
        DrawLines();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuUndo_Click(object sender, EventArgs e)
    {
      try
      {
        _winner.Competitor = null;
        Reload(null, null);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void cmsWinnerMenu_Opening(object sender, CancelEventArgs e)
    {
      try
      {
        //Only show the undo option if the child bracket is assigned and completed
        bool showUndo = ((_winner.ChildBracket != null) && (_winner.ChildBracket.Completed));

        e.Cancel = (!showUndo);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }
    #endregion

    #region Public Properties
    public Winner Winner
    {
      get
      {
        return _winner;
      }
      set
      {
        //Store the Bracket object internally
        _winner = value;

        //Hook up an event handler to update the control
        _winner.Updated += this.Reload;

        //Reload the bracket control info
        Reload(null, null);
      }
    } 
    #endregion 
  }
}

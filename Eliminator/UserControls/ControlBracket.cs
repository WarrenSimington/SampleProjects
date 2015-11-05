using Eliminator.BusinessObjects;
using Eliminator.Utility;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Eliminator.UserControls
{
  public partial class ControlBracket : UserControl
  {
    #region Constructors
    public ControlBracket()
    {
      InitializeComponent();

      DrawBracketLines();
      _bracket = null;
    } 
    #endregion

    #region Private Constants
    private const string URL_INDICATOR_SUBSTRING = "http"; 
    #endregion
    
    #region Private Enums
    private enum MenuVisibilityOption { Competitor1, Competitor2, Both }; 
    #endregion

    #region Private Members
    private Bracket _bracket;
    private ToolTip _toolTip;
    #endregion

    #region Private Methods
    /// <summary>
    /// Draws the bracket lines on the control.
    /// </summary>
    private void DrawBracketLines()
    {
      //Prepare the Graphics and Pen objects
      Graphics g = this.CreateGraphics();
      Pen pen = Ui.CreateBracketPen();

      //Declare constants to help adjust bracket line positioning
      const int BRACKET_RIGHT_LINE_LEFT_OFFSET = -2;
      const int TEXTBOX_BOTTOM_LINE_OFFSET = 2;

      //DRAW THE LINE FOR COMPETITOR 1
      //Get the starting position to draw the line under the Competitor 1 text box
      int comp1X = this.ClientRectangle.Left;
      int comp1Y = tCompetitor1.Bottom + TEXTBOX_BOTTOM_LINE_OFFSET;
      Point comp1LineStart = new Point(comp1X, comp1Y);

      //Get the end position for the line under the Competitor 1 text box
      comp1X = this.ClientRectangle.Right;
      //Y stays the same, since we're drawing a horizontal line
      Point comp1LineEnd = new Point(comp1X, comp1Y);

      //Draw the line
      g.DrawLine(pen, comp1LineStart, comp1LineEnd);
      

      //DRAW THE LINE FOR COMPETITOR 2
      //Get the starting position to draw the line under the Competitor 2 text box
      int comp2X = this.ClientRectangle.Left;
      int comp2Y = tCompetitor2.Bottom + TEXTBOX_BOTTOM_LINE_OFFSET;
      Point comp2LineStart = new Point(comp2X, comp2Y);

      //Get the end position for the line under the Competitor 2 text box
      comp2X = this.ClientRectangle.Right;
      //Y stays the same, since we're drawing a horizontal line
      Point comp2LineEnd = new Point(comp2X, comp2Y);

      //Draw the line
      g.DrawLine(pen, comp2LineStart, comp2LineEnd);

      //DRAW THE LINE TO CONNECT THE BRACKET ON THE RIGHT SIDE
      g.DrawLine(pen, new Point(this.ClientRectangle.Right + BRACKET_RIGHT_LINE_LEFT_OFFSET, comp1LineEnd.Y), 
          new Point(this.ClientRectangle.Right + BRACKET_RIGHT_LINE_LEFT_OFFSET, comp2LineEnd.Y));
    }

    /// <summary>
    /// Hides the internal ToolTip object.
    /// </summary>
    private void HideCompetitorToolTip()
    {
      _toolTip.Hide(this);
      _toolTip = null;
    }

    /// <summary>
    /// Determines whether or not the provided string is a URL.
    /// </summary>
    /// <param name="textVal"></param>
    /// <returns></returns>
    private bool IsUrl(string textVal)
    {
      return (textVal.ToLower().Trim().IndexOf(URL_INDICATOR_SUBSTRING.ToLower()) == 0);
    }

    /// <summary>
    /// Executes the Windows default action for the provided URL.
    /// Typically, this means that a browser opens the provided URL.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private void OpenUrlInBrowser(string url)
    {
      Process.Start(url);
    }
    
    /// <summary>
    /// Refreshes the bracket control's UI.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Reload(object sender, EventArgs e)
    {
      //Set competitor control text
      SetCompetitorTextAndColor();
    }

    /// <summary>
    /// Resets the current bracket's child bracket controls to use standard competitor colors.
    /// </summary>
    private void ResetChildBracketColorsToStandard()
    {
      //For both child brackets, fire off the OnUpdated event handler so that the controls
      //know to redraw themselves
      _bracket.ChildBracket.OnUpdated(null);
      _bracket.ChildBracket2.OnUpdated(null);
    }

    /// <summary>
    /// Sets the text for each competitor textbox control for the bracket.
    /// </summary>
    private void SetCompetitorTextAndColor()
    {
      //Set the competitor information (name and seed) in the control
      const string BYE_INDICATOR = "BYE";

      //Perform the following logic to set the bracket control UI for each competitor (there are 2)
      Competitor targetCompetitor;
      TextBox targetControl;
      string competitorDesc;

      for (int i = 1; i <= 2; i++)
      {
        switch (i)
        {
          case 1:
            {
              targetCompetitor = _bracket.Competitor;
              targetControl = tCompetitor1;
              break;
            }

          case 2:
            {
              targetCompetitor = _bracket.Competitor2;
              targetControl = tCompetitor2;
              break;
            }

          default:
            continue;
        }

        //Set the string to display for the competitor control
        if (targetCompetitor != null)
        {
          //If the tournament is seeded, show the seed
          if (_bracket.SeedOption == SeedOption.Seeded)
            competitorDesc = string.Format(Constants.COMPETITOR_DISPLAY_FORMAT_SEEDED, targetCompetitor.Seed, targetCompetitor.Name);
          else
            competitorDesc = targetCompetitor.Name; 
        }
        else
        {
          if (_bracket.HasChildrenBrackets)
            competitorDesc = string.Empty;
          else
            competitorDesc = BYE_INDICATOR;
        }

        //Set the text forecolor for the competitor textbox
        Color foreColor;
        if ((targetCompetitor == null) && (!_bracket.HasChildrenBrackets))
        {
          foreColor = Ui.ByeCompetitorColor;
        }
        else
        {
          if (_bracket.Completed)
          {
            if (targetCompetitor == _bracket.AdvancedCompetitor)
              foreColor = Ui.AdvanceCompetitorColor;
            else
              foreColor = Ui.StandardCompetitorColor;
          }
          else
            foreColor = Ui.StandardCompetitorColor;
        }

        targetControl.ForeColor = foreColor;

        //Set the text for the competitor textbox
        targetControl.Text = competitorDesc;
      }
    }

    /// <summary>
    /// Sets the control's cursor, based on whether the text is a URL or not.
    /// </summary>
    /// <param name="sourceTextBox"></param>
    private void SetTextBoxControlCursor(TextBox sourceTextBox)
    {
      //Check to see if the text is a URL
      if (IsUrl(sourceTextBox.Text))
        sourceTextBox.Cursor = Cursors.Hand;
      else
        sourceTextBox.Cursor = Cursors.Default;
    }

    /// <summary>
    /// Shows a tool tip for the source TextBox control.
    /// </summary>
    /// <param name="sourceTextBox"></param>
    private void ShowCompetitorToolTip(TextBox sourceTextBox)
    {
      //Offset the tooltip position so that it doesn't appear exactly where the control is
      int TOOLTIP_X_OFFSET = 12;
      int TOOLTIP_Y_OFFSET = 36;
      Point toolTipLocation = new Point(sourceTextBox.Location.X + TOOLTIP_X_OFFSET, sourceTextBox.Location.Y + TOOLTIP_Y_OFFSET);
      
      _toolTip = new ToolTip();
      _toolTip.Show(sourceTextBox.Text, this, toolTipLocation);
    }
    
    /// <summary>
    /// Display and set the text for menu items based on the source control that opened the context menu.
    /// </summary>
    /// <param name="menuVisibilityOption"></param>
    /// <param name="competitor1"></param>
    /// <param name="competitor2"></param>
    private void SetContextMenuTextAndItemVisibility(MenuVisibilityOption menuVisibilityOption, string competitor1, 
        string competitor2)
    {
      const string ADVANCE_COMPETITOR_CAPTION = "Advance \"{0}\"";

      mnuAdvanceCompetitor1.Text = string.Format(ADVANCE_COMPETITOR_CAPTION, competitor1);
      mnuAdvanceCompetitor1.Visible = 
          (
            (_bracket.Competitor != null) && 
            (
              (menuVisibilityOption == MenuVisibilityOption.Competitor1) || 
              (menuVisibilityOption == MenuVisibilityOption.Both)
            )
          );

      mnuAdvanceCompetitor2.Text = string.Format(ADVANCE_COMPETITOR_CAPTION, competitor2);
      mnuAdvanceCompetitor2.Visible = 
          (
            (_bracket.Competitor2 != null) &&
            (
              (menuVisibilityOption == MenuVisibilityOption.Competitor2) ||
              (menuVisibilityOption == MenuVisibilityOption.Both)
            )
          );

      bool showUndo =   (
                          (_bracket.ChildBracket != null) && 
                          (_bracket.ChildBracket2 != null) && 
                          (_bracket.ChildBracket.Completed) && 
                          (_bracket.ChildBracket2.Completed)
                        );
      mnuSeparator1.Visible = showUndo;
      mnuUndo.Visible = showUndo;
    }

    private void cmsBracketMenu_Opening(object sender, CancelEventArgs e)
    {
      try
      {
        //If no competitors have been assigned to the bracket yet, or the bracket
        //has already been completed to the next level in the tournament, prevent the
        //popup menu from showing and clear both textboxes
        if (
              ((!_bracket.Assigned) || (_bracket.Completed)) ||
              ((_bracket.ParentBracket is Winner) && (((Winner)_bracket.ParentBracket).Completed))
            )
          e.Cancel = true;
        
        //Get the control that invoked the context menu
        Control sourceControl = ((ContextMenuStrip)sender).SourceControl;

        string competitor1DisplayInfo = tCompetitor1.Text;
        string competitor2DisplayInfo = tCompetitor2.Text;
        
        //Set menu visibility and item caption appropriately
        SetContextMenuTextAndItemVisibility(MenuVisibilityOption.Both, competitor1DisplayInfo, competitor2DisplayInfo);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuAdvanceCompetitor1_Click(object sender, EventArgs e)
    {
      try
      {
        //Advance the competitor in the #1 slot to the next level in the tournament
        _bracket.Advance(_bracket.Competitor);

        //Refresh the control now that we've advanced a competitor
        Reload(null, null);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuAdvanceCompetitor2_Click(object sender, EventArgs e)
    {
      try
      {
        //Advance the competitor in the #2 slot to the next level in the tournament
        _bracket.Advance(_bracket.Competitor2);

        //Refresh the control now that we've advanced a competitor
        Reload(null, null);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void ControlBracket_Paint(object sender, PaintEventArgs e)
    {
      try
      {
        DrawBracketLines();
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
        _bracket.Competitor = null;
        _bracket.Competitor2 = null;

        //Reset the competitor text color of the child bracket that advanced to this level
        //to the standard coloring
        ResetChildBracketColorsToStandard();

        Reload(null, null);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor1_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        ShowCompetitorToolTip((TextBox)sender);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor1_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        HideCompetitorToolTip();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor2_MouseEnter(object sender, EventArgs e)
    {
      try
      {
        ShowCompetitorToolTip((TextBox)sender);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor2_MouseLeave(object sender, EventArgs e)
    {
      try
      {
        HideCompetitorToolTip();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor1_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetTextBoxControlCursor((TextBox)sender);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor2_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetTextBoxControlCursor((TextBox)sender);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor1_Click(object sender, EventArgs e)
    {
      try
      {
        string comp1Text = ((TextBox)sender).Text;
        if (IsUrl(comp1Text))
          OpenUrlInBrowser(comp1Text);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void tCompetitor2_MouseClick(object sender, MouseEventArgs e)
    {
      try
      {
        string comp2Text = ((TextBox)sender).Text;
        if (IsUrl(comp2Text))
          OpenUrlInBrowser(comp2Text);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }
    #endregion

    #region Public Properties
    public Bracket Bracket
    {
      get
      {
        return _bracket;
      }
      set
      {
        //Store the Bracket object internally
        _bracket = value;

        //Hook up an event handler to update the control
        _bracket.Updated += this.Reload;

        //Reload the bracket control info
        Reload(null, null);
      }
    } 
    #endregion
  }
}

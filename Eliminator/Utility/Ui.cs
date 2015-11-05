using System.Drawing;
using System.Windows.Forms;

namespace Eliminator.Utility
{
  public static class Ui
  {
    #region Public Methods
    /// <summary>
    /// Returns a Pen object used to draw all bracket lines for the UI.
    /// </summary>
    /// <returns></returns>
    public static Pen CreateBracketPen()
    {
      return new Pen(Color.DarkGray, 4);
    }

    /// <summary>
    /// Common method to display error messages.
    /// </summary>
    /// <param name="message"></param>
    public static void DisplayError(string message)
    {
      MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } 
    #endregion

    #region Public Properties
    /// <summary>
    /// Color to use for competitors that have advanced to the next level in the tournament.
    /// </summary>
    public static Color AdvanceCompetitorColor
    {
      get
      {
        return Color.LimeGreen;
      }
    }

    /// <summary>
    /// Color to use for bye competitor slots.
    /// </summary>
    public static Color ByeCompetitorColor
    {
      get
      {
        return Color.Orange;
      }
    }

    /// <summary>
    /// Color to use for competitors that have not yet advanced or lost their bracket in the tournament.
    /// </summary>
    public static Color StandardCompetitorColor
    {
      get
      {
        return Color.Black;
      }
    }
    #endregion
  }
}

using Eliminator.BusinessObjects;
using Eliminator.UserControls;
using Eliminator.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Eliminator.Forms
{
  public partial class FormMain : Form
  {
    #region Constructors
    public FormMain()
    {
      InitializeComponent();

      //Initialize private members
      _movingSplitter = false;
      _tournament = null;
      _bracketControls = new List<ControlBracket>();
      _winnerControl = null;
      _currentTournamentFilePath = string.Empty;
    } 
    #endregion

    #region Private Constants
    //Grid column name constants
    private const string COLUMN_NAME_COMPETITOR = "colCompetitor";
    private const string COLUMN_NAME_SEED = "colSeed";
    //Dialog constants
    private const string DIALOG_FILE_FILTER = "Eliminator Tournament Files (*.elim)|*.elim|All Files (*.*)|*.*";
    #endregion

    #region Private Enum
    private enum MoveDirection { Up, Down }; 
    #endregion
    
    #region Private Members
    private List<ControlBracket> _bracketControls;
    private string _currentTournamentFilePath;
    private bool _movingSplitter;
    private Tournament _tournament;
    private ControlWinner _winnerControl;
    #endregion
    
    #region Private Methods
    /// <summary>
    /// Nulls all bracket controls stored in our internal collection and clears the collection after all controls have been nulled.
    /// </summary>
    private void ClearExistingBracketsAndWinner()
    {
      for (int i = _bracketControls.Count - 1; i >= 0; i--)
      {
        _bracketControls[i].Dispose();
        _bracketControls.RemoveAt(i);
      }

      _bracketControls.Clear();

      if (_winnerControl != null)
      {
        _winnerControl.Dispose();
        _winnerControl = null;
      }
    }

    /// <summary>
    /// Creates/draws tournament all brackets and displays on the appropriate panel.
    /// </summary>
    private void DrawTournamentBrackets()
    {
      //If the tournament object hasn't been instantiated, just exit (since there is
      //nothing to draw)
      if (_tournament == null)
        return;
      
      //Clear the existing controls
      ClearExistingBracketsAndWinner();

      const int BRACKET_VERTICAL_MARGIN = 32;
      const int BRACKET_HORIZONTAL_MARGIN = 96;

      //Iterate through each tournament level, starting with the lowest brackets (highest
      //level value) first
      int bracketX = BRACKET_HORIZONTAL_MARGIN;
      int bracketY = BRACKET_VERTICAL_MARGIN;
      int? bracketWidth = null;
      
      int totalLevels = _tournament.TournamentLevels;
      for (int level = totalLevels; level >= 1; level--)
      {
        //Get all Bracket objects for the current level
        List<Bracket> levelBrackets = _tournament.GetBracketsForLevel(level);

        if (level == totalLevels)
        {
          //For the first/lowest level of the tournament, place each bracket evenly
          foreach (Bracket bracket in levelBrackets)
          {
            //Create the bracket control and store it internally
            ControlBracket newBracket = new ControlBracket()
            {
              Bracket = bracket,
              Parent = scLayout.Panel2,
              Location = new Point(bracketX, bracketY),
              Visible = true
            };

            _bracketControls.Add(newBracket);

            //Adjust the Y position for the next bracket
            bracketY += newBracket.Height + BRACKET_VERTICAL_MARGIN;

            //Assign the bracket width, if it hasn't already been assigned already
            if (!bracketWidth.HasValue)
              bracketWidth = newBracket.Width;
          }

          bracketX += bracketWidth.Value + BRACKET_HORIZONTAL_MARGIN;
          bracketY = BRACKET_VERTICAL_MARGIN;
        }
        else
        {
          //Adjust the current level brackets according to the previous level
          
          //Get the previous level's bracket objects
          List<ControlBracket> prevLevelBrackets = (from plb in _bracketControls
                                                    where plb.Bracket.Level == level + 1
                                                    select plb)
                                                    .OrderBy(bc => bc.Bracket.Sequence)
                                                    .ToList();

          int prevLevelBracketIndex = 0;
          
          foreach (Bracket bracket in levelBrackets)
          {
            //Evaluate the next two previous level brackets to determine sizing requirements for the current
            //bracket
            ControlBracket prevLevelTopBracket = prevLevelBrackets[prevLevelBracketIndex++];
            ControlBracket prevLevelBottomBracket = prevLevelBrackets[prevLevelBracketIndex++];

            //Get the coordinates of the right side's midpoint for each previous level's bracket control
            int newBracketX = prevLevelTopBracket.Right;
            int topLeftY = (prevLevelTopBracket.Top) + (prevLevelTopBracket.Bottom - prevLevelTopBracket.Top) / 2;
            int bottomLeftY = (prevLevelBottomBracket.Top) + (prevLevelBottomBracket.Bottom - prevLevelBottomBracket.Top) / 2;

            //Determine the height of the new bracket
            int newBracketHeight = bottomLeftY - topLeftY;

            //Create the new bracket for the level and store it internally
            ControlBracket newBracket = new ControlBracket()
            {
              Bracket = bracket,
              Parent = scLayout.Panel2,
              Location = new Point(newBracketX, topLeftY),
              Height = newBracketHeight,
              Visible = true
            };

            _bracketControls.Add(newBracket);
          }
        }
      }

      //Finally, now that the brackets have been created, create and place the winner control

      //Get the bracket control from the "finals" level
      ControlBracket finalBracketControl = (from bc in _bracketControls
                                            where bc.Bracket.Level == 1
                                            select bc).First();

      //Get the coordinates of the right side's midpoint of the final bracket control
      int winnerX = finalBracketControl.Right;
      int finalBracketMidpointY = finalBracketControl.Bottom - finalBracketControl.Top;
      
      //Determine location and place it in the UI
      _winnerControl = new ControlWinner()
      {
        Winner = _tournament.Winner,
        Parent = scLayout.Panel2,
        Location = new Point(winnerX, finalBracketMidpointY),
        Visible = true
      };
    }

    /// <summary>
    /// Returns a collection of Competitor objects from what has been entered into the grid control.
    /// </summary>
    /// <returns></returns>
    private List<Competitor> GetCompetitors()
    {
      List<Competitor> result = new List<Competitor>();

      foreach (DataGridViewRow row in dgCompetitors.Rows)
      {
        //If we don't have a seed value, just skip this (since it should be the last row)
        if (row.Cells[COLUMN_NAME_SEED].Value == null)
          continue;

        string seedStr = row.Cells[COLUMN_NAME_SEED].Value.ToString();
        string competitorNameVal = row.Cells[COLUMN_NAME_COMPETITOR].Value.ToString();

        //Convert the seed value to an int
        int seedVal = int.Parse(seedStr);

        //Make sure that we have a name for the competitor. If not, throw an exception.
        if (competitorNameVal.Trim().Length == 0)
          throw new InvalidCompetitorNameException(row.Index);

        //Create a Competitor object and add it to the list
        result.Add(new Competitor(seedVal, competitorNameVal.Trim()));
      }

      //Make sure that we have at least two competitors for the tournament
      const int MINIMUM_COMPETITOR_COUNT = 2;
      if (result.Count < MINIMUM_COMPETITOR_COUNT)
        throw new InsufficientCompetitorsException();
      
      return result;
    }
    
    /// <summary>
    /// Returns the SeedOption value based on the radio button option selected on the form.
    /// </summary>
    /// <returns></returns>
    private SeedOption GetSelectedSeed()
    {
      SeedOption result;

      if (rbRandom.Checked)
        result = SeedOption.Random;
      else
        result = SeedOption.Seeded;

      return result;
    }

    /// <summary>
    /// Clears and reloads the competitor grid from competitors in the tournament.
    /// </summary>
    private void LoadCompetitorGridFromTournament()
    {
      //Clear the existing grid
      dgCompetitors.Rows.Clear();

      //Reload the grid with the current tournament competitor information
      List<Competitor> competitors = _tournament.Competitors;
      foreach (Competitor competitor in competitors)
      {
        int newRowIndex = dgCompetitors.Rows.Add();
        DataGridViewRow newRow = dgCompetitors.Rows[newRowIndex];
        newRow.Cells[COLUMN_NAME_SEED].Value = competitor.Seed;
        newRow.Cells[COLUMN_NAME_COMPETITOR].Value = competitor.Name;
      }
    }
    
    /// <summary>
    /// Loads and applies user settings.
    /// </summary>
    private void LoadUserSettings()
    {
      //Set the spltter position
      scLayout.SplitterDistance = UserSettings.Default.SplitterPosition;
    }

    private void MoveCompetitorInGrid(MoveDirection direction, int selectedRowIndex)
    {
      //Based on our direction, check to see if we're at the upper or lower bound and
      //can't move anymore. If that's the case, just exit.
      if  (
            ((direction == MoveDirection.Up) && (selectedRowIndex <= 0)) ||
            ((direction == MoveDirection.Down) && (selectedRowIndex >= dgCompetitors.Rows.Count - 1))
          )
      {
        return;
      }

      //Get the competitor name values and target index value that we'll need for the move
      string movingCompetitorName = dgCompetitors.Rows[selectedRowIndex].Cells[COLUMN_NAME_COMPETITOR].Value.ToString();

      int targetRowIndex;
      if (direction == MoveDirection.Up)
        targetRowIndex = selectedRowIndex - 1;
      else
        targetRowIndex = selectedRowIndex + 1;

      //If we're moving down in the list, make sure that we have a valid competitor to replace. If not, exit.
      if (dgCompetitors.Rows[targetRowIndex].Cells[COLUMN_NAME_COMPETITOR].Value == null)
        return;

      string competitorNameToReplace = dgCompetitors.Rows[targetRowIndex].Cells[COLUMN_NAME_COMPETITOR].Value.ToString();

      //Put the selected competitor in the new target cell
      dgCompetitors.Rows[targetRowIndex].Cells[COLUMN_NAME_COMPETITOR].Value = movingCompetitorName;

      //Place the target competitor in the selected competitor's cell
      dgCompetitors.Rows[selectedRowIndex].Cells[COLUMN_NAME_COMPETITOR].Value = competitorNameToReplace;

      //Select the target row
      dgCompetitors.Rows[targetRowIndex].Selected = true;
    }

    /// <summary>
    /// Prompts the user for a dialog and attempts to open the specified tournament file.
    /// </summary>
    private void OpenTournament()
    {
      //Prompt for save here if a tournament is assigned
      bool cancel;
      PromptForSavingExistingTournament(out cancel);

      //If the user canceled, just exit.
      if (cancel)
        return;
      
      //Get the last save directory that was used
      string lastSaveDirPath = UserSettings.Default.LastSaveDirectory;

      //Create and show the open file dialog
      OpenFileDialog openDialog = new OpenFileDialog();
      openDialog.Filter = DIALOG_FILE_FILTER;
      openDialog.Title = "Open Tournament File";
      
      //If the user cancels the save dialog, just bail.
      if (openDialog.ShowDialog(this) != DialogResult.OK)
        return;

      //We have a selected file, so attempt to deserialize it
      _tournament = Tournament.Load(openDialog.FileName);

      //Load competitor grid
      LoadCompetitorGridFromTournament();
      
      //Create tournament controls in the UI
      DrawTournamentBrackets();
      
      //Set the form caption and file path
      SetTournamentFilePath(openDialog.FileName);

      //Disable the controls on the main form
      SetEditControlUsability(false);
    }

    /// <summary>
    /// Prompts the user to save the existing tournament if one is currently assigned.
    /// </summary>
    private void PromptForSavingExistingTournament(out bool cancel)
    {
      cancel = false;

      //Check to see if the tournament object has already been assigned. If so, ask the user
      //if they want to save the current tournament
      if (_tournament != null)
      {
        DialogResult dialogResult = MessageBox.Show("Do you wish to save the current tournament?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        switch (dialogResult)
        {
          case DialogResult.Yes:
            {
              bool promptUserForDestFilePath = (string.IsNullOrEmpty(_currentTournamentFilePath));
              SaveTournament(promptUserForDestFilePath);
              break;
            }

          case DialogResult.No:
            {
              //The user doesn't want to save, so continue on and get ready for a new
              //tournament
              break;
            }

          case DialogResult.Cancel:
            {
              //The user cancelled, so just bail.
              cancel = true;
              break;
            }

          default:
            {
              //We should never get here. But, if we do, just exit.
              return;
            }
        }
      }
    }

    /// <summary>
    /// Assigns row seed numbers to each competitor in the grid, skipping the row that corresponds to the provided index.
    /// </summary>
    private void ReassignRowSeedNumbers(int rowIndexToSkip)
    {
      int curSeed = 1;
      foreach (DataGridViewRow row in dgCompetitors.Rows)
      {
        string cellValue;

        if (row.Index == rowIndexToSkip)
          cellValue = null;
        else
          cellValue = (curSeed++).ToString();

        row.Cells[COLUMN_NAME_SEED].Value = cellValue;
      }
    }

    /// <summary>
    /// Saves/serializes the internal Tournament object to file.
    /// Prompts the user for the destination file path if necessary.
    /// </summary>
    private void SaveTournament(bool promptUserForDestFilePath)
    {
      try
      {
        //Before attempting to save, verify that we have a Tournament object to save.
        if (_tournament == null)
          throw new NullTournamentException();

        //Default to the tournament's filepath
        string destFilePath = _currentTournamentFilePath;

        //Prompt the user for a destination file path if needed
        if (promptUserForDestFilePath)
        {
          //Get the last save directory that was used
          string lastSaveDirPath = UserSettings.Default.LastSaveDirectory;

          //Create and show the dialog
          SaveFileDialog saveDialog = new SaveFileDialog();
          saveDialog.Filter = DIALOG_FILE_FILTER;
          saveDialog.Title = "Save Tournament To File";
          if ((!string.IsNullOrEmpty(lastSaveDirPath)) && (Directory.Exists(lastSaveDirPath)))
            saveDialog.InitialDirectory = (lastSaveDirPath);

          //If the user cancels the save dialog, just bail.
          if (saveDialog.ShowDialog(this) != DialogResult.OK)
            return;

          destFilePath = saveDialog.FileName;
        }

        //Try to save the tournament
        _tournament.Save(destFilePath);

        //Update the filepath
        SetTournamentFilePath(destFilePath);

        //Save the directory location for later
        UserSettings.Default.LastSaveDirectory = Path.GetDirectoryName(destFilePath);
        UserSettings.Default.Save();
      }
      catch (NullTournamentException ntEx)
      {
        //We are catching this exception here, since this method can be called multiple
        //times throughout the UI, and we can deal with it in one place.
        MessageBox.Show(string.Format("{0} Please create and start a new tournament before attempting to save.", ntEx.Message),
            "Tournament Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }
    
    /// <summary>
    /// Enables/disables edit controls that allow the user to enter/edit tournament information.
    /// </summary>
    /// <param name="enabled"></param>
    private void SetEditControlUsability(bool enabled)
    {
      dgCompetitors.ReadOnly = !enabled;
      dgCompetitors.AllowUserToAddRows = enabled;
      dgCompetitors.AllowUserToDeleteRows = enabled;
      bStart.Enabled = enabled;
      gbSeedOption.Enabled = enabled;
    }
    
    /// <summary>
    /// Hides/shows the competitor grid's Seed column based on the selected seed option.
    /// </summary>
    /// <param name="seedOption"></param>
    private void SetSeedColumnVisibility(SeedOption seedOption)
    {
      colSeed.Visible = (seedOption == SeedOption.Seeded);
    }

    /// <summary>
    /// Updates the tournament save file path and updates the form's caption.
    /// </summary>
    /// <param name="filePath"></param>
    private void SetTournamentFilePath(string filePath)
    {
      //Store the filepath for the tournament internally
      _currentTournamentFilePath = filePath;
      
      //Set the filename to display in the form caption
      string filename;
      if (string.IsNullOrEmpty(filePath))
        filename = "Untitled";
      else
        filename = Path.GetFileName(filePath);

      //Set the form caption text
      this.Text = string.Format("{0} - {1}", Assembly.GetExecutingAssembly().GetName().Name, filename);
    }

    /// <summary>
    /// Shows the number of competitors in the status bar.
    /// </summary>
    private void UpdateCompetitorCount()
    {
      int competitorCount;
      if (dgCompetitors.ReadOnly)
        competitorCount = dgCompetitors.RowCount;
      else
        competitorCount = dgCompetitors.Rows.GetLastRow(DataGridViewElementStates.None);

      tsslCompetitorCount.Text = string.Format("{0} competitor(s)", competitorCount);
    }

    private void mnuFileNew_Click(object sender, EventArgs e)
    {
      try
      {
        bool cancel;
        PromptForSavingExistingTournament(out cancel);

        //If the user canceled the action, just exit.
        if (cancel)
          return;

        //Reset the tournament, clear the bracket display and grid, and re-enable the UI controls
        _tournament = null;
        SetTournamentFilePath(string.Empty);
        ClearExistingBracketsAndWinner();
        dgCompetitors.Rows.Clear();
        SetEditControlUsability(true);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuFileOpen_Click(object sender, EventArgs e)
    {
      try
      {
        OpenTournament();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuFileSave_Click(object sender, EventArgs e)
    {
      try
      {
        //Check to see if we have a file path for the current tournament. If not,
        //prompt the user for one
        bool promptUserForDestFilePath = (string.IsNullOrEmpty(_currentTournamentFilePath));
        SaveTournament(promptUserForDestFilePath);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuFileSaveAs_Click(object sender, EventArgs e)
    {
      try
      {
        //Since we're doing a Save As, make sure we prompt the user for a destination
        //file path
        SaveTournament(true);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuFileExit_Click(object sender, EventArgs e)
    {
      try
      {
        if (_tournament != null)
        {
          if (MessageBox.Show("Do you wish to save the current tournament before exiting?", "Save Before Exit?",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
          {
            bool promptUserForDestFilePath = (string.IsNullOrEmpty(_currentTournamentFilePath));
            SaveTournament(promptUserForDestFilePath);
          }
        }

        Application.Exit();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuAbout_Click(object sender, EventArgs e)
    {
      try
      {
        //Show the About form
        FormAbout aboutForm = new FormAbout();
        aboutForm.ShowDialog(this);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void bStart_Click(object sender, EventArgs e)
    {
      try
      {
        try
        {
          this.Cursor = Cursors.WaitCursor;
          
          //Determine the seed we're to use
          SeedOption seedOption = GetSelectedSeed();

          //Create competitor collection based on what's entered into the form
          List<Competitor> competitors = GetCompetitors();

          //Create the tournament
          _tournament = new Tournament(competitors, seedOption);

          //Disable controls now that the tournament has been created
          SetEditControlUsability(false);

          //If the tournament was seeded randomly, repopulate our competitor grid
          LoadCompetitorGridFromTournament();

          //Draw/create tournament brackets to display on screen
          this.Cursor = Cursors.WaitCursor;
          DrawTournamentBrackets();
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void dgCompetitors_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      try
      {
        //Re-number the rows from the top
        ReassignRowSeedNumbers(e.RowIndex);

        //Update the competitor count in the status bar
        UpdateCompetitorCount();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      try
      {
        //Initialize the tournament file path on form load
        SetTournamentFilePath(string.Empty);
        
        //Load user settings/preferences.
        LoadUserSettings();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void scLayout_SplitterMoved(object sender, SplitterEventArgs e)
    {
      try
      {
        //If the user is moving the splitter, update the splitter position in the user
        //setttings to remember for next time.
        if (_movingSplitter)
        {
          try
          {
            UserSettings.Default.SplitterPosition = scLayout.SplitterDistance;
            UserSettings.Default.Save();
          }
          finally
          {
            //Make sure that we reset the user splitter move flag, regardless of what
            //happens when we try to update the settings.
            _movingSplitter = false;
          }
        }
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void scLayout_SplitterMoving(object sender, SplitterCancelEventArgs e)
    {
      try
      {
        //Set the indicator so that we know that the splitter is being moved by the user.
        if (!_movingSplitter)
          _movingSplitter = true;
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void bMoveUp_Click(object sender, EventArgs e)
    {
      try
      {
        //Make sure we have a row selected
        if (dgCompetitors.SelectedRows.Count == 0)
          throw new NoCompetitorRowSelected();

        //Get the selected row index
        int selectedRowIndex = dgCompetitors.SelectedRows[0].Index;

        //Move the selected row up in the list
        MoveCompetitorInGrid(MoveDirection.Up, selectedRowIndex);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void bMoveDown_Click(object sender, EventArgs e)
    {
      try
      {
        //Make sure we have a row selected
        if (dgCompetitors.SelectedRows.Count == 0)
          throw new NoCompetitorRowSelected();

        //Get the selected row index
        int selectedRowIndex = dgCompetitors.SelectedRows[0].Index;

        //Move the selected row up in the list
        MoveCompetitorInGrid(MoveDirection.Down, selectedRowIndex);
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void rbRandom_CheckedChanged(object sender, EventArgs e)
    {
      try
      {
        SetSeedColumnVisibility(GetSelectedSeed());
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void rbSeeded_CheckedChanged(object sender, EventArgs e)
    {
      try
      {
        SetSeedColumnVisibility(GetSelectedSeed());
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void mnuAddCompetitorsFromClipboard_Click(object sender, EventArgs e)
    {
      try
      {
        if (dgCompetitors.SelectedRows.Count == 0)
        {
          //We don't have any selected rows, so just exit
          return;
        }

        try
        {
          this.Cursor = Cursors.WaitCursor;

          //Get the currently selected row so that we know to kill it and add contents of our 
          //clipboard (we should only have one selected at this point)
          DataGridViewRow selectedRow = dgCompetitors.SelectedRows[0];

          if (selectedRow.Index != dgCompetitors.Rows.GetLastRow(DataGridViewElementStates.None))
          {
            //Remove the row at the current index
            dgCompetitors.Rows.Remove(selectedRow);
          }

          string clipboardContents = Clipboard.GetText();
          string[] newCompetitors = clipboardContents.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

          //Add each competitor that was parsed from the clipboard
          foreach (string competitor in newCompetitors)
          {
            int newRowIndex = dgCompetitors.Rows.Add();
            DataGridViewRow newRow = dgCompetitors.Rows[newRowIndex];
            newRow.Cells[COLUMN_NAME_COMPETITOR].Value = competitor;
          }

          int lastRowIndex = dgCompetitors.Rows.GetLastRow(DataGridViewElementStates.None);
          ReassignRowSeedNumbers(lastRowIndex);
        }
        finally
        {
          this.Cursor = Cursors.Default;
        }
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }

    private void dgCompetitors_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
      try
      {
        UpdateCompetitorCount();
      }
      catch (Exception ex)
      {
        Ui.DisplayError(ex.Message);
      }
    }
    #endregion
  }
}

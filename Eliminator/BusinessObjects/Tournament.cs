using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Eliminator.BusinessObjects
{
  [Serializable]
  public class Tournament
  {
    #region Constructors
    /// <summary>
    /// Private constructor used internally for deserialization.
    /// </summary>
    private Tournament()
    {
    }
    
    /// <summary>
    /// Public constructor used to create a new Tournament.
    /// </summary>
    /// <param name="competitors"></param>
    /// <param name="seedOption"></param>
    public Tournament(List<Competitor> competitors, SeedOption seedOption)
    {
      //Initialize internal members.
      _brackets = new List<Bracket>();
      _winner = null;
      
      //Store the constructor param data.
      Competitors = competitors;
      SeedOption = seedOption;

      //Create the bracket structure for the tournament.
      CreateBrackets();

      //Assign competitors to brackets
      AssignBrackets();

      //Add code here to automatically advance competitors with a bye for the staring level
      AdvanceByeCompetitors();
    } 
    #endregion

    #region Private Members
		private List<Bracket> _brackets;
    private Winner _winner;
	  #endregion
    
    #region Private Methods
    /// <summary>
    /// Automatically advances competitors that have a bye in the lowest level
    /// </summary>
    private void AdvanceByeCompetitors()
    {
      List<Bracket> startingBrackets = this.GetBracketsForLevel(TournamentLevels);
      foreach (Bracket bracket in startingBrackets)
      {
        if ((bracket.Competitor == null) && (bracket.Competitor2 != null))
          bracket.Advance(bracket.Competitor2);
        else if ((bracket.Competitor != null) && (bracket.Competitor2 == null))
          bracket.Advance(bracket.Competitor);
      }
    }
    
    /// <summary>
    /// Assigns competitors to brackets according to the stored seed option.
    /// </summary>
    private void AssignBrackets()
    {
      //Get the bottom bracket level for the tournemnt
      int bottomLevel = CalculateNoOfTournamentLevels();

      if (SeedOption == SeedOption.Seeded)
      {
        //Sort our competitor collection to ensure that they're sorted ascending by seed
        //before we begin bracket assignment
        Competitors.Sort();
      }
      else
      {
        //We're randomizing the competitors. Create a list to hold our randomized result.
        List<Competitor> randomizedCompetitors = new List<Competitor>();

        Random rnd = new Random();
        while (Competitors.Count > 0)
        {
          //Randomly generate an index to grab
          int rndIndex = rnd.Next(Competitors.Count);

          //Get the competitor at that index and add it to the randomized collection
          Competitor tempCompetitor = Competitors[rndIndex];
          randomizedCompetitors.Add(tempCompetitor);
          //Set the seed for the competitor
          tempCompetitor.Seed = randomizedCompetitors.Count;
          //Remove the competitor from the original source list
          Competitors.RemoveAt(rndIndex);
        }

        //Now that our competitors are now in the randomized collection, assign that one
        //as the Competitor collection to use
        Competitors = randomizedCompetitors;
      }
      
      //Assign Competitor 1 slots in starting brackets
      AssignCompetitor1Brackets(bottomLevel);

      //Assign Competitor 2 slots in starting brackets
      AssignCompetitor2Brackets(bottomLevel);
    }

    /// <summary>
    /// Assigns all Competitor 1 slots to the lowest level tournament brackets.
    /// </summary>
    private void AssignCompetitor1Brackets(int lowestBracketLevel)
    {
      //Get the final bracket and drill down from there
      Bracket finalBracket = GetBracketsForLevel(1)[0];

      //Execute Linq query to determine how many brackets are at the lowest level
      int bottomBracketCount = GetBracketsForLevel(lowestBracketLevel).Count;
      
      //Make sure that we have enough brackets for the number of competitors that
      //we have
      if ((bottomBracketCount * 2) < Competitors.Count)
        throw new InvalidBracketCountException(bottomBracketCount, Competitors.Count);

      //Assign competitor 1 fields for the bottom level of brackets
      for (int i = 1; i <= bottomBracketCount; i++)
      {
        Bracket curBracket = finalBracket;

        bool competitorAssigned = false;
        while (!competitorAssigned)
        {
          int bracket1Count = 0;
          int bracket2Count = 0;

          if ((curBracket.ChildBracket != null) && (curBracket.ChildBracket2 != null))
          {
            bracket1Count = curBracket.ChildBracket.AssignedBracketCount;
            bracket2Count = curBracket.ChildBracket2.AssignedBracketCount;

            if (bracket1Count == bracket2Count)
            {
              //Check to see which bracket has a higher seed
              int bracket1HighSeed = curBracket.ChildBracket.AssignedBracketHighestSeed;
              int bracket2HighSeed = curBracket.ChildBracket2.AssignedBracketHighestSeed;

              if (bracket1HighSeed > bracket2HighSeed)
                curBracket = curBracket.ChildBracket;
              else if (bracket2HighSeed > bracket1HighSeed)
                curBracket = curBracket.ChildBracket2;
              else
              {
                //We haven't assigned any brackets yet, so go with the first one
                curBracket = curBracket.ChildBracket;
              }
            }
            else if (bracket1Count > bracket2Count)
            {
              curBracket = curBracket.ChildBracket2;
            }
            else
            {
              curBracket = curBracket.ChildBracket;
            }
          }
          else
          {
            //We've found the bracket we're looking for, so assign the first
            //Competitor
            curBracket.Competitor = (from c in Competitors
                                      where c.Seed == i
                                      select c).First();
            competitorAssigned = true;
          }
        }
      }
    }

    /// <summary>
    /// Assigns all Competitor 2 slots to the lowest level tournament brackets.
    /// </summary>
    private void AssignCompetitor2Brackets(int lowestBracketLevel)
    {
      //All Competitor 1 slots should be filled at this point, so pull all of the starting
      //brackets
      List<Bracket> startingBrackets = GetBracketsForLevel(lowestBracketLevel);
      
      //Iterate through each starting bracket, and assign the Competitor 2 slot. We
      //are assigning slots according to seed using the following formula
      //(Competitor 2 seed = (Total slots + 1) - Competitor 1 seed)
      int totalSlots = startingBrackets.Count * 2;
      foreach(Bracket bracket in startingBrackets)
      {
        //Make sure that the Competitor 1 slot is assigned for the bracket, and 
        //throw an exception if not.
        
        if (bracket.Competitor == null)
          throw new CompetitorNotAssignedException(bracket.Level, bracket.Sequence);

        int targetCompetitor2Seed = totalSlots + 1 - bracket.Competitor.Seed;  

        //Find the competitor that matches the target seed and assign it to the current
        //bracket. If the query returns a default value, null will be assigned, which should
        //result in a bye for the seed.
        bracket.Competitor2 = (from c in Competitors
                               where c.Seed == targetCompetitor2Seed
                               select c).FirstOrDefault();
      }
    }

    /// <summary>
    /// Calculates how many levels deep the tournament will be.
    /// </summary>
    /// <returns></returns>
    private int CalculateNoOfTournamentLevels()
    {
      int result = 0;

      //The tournament level depth/count is a power of two
      while (Math.Pow(2, result) < Competitors.Count)
      {
        result++;
      }

      return result;
    }
    
    /// <summary>
    /// Creates Bracket objects for all available competitor matchups for the tournament.
    /// </summary>
    private void CreateBrackets()
    {
      //Determine the number of levels deep our tournament will be, based on
      //the number of competitors we have
      int tournamentLevelDepth = CalculateNoOfTournamentLevels();

      //Create the winner object
      _winner = new Winner(SeedOption);
      
      //Create the top level (finals-level) Bracket object
      int curBracketLevel = 1;
      int curBracketSequenceNo = 1;
      Bracket topLevelBracket = new Bracket(SeedOption, curBracketLevel, curBracketSequenceNo)
      {
        ParentBracket = _winner
      };
      
      //Assign the top-level bracket as the Winner object's child
      _winner.ChildBracket = topLevelBracket;
      
      //Add the top-level Bracket object to the collection
      _brackets.Add(topLevelBracket);

      //Continue creating children Bracket objects until we have created brackets to fill the 
      //depth of our tournament
      while (curBracketLevel < tournamentLevelDepth)
      {
        //Reset the bracket sequence number for the child brackets that we're about
        //to create.
        curBracketSequenceNo = 1;

        //Select the current level bracket(s).
        List<Bracket> foundBrackets = GetBracketsForLevel(curBracketLevel);

        //Increment the bracket level for the children-level bracket objects we're about to create.
        curBracketLevel++;

        //For each bracket we found, add two children to each.
        foreach (Bracket bracket in foundBrackets)
        {
          //Create the first child bracket, using the current bracket as its parent.
          Bracket childBracket1 = new Bracket(SeedOption, curBracketLevel, curBracketSequenceNo++)
          {
            ParentBracket = bracket
          };
          bracket.ChildBracket = childBracket1;
          _brackets.Add(childBracket1);

          //Create the second child bracket, using the current bracket as its parent.
          Bracket childBracket2 = new Bracket(SeedOption, curBracketLevel, curBracketSequenceNo++)
          {
            ParentBracket = bracket
          };
          bracket.ChildBracket2 = childBracket2;
          _brackets.Add(childBracket2);
        }
      }
    } 
    #endregion

    #region Public Methods
    /// <summary>
    /// Returns a list of Bracket objects for the specified level.
    /// </summary>
    public List<Bracket> GetBracketsForLevel(int level)
    {
      //Make sure we received a valid level to retrieve brackets for
      if ((level < 0) || (level > CalculateNoOfTournamentLevels()))
        throw new InvalidTournamentLevelException(level);

      //Assign and return the result
      return (from b in _brackets
              where b.Level == level
              select b)
              .OrderBy(b => b.Sequence)
              .ToList();
    }

    /// <summary>
    /// Deserializes a Tournament object from file and returns it as the result.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static Tournament Load(string filePath)
    {
      Tournament result = new Tournament();

      using (FileStream sourceFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        result = (Tournament)formatter.Deserialize(sourceFile);
      }

      return result;
    }

    /// <summary>
    /// Serializes/saves a Tournament object to file.
    /// </summary>
    /// <param name="destFilePath"></param>
    public void Save(string destFilePath)
    {
      using (FileStream outputFile = new FileStream(destFilePath, FileMode.Create, FileAccess.Write))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(outputFile, this);
      }
    }
    #endregion

    #region Public Properties
    /// <summary>
    /// List of competitors participating in the tournament.
    /// </summary>
    public List<Competitor> Competitors
    {
      get;
      private set;
    }

    /// <summary>
    /// Returns an enumerated value that indicates how the tournament is seeded.
    /// </summary>
    public SeedOption SeedOption
    {
      get;
      private set;
    }

    /// <summary>
    /// Returns the number of levels in the tournament (finals, semifinals, quarterfinals, etc).
    /// </summary>
    public int TournamentLevels
    {
      get
      {
        return CalculateNoOfTournamentLevels();
      }
    }

    /// <summary>
    /// Returns the Winner object for the tournament.
    /// </summary>
    public Winner Winner
    {
      get
      {
        return _winner;
      }
    }
    #endregion
  }
}

using System;
using Eliminator.BusinessObjects;

namespace Eliminator
{
  #region EliminatorException class
  /// <summary>
  /// Exception to be used for all Eliminator application-related exceptions.
  /// This exception is meant to be derived from, not instantiated directly.
  /// </summary>
  public abstract class EliminatorException : ApplicationException
  {
    public EliminatorException(string message)
      : base(message)
    {
    }
  } 
  #endregion

  #region ChildToParentBracketAssociationException class
  /// <summary>
  /// Exception to be used if a child bracket can not be reconciled with a parent bracket within the tournament.
  /// </summary>
  public class ChildToParentBracketAssociationException : EliminatorException
  {
    public ChildToParentBracketAssociationException(Winner parentBracket, Bracket childBracket)
      : base(string.Format("Child-to-Parent bracket association exception; Child Level: {0}, Sequence: {1}; Winner",
          childBracket.Level, childBracket.Sequence))
    {
    }
    
    public ChildToParentBracketAssociationException(Bracket parentBracket, Bracket childBracket)
      : base(string.Format("Child-to-Parent bracket association exception; Child Level: {0}, Sequence: {1}; " +
          "Parent Level: {2}; Sequence: {3}", childBracket.Level, childBracket.Sequence, parentBracket.Level, parentBracket.Sequence))
    {
    }
  } 
  #endregion

  #region CompetitorNotAssignedException class
  public class CompetitorAlreadyAssignedForBracketException : EliminatorException
  {
    public CompetitorAlreadyAssignedForBracketException(Bracket targetBracket, int competitorNo)
      : base(string.Format("Competitor {0} already assigned for bracket; Level: {1}, Sequence: {2}", 
          competitorNo, targetBracket.Level, targetBracket.Sequence))
    {
    }
  }
  
  /// <summary>
  /// Exception to be thrown if an excpected Competitor object is not assigned.
  /// </summary>
  public class CompetitorNotAssignedException : EliminatorException
  {
    public CompetitorNotAssignedException(int level, int sequence)
      : base(string.Format("Competitor not assigned, level {0}, sequence {1}.", level, sequence))
    {
    }
  } 
  #endregion

  #region DestinationBracketDeterminationExceptin class
  /// <summary>
  /// Exception to be thrown if the target bracket for a competitor cannot be determined.
  /// </summary>
  public class DestinationBracketDeterminationException : EliminatorException
  {
    public DestinationBracketDeterminationException(int competitorNumber)
      : base(string.Format("Error trying to determine destination bracket for competitor \"{0}\".", competitorNumber))
    {
    }
  } 
  #endregion
  
  #region InsufficientCompetitorsException class
  /// <summary>
  /// Exception to be thrown if no competitors are provided for a tournament.
  /// </summary>
  public class InsufficientCompetitorsException : EliminatorException
  {
    public InsufficientCompetitorsException()
      : base("Insufficient number of competitors.")
    {
    }
  }
  #endregion

  #region InvalidBracketCountException class
  /// <summary>
  /// Exception to be thrown if there aren't enough brackets in the tournament to accommodate all competitors.
  /// </summary>
  public class InvalidBracketCountException : EliminatorException
  {
    public InvalidBracketCountException(int bracketCount, int competitorCount)
      : base(string.Format("Invalid bracket count ({0}) for number of competitors ({1}).", bracketCount, competitorCount))
    {
    }
  } 
  #endregion

  #region InvalidBracketLevelException class
  /// <summary>
  /// Exception to be thrown if an invalid tournament level is used.
  /// </summary>
  public class InvalidTournamentLevelException : EliminatorException
  {
    public InvalidTournamentLevelException(int level)
      : base(string.Format("Invalid bracket level ({0}).", level))
    {
    }
  }
  #endregion

  #region InvalidCompetitorException class
  /// <summary>
  /// Exception to be thrown if an invalid competitor is selected for advancement.
  /// </summary>
  public class InvalidCompetitorException : EliminatorException
  {
    public InvalidCompetitorException(Competitor competitor)
      : base(string.Format("Invalid competitor; Seed: {0}, Name: {1}", competitor.Seed, competitor.Name))
    {
    }
  } 
  #endregion

  #region InvalidCompetitorNameException class
  /// <summary>
  /// Exception to the thrown if a competitor does not have a valid name.
  /// </summary>
  public class InvalidCompetitorNameException : EliminatorException
  {
    public InvalidCompetitorNameException(int rowIndex)
      : base(string.Format("No competitor name for row index {0}.", rowIndex))
    {
    }
  }
  #endregion

  #region NoCompetitorRowSelected class
  /// <summary>
  /// Exception to be thrown if a competitor row is not selected (for moving or other edit).
  /// </summary>
  public class NoCompetitorRowSelected : EliminatorException
  {
    public NoCompetitorRowSelected()
      : base("No competitor row selected.")
    {
    }
  } 
  #endregion

  #region NullTournamentException class
  /// <summary>
  /// Exception to be thrown if a Tournament object has not been assigned, and is expected to be.
  /// </summary>
  public class NullTournamentException : EliminatorException
  {
    public NullTournamentException()
      : base("No tournament assigned.")
    {
    }
  } 
  #endregion
}

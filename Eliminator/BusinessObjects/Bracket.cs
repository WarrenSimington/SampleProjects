using System;

namespace Eliminator.BusinessObjects
{
  [Serializable]
  public class Bracket : TournamentStage
  {
    #region Constructors
    public Bracket(SeedOption seedOption, int bracketLevel, int bracketSequence)
      : base(seedOption)
    {
      ChildBracket2 = null;
      _competitor2 = null;
      Level = bracketLevel;
      ParentBracket = null;
      Sequence = bracketSequence;
    }
    #endregion

    #region Private Members
    private Competitor _competitor2; 
    #endregion
    
    #region Public Methods
    /// <summary>
    /// Advances the provided competitor to the next round in the tournament.
    /// </summary>
    /// <param name="competitor"></param>
    public void Advance(Competitor competitor)
    {
      //Make sure that the provided Competitor object belongs to this bracket
      if ((competitor != this.Competitor) && (competitor != this.Competitor2))
        throw new InvalidCompetitorException(competitor);

      if (ParentBracket is Bracket)
      {
        Bracket parent = (Bracket)ParentBracket;

        //Check to see if this bracket is child 1 or child 2 in the parent
        if (parent.ChildBracket == this)
        {
          if (parent.Competitor != null)
            throw new CompetitorAlreadyAssignedForBracketException(parent, 1);

          parent.Competitor = competitor;
        }
        else if (parent.ChildBracket2 == this)
        {
          if (parent.Competitor2 != null)
            throw new CompetitorAlreadyAssignedForBracketException(parent, 2);

          parent.Competitor2 = competitor;
        }
        else
          throw new ChildToParentBracketAssociationException(parent, this);
      }
      else if (ParentBracket is Winner)
      {
        //Check to see if we're assigning a winner
        Winner parent = (Winner)ParentBracket;
        parent.Competitor = competitor;
      }
    } 
    #endregion

    #region Public Properties
    /// <summary>
    /// Returns which competitor in the bracket has advanced to the next level in the tournament.
    /// This method returns null if a competitor has not yet advanced to the next level.
    /// </summary>
    public Competitor AdvancedCompetitor
    {
      get
      {
        Competitor result = null;

        if (this.Completed)
        {
          //This stage has been completed, so get the parent
          if (ParentBracket is Bracket)
          {
            Bracket parent = (Bracket)ParentBracket;

            //Return the competitor that has advanced on to the parent bracket
            if (
                  (this.Competitor != null) &&
                  ((this.Competitor == parent.Competitor) || (this.Competitor == parent.Competitor2))
                )
            {
              result = this.Competitor;
            }
            else if (
                      (this.Competitor2 != null) &&
                      ((this.Competitor2 == parent.Competitor) || (this.Competitor2 == parent.Competitor2))
                    )
            {
              result = this.Competitor2;
            }
          }
          else if (ParentBracket is Winner)
          {
            Winner parent = (Winner)ParentBracket;

            //Return the competitor that has won the tournament
            if ((this.Competitor != null) && (this.Competitor == parent.Competitor))
              result = this.Competitor;
            else if ((this.Competitor2 != null) && (this.Competitor2 == parent.Competitor))
              result = this.Competitor2;
          }
        }

        return result;
      }
    }
    
    /// <summary>
    /// Returns whether or not the current object has child brackets/competitors assigned.
    /// </summary>
    public override bool Assigned
    {
      get
      {
        bool result;
        if ((ChildBracket == null) && (ChildBracket2 == null))
        {
          result = ((Competitor != null) || (Competitor2 != null));
        }
        else
        {
          result = ((Competitor != null) && (Competitor2 != null));
        }

        return result;
      }
    }

    /// <summary>
    /// Returns the total bracket count for child brackets.
    /// </summary>
    public int AssignedBracketCount
    {
      get
      {
        int result = 0;
        if (ChildBracket != null)
        {
          //Get bracket count for the first child
          result += ChildBracket.AssignedBracketCount;
        }

        if (ChildBracket2 != null)
        {
          //Get bracket count for the second child
          result += ChildBracket2.AssignedBracketCount;
        }

        //If competitor 1 is assigned, increment the result
        if ((this.Competitor != null) || (this.Competitor2 != null))
          result++;

        return result;
      }
    }

    /// <summary>
    /// Returns the highest seed found in child brackets.
    /// </summary>
    public int AssignedBracketHighestSeed
    {
      get
      {
        int result = 0;

        if ((ChildBracket != null) && (ChildBracket2 != null))
          result = Math.Max(ChildBracket.AssignedBracketHighestSeed, ChildBracket2.AssignedBracketHighestSeed);

        if (Competitor != null)
          result = Math.Max(result, Competitor.Seed);

        if (Competitor2 != null)
          result = Math.Max(result, Competitor2.Seed);

        return result;
      }
    }
    
    /// <summary>
    /// Second child Bracket object to this bracket.
    /// </summary>
    public Bracket ChildBracket2
    {
      get;
      set;
    }
    
    /// <summary>
    /// Competitor #2 for this bracket.
    /// </summary>
    public Competitor Competitor2
    {
      get
      {
        return _competitor2;
      }
      set
      {
        _competitor2 = value;
        OnUpdated(new EventArgs());
      }
    }

    /// <summary>
    /// Returns whether or not the current bracket is completed and has been advanced to the next level in the tournament.
    /// </summary>
    public override bool Completed
    {
      get
      {
        bool result = false;

        if (ParentBracket != null)
        {
          if (ParentBracket is Bracket)
          {
            Bracket parent = (Bracket)ParentBracket;

            //Find which child bracket the parent is using for this bracket
            if (parent.ChildBracket == this)
              result = (parent.Competitor != null);
            else if (parent.ChildBracket2 == this)
              result = (parent.Competitor2 != null);
            else
              throw new ChildToParentBracketAssociationException(parent, this);
          }
          else if (ParentBracket is Winner)
          {
            Winner parent = (Winner)ParentBracket;

            if (parent.ChildBracket == this)
              result = parent.Competitor != null;
            else
              throw new ChildToParentBracketAssociationException(parent, this);
          }
        }

        return result;
      }
    }

    /// <summary>
    /// Returns whether or not the current bracket has children bracket objects
    /// </summary>
    public bool HasChildrenBrackets
    {
      get
      {
        return ((this.ChildBracket != null) || (this.ChildBracket2 != null));
      }
    }
    
    /// <summary>
    /// Indicates the level (how deep) in the tournament the bracket is.
    /// 1 = Finals, 2 = Semifinals, 3 = QuarterFinals, etc.
    /// </summary>
    public int Level
    {
      get;
      private set;
    }

    /// <summary>
    /// Bracket object that is the parent to this Bracket object.
    /// </summary>
    public TournamentStage ParentBracket
    {
      get;
      set;
    }
    
    /// <summary>
    /// Indicates what order this bracket appears in sequence for its level in the tournament.
    /// </summary>
    public int Sequence
    {
      get;
      private set;
    }
    #endregion
  }
}

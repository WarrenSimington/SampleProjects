using System;

namespace Eliminator.BusinessObjects
{
  [Serializable]
  public abstract class TournamentStage
  {
    #region Constructors
    public TournamentStage(SeedOption seedOption)
    {
      _competitor = null;
      ChildBracket = null;
      SeedOption = seedOption;
    } 
    #endregion

    #region Private Members
    private Competitor _competitor; 
    #endregion

    /// <summary>
    /// Event that is fired when the object's information is updated.
    /// This allows the UI to subscribe to update events to reflect changes.
    /// </summary>
    #region Public Events
    [field: NonSerializedAttribute()] //Don't try to serialize the event handler!
    public event EventHandler Updated;
    #endregion

    #region Public Methods
    public void OnUpdated(EventArgs e)
    {
      EventHandler updatedHandler = Updated;
        if (updatedHandler != null)
          updatedHandler(this, new EventArgs());
    } 
    #endregion

    #region Public Properties
    /// <summary>
    /// Returns whether or not the current object has a child bracket or competitor assigned.
    /// </summary>
    public virtual bool Assigned
    {
      get
      {
        return ((ChildBracket != null) && (Competitor != null));
      }
    }

    /// <summary>
    /// Child object to this bracket.
    /// </summary>
    public Bracket ChildBracket
    {
      get;
      set;
    }
    
    /// <summary>
    /// Competitor #1 for this bracket.
    /// </summary>
    public Competitor Competitor
    {
      get
      {
        return _competitor;
      }
      set
      {
        _competitor = value;
        
        //Fire the Updated event
        EventHandler updatedHandler = Updated;
        if (updatedHandler != null)
          updatedHandler(this, new EventArgs());
      }
    }

    /// <summary>
    /// Returns whether or not the current bracket is completed.
    /// </summary>
    public virtual bool Completed
    {
      get
      {
        return (Competitor != null);
      }
    }

    public SeedOption SeedOption
    {
      get;
      private set;
    }
    #endregion
  }
}

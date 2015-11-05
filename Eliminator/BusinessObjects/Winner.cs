using System;

namespace Eliminator.BusinessObjects
{
  [Serializable]
  public class Winner : TournamentStage
  {
    #region Constructors
    public Winner(SeedOption seedOption)
      : base(seedOption)
    {
    } 
    #endregion
  }
}

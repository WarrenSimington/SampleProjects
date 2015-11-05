using System;

namespace Eliminator.BusinessObjects
{
  [Serializable]
  public class Competitor : IComparable<Competitor>
  {
    #region Constructors
    public Competitor(int seed, string name)
    {
      Seed = seed;
      Name = name;
    } 
    #endregion

    #region IComparable<Competitor> Members
    public int CompareTo(Competitor other)
    {
      return this.Seed.CompareTo(other.Seed);
    }
    #endregion

    #region Public Properties
    public string Name
    {
      get;
      private set;
    }
    
    public int Seed
    {
      get;
      set;
    } 
    #endregion
  }
}

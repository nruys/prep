namespace prep.utility
{
  public class NegatingMatch<ItemToMatch> : IMatchAn<ItemToMatch>
  {
    IMatchAn<ItemToMatch> match;

    public NegatingMatch(IMatchAn<ItemToMatch> match)
    {
      this.match = match;
    }

    public bool matches(ItemToMatch item)
    {
      return !match.matches(item);
    }
  }
}
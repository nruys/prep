using System;

namespace prep.utility
{
  public class MatchFactory<ItemToMatch, PropertyType>
  {
    PropertyAccessor<ItemToMatch, PropertyType> accessor;

    public MatchFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> equal_to(PropertyType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).Equals(value));
    }

    public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
      throw new NotImplementedException();
    }
  }
}
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
      return equal_to_any(value);
    }

    public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
    {
        if (values == null)
            return null;

        IMatchAn<ItemToMatch> expressionIBuildUp = new ConditionalMatch<ItemToMatch>(x => false);

        foreach (var value in values)
        {
            var theval = value;
            expressionIBuildUp = new OrMatch<ItemToMatch>(expressionIBuildUp, 
                                                          new ConditionalMatch<ItemToMatch>(
                                                              x => accessor(x).Equals(theval)));
        }

        return expressionIBuildUp;
    }
  }
}
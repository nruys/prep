using System;

namespace prep.utility
{
  public class ComparableMatchFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToMatch, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> greater_than(PropertyType value)
    {
      throw new NotImplementedException();
    }

    public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
    {
      throw new NotImplementedException();
    }
  }
}
using System;

namespace prep.utility
{
  public class ComparableMatchFactory<ItemToMatch, PropertyType> : IMatchFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
  {
    PropertyAccessor<ItemToMatch, PropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> greater_than(PropertyType value)
    {
        return new ConditionalMatch<ItemToMatch>(x => (accessor(x).CompareTo(value) > 0));
    }

    public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
    {
        return new ConditionalMatch<ItemToMatch>(x => (accessor(x).CompareTo(start) >= 0) && (accessor(x).CompareTo(end) <= 0));
    }

      public IMatchAn<ItemToMatch> equal_to(PropertyType value)
      {
          return new MatchFactory<ItemToMatch, PropertyType>(accessor).equal_to(value);
      }

      public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
      {
          return new MatchFactory<ItemToMatch, PropertyType>(accessor).equal_to_any(values);
      }

      public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
      {
          return new MatchFactory<ItemToMatch, PropertyType>(accessor).not_equal_to(value);
      }
  }
}
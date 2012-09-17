using System;

namespace prep.utility
{
  public class Where<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToMatch, PropertyType> accessor)
    {
      return new MatchFactory<ItemToMatch, PropertyType>(accessor);
    }

    public static ComparableMatchFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
      PropertyAccessor<ItemToMatch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
    {
      return new ComparableMatchFactory<ItemToMatch, PropertyType>(accessor);
    }
  }
}
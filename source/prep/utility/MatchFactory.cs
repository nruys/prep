using System;
using System.Collections.Generic;
using prep.collections;

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
      return new ConditionalMatch<ItemToMatch>(x => new List<PropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
    {
        return new NotMatch<ItemToMatch>(equal_to(value));
    }
  }

    public class NotMatch<ItemToMatch> : IMatchAn<ItemToMatch>
    {
        private IMatchAn<ItemToMatch> match;

        public NotMatch(IMatchAn<ItemToMatch> match)
        {
            this.match = match;
        }

        public bool matches(ItemToMatch item)
        {
            return !match.matches(item);
        }
    }
}
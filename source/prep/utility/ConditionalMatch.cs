namespace prep.utility
{
  public class ConditionalMatch<Item> : IMatchAn<Item>
  {
    Condition<Item> condition;

    public ConditionalMatch(Condition<Item> condition)
    {
      this.condition = condition;
    }

    public bool matches(Item item)
    {
      return condition(item);
    }
  }
}
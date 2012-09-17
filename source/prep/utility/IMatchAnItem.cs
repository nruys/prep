namespace prep.utility
{
  public interface IMatchAn<in Item>
  {
    bool matches(Item item);
  }
}
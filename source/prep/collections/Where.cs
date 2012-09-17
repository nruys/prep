using prep.utility;

namespace prep.collections
{
  public delegate ProductionStudio StudioAccessor(Movie movie);

  public class Where<ItemToMatch>
  {
    public static StudioAccessor has_a(StudioAccessor accessor)
    {
      return accessor;
    }
  }

  public static  class StudioAccessorExtensions
  {
    public static IMatchAn<Movie> equal_to(this StudioAccessor accessor,
                                           ProductionStudio value)
    {
      return new ConditionalMatch<Movie>(x => x.production_studio == value);
    }
  }
}
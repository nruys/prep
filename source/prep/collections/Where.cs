using System;
using prep.utility;

namespace prep.collections
{
  public delegate ProductionStudio StudioAccessor(Movie movie);

  public class Where<ItemToMatch>
  {
    public static void has_a(StudioAccessor accessor)
    {
      throw new NotImplementedException();
    }
  }

}
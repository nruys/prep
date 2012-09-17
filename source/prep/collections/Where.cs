using System;
using prep.utility;

namespace prep.collections
{
  public delegate ProductionStudio StudioAccessor(Movie movie);

  public class Where<ItemToMatch>
  {
    public static IEqualizer<Movie> has_a(StudioAccessor accessor)
    {
        return new Equalizer(accessor);
    }
  }

    public interface IEqualizer<T>
    {
        IMatchAn<Movie> equal_to(ProductionStudio a_production_studio);
    }

    public class Equalizer : IEqualizer<Movie>
    {
        private StudioAccessor _accessor;

        public Equalizer(StudioAccessor accessor)
        {
            _accessor = accessor;
        }

        public IMatchAn<Movie> equal_to(ProductionStudio a_production_studio)
        {
            return new EqualMatch(_accessor, a_production_studio);
        }
    }

    public class EqualMatch : IMatchAn<Movie>
    {
        private StudioAccessor _accessor;
        private ProductionStudio _studio;

        public EqualMatch(StudioAccessor accessor, ProductionStudio aProductionStudio)
        {
            _accessor = accessor;
            _studio = aProductionStudio;
        }

        public bool matches(Movie item)
        {
            return _accessor(item) == _studio;
        }
    }
}
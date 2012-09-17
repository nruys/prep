using System;
using System.Collections.Generic;
using prep.utility;

namespace prep.collections
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (movies.Contains(movie)) return;

      movies.Add(movie);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
        var titleInit = "a";
        var minimalTitle = titleInit;
        Movie minimalMovie = null;

        var numberOfMovies = 0;
        foreach (var movie in movies)
        {
            numberOfMovies++;
        }

        for (int ctr = 0; ctr < numberOfMovies; ctr++)
        {
            var foundIndex = 0;
            for (int innerctr = ctr; innerctr < numberOfMovies; innerctr++)
            {
                var movie = movies[innerctr];
                var result = movie.title.CompareTo(minimalTitle);
                if (result > 0)
                {
                    minimalTitle = movie.title;
                    minimalMovie = movie;
                    foundIndex = innerctr;
                }
            }

            var temp = movies[ctr];
            movies[ctr] = movies[foundIndex];
            movies[foundIndex] = temp;
            minimalTitle = titleInit;
        }

        foreach (var movie in movies)
        {
            yield return movie;
        }
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        return filter_movies_by(m => m.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> filter_movies_by(Condition<Movie> filter)
    {
      return movies.all_items_matching(Match<Movie>.Condition(filter));
    }

    bool is_pixar_movie(Movie movie)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
        return
            filter_movies_by(
                m => m.production_studio == ProductionStudio.Pixar || m.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
        var titleInit = "zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz";
        var minimalTitle = titleInit;
        Movie minimalMovie = null;

        var numberOfMovies = 0;
        foreach (var movie in movies)
        {
            numberOfMovies++;
        }

        for (int ctr = 0; ctr < numberOfMovies; ctr++)
        {
            var foundIndex = 0;
            for (int innerctr = ctr; innerctr < numberOfMovies; innerctr++)
            {
                var movie = movies[innerctr];
                var result = movie.title.CompareTo(minimalTitle);
                if (result < 0)
                {
                    minimalTitle = movie.title;
                    minimalMovie = movie;
                    foundIndex = innerctr;
                }
            }

            var temp = movies[ctr];
            movies[ctr] = movies[foundIndex];
            movies[foundIndex] = temp;
            minimalTitle = titleInit;
        }

        foreach (var movie in movies)
        {
            yield return movie;
        }
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
        ProductionStudio minimalStudio = ProductionStudio.MGM;
        Movie minimalMovie = null;

        var numberOfMovies = 0;
        foreach (var movie in movies)
        {
            numberOfMovies++;
        }

        for (int ctr = 0; ctr < numberOfMovies; ctr++)
        {
            var foundIndex = 0;
            for (int innerctr = ctr; innerctr < numberOfMovies; innerctr++)
            {
                var movie = movies[innerctr];
                if (movie.production_studio == minimalStudio)
                {
                    minimalStudio = movie.production_studio;
                    minimalMovie = movie;
                    foundIndex = innerctr;
                }
            }

            var temp = movies[ctr];
            movies[ctr] = movies[foundIndex];
            movies[foundIndex] = temp;
            minimalStudio = ProductionStudio.MGM;
        }

        foreach (var movie in movies)
        {
            yield return movie;
        }
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
        return filter_movies_by(m => m.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
        return filter_movies_by(m => m.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
        return filter_movies_by(m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
        return filter_movies_by(m => m.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
        return filter_movies_by(m => m.genre == Genre.action);
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
        var maximumMovieYear = DateTime.MinValue;
        Movie minimalMovie = null;

        var numberOfMovies = 0;
        foreach (var movie in movies)
        {
            numberOfMovies++;
        }

        for (int ctr = 0; ctr < numberOfMovies; ctr++)
        {
            var foundIndex = 0;
            for (int innerctr = ctr; innerctr < numberOfMovies; innerctr++)
            {
                var movie = movies[innerctr];
                if (movie.date_published > maximumMovieYear)
                {
                    maximumMovieYear = movie.date_published;
                    minimalMovie = movie;
                    foundIndex = innerctr;
                }
            }

            var temp = movies[ctr];
            movies[ctr] = movies[foundIndex];
            movies[foundIndex] = temp;
            maximumMovieYear = DateTime.MinValue;
        }

        foreach (var movie in movies)
        {
            yield return movie;
        }
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
        var minimalMovieYear = DateTime.MaxValue;
        Movie minimalMovie = null;

        var numberOfMovies = 0;
        foreach (var movie in movies)
        {
            numberOfMovies++;
        }

        for (int ctr = 0; ctr < numberOfMovies; ctr++ )
        {
            var foundIndex = 0;
            for (int innerctr = ctr; innerctr < numberOfMovies; innerctr++)
            {
                var movie = movies[innerctr];
                if (movie.date_published < minimalMovieYear)
                {
                    minimalMovieYear = movie.date_published;
                    minimalMovie = movie;
                    foundIndex = innerctr;
                }                
            }

            var temp = movies[ctr];
            movies[ctr] = movies[foundIndex];
            movies[foundIndex] = temp;
            minimalMovieYear = DateTime.MaxValue;
        }

        foreach (var movie in movies)
        {
            yield return movie;
        }
    }
  }
}
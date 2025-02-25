using DotNetRazorPages.Data;
using DotNetRazorPages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DotNetRazorPages.Entity;

public class MovieRepository<T>(MovieDbContext context) : Repository<T>(context) where T : class
{
  public override async Task CreateAsync(T entity)
    {
        var set = context.Set<T>();

        Movie? movie = entity as Movie;
        await Task.Run(() =>
        {
          // make sure create_movie exists
          var result = set.FromSqlRaw<T>("CALL create_movie({0}, {1})", movie!.Name, movie!.Actors!);
          var m = result.ToList().FirstOrDefault();
        });
    }

  public override async Task<T?> ReadAsync(int id)
  {
    var set = context.Set<T>();

    T? movie = default;
    await Task.Run(() =>
    {
      // make sure get_movie exists
      movie = set.FromSqlRaw<T>("CALL get_movie({0})", id).ToList().FirstOrDefault();
    });
    return movie;
  }

  public override async Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take)
  {
    var set = context.Set<T>();
    int total = 0;
    List<T> movies = [];
    await Task.Run(() =>
    {
      // make sure get_movies exists
      movies = [.. set.FromSqlRaw<T>("CALL get_movies({0}, {1})", skip, take)];

      total = set.FromSqlRaw<T>("""
          SELECT
            m.id,
            m.name,
            GROUP_CONCAT(a.name) AS `actors`
          FROM
            movies m
            LEFT JOIN movieActors ma ON ma.movieId = m.id
            LEFT JOIN actors a ON a.id = ma.actorId
          GROUP BY
            m.id
      """).Count();
    });

    // the records along with the count of all the records in a Tuple.
    (List<T>, int) result = (movies, total);

    return result;
  }
}

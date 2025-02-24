using DotNetRazorPages.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Entity;

public class MovieRepository<T>(MovieDbContext context) : Repository<T>(context) where T : class
{
  public override async Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take)
    {
        var set = context.Set<T>();
        int total = 0;
        List<T> movies = [];
        await Task.Run(() =>
        {
            // make sure get_movies exists
            movies = [.. set.FromSqlRaw<T>("CALL get_movies({0}, {1})", skip, take)];

            total = set.FromSqlRaw<T>(@"SELECT
  m.id,
  m.name,
  GROUP_CONCAT(a.name) AS `actors`
FROM
  movies m
  INNER JOIN movieActors ma ON ma.movieId = m.id
  INNER JOIN actors a ON a.id = ma.actorId
GROUP BY
  m.id").Count(); 
        });

        // the records along with the count of all the records in a Tuple.
        (List<T>, int) result = (movies, total);

        return result;
    }
}

using System.Text.Json;

namespace KinoSGopeto.Entities
{
    public class MoviesContextSeed
    {
        public static async Task SeedAsync(MoviesContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Movies.Any())
                {
                    var moviesData =
                        File.ReadAllText("SeedData/movies.json");
                    var movies = JsonSerializer.Deserialize<List<Movie>>(moviesData);

                    foreach (var item in movies)
                    {
                        context.Movies.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<MoviesContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}

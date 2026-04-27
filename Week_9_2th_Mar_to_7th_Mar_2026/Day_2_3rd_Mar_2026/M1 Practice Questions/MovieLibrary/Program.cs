namespace MovieLibrary
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }

    public class MovieLibrary
    {
        private List<Movie> movies = new List<Movie>();

        public void AddMovie(Movie movie)
        {
            var existing = movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existing == null)
                movies.Add(movie);
        }

        public void RemoveMovie(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
                movies.Remove(movie);
        }

        public List<Movie> SearchByDirector(string director)
        {
            return movies.Where(m => m.Director == director).ToList();
        }

        public List<Movie> SearchByGenre(string genre)
        {
            return movies.Where(m => m.Genre == genre).ToList();
        }

        public List<Movie> GetMoviesAfterYear(int year)
        {
            return movies.Where(m => m.ReleaseYear > year).ToList();
        }

        public int GetTotalMovies()
        {
            return movies.Count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MovieLibrary library = new MovieLibrary();

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                library.AddMovie(new Movie
                {
                    Id = Convert.ToInt32(input[0]),
                    Title = input[1],
                    Director = input[2],
                    Genre = input[3],
                    ReleaseYear = Convert.ToInt32(input[4])
                });
            }

            string director = Console.ReadLine();
            string genre = Console.ReadLine();
            int year = Convert.ToInt32(Console.ReadLine());

            var byDirector = library.SearchByDirector(director);
            var byGenre = library.SearchByGenre(genre);
            var afterYear = library.GetMoviesAfterYear(year);

            Console.WriteLine("Movies by Director:");
            foreach (var m in byDirector)
                Console.WriteLine(m.Title);

            Console.WriteLine("Movies by Genre:");
            foreach (var m in byGenre)
                Console.WriteLine(m.Title);

            Console.WriteLine("Movies after Year:");
            foreach (var m in afterYear)
                Console.WriteLine(m.Title);

            Console.WriteLine("Total Movies: " + library.GetTotalMovies());
        }
    }
}

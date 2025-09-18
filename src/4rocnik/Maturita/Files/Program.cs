using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;

namespace Files
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            string[] items = new string[8];
            bool isHeader = true;
            
            foreach (string line in File.ReadLines("movies.csv"))
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }
                
                items =  line.Split(',');
                string worldwidegrossstring = items[6].Replace("$", "");
                
                movies.Add(new Movie
                {
                    Film = items[0],
                    Genre = items[1],
                    LeadStudio = items[2],
                    AudienceScore = int.Parse(items[3]),
                    Profitability = double.Parse(items[4], CultureInfo.InvariantCulture),
                    RottenTomatoes = int.Parse(items[5]),
                    WorldwideGross = double.Parse(worldwidegrossstring, CultureInfo.InvariantCulture),
                    Year = int.Parse(items[7])
                });
            }
            var worstMovies = movies.GroupBy(movie => movie.Year).Select(group => group.OrderBy(movie => movie.RottenTomatoes).First());
            var bestMovies = movies.GroupBy(movie => movie.Year).Select(group => group.OrderByDescending(movie => movie.RottenTomatoes).First());
            var bestEarnMovies = movies.GroupBy(movie => movie.Year).Select(group => group.OrderByDescending(movie => movie.Profitability).First());
            var worstEarnMovies = movies.GroupBy(movie => movie.Year).Select(group => group.OrderBy(movie => movie.Profitability).First());
            var wwgross = movies.GroupBy(movie => movie.Year).Select(group =>
                new { Year = group.Key, AvgGross = group.Average(movie => movie.WorldwideGross) });
            var median = movies.Select(movie => movie.Year).Average();
            
            Console.WriteLine("========= NEJHŮŘE HODHNOCENÉ FILMY ROKU =========");
            foreach (var movie in worstMovies)
            {
                Console.WriteLine($"[{movie.Year}] {movie.Film}: {movie.RottenTomatoes}%");
            }
            
            Console.WriteLine("========= NEJLÉPE HODHNOCENÉ FILMY ROKU =========");
            foreach (var movie in bestMovies)
            {
                Console.WriteLine($"[{movie.Year}] {movie.Film}: {movie.RottenTomatoes}%");
            }
            
            Console.WriteLine("========= NEJLÉPE VÝDĚLEČNÉ FILMY ROKU =========");
            foreach (var movie in bestEarnMovies)
            {
                Console.WriteLine($"[{movie.Year}] {movie.Film}: {movie.Profitability}$");
            }
            
            Console.WriteLine("========= NEJHŮŘE VÝDĚLEČNÉ FILMY ROKU =========");
            foreach (var movie in worstEarnMovies)
            {
                Console.WriteLine($"[{movie.Year}] {movie.Film}: {movie.Profitability}$");
            }
            
            Console.WriteLine("========= PRŮMĚR WORLDWIDE GROSS ROKU =========");
            foreach (var movie in wwgross)
            {
                Console.WriteLine($"[{movie.Year}] {movie.AvgGross}");
            }
            int medianInt = (int)median;
            Console.WriteLine("Median roků: "+ medianInt);
        }
    }
}
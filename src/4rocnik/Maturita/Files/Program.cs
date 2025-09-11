using System;
using System.Collections.Generic;
using System.IO;

namespace Files
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      string line; 
      string[] row = new string[8];
      List<Movie> movies = new List<Movie>();
      StreamReader sr = new StreamReader("C:\\Users\\roman.brdlik\\Desktop\\cSharpSPSMB\\src\\4rocnik\\Maturita\\Files\\movies.csv");

      sr.ReadLine();
      while ((line = sr.ReadLine()) != null)
      {
        
        if (row.Length < 8) continue;
        
        row = line.Split(',');
        string worldwideGrossStr = row[6].Replace("$", "").Trim();
        
        movies.Add(new Movie
        {
          Film = row[0],
          Genre = row[1],
          LeadStudio = row[2],
          AudienceScore = int.Parse(row[3]),
          Profitability = double.Parse(row[4]),
          RottenTomatoes = int.Parse(row[5]),
          WorldwideGross = double.Parse(worldwideGrossStr),
          Year = int.Parse(row[7]),
        });
      }
    }
  }
}
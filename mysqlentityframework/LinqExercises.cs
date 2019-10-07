using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostgreSqlEFCore
{
    class LinqExercises
    {
        public void Exercises()
        {
            // 2. This sample uses group by to partition a list of words by their first letter.

            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var result = from w in words
                         group w by w[0] into g
                         select new { Group = g.Key, Words = g };

            var res = words.GroupBy(x => x[0]).Select(x => new { x.Key, x });

            // 3. 
            //IEnumerable<Singer> singers = GetSingers();
            //IEnumerable<Concert> concerts = GetConcerts();

            //var singerConcerts = singers.SelectMany(s => concerts.Where(c => c.SingerId == s.Id)
            //    .Select(c => new { Year = c.Year, ConcertCount = c.ConcertCount, Name = string.Concat(s.FirstName, " ", s.LastName) }));

            //var res = from s in singers
            //          join c in concerts on s.Id equals c.SingerId
            //          select new { c.Year, c.ConcertCount, name = s.FirstName + s.LastName };

            //var res2 = singers.Join(concerts,
            //    s => s.Id,
            //    c => c.SingerId,
            //    (s, c) => new { s, c }).Select(x => new { x.c.SingerId, x.s.FirstName });

            //string[] first = new string[] { "hello", "hi", "good evening", "good day", "good morning", "goodbye" };
            //string[] second = new string[] { "whatsup", "how are you", "hello", "bye", "hi" };


            //foreach (var item in res)
            //{
            //    Console.WriteLine(string.Concat(item.name, ", ", item.Year, ", ", item.ConcertCount));
            //}


        }

        public class Singer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Concert
        {
            public int SingerId { get; set; }
            public int ConcertCount { get; set; }
            public int Year { get; set; }
        }

        public static IEnumerable<Singer> GetSingers()
        {
            return new List<Singer>()
    {
        new Singer(){Id = 1, FirstName = "Freddie", LastName = "Mercury"}
        , new Singer(){Id = 2, FirstName = "Elvis", LastName = "Presley"}
        , new Singer(){Id = 3, FirstName = "Chuck", LastName = "Berry"}
        , new Singer(){Id = 4, FirstName = "Ray", LastName = "Charles"}
        , new Singer(){Id = 5, FirstName = "David", LastName = "Bowie"}
    };
        }

        public static IEnumerable<Concert> GetConcerts()
        {
            return new List<Concert>()
    {
        new Concert(){SingerId = 1, ConcertCount = 53, Year = 1979}
        , new Concert(){SingerId = 1, ConcertCount = 74, Year = 1980}
        , new Concert(){SingerId = 1, ConcertCount = 38, Year = 1981}
        , new Concert(){SingerId = 2, ConcertCount = 43, Year = 1970}
        , new Concert(){SingerId = 2, ConcertCount = 64, Year = 1968}
        , new Concert(){SingerId = 3, ConcertCount = 32, Year = 1960}
        , new Concert(){SingerId = 3, ConcertCount = 51, Year = 1961}
        , new Concert(){SingerId = 3, ConcertCount = 95, Year = 1962}
        , new Concert(){SingerId = 4, ConcertCount = 42, Year = 1950}
        , new Concert(){SingerId = 4, ConcertCount = 12, Year = 1951}
        , new Concert(){SingerId = 5, ConcertCount = 53, Year = 1983}
    };
        }
    }
}

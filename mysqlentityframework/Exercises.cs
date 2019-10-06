using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostgreSqlEFCore
{
    class Exercises
    {
        public void Exercise()
        {
            var ctx = new DvdrentalContext();

            // 1. Which actors have the first name ‘Scarlett’ => 2
            //var restult = ctx.Actor.Where(x => x.FirstName == "Scarlett").ToList();

            // 2. How many distinct actors last names are there? => 122
            //var restult = ctx.Actor.Select(x => x.LastName).Distinct().ToList();

            //var restult = ctx.Actor.GroupBy(x => x.LastName)
            //                        .Select(x => x.First())
            //                        .ToList().Count;

            //var restult = ctx.Actor.GroupBy(x => new { x.LastName, x.FirstName })
            //                        .Select(x => x.First())
            //                        .ToList().Count;

            // 3. Which last names are not repeated?
            var restult = ctx.Actor.Select(x => x.LastName).ToList();
            var arrayOfAllNames = new List<string>();
            var arrayOfDuplicateNames = new List<string>();
            var arrayOfSingleNames = new List<string>();

            foreach (var item in restult)
            {
                if (!arrayOfAllNames.Contains(item))
                {
                    arrayOfAllNames.Add(item);
                }
                else if (!arrayOfDuplicateNames.Contains(item))
                {
                    arrayOfDuplicateNames.Add(item);
                }
            }

            foreach (var allName in arrayOfAllNames)
            {
                if (!arrayOfDuplicateNames.Contains(allName))
                {
                    arrayOfSingleNames.Add(allName);
                }
            }

            var filteredList = ctx.Actor.GroupBy(x => x.LastName)
                              .Where(x => x.Count() == 1)
                              .OrderBy(x => x.Key)
                              .Select(x => x.First());

            // 4. Which last names appear more than once ?
            var result = ctx.Actor.GroupBy(x => x.LastName)
                                  .Where(x => x.Count() > 1)
                                  .OrderBy(x => x.Key)
                                  .Select(x => x.First());

            // 5.  Which actor has appeared in the most films?
            var result2 = (from actor in ctx.Actor
                          join film in ctx.FilmActor on actor.ActorId equals film.ActorId
                          group actor by new { actor.ActorId, actor.FirstName, actor.LastName } into newActor
                          select new
                          {
                              newActor.Key.ActorId,
                              newActor.Key.FirstName,
                              newActor.Key.LastName,
                              count = newActor.Sum(x => x.ActorId)
                          }).OrderByDescending(x => x.count).Take(1);

            // 6. Is 'Academy Dinosaur' available for rent from Store 1 ?

            var res = from film in ctx.Film
                      join store in ctx.Store on film.FilmId equals store.StoreId
                      where film.Title == "Academy Dinosaur" && store.StoreId == 1
                      select new { film.Title, store.StoreId };
        }
    }
}

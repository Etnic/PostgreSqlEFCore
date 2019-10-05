using MySqlEntityFramework;
using MySqlEntityFramework.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace mysqlentityframework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DvdrentalContext())
            {
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
                    else if(!arrayOfDuplicateNames.Contains(item))
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
                                  .OrderBy(x =>x.Key)
                                  .Select(x => x.First());
            }

        }
    }
}

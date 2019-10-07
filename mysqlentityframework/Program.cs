using PostgreSqlEFCore;
using PostgreSqlEFCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PostgreSqlEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DvdrentalContext())
            {
                // 5.  Which actor has appeared in the most films?

                //var id = 1;
                //var query = database.Posts    // your starting point - table in the "from" statement
                //   .Join(database.Post_Metas, // the source table of the inner join
                //      post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                //      meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
                //      (post, meta) => new { Post = post, Meta = meta }) // selection
                //   .Where(postAndMeta => postAndMeta.Post.ID == id);    // where statement

                //var result2 = (from actor in ctx.Actor
                //               join film in ctx.FilmActor on actor.ActorId equals film.ActorId
                //               group actor by new { actor.ActorId, actor.FirstName, actor.LastName } into newActor
                //               select new
                //               {
                //                   newActor.Key.ActorId,
                //                   newActor.Key.FirstName,
                //                   newActor.Key.LastName,
                //                   count = newActor.Sum(x => x.ActorId)
                //               }).OrderByDescending(x => x.count).Take(1);


                //var result = ctx.Actor
                //    .Join(ctx.FilmActor,
                //    a => a.ActorId,
                //    fa => fa.ActorId,
                //    (a, fa) => new { A = a, FA = fa })
                //    .GroupBy(x => x.FA.ActorId)
                //    .OrderBy(x => x.)
                //    .Sum(x => x.)



                var result = ctx.JohannsonName.FirstOrDefault();



            }

        }
    }
}

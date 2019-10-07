using PostgreSqlEFCore;
using PostgreSqlEFCore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static PostgreSqlEFCore.LinqExercises;

namespace PostgreSqlEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DvdrentalContext())
            {
                string[] first = new string[] { "hello", "hi", "good evening", "good day", "good morning", "goodbye" };
                string[] second = new string[] { "whatsup", "how are you", "hello", "bye", "hi" };

                var res = first.Union(second);




                Console.ReadKey();

            }

        }
    }
}

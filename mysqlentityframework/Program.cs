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
                // 6. Is 'Academy Dinosaur' available for rent from Store 1 ?

                var res = (from c in ctx.Customer
                           join r in ctx.Rental on c.CustomerId equals r.CustomerId
                           join i in ctx.Inventory on r.InventoryId equals i.InventoryId
                           join f in ctx.Film on i.FilmId equals f.FilmId
                           where f.Title == "Academy Dinosaur"
                           select new { c.FirstName, c.LastName }).OrderBy(x => x.LastName);

                //var id = from c in ctx.Customer
                //         where c.LastName == "Smith" && c.FirstName == "Marry"
                //         select c.CustomerId;

                //var xy = ctx.Customer.Where(x => x.FirstName == "Mary" && x.LastName == "Smith").Select(x => x.CustomerId).FirstOrDefault();

                //var rental = new Rental()
                //{
                //    CustomerId = xy,
                //    RentalDate = DateTime.Now,
                //    StaffId = 1,
                //    InventoryId = 1
                //};

                //ctx.Rental.Add(rental);
                //ctx.SaveChanges();



            }

        }
    }
}

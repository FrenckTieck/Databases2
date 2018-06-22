                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Diagnostics;

namespace Entity_Framework
{
    class Program
    {

        public Program()
        {
        }

        public void EntityInsertTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            using (var db = new netflix())
            {
                for (int i = 0; i < rows; i++)
                {
                    string email = "email" + i + "@test.nl";
                    var acount = new acount();
                    acount.email = email;
                    acount.password = "wachtwoord";
                    acount.tries = 1;
                    acount.isVerified = 1;
                    acount.membership_id = 1;
                    acount.joinDate = DateTime.Now;

                    db.acounts.Add(acount);
                }
                db.SaveChanges();
            }
            stopwatch.Stop();
            Console.WriteLine("Entity insert " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void EntitySelectTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int effected = 0;
            using (var db = new netflix())
            {
                var query = from b in db.acounts
                            select b;
                query.Take(rows);
                query.ToList();
                effected = query.Count();
            }
            stopwatch.Stop();
            if(effected < rows)
            {
                Console.WriteLine("Not enough rows. Only " + effected + " rows selected.");
            }
            Console.WriteLine("Entity select " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void EntityUpdateTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int effected = 0;
            using (var db = new netflix())
            {
                var query = from b in db.acounts
                            select b;
                query.Take(rows);
                foreach(var item in query)
                {
                    item.password = "test";
                    effected += 1;
                }
                db.SaveChanges();
            }
            stopwatch.Stop();
            if (effected < rows)
            {
                Console.WriteLine("Not enough rows. Only " + effected + " rows selected.");
            }
            Console.WriteLine("Entity update " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void EntityDeleteTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int effected = 0;
            using (var db = new netflix())
            {
                var query = from b in db.acounts
                            select b;
                query.Take(rows);
                foreach (var item in query)
                {
                    db.acounts.Remove(item);
                    effected += 1;
                }
                db.SaveChanges();
            }
            stopwatch.Stop();
            if (effected < rows)
            {
                Console.WriteLine("Not enough rows. Only " + effected + " rows selected.");
            }
            Console.WriteLine("Entity delete " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("starting:");

            program.EntityInsertTest(1);
            program.EntityInsertTest(1000);
            program.EntityInsertTest(100000);
            //program.EntityInsertTest(1000000);

            program.EntitySelectTest(1);
            program.EntitySelectTest(1000);
            program.EntitySelectTest(100000);
           //program.EntitySelectTest(1000000);

            program.EntityUpdateTest(1);
            program.EntityUpdateTest(1000);
            program.EntityUpdateTest(100000);
            //program.EntityUpdateTest(1000000);

            program.EntityDeleteTest(1);
            program.EntityDeleteTest(1000);
            program.EntityDeleteTest(100000);
            //program.EntityDeleteTest(1000000);
        }
    }
}

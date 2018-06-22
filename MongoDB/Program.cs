using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics;

namespace MongoDB
{
    class Program
    {
        private MongoClient client;
        private IMongoDatabase db;
        private IMongoCollection<acount> collection;

        public Program()
        {
            client = new MongoClient("mongodb://localhost");
            db = client.GetDatabase("netflix");
            collection = db.GetCollection<acount>("acount");
        }

        public TimeSpan MongoInsertTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            List<acount> acounts = new List<acount>();

            for(int i = 0; i < rows; i++)
            {
                acount temp = new acount();
                temp.email = "email" + i + "@test.nl";
                temp.password = "wachtwoord";
                temp.isVerified = true;
                temp.tries = 0;
                temp.profiles = new List<profile>();

                acounts.Add(temp);
            }

            collection.InsertMany(acounts);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public void MongoSelectTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int effected = 0;

            List<acount> acounts = collection.AsQueryable().Select(x => new acount
            {
                email = x.email,
                password = x.password,
                tries = x.tries,
                isVerified = x.isVerified,
                profiles = x.profiles
            }).Take(rows).ToList();
            effected = acounts.Count;

            stopwatch.Stop();
            if (effected < rows)
            {
                Console.WriteLine("Not enough rows. Only " + effected + " rows selected.");
            }
            Console.WriteLine("Mongodb select " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void MongoUpdateTest(int rows)
        {
            db.DropCollection("acount");
            this.MongoInsertTest(rows);
            Stopwatch stopwatch = Stopwatch.StartNew();

            FilterDefinition<acount> filter = Builders<acount>.Filter.Empty;
            UpdateDefinition<acount> update = Builders<acount>.Update.Set("password", "test");
            collection.UpdateMany(filter, update);

            stopwatch.Stop();
            Console.WriteLine("Mongodb update " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void MongoDeleteTest(int rows)
        {
            db.DropCollection("acount");
            this.MongoInsertTest(rows);
            Stopwatch stopwatch = Stopwatch.StartNew();

            FilterDefinition<acount> filter = Builders<acount>.Filter.Empty;
            collection.DeleteMany(filter);

            stopwatch.Stop();
            Console.WriteLine("Mongodb delete " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("starting:");

            TimeSpan t1 = program.MongoInsertTest(1);
            Console.WriteLine("Mongodb insert 1 Time Elapsed={0}", t1);

            TimeSpan t2 = program.MongoInsertTest(1000);
            Console.WriteLine("Mongodb insert 1000 Time Elapsed={0}", t2);

            TimeSpan t3 = program.MongoInsertTest(100000);
            Console.WriteLine("Mongodb insert 100000 Time Elapsed={0}", t3);

            TimeSpan t4 = program.MongoInsertTest(1000000);
            Console.WriteLine("Mongodb insert 1000000 Time Elapsed={0}", t4);
            
            program.MongoSelectTest(1);
            program.MongoSelectTest(1000);
            program.MongoSelectTest(100000);
            program.MongoSelectTest(1000000);

            program.MongoUpdateTest(1);
            program.MongoUpdateTest(1000);
            program.MongoUpdateTest(100000);
            program.MongoUpdateTest(1000000);

            program.MongoDeleteTest(1);
            program.MongoDeleteTest(1000);
            program.MongoDeleteTest(100000);
            program.MongoDeleteTest(1000000);
            

        }
    }

    class acount
    {
        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("tries")]
        public int tries { get; set; }

        [BsonElement("isVerified")]
        public bool isVerified { get; set; }

        [BsonElement("Profiles")]
        public List<profile> profiles { get; set; }
    }

    class watchobject
    {
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("quality")]
        public string quality { get; set; }
    }

    class profile
    {
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("dateOfBirth")]
        public DateTime dateOfBirth { get; set; }

        [BsonElement("language")]
        public string language { get; set; }

        [BsonElement("acount")]
        public acount acount { get; set; }

        [BsonElement("watchlist")]
        public List<watchobject> watchlist { get; set; }

    }
}

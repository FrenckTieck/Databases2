using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace Databases
{
    class Program
    {
        private string connectionString;

        public Program(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal static string GetConnectionString()
        { 
            string returnValue = null;
  
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["Databases.Properties.Settings.connString"];
            
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public void ADOInsertTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.acount (email, password, tries, isVerified, membership_id, joinDate) VALUES(@email, 'wachtwoord', 1, 1, 1, '19000101 00:00:00');";
                try
                {
                    con.Open();
                    for (int i = 0; i < rows; i++)
                    {
                        SqlCommand command = new SqlCommand(query, con);
                        string email = "email" + i + "@test.nl";
                        command.Parameters.AddWithValue("@email", email);
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET insert " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void ADOSelectTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int effected = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP " + rows + " * from acount;";
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        effected += 1;
                    }
                    con.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            stopwatch.Stop();
            if(effected < rows)
            {
                Console.WriteLine("Not enough rows. Only " + effected + " rows selected.");
            }
            Console.WriteLine("ADO.NET select " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void ADOUpdateTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int effected = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE TOP (" + rows + ") acount set password = 'test';";
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    effected = command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            stopwatch.Stop();
            if (effected < rows)
            {
                Console.WriteLine("Not enough rows. Only " + effected + " rows effected.");
            }
            Console.WriteLine("ADO.NET update " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        public void ADODeleteTest(int rows)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int effected = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE TOP (" + rows + ") FROM acount";
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    effected = command.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            stopwatch.Stop();
            if (effected < rows)
            {
                Console.WriteLine("Not enough rows. Only " + effected + " rows effected.");
            }
            Console.WriteLine("ADO.NET delete " + rows + " Time Elapsed={0}", stopwatch.Elapsed);
        }

        static void Main(string[] args)
        {
            Program program = new Program(GetConnectionString());
            Console.WriteLine("starting:");

            program.ADOInsertTest(1);
            program.ADOInsertTest(1000);
            program.ADOInsertTest(100000);
            program.ADOInsertTest(1000000);

            program.ADOSelectTest(1);
            program.ADOSelectTest(1000);
            program.ADOSelectTest(100000);
			program.ADOSelectTest(1000000);

            program.ADOUpdateTest(1);
            program.ADOUpdateTest(1000);
            program.ADOUpdateTest(100000);
            program.ADOUpdateTest(1000000);

            program.ADODeleteTest(1);
            program.ADODeleteTest(1000);
            program.ADODeleteTest(100000);
            program.ADODeleteTest(1000000);
        }
    }
}

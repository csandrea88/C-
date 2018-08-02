using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DbConnection;

namespace SimpleCrud
{
    public class Program
    {

        public static void Read()
        {
           List<Dictionary<string, object>> Users = DbConnector.Query("SELECT * FROM users");
            for (int i=0;i<Users.Count; i++) {
                foreach (var entry in Users[i]) {
                 
                    Console.WriteLine(entry.Value);
                }
            }
        }
        public static void Create()
        {

            Console.WriteLine ("First Name:");
            string ifname = Console.ReadLine();
            

            Console.WriteLine ("Last Name:");
            string ilname = Console.ReadLine();
           

            Console.WriteLine ("Favorite Number:");
            string ifavnum = Console.ReadLine();
            

            string query = "INSERT INTO Users(FName,LName,FavNum) VALUES ('" + ifname + "','" + ilname + "'," + ifavnum + ")";
            Console.WriteLine(query);

            DbConnector.Execute(query);

            Read();

        }


        public static void Main(string[] args)
        {            
            Read();
            Create();

          
        }
    }
}

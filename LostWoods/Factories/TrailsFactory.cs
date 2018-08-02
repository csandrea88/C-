using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostWoods.Models;
 
namespace LostWoods.Factory
{
    public class TrailsFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailsFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=Trails;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails (Name, Descrip, Length, ElevChg, Longitude, Latitude,Created_At,Updated_At) VALUES (@Name, @Descrip, @Length, @ElevChg, @Longitude, @Latitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

    }
}


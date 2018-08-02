using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;
 
namespace DojoLeague.Factory
{
    public class NinjaFactory : IFactory<Dojo>
    {
        private string connectionString;
        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=DLeagueDB;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
    public void Add(Ninja item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO Ninjas (Name, Level, Descrip, Created_At, Updated_At) VALUES (@Name, @Location, @Add_Info, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
    
    public IEnumerable<Ninja> NinjasForDojoById(int id)
{
    using (IDbConnection dbConnection = Connection)
    {
        var query = $"SELECT * FROM Ninjas JOIN Dojos ON Ninjas.Dojoid WHERE Dojos.id = ninjas.Dojoid AND Dojo.id = {id}";
        dbConnection.Open();
 
        var myPlayers = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
        return myPlayers;
    }
}

    }
}
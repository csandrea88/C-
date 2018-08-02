using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            // var first = Artists.Where(a => a.Hometown == "Mount Vernon");
            // foreach (var f in first) {
            //     Console.WriteLine(f.ArtistName);
            //     Console.WriteLine(f.RealName);
            // }
        
            //Who is the youngest artist in our collection of artists?
            // var second = Artists.OrderBy(art => art.Age).First();
            // Console.WriteLine(second.RealName);

            //Display all artists with 'William' somewhere in their real name
            var third = Artists.Where(s => s.RealName.Contains("William")).ToList();
            //  foreach (var f in third) {
            //      Console.WriteLine(f.RealName);
            // }

            //Display the 3 oldest artist from Atlanta

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}

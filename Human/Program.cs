using System;

namespace Human
{
   public class Human
   {
        public string name;
        public int strength = 3;
        public int intellig = 3;  
        public int dexterity = 3;
        public int health = 100;

        //Notice the Constructor function doesn't need
        //a return type or the static keyword
        
        public Human(string iname)
        {
            name = iname;
        }
        public void Setup(string iname, int istrength, int iintellig, int idexterity, int ihealth) {
            name = iname;
            strength = istrength;
            intellig = iintellig;
            dexterity = idexterity;
            health = ihealth;
        }
        public void Attack(string outcome) {
            if (outcome == "won") {
                strength++ ;
            } else {
                strength -= 5;
            }
        }   
    }
 
    
    class Program
    {
        static void Main(string[] args)
        {
            Human teen17 = new Human("Andrea");
            Human teen15 = new Human("Treavor");

            teen17.Setup("Mary",4,3,2,1);
            teen15.Setup("John",9,7,6,5);

            teen17.Attack("won");
            teen15.Attack("lost");
            //Console.WriteLine("Hello World!");
        }
    }
}

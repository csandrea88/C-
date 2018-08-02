using System;

namespace WizNinSam
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
    public class Wizard
    {
        //public string name;
        //public int strength = 3;
        public int intellig = 25;  
        //public int dexterity = 3;
        public int health = 50;

        //Notice the Constructor function doesn't need
        //a return type or the static keyword
        
        public Wizard ()
        {
        
        }
    
        public void heal() {
            intellig *= 10;
        }
        public void fireball(Wizard oppon) {
            Random rand = new Random();
            int k = rand.Next(20,50);
            oppon.health -= k;
        }

    }
    public class Ninja
    {
        //public string name;
        //public int strength = 3;
        //public int intellig = 25;  
        public int dexterity = 175;
        public int health = 50;

        //Notice the Constructor function doesn't need
        //a return type or the static keyword
        
        public Ninja ()
        {
           
        }
    
        public void steal() {
            health += 10;
        }
        public void get_away() {
            health -= 15;
        }
    }
    
    public class Samurai
    {
        //public string name;
        //public int strength = 3;
        //public int intellig = 25;  
        //public int dexterity = 3;
        public int health = 200;

        //Notice the Constructor function doesn't need
        //a return type or the static keyword
        
        public Samurai ()
        {
           
        }
    
        public void death_blow(Samurai oppon) {
            if (oppon.health < 50) {
                oppon.health = 0;
            }
        }
        public void meditate () {
            
            health = 200;
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Wizard treavor = new Wizard();
            Wizard Don = new Wizard();
            Ninja jenny = new Ninja();
            Samurai Sal = new Samurai();
            Samurai Andrea = new Samurai();
            treavor.heal();
            treavor.fireball(Don);
            jenny.steal();
            jenny.get_away();
            Sal.death_blow(Andrea);
            Andrea.meditate();

            Console.WriteLine("Hello World!");
        }
    }
}

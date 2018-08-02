using System;
using System.Collections.Generic;

namespace DeckOfCards
{
   public class Card
    {
        public string cardVal;
        public string suit;
        public int val;
        public Card(int ival, string isuit, string icardv)
        {
            val = ival;
            suit = isuit;
            cardVal = icardv;
        }
       
    }
    
    public class Deck
    {
        List<Card> deck = new List<Card>(52);


        public Deck()
        {
            string cardv;

            string[] suitarr = {"Hearts","Diamonds","Spades","Clubs"}; 
                        
            for (int k=0; k<suitarr.Length; k++) {
                for(int i=1; i<14; i++) {
                    
                    if (i==1) {
                        cardv = "Ace";
                    } else if(i==11) {
                        cardv = "Jack";
                    } else if(i==12) {
                        cardv = "Queen";
                    } else if(i==13) {
                        cardv = "King";
                    } else {
                        cardv = Convert.ToString(i);
                    }
                    //deck[cnt++] = new Card(i,suitarr[k],cardv);
                    deck.Add(new Card(i,suitarr[k],cardv));
                }
            }

 
        }
        public Card deal() {
            Card firstCard = deck[0]; 
            deck.RemoveAt(0);
            return firstCard;
        }

        public void reset() {
            
            string cardv;

            deck.Clear();

            string[] suitarr = {"Hearts","Diamonds","Spades","Clubs"}; 
                     
            for (int k=0; k<suitarr.Length; k++) {
                for(int i=1; i<14; i++) {
                    
                    if (i==1) {
                        cardv = "Ace";
                    } else if(i==11) {
                        cardv = "Jack";
                    } else if(i==12) {
                        cardv = "Queen";
                    } else if(i==13) {
                        cardv = "King";
                    } else {
                        cardv = Convert.ToString(i);
                    }
                    //deck[cnt++] = new Card(i,suitarr[k],cardv);
                    deck.Add(new Card(i,suitarr[k],cardv));
                    
                }
            }
        }

        public void shuffle() {

            Random rand = new Random();
            
            for (int i=0; i<deck.Count; i++) {
                int k = rand.Next(0,12);
                Card temp = deck[i];
                deck[i] = deck[k];
                deck[k] = temp;
            }
        
        }
    
    }
    public class Player {
        public string name;
        List<Card> hand = new List<Card>();
        
        public Player(string iname) {
            name = iname;
        }

        public Card draw(Deck rummydeck) {
            Card removedcard = rummydeck.deal();
            hand.Add(removedcard);
            return removedcard;
        }

        public Card discard(int i) {
            if (i > hand.Count-1) {
                return null;
            } else {
                Card discard = hand[i]; 
                hand.RemoveAt(i);
                return discard;  
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Deck rummydeck = new Deck();

            Card removedcard = rummydeck.deal();

            rummydeck.shuffle();

            rummydeck.reset(); 

            Player Don = new Player("Don");

            Card cardret = Don.draw(rummydeck);

            Card cardret2 = Don.draw(rummydeck);

            Card cardret3 = Don.draw(rummydeck);

            Card Discard = Don.discard(5);

            

        }
    }
}

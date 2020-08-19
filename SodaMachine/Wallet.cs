using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //has coins and a card
        public List<Coin> customerCoins = new List<Coin>();
        Card card = new Card();

        public Wallet()
        {
            StartingChange();
        }

        private void StartingChange()
        {
            for(int i = 0; i < 12; i++)
            {
                Quarter quarter = new Quarter();
                customerCoins.Add(quarter);
            }
            for(int i = 0; i < 10; i++)
            {
                Dime dime = new Dime();
                customerCoins.Add(dime);
            }
            for(int i = 0; i < 10; i++)
            {
                Nickle nickle = new Nickle();
                customerCoins.Add(nickle);
            }
            for(int i = 0; i < 50; i++)
            {
                Penny penny = new Penny();
                customerCoins.Add(penny);
            }
        }
    }
}

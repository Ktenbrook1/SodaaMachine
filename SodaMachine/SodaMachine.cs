using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> coins = new List<Coin>();
        public List<Can> cans = new List<Can>();

        public SodaMachine()
        {
            StartingInventory();
        }

        public int CheckInventory(string sodaSelection)
        {
            int indexOfSoda = -1;

            // loop through the cans
            // compare the .name of each can to the 'sodaSelection'
            for(int i = 0; i < cans.Count; i++)
            {
                //if(sodaSelection == cans.name)
                //{
                //    int indexOfSoda = cans[can];
                //}
            }

            return indexOfSoda;
        }
        private void StartingInventory()
        {
            StartingChange();
            StartingCans();
        }
        private void StartingChange()
        {
            for (int i = 0; i < 20; i++)
            {
                Quarter quarter = new Quarter();
                coins.Add(quarter);
            }
            for (int i = 0; i < 10; i++)
            {
                Dime dime = new Dime();
                coins.Add(dime);
            }
            for (int i = 0; i < 20; i++)
            {
                Nickle nickle = new Nickle();
                coins.Add(nickle);
            }
            for (int i = 0; i < 50; i++)
            {
                Penny penny = new Penny();
                coins.Add(penny);
            }
        }
        private void StartingCans()
        {
            for (int i = 0; i < 5; i++)
            {
                Cola cola = new Cola();
                cans.Add(cola);
            }
            for (int i = 0; i < 1; i++)
            {
                OrangeSoda orangeSoda = new OrangeSoda();
                cans.Add(orangeSoda);
            }
            for(int i = 0; i < 2; i++)
            {
                RootBeer rootBeer = new RootBeer();
                cans.Add(rootBeer);
            }

        }
    }
}

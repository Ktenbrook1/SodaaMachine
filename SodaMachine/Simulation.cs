using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Simulation
    {
        SodaMachine sodaMachine = new SodaMachine();
        Customer customer = new Customer();

        public void RunMachine()
        {
            string userChoice = customer.ChooseSoda(sodaMachine.cans);
            int locationOfSoda = sodaMachine.CheckInventory(userChoice);



        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Card
    {//-available fundssss
        private double availableFunds;

        public double AvailiableFunds
        {
            get => availableFunds;
        }
        public Card()
        {
            availableFunds = .15;
        }

        public void ChargeCard(double chargeValue)
        {
            availableFunds -= chargeValue;
        }
    }
}

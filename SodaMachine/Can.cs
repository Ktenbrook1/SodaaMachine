using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public abstract class Can
    {
        //has a
        public string name;
        protected double cost;
        public double Cost
        {
            get => cost;
        }
        //con
        public Can()
        {
         
        }
        //can do
        //can be purchased/ selected
    }
}

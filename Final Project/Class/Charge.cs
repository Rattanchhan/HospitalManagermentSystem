using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Class
{
    public class Charge
    {
        private double[] amount =
        {
            120,140,240,350,100,85,15,25,30,40,420
        };
        private int index;
        public double getAmount()
        {
            Random rnd = new Random();
            index = rnd.Next(0,amount.Length);
            return amount[index];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegacje
{
    class Calculations
    {
        public delegate int Oper(int a, int b);
        public Oper o;
        public Calculations()
        {
            o += Add;
            o += Substract;
            o -=Substract;
        }
        private int Add(int x,int b)
        {
            return x + b;
        }
        private int Substract(int a, int b)
        {
            return a - b;
        }
    }
}

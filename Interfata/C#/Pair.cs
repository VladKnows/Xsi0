using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsi0
{
    public class Pair
    {
        private int _first { get; set; }
        private int _second { get; set; }

        public int First()
        {
            return _first;
        }

        public int Second()
        {
            return _second;
        }

        public Pair(int first, int second)
        {
            _first = first;
            _second = second;
        }
    }
}

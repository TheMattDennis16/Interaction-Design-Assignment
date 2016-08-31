using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Classes.SystemObjects.Other
{
    class ScoreItem
    {
        public bool modified = false;
        public bool correct  = false;

        public ScoreItem()
        { }

        public ScoreItem(bool mod, bool cor)
        {
            modified = mod;
            correct = cor;
        }
    }
}

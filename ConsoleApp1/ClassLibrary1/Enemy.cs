using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class Enemy : Entity
    {
        public bool Distracted { get; private set; }

        public Enemy()
        {
            Distracted = false;
        }

    }
}

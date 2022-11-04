using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Enemy : Entity
    {
        public bool Distracted { get; set; }

        public Enemy():base()
        {
            Distracted = false;
        }

    }
}

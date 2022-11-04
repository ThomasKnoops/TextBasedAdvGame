using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class UselessItem : Item
    {
        public UselessItem(string name, string description):base(name, description) { }

        public override void UseMe(World w)
        {
            return;
        }
    }
}

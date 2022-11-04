using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    internal class TextItem : Item, iReadable
    {
        public string Content { get; private set; }
        public TextItem(string name, string description, string content) : base(name, description)
        {
            Content = content;
        }



        public void Read()
        {
            Console.WriteLine(Content);
        }

        public override void UseMe(World w)
        {
            this.Read();
        }
    }
}

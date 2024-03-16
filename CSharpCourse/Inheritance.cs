using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    public class Animal
    {
        public string Type
        { get; set; }

        public Animal(string type)
        {
            this.Type = type;
        }

        public virtual void Info ()
        {
            Console.WriteLine($"Type of this Animal is {Type}");
        }
    }

    public class Cat : Animal 
    {
        public Cat(string type, string name) : base(type) 
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public override void Info()
        {
            base.Info();
            Console.WriteLine($"His\\Her name is {Name}");
        }

    }
}

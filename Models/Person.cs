using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }

        public static Person John = new Person { Name = "John" };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Task_B
{
    class Person : IComparable
    {
        private string name;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public Person(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            Person other = (Person)obj;
            return Name.CompareTo(other.Name);
        }
    }
}

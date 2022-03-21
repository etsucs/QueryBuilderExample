using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3212022.Models
{
    public class BadClass
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public BadClass()
        {
            Name = "No Name";
        }
        public BadClass(string name)
        { 
            Name = name;
        }

    }
}

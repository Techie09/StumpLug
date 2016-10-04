using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stumpLugApp.Data;

namespace stumpLugApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectCache.LoadObjectCache(); // Reads and deserializes the .json data which populates the course and student lists. 
        }
    }
}

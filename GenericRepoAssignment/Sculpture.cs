using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepoAssignment
{
    public class Sculpture : Product
    {
        public string Name { get; set; }    
        public string Author { get; set; }
        public string Material { get; set; }    
        public DateTime finishTime { get; set; }
        public decimal Price { get; set; }  
        public float Weight { get; set; }
        public int SculptureCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepoAssignment
{
    public class Order : Product
    {    
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; } 
        public float Quantity { get; set; } 
        public string? CustomerName { get; set; }   

    }
}

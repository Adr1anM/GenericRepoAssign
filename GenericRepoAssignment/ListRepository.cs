using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepoAssignment
{
    public class ListRepository<T> : IRepository<T> where T : Product
    {
        List<T> products = new List<T>();
        public void Add(T entity)
        {
            products.Add(entity);
        }

        public void Delete(T enltity)
        {
            products.Remove(enltity);   
        }

        public IList<T> GetAll()
        {
            return products.ToList();   
        }

        public T GetById(int id)
        {
           foreach(var product in products)
           {
                if(product.Id == id)
                {
                    return product;
                }
           }
           throw new KeyNotFoundException($"Product with ID {id} was not found.");
        }

        public void Update(T entity)
        {
            int index  = products.IndexOf(entity);   

            if(index != -1 || index >= 0)
            {
                products[index] = entity;   
            }
            else
            {
                throw new InvalidOperationException($"Entity with Id {entity.Id} was not found");
            }

        }
    }
}

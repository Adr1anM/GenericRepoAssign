using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepoAssignment
{
    public interface IRepository<T> where T :  Product
    { 
        T GetById(int id);
        IList<T> GetAll();
        void Delete(T enltity);
        void Add(T entity);
        void Update(T entity);  
    }
}

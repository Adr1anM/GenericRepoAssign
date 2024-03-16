using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepoAssignment
{
    public class MarketPlace
    {
        private readonly IRepository<Paint> _paints;
        private readonly IRepository<Sculpture> _sculptures;
        private readonly IRepository<Order> _orders;
        private static int _lastOrderId = 0;

        public MarketPlace(IRepository<Paint> paints , IRepository<Sculpture> sculptures,         IRepository<Order> order)
        {
            _paints = paints;
            _sculptures = sculptures;
            _orders = order;
        }

     
        public IList<Product> GetAllProducts()
        {
            var allProducts = new List<Product>();
            allProducts.AddRange(_paints.GetAll());
            allProducts.AddRange(_sculptures.GetAll());  
            return allProducts;
        }

        public IList<Product> GetProductsByAuthor(string author)
        {
            var productsByAuthor = new List<Product>();
            foreach (var paint in _paints.GetAll())
            {
                if (paint.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    productsByAuthor.Add(paint);
                }
            }
            foreach (var sculpture in _sculptures.GetAll())
            {
                if (sculpture.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    productsByAuthor.Add(sculpture);
                }
            }
            return productsByAuthor;
        }

        public int GetTotalProductCount() => _paints.GetAll().Count + _sculptures.GetAll().Count;

        public void Purchase(Product product, int quantity, string customerName)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");

            if (quantity <= 0)
                throw new ArgumentException("Quantity should be greater than zero.", nameof(quantity));

            if (product is Paint paint)
            {
                var availablePaint = _paints.GetById(paint.Id);
                if (availablePaint == null || availablePaint.PaintsCount < quantity)
                {
                    throw new InvalidOperationException("Requested quantity of paint is not available.");
                }

                availablePaint.PaintsCount -= quantity;
                _paints.Update(availablePaint);
            }
            else if (product is Sculpture sculpture)
            {
                var availableSculpture = _sculptures.GetById(sculpture.Id);
                if (availableSculpture == null || availableSculpture.SculptureCount < quantity)
                {
                    throw new InvalidOperationException("Requested quantity of sculpture is not available.");
                }

                availableSculpture.SculptureCount -= quantity;
                _sculptures.Update(availableSculpture);
            }
            else
            {
                throw new ArgumentException("Unsupported product type.", nameof(product));
            }

            var order = new Order
            {
                Id = ++_lastOrderId,
                ProductId = product.Id,
                OrderDate = DateTime.Now,
                Quantity = quantity,
                CustomerName = customerName
            };
            _orders.Add(order);
        }

    }
}

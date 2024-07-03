using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;

        public ProductService(MyDbContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        /*public Product GetByName(string name)
        {
            

            var a = (from p in _context.Products
                     where p.Name == name
                     select new
                     {
                         p.Id,
                         p.Price

                     }).ToList();
                    

            var x = _context.Products.Where(p => p.Name == name);
            x.ToList();
            return x;
        }*/

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product =_context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}

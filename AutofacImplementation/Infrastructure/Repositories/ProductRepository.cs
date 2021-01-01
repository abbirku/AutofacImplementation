using Core;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Products, ListContext>
    {
    }

    public class ProductRepository : Repository<Products, ListContext>, IProductRepository
    {
        public ProductRepository(ListContext listContext)
            : base(listContext)
        { }
    }
}

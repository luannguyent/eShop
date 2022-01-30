using Catalog.Domain.CatalogAggregate;
using Catalog.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class CatalogItemRepository : GenericRepository<CatalogItem>, ICatalogItemRepository
    {
        public CatalogItemRepository(CatalogDbContext catalogDbContext) : base(catalogDbContext)
        {
        }
    }
}

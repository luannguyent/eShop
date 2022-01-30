using Catalog.Domain.CatalogAggregate;
using Catalog.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class CatalogTypeRepository : GenericRepository<CatalogType>, ICatalogTypeRepository
    {
        public CatalogTypeRepository(CatalogDbContext catalogDbContext) : base(catalogDbContext)
        {
        }
    }
}

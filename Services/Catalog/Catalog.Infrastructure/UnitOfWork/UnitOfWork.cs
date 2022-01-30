using Catalog.Domain.CatalogAggregate;
using Catalog.Domain.SeedWork;
using Catalog.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogDbContext _catalogDbContext;
        public UnitOfWork(CatalogDbContext catalogDbContext, ICatalogBrandRepository catalogBrandRepository,
            ICatalogItemRepository catalogItemRepository, ICatalogTypeRepository catalogTypeRepository)
        {
            _catalogDbContext = catalogDbContext ?? throw new ArgumentNullException(nameof(catalogDbContext));
            CatalogBrandRepository = catalogBrandRepository ?? throw new ArgumentNullException(nameof(catalogBrandRepository));
            CatalogItemRepository = catalogItemRepository ?? throw new ArgumentNullException(nameof(catalogItemRepository));
            CatalogTypeRepository = catalogTypeRepository ?? throw new ArgumentNullException(nameof(catalogTypeRepository));
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICatalogBrandRepository CatalogBrandRepository { get; set; }
        public ICatalogItemRepository CatalogItemRepository { get; set; }
        public ICatalogTypeRepository CatalogTypeRepository { get; set; }

        public async Task<int> SaveChange()
        {
            return await _catalogDbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _catalogDbContext.Dispose();
            }
        }
    }
}

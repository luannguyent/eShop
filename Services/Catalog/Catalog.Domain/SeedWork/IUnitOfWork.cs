using Catalog.Domain.CatalogAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChange();

        ICatalogBrandRepository CatalogBrandRepository { get; set; }

        ICatalogItemRepository CatalogItemRepository { get; set; }

        ICatalogTypeRepository CatalogTypeRepository { get; set; }

    }
}

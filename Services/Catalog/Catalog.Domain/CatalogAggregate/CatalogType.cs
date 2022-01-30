using Catalog.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.CatalogAggregate
{
    public class CatalogType : IAggregateRoot
    {
        public int Id { get; set; }

        public string? Type { get; set; }
    }
}

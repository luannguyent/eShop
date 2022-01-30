using Catalog.API.Extensions;
using Catalog.API.Models;
using Catalog.API.ViewModel;
using Catalog.Domain.CatalogAggregate;
using Catalog.Domain.SeedWork;
using Catalog.Infrastructure;
using Catalog.Infrastructure.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly CatalogSettings _settings;
        public CatalogController(IUnitOfWork unitOfWork, ILogger<CatalogController> logger, IOptionsSnapshot<CatalogSettings> settings)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _settings = settings.Value;
            _logger.LogInformation("Testing");
        }

        [HttpGet]
        [Route("CheckServiceStatus")]
        public ActionResult<string> CheckServiceStatus()
        {
            return (Ok("The service is running."));
        }

        [HttpGet]
        [Route("items")]
        public async Task<ActionResult> GetItemsAsync([FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            var totalItems = await _unitOfWork.CatalogItemRepository.LongCountAsync();
            var itemsOnPage = await _unitOfWork.CatalogItemRepository.GetAll(pageSize, pageIndex, "Name");

            itemsOnPage = ChangeUriPlaceholder(itemsOnPage);

            var model = new PaginatedItemsViewModel<CatalogItem>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        private List<CatalogItem> ChangeUriPlaceholder(List<CatalogItem> items)
        {
            var baseUri = _settings.PicBaseUrl;
            var azureStorageEnabled = _settings.AzureStorageEnabled;

            foreach (var item in items)
            {
                item.FillProductUrl(baseUri, azureStorageEnabled: azureStorageEnabled);
            }

            return items;
        }
    }
}

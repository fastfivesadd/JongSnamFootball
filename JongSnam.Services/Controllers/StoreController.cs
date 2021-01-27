using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;

namespace JongSnam.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreManager _storeManager;

        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }

        [HttpGet]
        public async Task<BasePagingDto<StoreDto>> GetAll(int currentPage, int pageSize)
        {
            return await _storeManager.GetListStore(currentPage, pageSize);
        }

        [HttpGet("{ownerId}")]
        public async Task<BasePagingDto<YourStore>> GetYourStore(int ownerId, int currentPage, int pageSize)
        {
            return await _storeManager.GetYourStore(ownerId, currentPage, pageSize);
        }
    }
}

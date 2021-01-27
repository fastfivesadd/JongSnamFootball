using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JongSnam.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentManager _commentManager;
        public CommentController(ICommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        //[HttpGet("{storeId}")]
        //public async Task<BasePagingDto<CommentDto>> GetFieldByStore(int storeId, int currentPage, int pageSize)
        //{
        //    return await _commentManager.GetFieldByStore(storeId, currentPage, pageSize);
        //}

        [HttpGet("{storeId}")]
        public async Task<BasePagingDto<CommentDto>> GetCommentByStoreId(int storeId, int currentPage, int pageSize)
        {
            return await _commentManager.GetCommentByStoreId(storeId, currentPage, pageSize);
        }
    }
}

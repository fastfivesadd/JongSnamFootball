using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class CommentManager : ICommentManager
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        public CommentManager(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<BasePagingDto<CommentDto>> GetCommentByStoreId(int storeId, int currentPage, int pageSize)
        {
            var listComment = await _commentRepository.GetCommentByStoreId(storeId);

            var listCommentDto = _mapper.Map<List<CommentDto>>(listComment);

            var result = MakePaging.CommentDtoToPaging(listCommentDto, currentPage, pageSize);
            return result;
        }
    }
}

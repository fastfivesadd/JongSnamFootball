using System.Collections.Generic;
using System.Linq;
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

        public async Task<SumaryRatingDto> GetCommentByStoreId(int storeId, int currentPage, int pageSize)
        {
            var listComment = await _commentRepository.GetCommentByStoreId(storeId);

            var listCommentDto = _mapper.Map<List<CommentDto>>(listComment);

            var commentPaging = MakePaging.CommentDtoToPaging(listCommentDto, currentPage, pageSize);

            var result = new SumaryRatingDto();
            result.Collection = commentPaging.Collection;
            result.CurrentPage = commentPaging.CurrentPage;
            result.TotalPage = commentPaging.TotalPage;
            result.SummaryRating = listComment.Count > 0 ? listComment[0].Rating.GetValueOrDefault() : 0;

            result.TotalOne = commentPaging.Collection.Count(c => c.Rating == 1);
            result.TotalTwo = commentPaging.Collection.Count(c => c.Rating == 2);
            result.TotalThree = commentPaging.Collection.Count(c => c.Rating == 3);
            result.TotalFour = commentPaging.Collection.Count(c => c.Rating == 4);
            result.TotalFive = commentPaging.Collection.Count(c => c.Rating == 5);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JongSnamFootball.Entities.Dtos;
using JongSnamFootball.Entities.Models;
using JongSnamFootball.Entities.Request;
using JongSnamFootball.Interfaces.Managers;
using JongSnamFootball.Interfaces.Repositories;
using JongSnamFootball.Managers.Extensions;

namespace JongSnamFootball.Managers
{
    public class ReviewManager : IReviewManager
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ReviewManager(IMapper mapper, IReviewRepository reviewRepository, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<SumaryRatingDto> GetReviewByStoreId(int storeId, int currentPage, int pageSize)
        {
            var listComment = await _reviewRepository.GetReviewByStoreId(storeId);

            var listCommentDto = _mapper.Map<List<ReviewDto>>(listComment);

            var commentPaging = MakePaging.CommentDtoToPaging(listCommentDto, currentPage, pageSize);

            var result = new SumaryRatingDto();
            result.Collection = commentPaging.Collection;
            result.CurrentPage = commentPaging.CurrentPage;
            result.TotalPage = commentPaging.TotalPage;
            //result.SummaryRating = listComment.Count > 0 ? listComment[0].StoreModel.Rating.GetValueOrDefault() : 0;



            result.TotalOne = commentPaging.Collection.Count(c => c.Rating == 1);
            result.TotalTwo = commentPaging.Collection.Count(c => c.Rating == 2);
            result.TotalThree = commentPaging.Collection.Count(c => c.Rating == 3);
            result.TotalFour = commentPaging.Collection.Count(c => c.Rating == 4);
            result.TotalFive = commentPaging.Collection.Count(c => c.Rating == 5);


            var totalVote = result.TotalFive + result.TotalFour + result.TotalThree + result.TotalTwo + result.TotalOne;

            result.SummaryRating = (5 * (decimal)result.TotalFive + 4 * (decimal)result.TotalFour + 3 * (decimal)result.TotalThree + 2 * (decimal)result.TotalTwo + 1 * (decimal)result.TotalOne)
                / totalVote;

            return result;
        }

        public async Task<bool> AddReview(ReviewRequest request)
        {
            try
            {
                var reviewModel = _mapper.Map<ReviewModel>(request);

                reviewModel.CreatedDate = DateTime.Now;

                await _repositoryWrapper.Review.CreateAsync(reviewModel);

                await _repositoryWrapper.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

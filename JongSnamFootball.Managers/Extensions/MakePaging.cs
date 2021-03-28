using System.Collections.Generic;
using System.Linq;
using JongSnamFootball.Entities.Dtos;

namespace JongSnamFootball.Managers.Extensions
{
    public static class MakePaging
    {
        public static BasePagingDto<StoreDto> StoreDtoToPaging(List<StoreDto> list, int currentPage, int pageSize)
        {
            var result = new BasePagingDto<StoreDto>();

            var total = list.Count;
            if (total == 0)
            {
                return result;
            }

            var skip = (currentPage - 1) * pageSize;

            result.TotalPage = ((total - 1) / pageSize) + 1;

            result.Collection = list.Skip(skip).Take(pageSize).ToList();

            result.CurrentPage = currentPage;

            return result;
        }

        public static BasePagingDto<YourStore> YourStoreDtoToPaging(List<YourStore> list, int currentPage, int pageSize)
        {
            var result = new BasePagingDto<YourStore>();

            var total = list.Count;
            if (total == 0)
            {
                return result;
            }

            var skip = (currentPage - 1) * pageSize;

            result.TotalPage = ((total - 1) / pageSize) + 1;

            result.Collection = list.Skip(skip).Take(pageSize).ToList();

            result.CurrentPage = currentPage;

            return result;
        }

        public static BasePagingDto<FieldDto> FieldDtotoToPaging(List<FieldDto> list, int currentPage, int pageSize)
        {
            var result = new BasePagingDto<FieldDto>();

            var total = list.Count;
            if (total == 0)
            {
                return result;
            }

            var skip = (currentPage - 1) * pageSize;

            result.TotalPage = ((total - 1) / pageSize) + 1;

            result.Collection = list.Skip(skip).Take(pageSize).ToList();

            result.CurrentPage = currentPage;

            return result;
        }

        public static BasePagingDto<ReviewDto> CommentDtoToPaging(List<ReviewDto> list, int currentPage, int pageSize)
        {
            var result = new BasePagingDto<ReviewDto>();

            var total = list.Count;
            if (total == 0)
            {
                return result;
            }

            var skip = (currentPage - 1) * pageSize;

            result.Collection = list.Skip(skip).Take(pageSize).ToList();

            result.TotalPage = ((total - 1) / pageSize) + 1;

            result.CurrentPage = currentPage;

            return result;
        }

        public static BasePagingDto<ReservationDto> ReservationDtoToPaging(List<ReservationDto> list, int currentPage, int pageSize)
        {
            var result = new BasePagingDto<ReservationDto>();

            var total = list.Count;
            if (total == 0)
            {
                return result;
            }

            var skip = (currentPage - 1) * pageSize;

            result.Collection = list.Skip(skip).Take(pageSize).ToList();

            result.TotalPage = ((total - 1) / pageSize) + 1;

            result.CurrentPage = currentPage;

            return result;
        }

        public static BasePagingDto<GrahpDto> GraphDtoToPaging(List<GrahpDto> list, int currentPage, int pageSize)
        {
            var result = new BasePagingDto<GrahpDto>();

            var total = list.Count;
            if (total == 0)
            {
                return result;
            }

            var skip = (currentPage - 1) * pageSize;

            result.Collection = list.Skip(skip).Take(pageSize).ToList();

            result.TotalPage = ((total - 1) / pageSize) + 1;

            result.CurrentPage = currentPage;

            return result;
        }
    }
}

namespace JongSnamFootball.Entities.Dtos
{
    public class SumaryRatingDto : BasePagingDto<CommentDto>
    {
        public int TotalFive { get; set; }
        public int TotalFour { get; set; }
        public int TotalThree { get; set; }
        public int TotalTwo { get; set; }
        public int TotalOne { get; set; }
        public decimal SummaryRating { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Dtos
{
    public class SumaryRatingDto : BasePagingDto<CommentDto> 
    {
        public int TotalFive { get; set; }
        public int TotalFour { get; set; }
        public int TotalThree { get; set; }
        public int TotalTwo { get; set; }
        public int TotalOne { get; set; }
        public double Rating { get; set; }
    }
}

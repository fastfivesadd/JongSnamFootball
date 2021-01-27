using System.Collections.Generic;

namespace JongSnamFootball.Entities.Dtos
{
    public class BasePagingDto<T> where T : class
    {
        public int CurrentPage { get; set; }

        public int TotalPage { get; set; }

        public List<T> Collection { get; set; }

    }
}

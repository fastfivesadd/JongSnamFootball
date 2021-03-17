using System.Collections.Generic;

namespace JongSnamFootball.Entities.Dtos
{
    public class ProblemsDetailDto
    {
        public string Detail { get; set; }

        public IDictionary<string, object> Extensions { get; }

        public string Instance { get; set; }

        public int? Status { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public int? ErrorCode { get; set; }
    }
}

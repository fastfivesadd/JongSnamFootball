using System.Collections.Generic;

namespace JongSnamFootball.Entities.Dtos
{
    public class FieldDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsOpen { get; set; }

        public double Percentage { get; set; }

        public IEnumerable<ImageFieldDto> ImageFieldDto { get; set; }
    }
}

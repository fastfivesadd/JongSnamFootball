using System;
using System.Collections.Generic;

namespace JongSnamFootball.Entities.Dtos
{
    public class FieldByIdFieldDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Status { get; set; }
        public double Percentage { get; set; }

        public IEnumerable<PictureFieldDto> PictureFieldModel { get; set; }
    }
}

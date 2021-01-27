using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JongSnamFootball.Entities.Dtos
{
    public class ListFieldByIdFieldDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Discount { get; set; }

        public string Size { get; set; }

        public string Status { get; set; }
    }
}

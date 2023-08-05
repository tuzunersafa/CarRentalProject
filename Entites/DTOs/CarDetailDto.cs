using Core;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        

    }
}

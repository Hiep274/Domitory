using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
    public class GetVehiclePriceForInput
    {
        public long ModelId { get; set; }
        public long GradeId { get; set; }
        public long GradeProId { get; set; }
        public long IColorId { get; set; }
        public long EColorId { get; set; }
    }
}

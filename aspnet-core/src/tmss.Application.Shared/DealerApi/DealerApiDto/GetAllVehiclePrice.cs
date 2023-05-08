using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
    public class GetAllVehiclePrice
    {
        public long? Id { get; set; }
        public long? ModelId { get; set; }
        public long? GradeId { get; set; }
        public long? GradeProId { get; set; }
        public long? IColorId { get; set; }
        public long? EColorId { get; set; }
        public string Model { get; set; }
        public string Grade { get; set; }
        public string GradePro { get; set; }
        public string IColor { get; set; }
        public string EColor { get; set; }
        public long? TotalAmount { get; set; }

    }
}

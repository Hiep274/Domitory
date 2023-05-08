using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
    public class GetEColor
    {
        public long? Id { get; set; }
        public long? InteriorColorId { get; set; }
        public string InteriorColorName { get; set; }
        public string InteriorCode { get; set; }
        public long? ExteriorColorId { get; set; }
        public string ExteriorColorName { get; set; }
        public string ExteriorCode { get; set; }
        public string Model { get; set; }
        public string Grade { get; set; }
        public string GradeProduction { get; set; }
        public long? ModelId { get; set; }
        public long? GradeId { get; set; }
        public long? GradeProductionId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
    public class GetGradeProductDealerApi
    {
        public long? GradeId { get; set; }
        public long? GradeProductId { get; set; }
        public string GradeProductName { get; set; }
    }
}

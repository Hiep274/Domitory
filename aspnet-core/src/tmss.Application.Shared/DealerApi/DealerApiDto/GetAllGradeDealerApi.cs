using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
     public class GetAllGradeDealerApi
    {
        public long? ModelId { get; set; }
        public long? GradeId { get; set; }
        public string GradeName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
    public class GetAllDistrict
    {
        public long? ProvinceId { get; set; }
        public long? DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}

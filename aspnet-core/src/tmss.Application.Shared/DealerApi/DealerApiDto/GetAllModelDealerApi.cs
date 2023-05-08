using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
    public class GetAllModelDealerApi
    {
        public long? ModelId { get; set; }
        public string ModelName { get; set; }
    }
}

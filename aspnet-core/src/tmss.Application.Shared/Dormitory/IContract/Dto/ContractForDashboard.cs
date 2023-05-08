using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IContract.Dto
{
    public class ContractForDashboard //: EntityDto<long?>
    {
        public string Month { get; set; }
        public long Total { get; set; }
    }
}

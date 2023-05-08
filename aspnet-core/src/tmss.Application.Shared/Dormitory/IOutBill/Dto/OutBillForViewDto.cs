using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IOutBill.Dto
{
    public class OutBillForViewDto : EntityDto<long?>
    {
        public long Cost { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IContract.Dto
{
    public class ContractForViewDto : EntityDto<long?>
    {
        public string ContractNo { get; set; }
        public string StudentNo { get; set; }
        public string StudentName { get; set; }
        public long Gender { get; set; }
        public string Phone { get; set; }
        public string RoomNo { get; set; }
        public long UnitPrice { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

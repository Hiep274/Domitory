using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IContract.Dto
{
    public class CreateOrEditContractDto : EntityDto<long?>
    {
        public string ContractNo { get; set; }
        public long StudentId { get; set; }
        public long RoomId { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IContract.Dto
{
    public class ContractInputDto
    {
        public long? RoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

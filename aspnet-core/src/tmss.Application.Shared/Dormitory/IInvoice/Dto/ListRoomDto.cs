using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IInvoice.Dto
{
    public class ListRoomDto : EntityDto<long?>
    {
        public string RoomNo { get; set; }
        public long UnitPrice { get; set; }
        public long Empty { get; set; }
    }
}

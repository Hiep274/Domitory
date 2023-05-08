using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IInvoice.Dto
{
    public class CreateOrEditInvoiceDto : EntityDto<long?>
    {
        public long RoomId { get; set; }
        public long ElecOld { get; set; }
        public long ElecNew { get; set; }
        public long WarOld { get; set; }
        public long WarNew { get; set; }
        public long ElecUnit { get; set; }
        public long WarUnit { get; set; }
        public DateTime Month { get; set; }
        public bool IsPaid { get; set; }
    }
}

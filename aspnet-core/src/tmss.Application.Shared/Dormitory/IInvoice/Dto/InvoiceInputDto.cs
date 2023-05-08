using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IInvoice.Dto
{
    public class InvoiceInputDto
    {
        public long? RoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsPaid { get; set; }
    }
}

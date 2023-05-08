using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory
{
    public class InBill : IEntity<long>
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
        public DateTime DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public long RoomId { get; set; }
        public long Cost { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public bool IsPaid { get; set; }

    }
}

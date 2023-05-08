using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory
{
    public class Invoice : IEntity<long>
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
        public DateTime DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
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

using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory
{
    public class Room : IEntity<long>
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
        public DateTime DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public long BuildingId { get; set; }
        public string RoomNo { get; set; }
        public long UnitPrice { get; set; }
        public long Maxx { get; set; }
        public long Amount { get; set; }
    }

       

    
}

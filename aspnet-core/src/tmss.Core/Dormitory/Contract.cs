using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory
{
    public class Contract : IEntity<long>
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }

        public DateTime DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public string ContractNo { get; set; }
        public long StudentId { get; set; }
        public long RoomId { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

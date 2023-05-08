using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory
{
    public class Building : IEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}

using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory
{
    public class Student : IEntity<long>
    {
        public long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string StudentNo { get; set; }
        public long Gender { get; set; }
        public string Cmnd { get; set; }
        public string Phone { get; set; }
        public bool IsRoom { get; set; }
    }
}

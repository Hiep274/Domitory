using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IStudent.Dto
{
    public class CreateOrEditStudentDto: EntityDto<long?>
    {
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string StudentNo { get; set; }
        public long? Gender { get; set; }
        public string Cmnd { get; set; }
        public string Phone { get; set; }
        public bool IsRoom { get; set; }
    }
}

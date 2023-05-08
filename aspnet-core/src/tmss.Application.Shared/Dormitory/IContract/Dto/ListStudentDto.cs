using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IContract.Dto
{
    public class ListStudentDto : EntityDto<long?>
    {
        public string Name { get; set; }
        public string StudentNo { get; set; }
    }
}

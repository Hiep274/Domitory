using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IBuildingRoom.Dto
{
    public class CreateOrEditBuildingDto : EntityDto<long?>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

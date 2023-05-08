using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IBuildingRoom.Dto
{
    public class CreateOrEditRoomDto : EntityDto<long?>
    {
        public long BuildingId { get; set; }
        public string RoomNo { get; set; }
        public long UnitPrice { get; set; }
        public long Maxx { get; set; }
        public long Amount { get; set; }
    }
}

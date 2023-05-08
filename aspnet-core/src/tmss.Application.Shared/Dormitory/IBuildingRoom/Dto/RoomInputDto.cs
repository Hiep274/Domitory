using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Dormitory.IBuildingRoom.Dto
{
    class RoomInputDto
    {
        public long BuildingId { get; set; }
        public string RoomNo { get; set; }
        public long UnitPrice { get; set; }
        public long Maxx { get; set; }
        public long Amount { get; set; }
    }
}

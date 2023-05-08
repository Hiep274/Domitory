using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.DealerApi.DealerApiDto
{
    public class GetAllSalesPerson : EntityDto<long>
    {
        public string Name { get; set; }
        public DateTime? BirthDay { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public bool? IsSaleAdmin { get; set; }

    }
}

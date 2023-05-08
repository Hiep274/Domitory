using Abp.Application.Services.Dto;

namespace tmss.AbpCore.Role.Dto
{
    public class RoleInfoDto : EntityDto<long>
    {
        public string Code { get; set; }
        public string Description { get; set; }

    }
}

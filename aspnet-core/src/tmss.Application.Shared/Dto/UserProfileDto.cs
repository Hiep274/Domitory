using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace tmss.Dto
{
    public class UserProfileDto : EntityDto<long>
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public int TenantId { get; set; }
        public bool IsManager { get; set; }
        public long SalesPersonId { get; set; }
        public bool? IsContractApprove { get; set; }
        public bool? IsProposalApprove { get; set; }
        public bool? IsViewCustomer { get; set; }
        public bool? IsApproveTestDrive { get; set; }
        public bool? IsCreateTransferCustomer { get; set; }
        public int Gender { get; set; }
        public List<long?> IsUsingFunction { get; set; }
    }
}

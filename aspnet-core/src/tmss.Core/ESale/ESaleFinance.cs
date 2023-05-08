using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace tmss.ESale
{
    public class ESaleFinance : FullAuditedEntity<long>, IEntity<long>
    {
        public long? ModelId { get; set; }
        public long? GradeId { get; set; }
        public long? ColorId { get; set; }
        public long? CustomerTypeId { get; set; }
        public bool? IsTFS { get; set; }
        public long? TFSPackageId { get; set; }
        public long? LoanValueId { get; set; }
        public long? ClassicTFSPackageId { get; set; }
        // Package 50/50
        public long? HalfPercentPrepaid { get; set; }
        public long? HalfPrepaidAmount { get; set; }
        public long? HalfLoanAmount { get; set; }
        public long? HalfLoanTerm { get; set; }
        public DateTime? HalfDisbursementDate { get; set; }
        public DateTime? HalfMaturityDate { get; set; }
        // Package Balloon
        public long? BalloonPercentPrepaid { get; set; }
        public long? BalloonPrepaidAmount { get; set; }
        public long? BalloonPercentAmount { get; set; }
        public long? BalloonAmount { get; set; }
        public long? BalloonLoanAmount { get; set; }
        public long? BalloonLoanTerm { get; set; }
        public DateTime? BalloonDisbursementDate { get; set; }
        public DateTime? BalloonMaturityDate { get; set; }
        public long? BalloonInstalmentPlanId { get; set; }
        // classic package
        public long? ClassicPercentPrepaid { get; set; }
        public long? ClassicPrepaidAmount { get; set; }
        public long? ClassicPercentAmount { get; set; }
        public long? ClassicAmount { get; set; }
        //public long? BalloonLoanAmount { get; set; }
        //public long? BalloonLoanTerm { get; set; }
        //public DateTime? BalloonDisbursementDate { get; set; }
        //public DateTime? BalloonMaturityDate { get; set; }
        //public long? BalloonInstalmentPlanId { get; set; }

    }
}

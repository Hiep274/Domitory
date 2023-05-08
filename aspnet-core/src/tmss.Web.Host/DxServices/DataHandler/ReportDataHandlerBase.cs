using Abp.Auditing;
using Abp.Dependency;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using tmss.MultiTenancy;

namespace tmss.Web.DxServices.DataHandler
{
    public class ReportDataHandlerBase
    {
        private static IRepository<AuditLog, long> _auditLogRepository;
        private static IRepository<Tenant, int> _tenant;

        static ReportDataHandlerBase()
        {
            _auditLogRepository = IocManager.Instance.Resolve<IRepository<AuditLog, long>>();
            _tenant = IocManager.Instance.Resolve<IRepository<Tenant, int>>();
        }

        public static List<AuditLog> GetAuditLogMaster()
        {
            var auditLog = _auditLogRepository.GetAll().Take(10).ToList();
            return auditLog;
        }

        public static Tenant GetTenantHeader(int tenantId)
        {
            var tenant = _tenant.GetAll().Where(e => e.Id == tenantId).FirstOrDefault();
            return tenant;
        }
    }
}
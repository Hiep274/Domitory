using Abp.Dependency;
using System.Threading.Tasks;

namespace tmss.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}
using Abp.Application.Services;
using System.Threading.Tasks;
using tmss.Sessions.Dto;

namespace tmss.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}

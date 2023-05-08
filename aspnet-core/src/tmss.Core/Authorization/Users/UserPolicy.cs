using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using System.Threading.Tasks;

namespace tmss.Authorization.Users
{
    public class UserPolicy : tmssServiceBase, IUserPolicy
    {
        private readonly IFeatureChecker _featureChecker;
        private readonly IRepository<User, long> _userRepository;

        public UserPolicy(IFeatureChecker featureChecker, IRepository<User, long> userRepository)
        {
            _featureChecker = featureChecker;
            _userRepository = userRepository;
        }

       
    }
}
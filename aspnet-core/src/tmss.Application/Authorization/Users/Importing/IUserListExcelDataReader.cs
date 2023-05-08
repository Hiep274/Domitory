using Abp.Dependency;
using System.Collections.Generic;
using tmss.Authorization.Users.Importing.Dto;

namespace tmss.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader : ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}

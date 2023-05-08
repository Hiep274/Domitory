using GraphQL.Types;
using tmss.Dto;

namespace tmss.Types
{
    public class UserType : ObjectGraphType<UserDto>
    {
        public static class ChildFields
        {
            public const string Items = "items";
            public const string Roles = "roles";

            public static string GetFieldSelector(string childField)
            {
                return string.Concat(Items, ":", childField);
            }
        }

        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Surname);
            Field(x => x.UserName);
            Field(x => x.EmailAddress);
            Field(x => x.PhoneNumber);
            Field(x => x.IsActive);
            Field(x => x.IsEmailConfirmed);
            Field(x => x.CreationTime);
            Field(x => x.TenantId, nullable: true);
            Field(x => x.ProfilePictureId, nullable: true, type: typeof(StringGraphType));

            Field<ListGraphType<RoleType>>(ChildFields.Roles);
        }

        public class RoleType : ObjectGraphType<UserDto.RoleDto>
        {
            public RoleType()
            {
                Field(x => x.Id);
                Field(x => x.Name);
                Field(x => x.DisplayName);
            }
        }

      
    }
}

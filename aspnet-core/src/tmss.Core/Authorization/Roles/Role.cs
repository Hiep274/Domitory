﻿using Abp.Authorization.Roles;
using tmss.Authorization.Users;

namespace tmss.Authorization.Roles
{
    /// <summary>
    /// Represents a role in the system.
    /// </summary>
    public class Role : AbpRole<User>
    {
        //Can add application specific role properties here

        public Role()
        {

        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }

        public string Description { get; set; }
    }
}

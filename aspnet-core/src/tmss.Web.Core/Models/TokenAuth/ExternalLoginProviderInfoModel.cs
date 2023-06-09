﻿using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace tmss.Web.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }

        public Dictionary<string, string> AdditionalParams { get; set; }

    }
}

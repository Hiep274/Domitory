﻿using System.Collections.Generic;

namespace tmss.Web.Common
{
    public static class WebConsts
    {
        public const string SwaggerUiEndPoint = "/swagger"; 
        public const string HangfireDashboardEndPoint = "/hangfire";

        public static bool SwaggerUiEnabled = true;
        public static bool HangfireDashboardEnabled = false; //for UI
        public static bool EnableJob = true;

        public static List<string> ReCaptchaIgnoreWhiteList = new List<string>
        {
            tmssConsts.AbpApiClientUserAgent
        };

        public static class GraphQL
        {
            public const string PlaygroundEndPoint = "/ui/playground";
            public const string EndPoint = "/graphql";

            public static bool PlaygroundEnabled = false;
            public static bool Enabled = false;
        }
    }
}

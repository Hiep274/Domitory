﻿using Abp.Reflection.Extensions;
using System;
using System.IO;

namespace tmss
{
    /// <summary>
    /// Central point for application version.
    /// </summary>
    public class AppVersionHelper
    {
        /// <summary>
        /// Gets current version of the application.
        /// It's also shown in the web page.
        /// </summary>
        public const string Version = "8.6.0.0";

        /// <summary>
        /// Gets release (last build) date of the application.
        /// It's shown in the web page.
        /// </summary>
        public static DateTime ReleaseDate => new FileInfo(typeof(AppVersionHelper).GetAssembly().Location).LastWriteTime;
    }
}
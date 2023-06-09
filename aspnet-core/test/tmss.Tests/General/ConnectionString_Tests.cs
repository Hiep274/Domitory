﻿using Shouldly;
using System.Data.SqlClient;
using Xunit;

namespace tmss.Tests.General
{
    // ReSharper disable once InconsistentNaming
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=tmss; Trusted_Connection=True;");
            csb["Database"].ShouldBe("tmss");
        }
    }
}

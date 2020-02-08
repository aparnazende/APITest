using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ViewModel
{
    public static class ConstantsViewModel
    {
        private static readonly IConfiguration AppSeetingconfig = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.json").Build();

        private static readonly IConfiguration config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings." + AppSeetingconfig["Environment"] + ".json").Build();

        public static string ConnectionString => config["App:ConnectionString"];
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccMembers.Api.Client.Tests
{
    public class ConfigHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("testsettings.json", optional: true)
                .AddUserSecrets("f8792b99-bca9-4d9d-a2f6-b421aeaf4947") //Should match user secrets ID in project file
                .AddEnvironmentVariables()
                .Build();
        }

        public static T GetConfig<T>(string outputPath, string section)
        {
            var configuration = Activator.CreateInstance<T>();

            var configRoot = GetIConfigurationRoot(outputPath);

            configRoot
                .GetSection(section)
                .Bind(configuration);

            return configuration;
        }
    }
}

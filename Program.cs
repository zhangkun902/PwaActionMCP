using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;

namespace PwaActionsMcp;

class Program
{
    static async Task Main(string[] args)
    {
        // Accept wamiPackageFamilyName and samplePackageFamilyName as command-line arguments
        string? wamiPackageFamilyName = args.Length > 0 ? args[0] : null;
        string? samplePackageFamilyName = args.Length > 1 ? args[1] : null;

        if (!string.IsNullOrEmpty(wamiPackageFamilyName))
        {
            Environment.SetEnvironmentVariable("PWA_MCP_WAMI_PACKAGE_FAMILY_NAME", wamiPackageFamilyName);
        }
        if (!string.IsNullOrEmpty(samplePackageFamilyName))
        {
            Environment.SetEnvironmentVariable("PWA_MCP_SAMPLE_PACKAGE_FAMILY_NAME", samplePackageFamilyName);
        }

        var builder = Host.CreateApplicationBuilder(args);

        // Register the MCP server with stdio transport and tools from this assembly
        builder.Services.AddMcpServer()
            .WithStdioServerTransport()
            .WithToolsFromAssembly();

        var app = builder.Build();
        await app.RunAsync();
    }
}

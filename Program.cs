using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol;

namespace PwaActionsMcp;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        // Register the MCP server with stdio transport and tools from this assembly
        builder.Services.AddMcpServer()
            .WithStdioServerTransport()
            .WithToolsFromAssembly();

        var app = builder.Build();
        await app.RunAsync();
    }
}

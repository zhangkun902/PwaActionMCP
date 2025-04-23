using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.System;
using ModelContextProtocol.Server;

namespace PwaActionsMcp.Tools;

[McpServerToolType]
public static class PwaActionTools
{
    // --- AUTO-GENERATED TOOLS FROM wamiActionsmManifest.json ---

    [McpServerTool]
    [Description("Resize the image to a specific width")]
    public static async Task<string> Wami_Resize_Width(
        [Description("Photo to be resized in Wami.")] string File)
    {
        return await LaunchPwaAction(
            "web+wami://resize",
            GetWamiPackageFamilyName("microsoftedge.github.io-44696A99_5gmymy4r41ddc"),
            File,
            "File"
        );
    }

    [McpServerTool]
    [Description("Blur the image with a Gaussian operator")]
    public static async Task<string> Wami_Blur(
        [Description("Photo to be blurred in Wami.")] string File)
    {
        return await LaunchPwaAction(
            "web+wami://blur",
            GetWamiPackageFamilyName("microsoftedge.github.io-44696A99_5gmymy4r41ddc"),
            File,
            "File"
        );
    }

    // --- AUTO-GENERATED TOOLS FROM sampleActionsManifest.json ---

    [McpServerTool]
    [Description("Edit an image")]
    public static async Task<string> Sample_Edit_Image(
        [Description("Image will be edited.")] string imageOne)
    {
        return await LaunchPwaAction(
            "web+pwa://editimage",
            GetSamplePackageFamilyName("zhangkun902.github.io-98DF0E21_hbvpby5sxra9r"),
            imageOne,
            "imageOne"
        );
    }

    [McpServerTool]
    [Description("Watch a movie")]
    public static async Task<string> Sample_Watch_movie(
        [Description("Watch a movie")] string Video)
    {
        return await LaunchPwaAction(
            "web+pwa://watchmovie",
            GetSamplePackageFamilyName("zhangkun902.github.io-98DF0E21_hbvpby5sxra9r"),
            Video,
            "Video"
        );
    }

    // --- END AUTO-GENERATED TOOLS ---

    private static string GetWamiPackageFamilyName(string defaultValue)
    {
        var env = Environment.GetEnvironmentVariable("PWA_MCP_WAMI_PACKAGE_FAMILY_NAME");
        return string.IsNullOrEmpty(env) ? defaultValue : env;
    }

    private static string GetSamplePackageFamilyName(string defaultValue)
    {
        var env = Environment.GetEnvironmentVariable("PWA_MCP_SAMPLE_PACKAGE_FAMILY_NAME");
        return string.IsNullOrEmpty(env) ? defaultValue : env;
    }

    private static async Task<string> LaunchPwaAction(
        string uri,
        string packageFamilyName,
        string filePath,
        string inputKey)
    {
        try
        {
            var options = new LauncherOptions
            {
                TargetApplicationPackageFamilyName = packageFamilyName
            };

            var valueSet = new ValueSet();
            valueSet.Add("$windows.actions.scenario", "ActionLaunch");

            var fileValueSet = new ValueSet();
            fileValueSet.Add("Kind", "File");

            var fileDataValueSet = new ValueSet();
            fileDataValueSet.Add("Path", filePath);
            fileDataValueSet.Add("Extension", Path.GetExtension(filePath));
            fileDataValueSet.Add("FileName", Path.GetFileName(filePath));

            fileValueSet.Add("Value", fileDataValueSet);
            valueSet.Add(inputKey, fileValueSet);

            bool success = await Launcher.LaunchUriAsync(new Uri(uri), options, valueSet);
            return success ? "Action executed successfully" : "Failed to execute action";
        }
        catch (Exception ex)
        {
            return $"Error launching URI: {ex.Message}";
        }
    }
}
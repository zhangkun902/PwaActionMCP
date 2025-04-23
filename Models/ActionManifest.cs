using System.Text.Json.Serialization;

namespace PwaActionsMcp.Models;

public class ActionManifest
{
    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("packageFamilyName")]
    public string PackageFamilyName { get; set; } = string.Empty;

    [JsonPropertyName("actions")]
    public List<Action> Actions { get; set; } = new();
}

public class Action
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;

    [JsonPropertyName("inputs")]
    public List<ActionInput> Inputs { get; set; } = new();

    [JsonPropertyName("outputs")]
    public List<object> Outputs { get; set; } = new();

    [JsonPropertyName("invocation")]
    public ActionInvocation Invocation { get; set; } = new();

    [JsonPropertyName("inputCombinations")]
    public List<InputCombination> InputCombinations { get; set; } = new();
}

public class ActionInput
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;
}

public class ActionInvocation
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("uri")]
    public string Uri { get; set; } = string.Empty;
}

public class InputCombination
{
    [JsonPropertyName("inputs")]
    public List<string> Inputs { get; set; } = new();

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}
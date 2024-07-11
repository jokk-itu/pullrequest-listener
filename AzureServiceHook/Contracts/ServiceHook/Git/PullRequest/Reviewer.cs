using System.Text.Json.Serialization;

namespace AzureServiceHook.Contracts.ServiceHook.Git.PullRequest;

internal class Reviewer : Person
{
  [JsonPropertyName("vote")]
    public required long Vote { get; init; }
}
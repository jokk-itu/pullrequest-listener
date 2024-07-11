using System.Text.Json.Serialization;

namespace AzureServiceHook.Contracts.ServiceHook.Git.PullRequest;

internal class PullRequestEvent
{
  [JsonPropertyName("id")]
  public required Guid Id { get; init; }

  [JsonPropertyName("eventType")]
  public required string EventType { get; init; }

  [JsonPropertyName("resource")]
  public required PullRequestResource Resource { get; init; }

  [JsonPropertyName("createdDate")]
  public required DateTime CreatedDate { get; init; }
}
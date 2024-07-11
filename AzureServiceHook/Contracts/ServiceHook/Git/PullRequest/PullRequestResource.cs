using System.Text.Json.Serialization;

namespace AzureServiceHook.Contracts.ServiceHook.Git.PullRequest;

internal class PullRequestResource
{
  [JsonPropertyName("pullRequestId")]
  public required long PullRequestId { get; init; }

  [JsonPropertyName("url")]
  public required string Url { get; init; }

  [JsonPropertyName("status")]
  public required string Status { get; init; }

  [JsonPropertyName("title")]
  public required string Title { get; init; }

  [JsonPropertyName("creationDate")]
  public required DateTime CreationDate { get; init; }

  [JsonPropertyName("description")]
  public required string Description { get; init; }

  [JsonPropertyName("sourceRefName")]
  public required string SourceRefName { get; init; }

  [JsonPropertyName("destinationRefName")]
  public required string DestinationRefName { get; init; }

  [JsonPropertyName("mergeStatus")]
  public required string MergeStatus { get; init; }

  [JsonPropertyName("createdBy")]
  public required Person CreatedBy { get; init; }

  [JsonPropertyName("reviewers")]
  public IEnumerable<Reviewer> Reviewers { get; init; } = [];

  [JsonPropertyName("commits")]
  public IEnumerable<Commit> Commits { get; init; } = [];
}
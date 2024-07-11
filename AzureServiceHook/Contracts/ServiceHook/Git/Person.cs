using System.Text.Json.Serialization;

namespace AzureServiceHook.Contracts.ServiceHook.Git;

internal class Person
{
	[JsonPropertyName("id")]
	public required Guid Id { get; init; }

	[JsonPropertyName("displayName")]
	public required string DisplayName { get; init; }

	[JsonPropertyName("uniqueName")]
	public required string UniqueName { get; init; }

	[JsonPropertyName("imageUrl")]
	public string? ImageUrl { get; init; }
}
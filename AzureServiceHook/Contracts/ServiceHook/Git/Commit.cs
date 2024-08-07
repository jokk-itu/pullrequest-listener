﻿using System.Text.Json.Serialization;

namespace AzureServiceHook.Contracts.ServiceHook.Git;

internal class Commit
{
	[JsonPropertyName("commitId")]
	public required string CommitId { get; init; }

	[JsonPropertyName("url")] 
	public required string Url { get; init; }
}
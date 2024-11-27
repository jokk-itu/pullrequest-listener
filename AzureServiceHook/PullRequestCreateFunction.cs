using System.Net;
using System.Text.Json;
using AzureServiceHook.Contracts.ServiceHook.Git.PullRequest;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureServiceHook;

public class PullRequestCreateFunction(ILoggerFactory loggerFactory)
{
	private readonly ILogger _logger = loggerFactory.CreateLogger<PullRequestCreateFunction>();

	[Function("PullRequestCreate")]
	public async Task<HttpResponseData> Run(
		[HttpTrigger(AuthorizationLevel.Function, "post", Route = "pull-request/create")]
		HttpRequestData request)
	{
		var pullRequestEvent = await JsonSerializer.DeserializeAsync<PullRequestEvent>(request.Body);
		if (pullRequestEvent is null)
		{
			_logger.LogWarning("Request is not deserializable for PullRequestEvent");
			return request.CreateResponse(HttpStatusCode.BadRequest);
		}

		using var logScope = _logger.BeginScope(new Dictionary<string, object>
		{
			{ "EventId", pullRequestEvent.Id },
			{ "EventType", pullRequestEvent.EventType },
			{ "PullRequestId", pullRequestEvent.Resource.PullRequestId }
		});

		var accessToken = Environment.GetEnvironmentVariable("AzureDevOpsToken", EnvironmentVariableTarget.Process);

		// TODO invoke the REST API and add a comment on changing the title

		_logger.LogInformation("Successfully created PR {Event}", pullRequestEvent);

		return request.CreateResponse(HttpStatusCode.OK);
	}
}

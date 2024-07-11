using System.Net;
using System.Text.Json;
using AzureServiceHook.Contracts.ServiceHook.Git.PullRequest;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureServiceHook;

public class PullRequestUpdateFunction(ILoggerFactory loggerFactory)
{
	private readonly ILogger _logger = loggerFactory.CreateLogger<PullRequestUpdateFunction>();

	[Function("PullRequestUpdate")]
	public async Task<HttpResponseData> Run(
		[HttpTrigger(AuthorizationLevel.Function, "post", Route = "pull-request/update")] HttpRequestData request)
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

		_logger.LogInformation("Successfully created PR {Event}", pullRequestEvent);

		return request.CreateResponse(HttpStatusCode.OK);
	}
}
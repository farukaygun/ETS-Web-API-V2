using Common.Services;
using Contract.Dto;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace ETS_Web_API_V2.Middlewares;

public class CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
{
	private readonly RequestDelegate next = next;
	private readonly ILoggerService loggerService = loggerService;

	public async Task Invoke(HttpContext context)
	{
		var watch = Stopwatch.StartNew();

		try
		{
			var message = $"[Request] HTTP\tMethod:{context.Request.Method}\tPath: {context.Request.Path}\tStatus Code: {context.Response.StatusCode}\tResponse Time: {watch.ElapsedMilliseconds} ms";
			loggerService.Log(message);

			await next(context);

			watch.Stop();

			message = $"[Response] HTTP\tMethod:{context.Request.Method}\tPath: {context.Request.Path}\tStatus Code: {context.Response.StatusCode}\tResponse Time: {watch.ElapsedMilliseconds} ms";
			loggerService.Log(message);
		}
		catch (Exception e)
		{
			watch.Stop();
			await HandleException(context, e, watch);
		}
	}

	private Task HandleException(HttpContext context, Exception e, Stopwatch watch)
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		string message = $"[Error] HTTP\tMethod:{context.Request.Method}\tStatus Code: {context.Response.StatusCode}\tError: {e.Message}\tResponse Time: {watch.ElapsedMilliseconds} ms";
		loggerService.Log(message);

		var response = new ApiResponse<object>
		{
			Success = false,
			Data = null,
			StatusCode = (int)HttpStatusCode.InternalServerError,
			Message = e.Message,
			StackTrace = e.StackTrace
		};

		var result = JsonSerializer.Serialize(response);
		return context.Response.WriteAsync(result);
	}
}

public static class CustomExceptionMiddlewareExtensions
{
	public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<CustomExceptionMiddleware>();
	}
}

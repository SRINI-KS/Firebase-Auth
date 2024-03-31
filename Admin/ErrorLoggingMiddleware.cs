using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace Admin
{
		public class ErrorLoggingMiddleware
		{
				private readonly RequestDelegate _next;
				private readonly ILogger _logger;
				public ErrorLoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
				{
				_logger = loggerFactory.CreateLogger<ErrorLoggingMiddleware>();
				_next = next;
				}
				public async Task Invoke(HttpContext context)
				{
				try
				{
				await _next(context);
				}
				catch (Exception e)
				{
				_logger.LogError("Admin API MIDDLEWARE UNHANDLED EXCEPTION -> " + e.Message);
				System.Diagnostics.Debug.WriteLine($"The following error happened: {e.Message}");
				throw;
}
		}
		}
}


using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Text.Json;
using Poodle.Services.Exceptions;

namespace Poodle.Services.Helpers
{
	//Error handling step 1
	public class ExceptionHandlingMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception error)
			{
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case UnauthorizedOperationException:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case EntityNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case DuplicateEntityException:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
		}
	}
}

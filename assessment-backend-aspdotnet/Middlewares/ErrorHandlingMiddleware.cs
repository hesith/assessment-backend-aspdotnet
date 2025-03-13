using static assessment_backend_aspdotnet.CustomConfig.UserDefinedException;
using System.Net;
using System;
using assessment_backend_aspdotnet.Model.Response;
using System.Text.Json;

namespace assessment_backend_aspdotnet.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case UDInvalidOperationException:
                        response.StatusCode = (int)HttpStatusCode.Accepted;
                        break;
                    case UDNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.Accepted;
                        break;
                    case UDUnauthorizedAccessException:
                        response.StatusCode = (int)HttpStatusCode.Accepted;
                        break;
                    case UDArgumentException:
                        response.StatusCode = (int)HttpStatusCode.Accepted;
                        break;
                    case UDValiationException:
                        response.StatusCode = (int)HttpStatusCode.Accepted;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                BaseResponse<string> exceptionResponse = new BaseResponse<string>
                {
                    Success = false,
                    Message = response.StatusCode == (int)HttpStatusCode.InternalServerError ? "Internal Server Error" : exception.Message,
                    Data = null
                };

                string result = JsonSerializer.Serialize(exceptionResponse);
                await response.WriteAsync(result);
            }
        }
    }
}

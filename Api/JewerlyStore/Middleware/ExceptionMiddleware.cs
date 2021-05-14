using JewelryStore.Services.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JewelryStore.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void UserExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "application/json";

                            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                            if (exceptionObject != null)
                            {
                                if (exceptionObject.Error is UnauthorizedAccessException)
                                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                                ErrorResult errorResult = new ErrorResult
                                {
                                    ErrorMessage = exceptionObject.Error.Message,
                                    IsSuccess = false,
                                    Status = context.Response.StatusCode
                                };
                                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResult));
                            }
                        });
                }
            );
        }
    }
}

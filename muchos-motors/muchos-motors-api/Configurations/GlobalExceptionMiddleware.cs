using Microsoft.AspNetCore.Http;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using muchos_motors_api.Services;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace muchos_motors_api.Configurations
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public GlobalExceptionMiddleware(
            RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, DataDbContext dataDbContext)
        {
            try
            {
                await next(context);
            }
            catch (AppException appException)
            {
                await HandleExceptionAsync(context, appException);
                LogExceptionToDatabase(appException, dataDbContext);
            }
            catch (OperationCanceledException exception)
            {
                await HandleExceptionAsync(context, exception);
                LogExceptionToDatabase(exception, dataDbContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
                LogExceptionToDatabase(exception, dataDbContext);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            object response;
            if (exception is AppException appException)
            {
                context.Response.StatusCode = appException.StatusCode;
                response = new
                {
                    error = new
                    {
                        message = "Desila se greška u aplikaciji prilikom procesuiranja vašeg zahtjeva.",
                        details = appException.Message
                    }
                };
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = new
                {
                    error = new
                    {
                        message = "Desila se greška u aplikaciji prilikom procesuiranja vašeg zahtjeva.",
                        details = exception.Message
                    }
                };
            }

            
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private void LogExceptionToDatabase(Exception exception, DataDbContext dataDbContext)
        {
            var errorLog = new ErrorLog
            {
                Timestamp = DateTime.UtcNow,
                Message = exception.Message,
                StackTrace = exception.StackTrace
            };

            if (exception is AppException appException)
            {
                errorLog.StatusCode = appException.StatusCode;
            }
            else
            {
                errorLog.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            dataDbContext.ErrorLog.Add(errorLog);
            dataDbContext.SaveChanges();
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Rede.Domain.Exception;

namespace Rede.Api.Middleware;

public class GlobalErrorHandlingMiddleware : IExceptionFilter
{
    private IHostEnvironment _hostEnvironment;

    public GlobalErrorHandlingMiddleware(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public void OnException(ExceptionContext context)
    {
        var details = new ProblemDetails();
        var exception = context.Exception;

        details.Title = "Ocorreu um erro";
        details.Detail = _hostEnvironment.IsDevelopment() ? exception.StackTrace : null;
        details.Status = StatusCodes.Status500InternalServerError;

        if (_hostEnvironment.IsDevelopment())
        {
            details.Extensions.Add("StackTrace", exception.StackTrace);
        }

        if(exception is ExcecaoDeDominio)
        {
            details.Title = "Ocorreu um erro de dominio";
            details.Detail = exception.Message;
            details.Status = StatusCodes.Status400BadRequest;
        }

        if(exception is NotFounException)
        {
            details.Title = "Recurso não encontrado";
            details.Detail = exception.Message;
            details.Status = StatusCodes.Status406NotAcceptable;
        }

        context.HttpContext.Response.StatusCode = details.Status.Value;
        context.Result = new ObjectResult(details);
        context.ExceptionHandled = true;


    }
}

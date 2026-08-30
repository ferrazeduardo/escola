using System;
using Academico.Domain.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Academico.Api.Middleware;

public class GlobalErrorHandlingMiddleware : IExceptionFilter
{
    private IHostEnvironment _hostEnvironment;

    public GlobalErrorHandlingMiddleware(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public void OnException(ExceptionContext context)
    {
        var datails = new ProblemDetails();
        var exception = context.Exception;

        datails.Title = "Ocorreu um erro inesperado";
        datails.Detail = _hostEnvironment.IsDevelopment() ? exception.StackTrace : null;
        datails.Status = StatusCodes.Status500InternalServerError;

        if (_hostEnvironment.IsDevelopment())
        {
            datails.Extensions.Add("StackTrace",exception.StackTrace);
        }

        if(exception is ExcecaoDeDominio)
        {
            datails.Title = "Ocrreu um erro de dominio";
            datails.Detail = exception.Message;
            datails.Status = StatusCodes.Status400BadRequest;
        }

        if(exception is NotFoundException)
        {
            datails.Title = "Recurso não encontrado";
            datails.Detail = exception.Message;
            datails.Status = StatusCodes.Status404NotFound;
        }

        context.HttpContext.Response.StatusCode = datails.Status.Value;
        context.Result = new ObjectResult(datails);
        context.ExceptionHandled = true;
    }
}

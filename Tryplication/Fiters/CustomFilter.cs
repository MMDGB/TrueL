using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace Tryplication.Fiters
{
    public class CustomFilter : Attribute, IActionFilter, IResultFilter
    {
        private void LogExecutinTime(string data)
        {
            File.AppendAllText("C:\\Users\\denis.marchis\\Desktop\\Tryplication\\FiltersOutPut.txt", data);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            string message = "\n" + context.ActionDescriptor.AttributeRouteInfo
                            + context.ActionDescriptor.DisplayName + DateTime.Now.ToString() + "\n";
            LogExecutinTime(message);
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string message = "\n" + context.ActionDescriptor.AttributeRouteInfo
                            + context.ActionDescriptor.DisplayName + DateTime.Now.ToString() + "\n";
            LogExecutinTime(message);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string message = "\n" + context.ActionDescriptor.AttributeRouteInfo
                            + context.ActionDescriptor.DisplayName + DateTime.Now.ToString() + "\n";
            LogExecutinTime(message);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string message = "\n" + context.ActionDescriptor.AttributeRouteInfo
                            + context.ActionDescriptor.DisplayName + DateTime.Now.ToString() + "\n";
            LogExecutinTime(message);
        }
    }
}
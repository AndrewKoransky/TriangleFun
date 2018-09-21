using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using TriangleFun.Filters;

namespace TriangleFun
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      config.Filters.Add(new ValidateActionParametersAttribute());
      config.Filters.Add(new ValidateModelAttribute());
      config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{action}/{row}/{column}",
          defaults: new { row = RouteParameter.Optional, column = RouteParameter.Optional }
      );

    }
  }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace TriangleFun.Filters
{
  public class ValidateActionParametersAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(HttpActionContext context)
    {
      if (context.ActionDescriptor != null)
      {
        foreach (HttpParameterDescriptor parameter in context.ActionDescriptor.GetParameters())
        {
          foreach (var attr in parameter.GetCustomAttributes<System.Attribute>())
          {
            var validationAttribute = attr as ValidationAttribute;
            if (validationAttribute != null)
            {
              var isValid = validationAttribute.IsValid(context.ActionArguments[parameter.ParameterName]);
              if (!isValid)
              {
                context.ModelState.AddModelError(parameter.ParameterName, validationAttribute.FormatErrorMessage(parameter.ParameterName));
              }
            }
          }
        }
      }
    }
  }
}

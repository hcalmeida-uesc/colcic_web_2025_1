using Microsoft.AspNetCore.Mvc;
using ddd_project.Domain.ResultPattern;

namespace ddd_project.API.Extensions;

public static class ControllerResultExtensions
{
   public static ActionResult<T> MapResult<T>(this ControllerBase controller, Result<T> result)
   {
      if (result.IsSuccess)
      {
         return controller.Ok(result.Value);
      }

      return GetErrorResult<T>(controller, result.Error);
   }

   internal static ActionResult<T> GetErrorResult<T>(ControllerBase controller, Error error)
   {
      return error.Type switch
      {
         ErrorType.NotFound      => controller.NotFound(error.Details),
         ErrorType.Validation    => controller.BadRequest(error.Details),
         ErrorType.Unauthorized  => controller.Unauthorized(),
         ErrorType.Forbidden     => controller.Forbid(),
         ErrorType.Conflict      => controller.Conflict(error.Details),
         _                       => controller.Problem(
            statusCode: 500,
            title: "Server Failure",
            type: Enum.GetName(ErrorType.InternalServerError),
            extensions: new Dictionary<string, object?>
            {
               { "errors", new[] {error} }
            }
         )
      };
   }
}

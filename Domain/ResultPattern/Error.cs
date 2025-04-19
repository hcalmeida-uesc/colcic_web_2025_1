using System;

namespace ddd_project.Domain.ResultPattern;

public enum ErrorType
{
   None,
   Failure,
   NotFound,
   Validation,
   Unauthorized,
   Forbidden,
   Conflict,
   InternalServerError
}
public record Error
{

   public string Code { get; set;}
   public string Details { get; set;}
   public ErrorType Type { get; set;}

   private Error(string code, string details, ErrorType type)
   {
      Code = code;
      Details = details ?? string.Empty;
      Type = type;
   }
   public static Error None => new(string.Empty, string.Empty, ErrorType.None);
   public static Error Failure(string code, string details) => new(code, details, ErrorType.Failure);
   public static Error NotFound(string code, string details) => new(code, details, ErrorType.NotFound);
   public static Error Validation(string code, string details) => new(code, details, ErrorType.Validation);
   public static Error Unauthorized(string code, string details) => new(code, details, ErrorType.Unauthorized);
   public static Error Forbidden(string code, string details) => new(code, details, ErrorType.Forbidden);
   public static Error Conflict(string code, string details) => new(code, details, ErrorType.Conflict);
   public static Error InternalServerError(string code, string details) => new(code, details, ErrorType.InternalServerError);
}


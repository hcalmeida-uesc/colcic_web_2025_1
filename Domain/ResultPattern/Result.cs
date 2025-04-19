using System;

namespace ddd_project.Domain.ResultPattern;

public class Result<T>
{
   public bool IsSuccess { get; private set; }
   public bool IsFailure => !IsSuccess;
   public T? Value { get; private set; }
   public Error Error { get; private set; } 

   private Result(T value)
   {
      IsSuccess = true;
      Value = value;
      Error = Error.None;
   }
   private Result(Error error)
   {
      IsSuccess = false;
      Error = error;
   }

   public static Result<T> Success(T value) => new(value);
   public static Result<T> Failure(Error error) => new(error);
}

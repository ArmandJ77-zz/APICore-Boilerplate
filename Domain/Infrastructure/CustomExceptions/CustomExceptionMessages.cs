namespace Domain.Infrastructure.CustomExceptions
{
    public static class CustomExceptionMessages
    {
        public const string DtoNullException = "The request body may not be null or empty";
        public const string ResourceNotFound = "The requested resource could not be found.";
        public const string ResourceNotFoundByCriteria = "The requested resource filtred by the specified criteria could not be found.";
        

        public static string ExternalAPIResponseExceptionMessageBuilder(string endpoint, string httpStatusCode)
            => $"Exception has occured while communicating with {endpoint}, with a return status code of {httpStatusCode}";

        public static string DtoNullCustomException(string dtoName)
            => $"The request body may not be null or empty: {dtoName}";
    }
}

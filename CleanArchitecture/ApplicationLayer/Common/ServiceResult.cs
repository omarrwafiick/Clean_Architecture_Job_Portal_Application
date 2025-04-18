  
namespace ApplicationLayer.Common
{
    public class ServiceResult
    {
        public bool SuccessOrNot { get; private set; }
        public string Message { get; private set; } 

        public static ServiceResult Success(string message = null)
        {
            return new ServiceResult
            {
                SuccessOrNot = true,
                Message = message
            };
        }

        public static ServiceResult Failure(string message)
        {
            return new ServiceResult
            {
                SuccessOrNot = false,
                Message = message
            };
        }
    }
}

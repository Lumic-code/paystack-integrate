namespace PaystackIntegrateAPI.Service
{
    public interface IPaystackService
    {
        Task<PaystackResponseDto> VerifyPayment(string reference);
    }
}

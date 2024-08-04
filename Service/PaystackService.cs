using System.Text.Json;

namespace PaystackIntegrateAPI.Service
{
    public class PaystackService : IPaystackService
    {
        private readonly IHttpClientFactory _httpClient;

        public PaystackService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaystackResponseDto> VerifyPayment(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
            {
                throw new ArgumentNullException(nameof(reference));
            }

            var client = _httpClient.CreateClient("paystack");

            string apiUrl = $"transaction/verify/{reference}";

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var responseData = JsonSerializer.Deserialize<PaystackResponseDto>(content);
               if(responseData?.data != null)
                {
                    var dataz = responseData.data;
                    var res1 = new PaystackResponseDto()
                    {
                        Status = responseData.Status,
                        StatusMessage = responseData.StatusMessage,
                        data = dataz
                    };
                    return res1;
                }
            }
            else
            {
                var res2 = new PaystackResponseDto()
                {
                    Status = 400,
                    StatusMessage = "Invalid transaction",
                    data = null
                };
                return res2;
            }

            var res3 = new PaystackResponseDto()
            {
                Status = 500,
                StatusMessage = "Internal Server Error",
                data = null
            };
            return res3;
        }
    }
}

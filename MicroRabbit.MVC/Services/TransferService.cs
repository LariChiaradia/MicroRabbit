using MicroRabbit.MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDTO transferDTO)
        {
            var uri = "https://localhost:7265/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO),
                                                    Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Lazar_Horatiu_Lab5_Master.Services;

namespace Lazar_Horatiu_Lab5_Master.Services
{
    public class RiskPredictionService : IRiskPredictionService
    {
        private readonly HttpClient _httpClient;

        public RiskPredictionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> PredictRiskAsync(Models.RiskInput input)
        {
            // POST catre /predict
            var response = await _httpClient.PostAsJsonAsync("/predict", input);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<RiskApiResponse>();
            return result?.predictedLabel;
            //Prediction
        }

        private class RiskApiResponse
        {
            public string predictedLabel { get; set; }
        }
    }
}

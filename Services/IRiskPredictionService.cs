using System.Threading.Tasks;
using Lazar_Horatiu_Lab5_Master.Models;

namespace Lazar_Horatiu_Lab5_Master.Services
{
    public interface IRiskPredictionService
    {
        Task<string> PredictRiskAsync(RiskInput input);
    }
}

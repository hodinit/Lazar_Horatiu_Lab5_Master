namespace Lazar_Horatiu_Lab5_Master.Models
{
    public class RiskPredictionViewModel
    {
        public string InspectionType { get; set; }
        public string ViolationDescription { get; set; }
        
        //rezultat intors de API
        public string PredictedRisk { get; set; }
    }
}

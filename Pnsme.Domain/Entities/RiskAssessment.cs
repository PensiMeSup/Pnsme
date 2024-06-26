namespace Pnsme.Domain.Entities
{
    public class RiskAssessment
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public decimal RiskToleranceScore { get; private set; }
        public decimal RiskCapacityScore { get; private set; }
        public Enums.RiskCategory RiskCategory { get; private set; }
        public string RecommendedStrategy { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public RiskAssessment(Guid userId, decimal riskToleranceScore, decimal riskCapacityScore)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            RiskToleranceScore = riskToleranceScore;
            RiskCapacityScore = riskCapacityScore;
            CreatedAt = DateTime.UtcNow;

            CalculateRiskCategory();
            DetermineRecommendedStrategy();
        }

        private void CalculateRiskCategory()
        {
            decimal combinedScore = (RiskToleranceScore + RiskCapacityScore) / 2;

            RiskCategory = combinedScore switch
            {
                < 20 => Enums.RiskCategory.Conservative,
                < 40 => Enums.RiskCategory.ModeratelyConservative,
                < 60 => Enums.RiskCategory.Moderate,
                < 80 => Enums.RiskCategory.ModeratelyAggressive,
                _ => Enums.RiskCategory.Aggressive
            };
        }

        private void DetermineRecommendedStrategy()
        {
            RecommendedStrategy = RiskCategory switch
            {
                Enums.RiskCategory.Conservative => "Focus on capital preservation with low-risk investments.",
                Enums.RiskCategory.ModeratelyConservative => "Emphasize capital preservation with some growth potential.",
                Enums.RiskCategory.Moderate => "Balance between growth and capital preservation.",
                Enums.RiskCategory.ModeratelyAggressive => "Emphasize growth with some capital preservation.",
                Enums.RiskCategory.Aggressive => "Focus on maximum growth potential.",
                _ => throw new InvalidOperationException("Invalid risk category.")
            };
        }
    }
}

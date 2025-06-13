namespace EcoSphere.Domain
{
    public enum PlantStage
    {
        Seed,
        Sprout,
        Mature
    }

    public class Plant
    {
        public PlantStage Stage { get; private set; }
        public float Growth { get; private set; }

        private const float GrowthThresholdSprout = 5f;
        private const float GrowthThresholdMature = 10f;

        public Plant()
        {
            Stage = PlantStage.Seed;
            Growth = 0f;
        }

        public void AccumulateGrowth(float amount)
        {
            Growth += amount;

            if (Growth >= GrowthThresholdMature)
                Stage = PlantStage.Mature;
            else if (Growth >= GrowthThresholdSprout)
                Stage = PlantStage.Sprout;
        }
    }
}
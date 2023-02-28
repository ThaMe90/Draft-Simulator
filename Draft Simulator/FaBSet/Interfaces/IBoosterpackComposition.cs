using Draft_Simulator.FaBSet.Enums;

namespace Draft_Simulator.FaBSet.Interfaces {
    internal interface IBoosterpackComposition {
        public Dictionary<CompositionType, int> GetComposition();
        public Dictionary<CompositionType, Dictionary<Rarity, double>> GetDistributions();
    }
}

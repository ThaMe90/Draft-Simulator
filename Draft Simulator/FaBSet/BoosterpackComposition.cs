using Draft_Simulator.FaBSet.Enums;
using Draft_Simulator.FaBSet.Interfaces;

namespace Draft_Simulator.FaBSet {
    internal class BoosterpackComposition : IBoosterpackComposition {
        private static readonly Dictionary<CompositionType, int> Composition = new()
        {
            { CompositionType.Token, 1 },
            { CompositionType.Common, 11 },
            { CompositionType.Rare, 1 },
            { CompositionType.RarePlus, 1 },
            { CompositionType.Equipment, 1 },
            { CompositionType.Foil, 1 },
        };

        private static readonly Dictionary<CompositionType, Dictionary<Rarity, double>> Distributions = new()
        {
            {
                CompositionType.Token, new() {
                    { Rarity.Token, 1 },
                }
            },
            {
                CompositionType.Common, new() {
                    { Rarity.Common, 1 },
                }
            },
            {
                CompositionType.Rare, new() {
                    { Rarity.Rare, 1 },
                }
            },
            {
                CompositionType.RarePlus, new() {
                    { Rarity.Rare, 0.75 },
                    { Rarity.Majestic, 1 },
                }
            },
            {
                CompositionType.Equipment, new() {
                    { Rarity.Common, 1 },
                }
            },
            {
                CompositionType.Foil, new() {
                    // Includes regular Common & CommonEquipment odds.
                    { Rarity.Common, 0.842 },
                    { Rarity.Rare, 0.971 },
                    // Includes SuperRare & Majestic odds.
                    { Rarity.Majestic, 0.989 },
                    { Rarity.Legendary, 0.999 },
                    { Rarity.Fabled, 1 },
                }
            },
        };

        public Dictionary<CompositionType, int> GetComposition() {
            return Composition;
        }

        public Dictionary<CompositionType, Dictionary<Rarity, double>> GetDistributions() {
            return Distributions;
        }
    }
}

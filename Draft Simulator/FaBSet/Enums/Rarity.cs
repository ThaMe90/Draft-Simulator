namespace Draft_Simulator.FaBSet.Enums {
    internal enum Rarity {
        Unknown,
        Token,
        Common,
        Rare,
        SuperRare,
        Majestic,
        Legendary,
        Fabled
    }

    internal static class CharExtensions {
        private static Dictionary<char, Rarity> RaritiesMap = new()
        {
            { 'T', Rarity.Token },
            { 'C', Rarity.Common },
            { 'R', Rarity.Rare },
            { 'S', Rarity.SuperRare },
            { 'M', Rarity.Majestic },
            { 'L', Rarity.Legendary },
            { 'F', Rarity.Fabled },
        };

        public static Rarity GetRarity(this char rarity) {
            if (RaritiesMap.ContainsKey(rarity)) {
                return RaritiesMap[rarity];
            }
            return Rarity.Unknown;
        }
    }
}

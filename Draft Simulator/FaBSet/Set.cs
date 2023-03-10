using Draft_Simulator.FaBSet.Enums;
using Draft_Simulator.FaBSet.Interfaces;

namespace Draft_Simulator.FaBSet {
    internal class Set : ISet {
        public static ISet ReadFromFile(string name, string path) {
            bool includesSuperRares = false;
            bool firstEdition = false;
            IBoosterpackComposition boosterpackComposition = new BoosterpackComposition();
            List<Card> cards = new();
            string[] fileContents = File.ReadAllText(path).Split('\n');
            foreach (string line in fileContents) {
                if (string.IsNullOrEmpty(line)) continue;

                string[] lineParts = line.Split(';');
                string cardName = lineParts[1].Trim();
                Rarity cardRarity = lineParts[2].Trim()[0].GetRarity();
                string cardNumber = lineParts[0];
                CardType cardType = (CardType)Enum.Parse(typeof(CardType), lineParts[3]);
                cards.Add(Card.CreateCard(cardName, cardRarity, cardType, cardNumber, firstEdition));
            }

            return new Set(name, boosterpackComposition, cards, includesSuperRares, firstEdition);
        }

        public static ISet ReadFromResourceString(string name, string resource) {
            bool includesSuperRares = false;
            bool firstEdition = true;
            IBoosterpackComposition boosterpackComposition = new BoosterpackComposition();
            List<Card> cards = new();
            string[] fileContents = resource.Split('\n');
            foreach (string line in fileContents) {
                if (string.IsNullOrEmpty(line)) continue;

                string[] lineParts = line.Split(';');
                string cardName = lineParts[1].Trim();
                Rarity cardRarity = lineParts[2].Trim()[0].GetRarity();
                string cardNumber = lineParts[0];
                CardType cardType = (CardType)Enum.Parse(typeof(CardType), lineParts[3]);
                cards.Add(Card.CreateCard(cardName, cardRarity, cardType, cardNumber, firstEdition));
            }

            return new Set(name, boosterpackComposition, cards, includesSuperRares, firstEdition);
        }

        private Set(string name, IBoosterpackComposition boosterpackComposition, List<Card> cards, bool includeSuperRares, bool firstEdition) {
            this.Name = name;
            this.BoosterpackComposition = boosterpackComposition;
            this.Cards = cards;
            this.IncludesSuperRares = includeSuperRares;
            this.FirstEdition = firstEdition;
        }

        public IBoosterbox GenerateBoosterBox() {
            return Boosterbox.Generate(Cards, BoosterpackComposition, FirstEdition);
        }

        public string Name { get; private set; }

        public IBoosterpackComposition BoosterpackComposition { get; private set; }

        public List<Card> Cards { get; private set; }

        public bool IncludesSuperRares { get; private set; }

        public bool FirstEdition { get; private set; }
    }
}

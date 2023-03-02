using Draft_Simulator.FaBSet.Enums;
using Draft_Simulator.FaBSet.Interfaces;

namespace Draft_Simulator.FaBSet {
    internal class Card : ICard {
        public static Card CreateCard(string name, Rarity rarity, CardType type, string number, bool firstEdition) {
            return new Card(name, rarity, type, number, firstEdition);
        }

        public static Card CreateCopy(Card other) {
            return new Card(other.Name, other.Rarity, other.Type, other.Number, other.FirstEdition);
        }

        private Card(string name, Rarity rarity, CardType type, string number, bool firstEdition) {
            this.Name = name.Trim();
            this.Rarity = rarity;
            this.Number = number;
            this.Type = type;
            this.FirstEdition = firstEdition;
        }

        public override string ToString() {
            return $"{GetFoilText()}{Name} ({Rarity}, {Type}, {Number})";
        }

        private string GetFoilText() {
            if(Foil) {
                if(FirstEdition && (Rarity == Rarity.Legendary || (Rarity == Rarity.Common && Type == CardType.Equipment))) {
                    return "(CF) ";
                }
                return "(F) ";
            }
            return string.Empty;
        }

        public string Name { get; private set; }
        public Rarity Rarity { get; private set; }
        public CardType Type { get; private set; }
        public string Number { get; private set; }
        public bool Foil { get; set; } = false;
        public bool FirstEdition { get; private set; }
    }
}

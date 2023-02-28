using Draft_Simulator.FaBSet.Enums;
using Draft_Simulator.FaBSet.Interfaces;

namespace Draft_Simulator.FaBSet {
    internal class Card : ICard {
        public static Card CreateCard(string name, Rarity rarity, CardType type, string number) {
            return new Card(name, rarity, type, number);
        }

        public static Card CreateCopy(Card other) {
            return new Card(other.Name, other.Rarity, other.Type, other.Number);
        }

        private Card(string name, Rarity rarity, CardType type, string number) {
            this.Name = name.Trim();
            this.Rarity = rarity;
            this.Number = number;
            this.Type = type;
        }

        public override string ToString() {
            return $"{GetFoilText()}{Name} ({Rarity}, {Type}, {Number})";
        }

        private string GetFoilText() {
            return Foil ? "Foil " : "";
        }

        public string Name { get; private set; }
        public Rarity Rarity { get; private set; }
        public CardType Type { get; private set; }
        public string Number { get; private set; }
        public bool Foil { get; set; } = false;
    }
}

using Draft_Simulator.FaBSet.Enums;
using Draft_Simulator.FaBSet.Interfaces;

namespace Draft_Simulator.FaBSet {
    internal class Card : ICard, IComparable<Card> {
        public static Card CreateCard(string name, Rarity rarity, CardType type, string number, bool firstEdition) {
            return new Card(name, rarity, type, number, firstEdition);
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

        public int CompareTo(Card? other) {
            if (other == null) return 1;
            if (other is Card otherCard) return this.Number.CompareTo(otherCard.Number);
            else throw new ArgumentException("Other ICard is not a Card");
        }

        public string Name { get; private set; }
        public Rarity Rarity { get; private set; }
        public CardType Type { get; private set; }
        public string Number { get; private set; }
        public bool Foil { get; set; } = false;
        public bool FirstEdition { get; private set; }
    }

    internal static class CardExtensions {
        public static Card DeepCopy(this Card card) {
            return Card.CreateCard(card.Name, card.Rarity, card.Type, card.Number);
        }
    }
 }

using Draft_Simulator.FaBSet.Enums;
using Draft_Simulator.FaBSet.Interfaces;

using System.Text;

namespace Draft_Simulator.FaBSet {
    internal class Boosterpack : IBoosterpack {
        public const int CardsPerPack = 16;

        public static IBoosterpack Generate(List<Card> cards, IBoosterpackComposition boosterpackComposition, Random random) {
            return new Boosterpack(cards, boosterpackComposition, random);
        }

        private Boosterpack(List<Card> cards, IBoosterpackComposition boosterpackComposition, Random random) {
            Cards = new(CardsPerPack);
            SelectCardsInBooster(cards, boosterpackComposition, random);
        }

        private void SelectCardsInBooster(List<Card> cards, IBoosterpackComposition boosterpackComposition, Random random) {
            foreach (KeyValuePair<CompositionType, int> composition in boosterpackComposition.GetComposition()) {
                if (!boosterpackComposition.GetDistributions().TryGetValue(composition.Key, out Dictionary<Rarity, double>? distribution)) {
                    Console.WriteLine($"No distribution set known for cardtype {composition.Key}");
                    return;
                }
                for (int i = 0; i < composition.Value; i++) {
                    double rarityValue = random.NextDouble();
                    Rarity selected = distribution.Where(kv => kv.Value >= rarityValue).First().Key;
                    List<Card> possibleCards = GetPossibleCards(cards, composition.Key, selected);
                    Card selectedCard = Card.CreateCopy(possibleCards[random.Next(possibleCards.Count)]);
                    selectedCard.Foil = composition.Key == CompositionType.Foil;
                    Cards.Add(selectedCard);
                }
            }
        }

        private List<Card> GetPossibleCards(List<Card> allCards, CompositionType type, Rarity rarity) {
            List<Card> possibleCards = allCards.Where(c => c.Rarity == rarity).ToList();
            possibleCards = type switch {
                CompositionType.Equipment => possibleCards.Where(c => c.Type == CardType.Equipment).ToList(),
                CompositionType.Foil => possibleCards.Where(c => c.Type != CardType.Resource && c.Rarity != Rarity.Token).ToList(),
                _ => possibleCards.Where(c => c.Type != CardType.Equipment).ToList(),
            };
            return possibleCards;
        }

        public override string ToString() {
            StringBuilder sb = new();
            sb.AppendLine("Content of booster:");
            foreach (Card card in Cards) {
                sb.Append(" - ");
                sb.AppendLine(card.ToString());
            }
            return sb.ToString();
        }

        public List<Card> Cards { get; set; }
    }
}

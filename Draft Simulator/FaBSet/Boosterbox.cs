using Draft_Simulator.FaBSet.Interfaces;

using System.Text;

namespace Draft_Simulator.FaBSet {
    internal class Boosterbox : IBoosterbox {
        public const int NumberOfBoostersInBox = 24;

        public static IBoosterbox Generate(List<Card> cards, IBoosterpackComposition boosterpackComposition, bool firstEdition) {
            return new Boosterbox(cards, boosterpackComposition, firstEdition);
        }

        private Boosterbox(List<Card> cards, IBoosterpackComposition boosterpackComposition, bool firstEdition) {
            Random random = new(DateTime.Now.Millisecond);
            this.Boosterpacks = new(NumberOfBoostersInBox);
            this.FirstEdition = firstEdition;
            for (int i = 0; i < NumberOfBoostersInBox; i++) {
                Boosterpacks.Add(Boosterpack.Generate(cards, boosterpackComposition, firstEdition, random));
            }
        }

        public override string ToString() {
            StringBuilder sb = new();
            sb.AppendLine("Content of boosterbox:");
            foreach (IBoosterpack boosterpack in Boosterpacks) {
                sb.AppendLine(boosterpack.ToString());
            }
            return sb.ToString();
        }

        public List<IBoosterpack> Boosterpacks { get; private set; }

        public bool FirstEdition { get; private set; }
    }
}

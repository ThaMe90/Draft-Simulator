using Draft_Simulator.FaBSet.Interfaces;

using System.Text;

namespace Draft_Simulator.FaBSet {
    internal class Boosterbox : IBoosterbox {
        public const int NumberOfBoostersInBox = 24;

        public static IBoosterbox Generate(List<Card> cards, IBoosterpackComposition boosterpackComposition) {
            return new Boosterbox(cards, boosterpackComposition);
        }

        private Boosterbox(List<Card> cards, IBoosterpackComposition boosterpackComposition) {
            Random random = new(DateTime.Now.Millisecond);
            Boosterpacks = new(NumberOfBoostersInBox);
            for (int i = 0; i < NumberOfBoostersInBox; i++) {
                Boosterpacks.Add(Boosterpack.Generate(cards, boosterpackComposition, random));
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

        public List<IBoosterpack> Take(int numberOfBoosters) {
            List<IBoosterpack> boosters = new();
            Random random = new(DateTime.Now.Millisecond);
            for(int i = 0; i < numberOfBoosters; i++) {
                IBoosterpack booster = Boosterpacks[random.Next(Boosterpacks.Count)];
                Boosterpacks.Remove(booster);
                boosters.Add(booster);
            }
            return boosters;
        }

        public List<IBoosterpack> Boosterpacks { get; set; }
    }
}

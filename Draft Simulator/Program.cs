using Draft_Simulator.FaBSet;
using Draft_Simulator.FaBSet.Interfaces;

namespace Draft_Simulator {
    internal class Program {
        static void Main(string[] _) {
            ISet set = Set.ReadFromResourceString("Monarch", Properties.SetLists.Monarch);
            Console.WriteLine("Generating boosterbox...");
            IBoosterbox box = set.GenerateBoosterBox();
            Console.WriteLine("Boosterbox generated.");

            Console.WriteLine("Number of players to simulate:");
            int? numPlayers = Console.ReadLine();

            Console.WriteLine("Taking 3 random boosters.");
            List<IBoosterpack> boosters = box.Take(3);
            List<Card> tokens = new();

            foreach(IBoosterpack booster in boosters) {
                Console.WriteLine("Removing token from booster.");
                Card? tokenCard = booster.RemoveToken();
                if (tokenCard == null) {
                    Console.WriteLine("Booster does not contain a token!!!");
                    Console.WriteLine("Booster content:");
                    Console.WriteLine(booster.ToString());
                    return;
                }
                tokens.Add(tokenCard);

            }

            Console.WriteLine();
            Console.WriteLine("Available tokens:");
            foreach (Card token in tokens.OrderBy(c => c.Name)) {
                Console.WriteLine(token.Name);
            }
            Console.ReadLine();
        }
    }
}
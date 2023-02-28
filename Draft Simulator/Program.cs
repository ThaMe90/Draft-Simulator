using Draft_Simulator.FaBSet;
using Draft_Simulator.FaBSet.Interfaces;

namespace Draft_Simulator {
    internal class Program {
        static void Main(string[] _) {
            ISet set = Set.ReadFromResourceString("Monarch", Properties.SetLists.Monarch);
            IBoosterbox box = set.GenerateBoosterBox();
            Console.WriteLine(box.ToString());
            Console.ReadLine();
        }
    }
}
using WormsWorld.WorldSimulator;

namespace WormsWorld.FoodGenerator
{
    public interface IFoodGenerator
    {
        void GenerateFood(WorldService worldService);
    }
}
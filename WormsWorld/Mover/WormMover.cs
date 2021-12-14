using System;
using WormsWorld.Entity;

namespace WormsWorld.Mover
{
    public class WormMover : IWormMover
    { 
        public Cell Move(Worm worm)
        {
            var closestFoodCell = FindClosestFoodCell(worm);
            if (Math.Abs(closestFoodCell.X) > Math.Abs(worm.Position.X))
            {
                worm.Position.X++;
            }
            else if (Math.Abs(closestFoodCell.X) < Math.Abs(worm.Position.X))
            {
                worm.Position.X--;
            }
            else if (Math.Abs(closestFoodCell.Y) > Math.Abs(worm.Position.Y))
            {
                worm.Position.Y++;
            }
            else if (Math.Abs(closestFoodCell.Y) > Math.Abs(worm.Position.Y))
            {
                worm.Position.Y--;
            }
            return closestFoodCell;
        }

        private Cell FindClosestFoodCell(Worm worm)
        {
            var minDistance = int.MaxValue;
            var closestFoodCell = new Cell();
            foreach (var food in worm.WorldService.Foods)
            {
                var deltaX = Math.Abs(food.Position.X - worm.Position.X);
                var deltaY = Math.Abs(food.Position.Y - worm.Position.Y);
                if (deltaX + deltaY < minDistance)
                {
                    closestFoodCell.X = deltaX;
                    closestFoodCell.Y = deltaY;
                    minDistance = deltaX + deltaY;
                }
            }
            return closestFoodCell;
        }
    }
}
using BotFramework.Actions;
using BotFramework.TemplateMethods;

namespace BotFramework.Locations
{
    class LocationTour : TourTemplate<ActionableLocation>
    {
        protected override int[,] GenerateCostMatrix()
        {
            int[,] costMatrix = new int[1, 1];

            return costMatrix;
        }
    }
}

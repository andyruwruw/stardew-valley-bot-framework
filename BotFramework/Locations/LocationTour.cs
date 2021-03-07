using BotFramework.Actions;
using BotFramework.TemplateMethods;

namespace BotFramework.Locations
{
    /// <summary>
    /// Find shortest tour through groups.
    /// </summary>
    /// 
    /// <remarks>
    /// Implements template method <see cref="TourTemplate{LocationParser}">TemplateMethods.TourTemplate</see>.
    /// </remarks>
    class LocationTour : TourTemplate<ActionableLocation>
    {
        protected override int[,] GenerateCostMatrix()
        {
            int[,] costMatrix = new int[1, 1];

            return costMatrix;
        }
    }
}
